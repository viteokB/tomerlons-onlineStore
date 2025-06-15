using Microsoft.EntityFrameworkCore;
using OnlineStore.Core.Common;
using OnlineStore.Core.Common.Pagination;
using OnlineStore.Core.Interfaces;
using OnlineStore.Core.Models;
using OnlineStore.Core.Models.WhareHouse;
using OnlineStore.Repository.Models;

namespace OnlineStore.Repository.Repository;

public class WarehouseRepository : IWarehouseRepository
{
    private readonly OnlineStoreDbContext _dbContext;
    private readonly DbSet<DatabaseWharehouse> _wharehouseDbSet;
    private readonly DbSet<DatabaseWharehouseProducts> _wharehouseProductsDbSet;

    public WarehouseRepository(DbSet<DatabaseWharehouseProducts> wharehouseProductsDbSet,
        DbSet<DatabaseWharehouse> wharehouseDbSet, OnlineStoreDbContext dbContext)
    {
        _wharehouseProductsDbSet = wharehouseProductsDbSet;
        _wharehouseDbSet = wharehouseDbSet;
        _dbContext = dbContext;
    }
    
    public async Task<OperationResult> AddWarehouse(Wharehouse warehouse, CancellationToken cancellationToken)
    {
        if (warehouse == null!)
            return OperationResult.Fail("Wharehouse не может быть null");
        try
        {
            var exsist = await _wharehouseDbSet
                .FirstOrDefaultAsync(w => w.Id == warehouse.Id, cancellationToken);

            if (exsist != null)
            {
                return OperationResult.Fail("Данный склад уже существует.");
            }

            await _wharehouseDbSet.AddAsync(DatabaseWharehouse.Map(warehouse), cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return OperationResult.Success();
        }
        catch (Exception ex)
        {
            return OperationResult.Fail($"Ошибка при добавлении склада: {ex.Message}");
        }
    }

    public async Task<OperationResult> UpdateWarehouse(int updateWhId, Wharehouse warehouse, CancellationToken cancellationToken)
    {
        if (warehouse == null!)
            return OperationResult.Fail("Склад не может быть null");

        try
        {
            var entity = await _wharehouseDbSet
                .FirstOrDefaultAsync(w => w.Id == updateWhId, cancellationToken);

            if (entity == null)
            {
                return OperationResult.Fail("Склада для обновления не существует");
            }

            entity.Address.Id = warehouse.Address.Id;
            entity.Name = warehouse.Name;
            entity.IsActive = warehouse.IsActive;
            _wharehouseDbSet.Update(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return OperationResult.Success();
        }
        catch (Exception ex)
        {
            return OperationResult.Fail($"Ошибка при обновлении склада: {ex.Message}");
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

    public async Task<OperationResult<List<Wharehouse>>> GetWarehouses(CancellationToken cancellationToken)
    {
        try
        {
            var warehouses = await _wharehouseDbSet
                .AsNoTracking()
                .Select(w => DatabaseWharehouse.Map(w)) // W мужики, W
                .ToListAsync(cancellationToken);
            
            return OperationResult<List<Wharehouse>>.Success(warehouses);
        }
        catch (Exception ex)
        {
            return OperationResult<List<Wharehouse>>.Fail($"Ошибка при получении складов: {ex.Message}")!;
        }
    }

    public async Task<OperationResult<PaginatedResult<Wharehouse>>> SearchWarehouses(SearchRequest<string> searchRequest, CancellationToken cancellationToken)
    {
        var query = _wharehouseDbSet.AsQueryable();

        if (!string.IsNullOrEmpty(searchRequest.Query))
        {
            var searchTerm = $"searchRequest.Query.ToLower()%";
            query = query
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

        return OperationResult<PaginatedResult<Wharehouse>>.Success(new PaginatedResult<Wharehouse>(
            Results: results,
            Pagination: new PaginationMetadata(
                NextOffset: nextOffset,
                HasMore: hasMore,
                TotalCount: totalCount)));
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

            var product = _dbContext.Products
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
            }
            
            return OperationResult.Success();
        }
        catch (Exception ex)
        {
            return OperationResult.Fail($"Ошибка обновления количества продукта: {ex.Message}");
        }
    }
}