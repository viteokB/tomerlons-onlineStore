using OnlineStore.Core.Common;
using OnlineStore.Core.Common.Pagination;
using OnlineStore.Core.Interfaces;
using OnlineStore.Core.Models;

namespace OnlineStore.Services.Orders;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IUserRepository _userRepository;
    private readonly IDeliveryStatusRepository _statusRepository;

    public OrderService(IOrderRepository orderRepository, 
        IUserRepository userRepository, IDeliveryStatusRepository statusRepository)
    {
        _orderRepository = orderRepository;
        _userRepository = userRepository;
        _statusRepository = statusRepository;
    }

    public async Task<OperationResult> CreateOrder(Order order, User currentUser)
    {
        if (currentUser == null!)
            return OperationResult.Fail("Пользователь не авторизован");

        order.User = currentUser;
        return await _orderRepository.AddOrder(order, CancellationToken.None);
    }

    public async Task<OperationResult> UpdateOrderStatus(int id, DeliveryStatus status, User currentUser)
    {
        if (!IsAdminOrManager(currentUser))
            return OperationResult.Fail("Недостаточно прав");

        var orderResult = await _orderRepository.GetOrderById(id, CancellationToken.None);
        if (!orderResult.IsSuccess)
            return orderResult;

        var order = orderResult.Data;
        order.DeliveryStatus = status;
        order.ChangedBy = currentUser;

        return await _orderRepository.UpdateOrder(id, order, CancellationToken.None);
    }

    public async Task<OperationResult> DeleteOrder(int id, User currentUser)
    {
        return await _orderRepository.DeleteOrder(id, CancellationToken.None);
    }

    public Task<OperationResult> PutOrderInUserCard(OrderCreateParameters createParameters, CancellationToken cancellationToken)
    {
        return _orderRepository.PutOrderInUserCard(createParameters, cancellationToken);
    }

    public async Task<OperationResult<PaginatedResult<Core.Models.Order>>> GetUserOrders(User currentUser, SearchRequest<OrderSearchParameters> request)
    {
        if (currentUser == null!)
            return OperationResult<PaginatedResult<Core.Models.Order>>.Fail("Пользователь не авторизован")!;

        return await _orderRepository.GetUserOrders(currentUser.Id, request, CancellationToken.None);
    }

    public async Task<OperationResult<PaginatedResult<Core.Models.Order>>> SearchOrders(SearchRequest<OrderSearchParameters> request, User currentUser)
    {
        if (!IsAdminOrManager(currentUser))
            return OperationResult<PaginatedResult<Core.Models.Order>>.Fail("Недостаточно прав")!;

        return await _orderRepository.SearchOrders(request, CancellationToken.None);
    }

    public async Task<OperationResult<Core.Models.Order>> GetOrderDetails(int id, User currentUser)
    {
        var orderResult = await _orderRepository.GetOrderById(id, CancellationToken.None);
        if (!orderResult.IsSuccess)
            return orderResult;

        // Проверка прав доступа
        if (!IsAdminOrManager(currentUser) && orderResult.Data.User.Id != currentUser.Id)
            return OperationResult<Core.Models.Order>.Fail("Недостаточно прав")!;

        return orderResult;
    }
    
    public async Task<OperationResult<List<DeliveryStatus>>> GetAllStatuses(User currentUser)
    {
        if (!IsAdminOrManager(currentUser))
            return OperationResult<List<DeliveryStatus>>.Fail("Недостаточно прав");

        return await _statusRepository.GetAllStatuses(CancellationToken.None);
    }

    public async Task<OperationResult<DeliveryStatus>> AddStatus(DeliveryStatus status, User currentUser)
    {
        if (!IsAdminOrManager(currentUser))
            return OperationResult<DeliveryStatus>.Fail("Недостаточно прав");

        return await _statusRepository.AddStatus(status, CancellationToken.None);
    }

    public async Task<OperationResult> DeleteStatus(int id, User currentUser)
    {
        if (!IsAdminOrManager(currentUser))
            return OperationResult.Fail("Недостаточно прав");

        return await _statusRepository.DeleteStatus(id, CancellationToken.None);
    }

    private bool IsAdminOrManager(User user)
    {
        return user?.Role?.Name?.ToLower() is "админ" or "менеджер";
    }
}