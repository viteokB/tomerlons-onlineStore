using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;
using OnlineStore.Core.Common;
using OnlineStore.Core.Common.Pagination;
using OnlineStore.Core.Interfaces;
using OnlineStore.Core.Models;
using OnlineStore.Core.Models.WhareHouse;
using OnlineStore.Repository.Models;
using Exception = System.Exception;

namespace OnlineStore.Repository.Repository;

public class WarehouseRepository : IWarehouseRepository
{
    private readonly OnlineStoreDbContext _dbContext;
    private readonly DbSet<DatabaseWharehouse> _wharehouseDbSet;
    private readonly DbSet<DatabaseWharehouseProducts> _wharehouseProductsDbSet;

    public WarehouseRepository(OnlineStoreDbContext dbContext)
    {
        _wharehouseProductsDbSet = dbContext.WarehousesProducts;
        _wharehouseDbSet = dbContext.Warehouses;
        _dbContext = dbContext;
    }
    
    public async Task<OperationResult<Warehouse>> AddWarehouse(Warehouse warehouse, CancellationToken cancellationToken)
    {
        if (warehouse == null!)
            return OperationResult<Warehouse>.Fail("Warehouse cannot be null")!;

        try
        {
            // 1. Проверяем существование склада
            var existingWarehouse = await _wharehouseDbSet
                .FirstOrDefaultAsync(w => w.Name == warehouse.Name, cancellationToken);
            
            if (existingWarehouse != null)
                return OperationResult<Warehouse>.Fail("Склад с таким названием уже существует")!;

            // 2. Обрабатываем адрес
            if (warehouse.Address != null!)
            {
                // Проверяем существование адреса
                var existingAddress = warehouse.Address.Id != 0 
                    ? await _dbContext.Addresses.FindAsync(warehouse.Address.Id, cancellationToken)
                    : null;

                if (existingAddress != null)
                {
                    // Если адрес существует - проверяем изменения
                    if (!AreAddressesEqual(existingAddress, warehouse.Address))
                    {
                        // Обновляем адрес
                        existingAddress.Country = warehouse.Address.Country;
                        existingAddress.City = warehouse.Address.City;
                        existingAddress.Street = warehouse.Address.Street;
                        existingAddress.HouseNumber = warehouse.Address.HouseNumber;
                        existingAddress.ApartmentNumber = warehouse.Address.ApartmentNumber;
                        existingAddress.Latitude = warehouse.Address.Coordinate.Latitude;
                        existingAddress.Longitude = warehouse.Address.Coordinate.Longitude;

                        _dbContext.Addresses.Update(existingAddress);
                        warehouse.Address = DatabaseAddress.Map(existingAddress);
                    }
                }
                else
                {
                    // Добавляем новый адрес
                    var newAddress = DatabaseAddress.Map(warehouse.Address);
                    
                    await _dbContext.Addresses.AddAsync(newAddress, cancellationToken);
                    await _dbContext.SaveChangesAsync(cancellationToken);
                    warehouse.Address = DatabaseAddress.Map(newAddress);
                }
            }

            // 3. Добавляем склад
            var dbWarehouse = DatabaseWharehouse.Map(warehouse);
            await _wharehouseDbSet.AddAsync(dbWarehouse, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            // Обновляем ID в возвращаемом объекте
            warehouse.Id = dbWarehouse.Id;
            return OperationResult<Warehouse>.Success(warehouse);
        }
        catch (Exception ex)
        {
            return OperationResult<Warehouse>.Fail($"Ошибка при добавлении склада: {ex.Message} \n Inner: '{ex.InnerException.Message}'")!;
        }
    }

    public async Task<OperationResult<Warehouse>> UpdateWarehouse(int updateWhId, Warehouse warehouse, CancellationToken cancellationToken)
    {
        if (warehouse == null!)
            return OperationResult<Warehouse>.Fail("Склад не может быть null")!;

        try
        {
            var entity = await _wharehouseDbSet
                .FirstOrDefaultAsync(w => w.Id == updateWhId, cancellationToken);

            if (entity == null)
            {
                return OperationResult<Warehouse>.Fail("Склада для обновления не существует")!;
            }
            
            entity.Name = warehouse.Name;
            entity.AddressId = warehouse.Address.Id;
            entity.IsActive = warehouse.IsActive;
            _wharehouseDbSet.Update(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            
            return OperationResult<Warehouse>.Success(DatabaseWharehouse.Map(entity));
        }
        catch (Exception ex)
        {
            return OperationResult<Warehouse>.Fail($"Ошибка при обновлении склада: {ex.Message}")!;
        }
    }

    public async Task<OperationResult> DeleteWarehouse(int deleteWhId, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _wharehouseDbSet
                .FirstOrDefaultAsync(w => w.Id == deleteWhId);
            if (entity == null)
            {
                return OperationResult.Fail($"Ошибка при удалении склада: такого склада не существует");
            }
            _wharehouseDbSet.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return OperationResult.Success();
        }
        catch (Exception ex)
        {
            return OperationResult.Fail($"Ошибка при удалении склада: {ex.Message}");
        }
    }

    public async Task<OperationResult<List<Warehouse>>> GetWarehouses(CancellationToken cancellationToken)
    {
        try
        {
            var warehouses = await _wharehouseDbSet
                .Include(w => w.Address)
                .AsNoTracking()
                .Select(w => DatabaseWharehouse.Map(w)) // W мужики, W
                .ToListAsync(cancellationToken);
            
            return OperationResult<List<Warehouse>>.Success(warehouses);
        }
        catch (Exception ex)
        {
            return OperationResult<List<Warehouse>>.Fail($"Ошибка при получении складов: {ex.Message}")!;
        }
    }

    public async Task<OperationResult<PaginatedResult<Warehouse>>> SearchWarehouses(SearchRequest<string> searchRequest, CancellationToken cancellationToken)
    {
        var query = _wharehouseDbSet
            .AsQueryable();

        if (!string.IsNullOrEmpty(searchRequest.Query))
        {
            var searchTerm = $"searchRequest.Query.ToLower()%";
            query = query
                .Include(w => w.Address)
                .Where(c =>
                    EF.Functions.Like(c.Name, searchTerm));
        }
        
        var totalCount = await query.CountAsync(cancellationToken);
        var skip = searchRequest.Offset ?? 0;
        
        skip = Math.Min(skip, Math.Max(totalCount - 1, 0)); // Не выходим за границы
        var take = Math.Min(searchRequest.Limit, totalCount - skip); // Не берем лишнего

        var results = await query
            .Skip(skip)
            .Take(take)
            .Select(c => DatabaseWharehouse.Map(c))
            .ToListAsync(cancellationToken);
        
        var hasMore = skip + take < totalCount;
        var nextOffset = hasMore ? skip + take : 0;

        return OperationResult<PaginatedResult<Warehouse>>.Success(new PaginatedResult<Warehouse>(
            Results: results,
            Pagination: new PaginationMetadata(
                NextOffset: nextOffset,
                HasMore: hasMore,
                TotalCount: totalCount)));
    }

    public async Task<OperationResult<Warehouse>> GetWarehouse(int id)
    {
        var result = await _wharehouseDbSet
            .FirstOrDefaultAsync(w => w.Id == id);

        if (result == null)
            return OperationResult<Warehouse>.Fail("Склад с таким id не найден")!;
        
        return OperationResult<Warehouse>.Success(DatabaseWharehouse.Map(result));
    }

    public async Task<OperationResult<int>> GetWarehouseProductsCount(int warehouseId, int productId, CancellationToken cancellationToken)
    {
        try
        {
            var result = await _wharehouseProductsDbSet
                .FirstOrDefaultAsync(w => w.WharehouseId == warehouseId && w.ProductId == productId, cancellationToken);
            if (result == null)
                return OperationResult<int>.Success(0);

            return OperationResult<int>.Success(result.Count);
        }
        catch (Exception ex)
        {
            return OperationResult<int>.Fail(
                $"Ошибка получения количества продукта в складе: '{ex.Message}';\n{ex.InnerException?.Message}");
        }
    }

    public async Task<OperationResult> UpdateWarehouseProductCount(
        int warehouseId, int productId, int changedById, int count, CancellationToken cancellationToken)
    {
        if (count < 0)
            return OperationResult.Fail($"Число продукции товара не может быть меньше 0");
        
        try
        {
            var wharehouse = await _wharehouseDbSet
                .FirstOrDefaultAsync(w => w.Id == warehouseId, cancellationToken);

            if (wharehouse == null)
            {
                return OperationResult.Fail("Такого склада не существует");
            }

            var product = await _dbContext.Products
                .FirstOrDefaultAsync(p => p.Id == productId, cancellationToken);

            var wharehouseProduct = await _wharehouseProductsDbSet
                .FirstOrDefaultAsync(wp => wp.WharehouseId == warehouseId && wp.ProductId == productId,
                    cancellationToken);

            if (wharehouseProduct != null)
            {
                wharehouseProduct.Count = count;
                _dbContext.Update(wharehouseProduct);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
            else
            {
                await _wharehouseProductsDbSet.AddAsync(new DatabaseWharehouseProducts
                {
                    ProductId = productId,
                    WharehouseId = warehouseId,
                    ChangedById = changedById,
                    Count = count,
                    ChangedAt = DateTime.Now
                }, cancellationToken);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
            
            return OperationResult.Success();
        }
        catch (Exception ex)
        {
            return OperationResult.Fail($"Ошибка обновления количества продукта: {ex.Message}");
        }
    }
    
    private bool AreAddressesEqual(DatabaseAddress dbAddress, Address domainAddress)
    {
        return dbAddress.Country == domainAddress.Country &&
               dbAddress.City == domainAddress.City &&
               dbAddress.Street == domainAddress.Street &&
               dbAddress.HouseNumber == domainAddress.HouseNumber &&
               dbAddress.ApartmentNumber == domainAddress.ApartmentNumber &&
               Math.Abs(dbAddress.Longitude - domainAddress.Coordinate.Longitude) < 0.000001 &&
               Math.Abs(dbAddress.Latitude - domainAddress.Coordinate.Latitude) < 0.000001;
    }
}