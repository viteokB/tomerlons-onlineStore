using Microsoft.EntityFrameworkCore;
using OnlineStore.Core.Common;
using OnlineStore.Core.Common.Pagination;
using OnlineStore.Core.Interfaces;
using OnlineStore.Core.Interfaces.HistoryParameters;
using OnlineStore.Core.Models;
using OnlineStore.Repository.Models;

namespace OnlineStore.Repository.Repository;

public class HistoryRepository : IHistoryRepository
{
    private readonly OnlineStoreDbContext _dbContext;

    public HistoryRepository(OnlineStoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<OperationResult<PaginatedResult<OrderHistory>>> GetOrderHistory(
        int productId, SearchRequest<OrderHistorySearchParameters> request, CancellationToken cancellationToken)
    {
        try
        {
            var query = _dbContext.DatabaseOrderHistory
                .Include(h => h.Product)
                .Include(h => h.User)
                .Where(h => h.ProductId == productId);

            // if (request.Query != null)
            // {
            //     if (request.Query.StartDate.HasValue)
            //         query = query.Where(h => h.CreatedAt >= request.Query.StartDate);
            //     
            //     if (request.Query.EndDate.HasValue)
            //         query = query.Where(h => h.CreatedAt <= request.Query.EndDate);
            // }

            var totalCount = await query.CountAsync(cancellationToken);
            var results = await query
                .OrderBy(h => h.CreatedAt)
                .Skip(request.Offset ?? 0)
                .Take(request.Limit)
                .Select(h => new OrderHistory
                {
                    Id = h.Id,
                    OrderId = h.OrderId,
                    ProductId = h.ProductId,
                    ProductName = h.Product.Name,
                    Count = h.Count,
                    ProductPrice = h.ProductPrice,
                    CreatedAt = h.CreatedAt,
                    ChangedBy = h.User != null ? DatabaseUser.Map(h.ChangedByUser) : null
                })
                .ToListAsync(cancellationToken);

            return OperationResult<PaginatedResult<OrderHistory>>.Success(
                new PaginatedResult<OrderHistory>(
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
            return OperationResult<PaginatedResult<OrderHistory>>.Fail($"Error getting order history: {ex.Message}");
        }
    }

    public async Task<OperationResult<PaginatedResult<ProductHistory>>> GetProductHistory(
        int productId, SearchRequest<ProductHistorySearchParameters> request, CancellationToken cancellationToken)
    {
        try
        {
            var query = _dbContext.ProductsHistory
                .Include(h => h.Product)
                .Include(h => h.ChangedBy)
                .Where(h => h.ProductId == productId);

            // if (request.Query != null)
            // {
            //     if (request.Query.StartDate.HasValue)
            //         query = query.Where(h => h.ChangedAt >= request.Query.StartDate);
            //     
            //     if (request.Query.EndDate.HasValue)
            //         query = query.Where(h => h.ChangedAt <= request.Query.EndDate);
            // }

            var totalCount = await query.CountAsync(cancellationToken);
            var results = await query
                .OrderBy(h => h.ChangedAt)
                .Skip(request.Offset ?? 0)
                .Take(request.Limit)
                .Select(h => new ProductHistory
                {
                    Id = h.Id,
                    ProductId = h.ProductId,
                    Name = h.Name,
                    CatalogNumber = h.CatalogNumber,
                    BasePrice = h.BasePrice,
                    IsActive = h.IsActive,
                    ChangedAt = h.ChangedAt,
                    ChangedBy = h.ChangedBy != null ? DatabaseUser.Map(h.ChangedBy) : null
                })
                .ToListAsync(cancellationToken);

            return OperationResult<PaginatedResult<ProductHistory>>.Success(
                new PaginatedResult<ProductHistory>(
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
            return OperationResult<PaginatedResult<ProductHistory>>.Fail($"Error getting product history: {ex.Message}");
        }
    }

    public async Task<OperationResult<PaginatedResult<WarehouseProductHistory>>> GetWarehouseProductHistory(
        int warehouseId, int productId, SearchRequest<WarehouseProductHistorySearchParameters> request, CancellationToken cancellationToken)
    {
        try
        {
            var query = _dbContext.WarehousesProductsHistory
                .Include(h => h.Product)
                .Include(h => h.ChangedBy)
                .Include(h => h.ChangedBy.Role)
                .Where(h => h.WharehouseId == warehouseId && h.ProductId == productId);

            // if (request.Query != null)
            // {
            //     if (request.Query.StartDate.HasValue)
            //         query = query.Where(h => h.ChangedAt >= request.Query.StartDate);
            //     
            //     if (request.Query.EndDate.HasValue)
            //         query = query.Where(h => h.ChangedAt <= request.Query.EndDate);
            // }

            var totalCount = await query.CountAsync(cancellationToken);
            var results = await query
                .OrderBy(h => h.ChangedAt)
                .Skip(request.Offset ?? 0)
                .Take(request.Limit)
                .Select(h => new WarehouseProductHistory
                {
                    Id = h.Id,
                    WarehouseProductId = h.WarehouseProdId,
                    WarehouseId = h.WharehouseId,
                    ProductId = h.ProductId,
                    ProductName = h.Product.Name,
                    Count = h.Count,
                    ChangedAt = h.ChangedAt,
                    ChangedBy = h.ChangedBy != null ? DatabaseUser.Map(h.ChangedBy) : null
                })
                .ToListAsync(cancellationToken);

            return OperationResult<PaginatedResult<WarehouseProductHistory>>.Success(
                new PaginatedResult<WarehouseProductHistory>(
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
            return OperationResult<PaginatedResult<WarehouseProductHistory>>.Fail($"Error getting warehouse product history: {ex.Message}");
        }
    }
}