using OnlineStore.Core.Common;
using OnlineStore.Core.Common.Pagination;
using OnlineStore.Core.Interfaces.HistoryParameters;
using OnlineStore.Core.Models;

namespace OnlineStore.Services.HistoryService;

public interface IHistoryService
{
    Task<OperationResult<PaginatedResult<OrderHistory>>> GetOrderHistory(
        int productId, SearchRequest<OrderHistorySearchParameters> request, User currentUser);
    
    Task<OperationResult<PaginatedResult<ProductHistory>>> GetProductHistory(
        int productId, SearchRequest<ProductHistorySearchParameters> request, User currentUser);
    
    Task<OperationResult<PaginatedResult<WarehouseProductHistory>>> GetWarehouseProductHistory(
        int warehouseId, int productId, SearchRequest<WarehouseProductHistorySearchParameters> request, User currentUser);
}