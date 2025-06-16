using OnlineStore.Core.Common.Pagination;
using OnlineStore.Core.Models;
using OnlineStore.Services.Orders;
using Presentation.Common;
using Presentation.NavigationService;
using Presentation.Views;

namespace Presentation.Presenters;

public class AdminOrdersPresenter : BasePresenter<IAdminOrdersView, User>
{
    private readonly IOrderService _orderService;
    private readonly INavigationService _navigationService;

    public AdminOrdersPresenter(
        IAdminOrdersView view,
        IOrderService orderService,
        INavigationService navigationService) : base(view)
    {
        _orderService = orderService;
        _navigationService = navigationService;
        
        View.SearchOrders = async () => await SearchAllOrders();
        View.UpdateOrderStatus = async () => await UpdateStatus();
        View.ViewOrderDetails = async () => await ShowOrderDetails();
        
        View.LoadStatuses = async () => await LoadAllStatuses();
        View.AddNewStatus = async () => await AddStatus();
        View.DeleteStatus = async () => await RemoveStatus();
    }

    public override void Run(User user)
    {
        View.CurrentUser = user;
        View.SearchRequest = new SearchRequest<OrderSearchParameters>(new OrderSearchParameters(), 10, 0);
        _ = Task.WhenAll(
            SearchAllOrders(),
            LoadAllStatuses()
        );
        View.Show();
    }
    
    private async Task LoadAllStatuses()
    {
        var result = await _orderService.GetAllStatuses(View.CurrentUser);
        if (!result.IsSuccess)
            View.ShowError(result.Message);
        else
            View.AllStatuses = result.Data;
    }

    private async Task AddStatus()
    {
        if (string.IsNullOrWhiteSpace(View.StatusName))
        {
            View.ShowError("Введите название статуса");
            return;
        }

        var newStatus = new DeliveryStatus
        {
            Name = View.StatusName,
            Description = View.StatusDescription,
            IsActive = View.StatusIsActive
        };

        var result = await _orderService.AddStatus(newStatus, View.CurrentUser);
        if (!result.IsSuccess)
            View.ShowError(result.Message);
        else
        {
            View.ShowInfo("Статус добавлен");
            await LoadAllStatuses();
        }
    }

    private async Task RemoveStatus()
    {
        if (View.SelectedStatus == null)
        {
            View.ShowError("Выберите статус для удаления");
            return;
        }

        var result = await _orderService.DeleteStatus(View.SelectedStatus.Id, View.CurrentUser);
        if (!result.IsSuccess)
            View.ShowError(result.Message);
        else
        {
            View.ShowInfo("Статус удален");
            await LoadAllStatuses();
        }
    }

    private async Task SearchAllOrders()
    {
        var result = await _orderService.SearchOrders(View.SearchRequest, View.CurrentUser);
        if (!result.IsSuccess)
            View.ShowError(result.Message);
        else
            View.Orders = result.Data;
    }

    private async Task UpdateStatus()
    {
        if (View.SelectedOrder == null || View.SelectedStatus == null)
        {
            View.ShowError("Выберите заказ и статус");
            return;
        }

        var result = await _orderService.UpdateOrderStatus(
            View.SelectedOrder.Id, 
            View.SelectedStatus, 
            View.CurrentUser);

        if (!result.IsSuccess)
            View.ShowError(result.Message);
        else
        {
            View.ShowInfo("Статус обновлен");
            await SearchAllOrders();
        }
    }

    private async Task ShowOrderDetails()
    {
        if (View.SelectedOrder == null)
        {
            View.ShowError("Выберите заказ");
            return;
        }

        var result = await _orderService.GetOrderDetails(View.SelectedOrder.Id, View.CurrentUser);
        if (!result.IsSuccess)
            View.ShowError(result.Message);
        else
            View.ShowInfo($"Детали заказа #{result.Data.Id}");
    }
}