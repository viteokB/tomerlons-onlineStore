﻿using Microsoft.EntityFrameworkCore;
using OnlineStore.Core.Common;
using OnlineStore.Core.Common.Pagination;
using OnlineStore.Core.Interfaces;
using OnlineStore.Core.Models;
using OnlineStore.Core.Models.WhareHouse;
using OnlineStore.Repository.Models;

namespace OnlineStore.Repository.Repository;

public class OrderRepository : IOrderRepository
{
    private readonly OnlineStoreDbContext _dbContext;
    private readonly DbSet<DatabaseOrder> _orders;
    private readonly DbSet<DatabaseOrderHistory> _orderHistory;

    public OrderRepository(OnlineStoreDbContext dbContext)
    {
        _dbContext = dbContext;
        _orderHistory = dbContext.DatabaseOrderHistory;
        _orders = dbContext.DatabaseOrders;
    }

    public async Task<OperationResult> AddOrder(Order order, CancellationToken cancellationToken)
    {
        using var transaction = await _dbContext.Database.BeginTransactionAsync(cancellationToken);
        
        try
        {
            // Проверка существования связанных сущностей
            if (!await _dbContext.Users.AnyAsync(u => u.Id == order.User.Id, cancellationToken))
                return OperationResult.Fail("Пользователь не найден");
            
            if (!await _dbContext.DeliveryStatuses.AnyAsync(d => d.Id == order.DeliveryStatus.Id, cancellationToken))
                return OperationResult.Fail("Статус доставки не найден");
            
            if (!await _dbContext.Addresses.AnyAsync(a => a.Id == order.DeliveryAddress.Id, cancellationToken))
                return OperationResult.Fail("Адрес доставки не найден");
            
            if (!await _dbContext.Products.AnyAsync(p => p.Id == order.Product.Id, cancellationToken))
                return OperationResult.Fail("Продукт не найден");
            
            if (!await _dbContext.Warehouses.AnyAsync(w => w.Id == order.Warehouse.Id, cancellationToken))
                return OperationResult.Fail("Склад не найден");

            var dbOrder = DatabaseOrder.Map(order);
            dbOrder.CreatedAt = DateTime.UtcNow;
            dbOrder.UpdatedAt = DateTime.UtcNow;

            await _orders.AddAsync(dbOrder, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken); // Сохраняем, чтобы получить ID

            // Добавляем запись в историю
            var history = new DatabaseOrderHistory
            {
                OrderId = dbOrder.Id,
                UserId = dbOrder.UserId,
                DeliveryStatusId = dbOrder.DeliveryStatusId,
                DeliveryAddressId = dbOrder.DeliveryAddressId,
                ProductId = dbOrder.ProductId,
                WharehouseId = dbOrder.WharehouseId,
                ChangedById = dbOrder.ChangedById,
                Count = dbOrder.Count,
                ProductPrice = dbOrder.ProductPrice,
                DeliveryPrice = dbOrder.DeliveryPrice,
                DeliveryDays = dbOrder.DeliveryDays,
                Description = dbOrder.Description,
                CreatedAt = dbOrder.CreatedAt,
                UpdatedAt = dbOrder.UpdatedAt
            };

            await _orderHistory.AddAsync(history, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            
            await transaction.CommitAsync(cancellationToken);
            return OperationResult.Success();
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync(cancellationToken);
            return OperationResult.Fail($"Ошибка при создании заказа: {ex.Message}");
        }
    }

    public async Task<OperationResult> UpdateOrder(int id, Order order, CancellationToken cancellationToken)
    {
        using var transaction = await _dbContext.Database.BeginTransactionAsync(cancellationToken);
        
        try
        {
            var dbOrder = await _orders
                .Include(o => o.DeliveryStatus)
                .Include(o => o.ChangedByUser)
                .FirstOrDefaultAsync(o => o.Id == id, cancellationToken);
            
            if (dbOrder == null) 
                return OperationResult.Fail("Заказ не найден");

            // Проверка существования нового статуса доставки
            if (!await _dbContext.DeliveryStatuses.AnyAsync(d => d.Id == order.DeliveryStatus.Id, cancellationToken))
                return OperationResult.Fail("Новый статус доставки не найден");

            // Проверка существования пользователя, который вносит изменения
            if (order.ChangedBy != null && 
                !await _dbContext.Users.AnyAsync(u => u.Id == order.ChangedBy.Id, cancellationToken))
            {
                return OperationResult.Fail("Пользователь, вносящий изменения, не найден");
            }

            // Сохраняем старые значения для истории
            var oldStatusId = dbOrder.DeliveryStatusId;
            var oldDescription = dbOrder.Description;

            // Обновляем заказ
            dbOrder.DeliveryStatusId = order.DeliveryStatus.Id;
            dbOrder.Description = order.Description;
            dbOrder.UpdatedAt = DateTime.UtcNow;
            dbOrder.ChangedById = order.ChangedBy?.Id;

            _dbContext.Update(dbOrder);
            await _dbContext.SaveChangesAsync(cancellationToken);

            // Добавляем запись в историю только если были изменения
            if (oldStatusId != dbOrder.DeliveryStatusId || oldDescription != dbOrder.Description)
            {
                var history = new DatabaseOrderHistory
                {
                    OrderId = dbOrder.Id,
                    UserId = dbOrder.UserId,
                    DeliveryStatusId = dbOrder.DeliveryStatusId,
                    DeliveryAddressId = dbOrder.DeliveryAddressId,
                    ProductId = dbOrder.ProductId,
                    WharehouseId = dbOrder.WharehouseId,
                    ChangedById = dbOrder.ChangedById,
                    Count = dbOrder.Count,
                    ProductPrice = dbOrder.ProductPrice,
                    DeliveryPrice = dbOrder.DeliveryPrice,
                    DeliveryDays = dbOrder.DeliveryDays,
                    Description = dbOrder.Description,
                    CreatedAt = dbOrder.CreatedAt,
                    UpdatedAt = dbOrder.UpdatedAt
                };

                await _orderHistory.AddAsync(history, cancellationToken);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }

            await transaction.CommitAsync(cancellationToken);
            return OperationResult.Success();
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync(cancellationToken);
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
        using var transaction = await _dbContext.Database.BeginTransactionAsync(cancellationToken);
        
        try
        {
            // Проверка наличия товара на складе
            var whProdEntity = await _dbContext.WarehousesProducts
                .Include(wh => wh.Product)
                .FirstOrDefaultAsync(w => 
                        w.WharehouseId == createParameters.WarehouseId && 
                        w.ProductId == createParameters.ProductId,
                    cancellationToken);

            if (whProdEntity == null)
                return OperationResult.Fail("Склада с таким товаром нет");
            
            if (whProdEntity.Count < createParameters.Count)
                return OperationResult.Fail("Недостаточно товара на складе");
            
            if (!whProdEntity.Product.IsActive)
                return OperationResult.Fail("Товар не доступен для продажи");

            // Обработка адреса
            if (createParameters.Address == null)
                return OperationResult.Fail("Адрес обязателен");

            DatabaseAddress addressEntity;
            
            // Если адрес новый (Id = 0)
            if (createParameters.Address.Id == 0)
            {
                addressEntity = DatabaseAddress.Map(createParameters.Address);
                await _dbContext.Addresses.AddAsync(addressEntity, cancellationToken);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
            else
            {
                // Если адрес существует - проверяем его
                addressEntity = await _dbContext.Addresses
                    .FirstOrDefaultAsync(a => a.Id == createParameters.Address.Id, cancellationToken);
                    
                if (addressEntity == null)
                    return OperationResult.Fail("Указанный адрес не найден");
            }

            // Получаем статус "в корзине"
            var inCartStatus = await _dbContext.DeliveryStatuses
                .FirstOrDefaultAsync(s => s.Name.ToLower() == "в корзине", cancellationToken);
                
            if (inCartStatus == null)
                return OperationResult.Fail("Статус 'в корзине' не настроен в системе");

            // Проверка существования пользователя
            if (!await _dbContext.Users.AnyAsync(u => u.Id == createParameters.User.Id, cancellationToken))
                return OperationResult.Fail("Пользователь не найден");

            // Создаем заказ
            var dbOrder = new DatabaseOrder
            {
                UserId = createParameters.User.Id,
                DeliveryStatusId = inCartStatus.Id,
                DeliveryAddressId = addressEntity.Id,
                ProductId = createParameters.ProductId,
                WharehouseId = createParameters.WarehouseId,
                Count = createParameters.Count,
                ProductPrice = whProdEntity.Product.BasePrice,
                DeliveryPrice = 100, // Примерная стоимость доставки
                DeliveryDays = createParameters.Count, // Примерное количество дней доставки
                Description = createParameters.Description ?? string.Empty,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _orders.AddAsync(dbOrder, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken); // Сохраняем, чтобы получить ID

            // Добавляем запись в историю
            var history = new DatabaseOrderHistory
            {
                OrderId = dbOrder.Id,
                UserId = dbOrder.UserId,
                DeliveryStatusId = dbOrder.DeliveryStatusId,
                DeliveryAddressId = dbOrder.DeliveryAddressId,
                ProductId = dbOrder.ProductId,
                WharehouseId = dbOrder.WharehouseId,
                ChangedById = dbOrder.ChangedById,
                Count = dbOrder.Count,
                ProductPrice = dbOrder.ProductPrice,
                DeliveryPrice = dbOrder.DeliveryPrice,
                DeliveryDays = dbOrder.DeliveryDays,
                Description = dbOrder.Description,
                CreatedAt = dbOrder.CreatedAt,
                UpdatedAt = dbOrder.UpdatedAt
            };

            await _orderHistory.AddAsync(history, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            
            await transaction.CommitAsync(cancellationToken);
            return OperationResult.Success();
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync(cancellationToken);
            return OperationResult.Fail($"Ошибка: {ex.Message}");
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
                .Include(o => o.Wharehouse)
                .Include(o => o.ChangedByUser)
                .Include(o => o.DeliveryAddress)
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
                .ToListAsync(cancellationToken);

            List<Order> orders = new List<Order>();
            
            foreach (var o in results)
            {
                orders.Add(new Order()
                {
                    Id = o.Id,
                    User = null,
                    DeliveryAddress = DatabaseAddress.Map(o.DeliveryAddress),
                    DeliveryStatus = DatabaseDeliveryStatus.Map(o.DeliveryStatus),
                    Warehouse = new Warehouse
                    {
                        Id = o.Wharehouse.Id,
                        IsActive = o.Wharehouse.IsActive,
                        Name = o.Wharehouse.Name,
                        Address = null,
                    },
                    ChangedBy = null,
                    Count = o.Count,
                    Product = new Product
                    {
                        Name = o.Product.Name,
                        CatalogNumber = o.Product.CatalogNumber
                    },
                    ProductPrice = o.ProductPrice,
                    DeliveryPrice = o.DeliveryPrice,
                    DeliveryDays = o.DeliveryDays,
                    Description = o.Description,
                    CreatedAt = o.CreatedAt,
                    UpdatedAt = o.UpdatedAt
                });
            }

            return OperationResult<PaginatedResult<Order>>.Success(
                new PaginatedResult<Order>(
                    orders,
                    new PaginationMetadata(
                        request.Offset + request.Limit < totalCount ? request.Offset + request.Limit : null,
                        request.Offset + request.Limit < totalCount,
                        totalCount
                    )
                ));
        }
        catch (Exception ex)
        {
            return OperationResult<PaginatedResult<Order>>.Fail($"Ошибка при получении заказов: {ex.Message};\n{ex.InnerException?.Message}");
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