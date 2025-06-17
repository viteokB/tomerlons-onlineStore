using OnlineStore.Core.Common;
using OnlineStore.Core.Common.Pagination;
using OnlineStore.Core.Interfaces.HistoryParameters;
using OnlineStore.Core.Models;

namespace OnlineStore.Core.Interfaces;

public interface IHistoryRepository
{
    Task<OperationResult<PaginatedResult<OrderHistory>>> GetOrderHistory(
        int productId, SearchRequest<OrderHistorySearchParameters> request, CancellationToken cancellationToken);
    
    Task<OperationResult<PaginatedResult<ProductHistory>>> GetProductHistory(
        int productId, SearchRequest<ProductHistorySearchParameters> request, CancellationToken cancellationToken);
    
    Task<OperationResult<PaginatedResult<WarehouseProductHistory>>> GetWarehouseProductHistory(
        int warehouseId, int productId, SearchRequest<WarehouseProductHistorySearchParameters> request, CancellationToken cancellationToken);
}