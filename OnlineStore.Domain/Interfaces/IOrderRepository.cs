// IOrderRepository.cs
using OnlineStore.Core.Common;
using OnlineStore.Core.Common.Pagination;
using OnlineStore.Core.Models;

namespace OnlineStore.Core.Interfaces;

public interface IOrderRepository
{
    Task<OperationResult> AddOrder(Order order, CancellationToken cancellationToken);
    Task<OperationResult> UpdateOrder(int id, Order order, CancellationToken cancellationToken);
    Task<OperationResult> DeleteOrder(int id, CancellationToken cancellationToken);

    Task<OperationResult> PutOrderInUserCard(
        OrderCreateParameters createParameters,
        CancellationToken cancellationToken);
    
    Task<OperationResult<PaginatedResult<Order>>> GetUserOrders(
        int userId, SearchRequest<OrderSearchParameters> request, CancellationToken cancellationToken);
    Task<OperationResult<PaginatedResult<Order>>> SearchOrders(
        SearchRequest<OrderSearchParameters> request, CancellationToken cancellationToken);
    Task<OperationResult<Order>> GetOrderById(int id, CancellationToken cancellationToken);
}