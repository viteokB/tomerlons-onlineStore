using OnlineStore.Core.Common;
using OnlineStore.Core.Common.Pagination;
using OnlineStore.Core.Models;

namespace OnlineStore.Services.Orders;

public interface IOrderService
{
    Task<OperationResult> CreateOrder(Core.Models.Order order, User currentUser);
    Task<OperationResult> UpdateOrderStatus(int id, DeliveryStatus status, User currentUser);
    Task<OperationResult> DeleteOrder(int id, User currentUser);
    Task<OperationResult<PaginatedResult<Core.Models.Order>>> GetUserOrders(User currentUser, SearchRequest<OrderParameters> request);
    Task<OperationResult<PaginatedResult<Core.Models.Order>>> SearchOrders(SearchRequest<OrderParameters> request, User currentUser);
    Task<OperationResult<Core.Models.Order>> GetOrderDetails(int id, User currentUser);

    Task<OperationResult<List<DeliveryStatus>>> GetAllStatuses(User currentUser);

    Task<OperationResult<DeliveryStatus>> AddStatus(DeliveryStatus status, User currentUser);
    
    Task<OperationResult> DeleteStatus(int id, User currentUser);
}