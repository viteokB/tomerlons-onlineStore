// OrderRepository.cs
using Microsoft.EntityFrameworkCore;
using OnlineStore.Core.Common;
using OnlineStore.Core.Common.Pagination;
using OnlineStore.Core.Interfaces;
using OnlineStore.Core.Models;
using OnlineStore.Repository.Models;

namespace OnlineStore.Repository.Repository;

public class OrderRepository : IOrderRepository
{
    private readonly OnlineStoreDbContext _dbContext;
    private readonly DbSet<DatabaseOrder> _orders;

    public OrderRepository(OnlineStoreDbContext dbContext)
    {
        _dbContext = dbContext;
        _orders = dbContext.DatabaseOrders;
    }

    public async Task<OperationResult> AddOrder(Order order, CancellationToken cancellationToken)
    {
        try
        {
            var dbOrder = new DatabaseOrder
            {
                UserId = order.User.Id,
                DeliveryStatusId = order.DeliveryStatus.Id,
                DeliveryAddressId = order.DeliveryAddress.Id,
                ProductId = order.Product.Id,
                WharehouseId = order.Warehouse.Id,
                Count = order.Count,
                ProductPrice = order.ProductPrice,
                DeliveryPrice = order.DeliveryPrice,
                DeliveryDays = order.DeliveryDays,
                Description = order.Description,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _orders.AddAsync(dbOrder, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return OperationResult.Success();
        }
        catch (Exception ex)
        {
            return OperationResult.Fail($"Ошибка при создании заказа: {ex.Message}");
        }
    }

    public async Task<OperationResult> UpdateOrder(int id, Order order, CancellationToken cancellationToken)
    {
        try
        {
            var dbOrder = await _orders.FindAsync(new object[] { id }, cancellationToken);
            if (dbOrder == null) return OperationResult.Fail("Заказ не найден");

            dbOrder.DeliveryStatusId = order.DeliveryStatus.Id;
            dbOrder.Description = order.Description;
            dbOrder.UpdatedAt = DateTime.UtcNow;
            dbOrder.ChangedById = order.ChangedBy?.Id;

            await _dbContext.SaveChangesAsync(cancellationToken);
            return OperationResult.Success();
        }
        catch (Exception ex)
        {
            return OperationResult.Fail($"Ошибка при обновлении заказа: {ex.Message}");
        }
    }

    public async Task<OperationResult> DeleteOrder(int id, CancellationToken cancellationToken)
    {
        try
        {
            var order = await _orders.FindAsync(new object[] { id }, cancellationToken);
            if (order == null) return OperationResult.Fail("Заказ не найден");

            _orders.Remove(order);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return OperationResult.Success();
        }
        catch (Exception ex)
        {
            return OperationResult.Fail($"Ошибка при удалении заказа: {ex.Message}");
        }
    }

    public async Task<OperationResult> PutOrderInUserCard(
        OrderCreateParameters createParameters,
        CancellationToken cancellationToken) 
    {
        try
        {
            var whProdEntity = await _dbContext.WarehousesProducts
                .Include(wh => wh.Product)
                .FirstOrDefaultAsync(w => 
                        w.WharehouseId == createParameters.WarehouseId && w.ProductId == createParameters.ProductId,
                    cancellationToken);

            if (whProdEntity == null)
            {
                return OperationResult.Fail("Склада с таким товаром нет");
            }
            if (whProdEntity.Count < createParameters.Count)
            {
                return OperationResult.Fail("Невозможно положить в корзину, товара на складе меньше чем вы выбрали");
            }
            if (!whProdEntity.Product.IsActive)
            {
                return OperationResult.Fail("Невозможно положить в корзину, товара не выпущен на продажу");
            }

            DatabaseAddress? addressEntity = null;
            if (createParameters.Address != null)
            {
                addressEntity = await _dbContext.Addresses
                    .FirstOrDefaultAsync(a => a.Id == createParameters.Address.Id, cancellationToken);

                if (addressEntity == null)
                {
                    await _dbContext.Addresses
                        .AddAsync(DatabaseAddress.Map(createParameters.Address), cancellationToken);
                    await _dbContext.SaveChangesAsync(cancellationToken);
                }
            }
            else
            {
                return OperationResult.Fail("Адрес не задан -> обязательно задать!");
            }

            var inCartStatus = await _dbContext.DeliveryStatuses
                .FirstOrDefaultAsync(s => s.Name == "в корзине", cancellationToken);

            if (inCartStatus == null)
            {
                return OperationResult.Fail("Не найден статус 'в корзине' срочно это исправьте!");
            }
            
            var dbOrder = new DatabaseOrder
            {
                UserId = createParameters.User.Id,
                DeliveryStatusId = inCartStatus.Id,
                DeliveryAddressId = addressEntity.Id,
                ProductId = createParameters.ProductId,
                WharehouseId = createParameters.WarehouseId,
                Count = createParameters.Count,
                ProductPrice = whProdEntity.Product.BasePrice,
                DeliveryPrice = 100, // пусть будет фиксированной без реализации по зонам
                DeliveryDays = createParameters.Count, // пусть будет фиксированной без реализации по зонам
                Description = (createParameters.Description ?? null)!,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            return OperationResult.Success();
        }
        catch (Exception ex)
        {
            return OperationResult.Fail($"Ошибка добавления в корзину: {ex.Message};\n{ex.InnerException?.Message}");
        }
    }

    public async Task<OperationResult<PaginatedResult<Order>>> GetUserOrders(int userId, SearchRequest<OrderSearchParameters> request, CancellationToken cancellationToken)
    {
        try
        {
            var query = _orders
                .Include(o => o.User)
                .Include(o => o.DeliveryStatus)
                .Include(o => o.Product)
                .Where(o => o.UserId == userId);

            if (request.Query != null)
            {
                if (request.Query.DeliveryStatus != null)
                    query = query.Where(o => o.DeliveryStatusId == request.Query.DeliveryStatus.Id);
                
                if (request.Query.StartDate.HasValue)
                    query = query.Where(o => o.CreatedAt >= request.Query.StartDate);
                
                if (request.Query.EndDate.HasValue)
                    query = query.Where(o => o.CreatedAt <= request.Query.EndDate);
            }

            var totalCount = await query.CountAsync(cancellationToken);
            var results = await query
                .OrderByDescending(o => o.CreatedAt)
                .Skip(request.Offset.Value)
                .Take(request.Limit)
                .Select(o => DatabaseOrder.Map(o))
                .ToListAsync(cancellationToken);

            return OperationResult<PaginatedResult<Order>>.Success(
                new PaginatedResult<Order>(
                    results,
                    new PaginationMetadata(
                        request.Offset + request.Limit < totalCount ? request.Offset + request.Limit : null,
                        request.Offset + request.Limit < totalCount,
                        totalCount
                    )
                ));
        }
        catch (Exception ex)
        {
            return OperationResult<PaginatedResult<Order>>.Fail($"Ошибка при получении заказов: {ex.Message}");
        }
    }

    public async Task<OperationResult<PaginatedResult<Order>>> SearchOrders(SearchRequest<OrderSearchParameters> request, CancellationToken cancellationToken)
    {
        try
        {
            var query = _orders
                .Include(o => o.User)
                .Include(o => o.DeliveryStatus)
                .Include(o => o.Product)
                .AsQueryable();

            if (request.Query != null)
            {
                if (request.Query.User != null)
                    query = query.Where(o => o.UserId == request.Query.User.Id);
                
                if (request.Query.DeliveryStatus != null)
                    query = query.Where(o => o.DeliveryStatusId == request.Query.DeliveryStatus.Id);
                
                if (request.Query.Id.HasValue)
                    query = query.Where(o => o.Id == request.Query.Id);
            }

            var totalCount = await query.CountAsync(cancellationToken);
            var results = await query
                .OrderByDescending(o => o.CreatedAt)
                .Skip(request.Offset.Value)
                .Take(request.Limit)
                .Select(o => DatabaseOrder.Map(o))
                .ToListAsync(cancellationToken);

            return OperationResult<PaginatedResult<Order>>.Success(
                new PaginatedResult<Order>(
                    results,
                    new PaginationMetadata(
                        request.Offset + request.Limit < totalCount ? request.Offset + request.Limit : null,
                        request.Offset + request.Limit < totalCount,
                        totalCount
                    )
                ));
        }
        catch (Exception ex)
        {
            return OperationResult<PaginatedResult<Order>>.Fail($"Ошибка при поиске заказов: {ex.Message}");
        }
    }

    public async Task<OperationResult<Order>> GetOrderById(int id, CancellationToken cancellationToken)
    {
        try
        {
            var order = await _orders
                .Include(o => o.User)
                .Include(o => o.DeliveryStatus)
                .Include(o => o.Product)
                .Include(o => o.Wharehouse)
                .Include(o => o.DeliveryAddress)
                .FirstOrDefaultAsync(o => o.Id == id, cancellationToken);

            if (order == null) return OperationResult<Order>.Fail("Заказ не найден");

            return OperationResult<Order>.Success(DatabaseOrder.Map(order));
        }
        catch (Exception ex)
        {
            return OperationResult<Order>.Fail($"Ошибка при получении заказа: {ex.Message}");
        }
    }
}