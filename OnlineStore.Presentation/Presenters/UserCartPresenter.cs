// UserCartPresenter.cs

using OnlineStore.Core.Common.Pagination;
using OnlineStore.Core.Models;
using OnlineStore.Services.Orders;
using Presentation.Common;
using Presentation.NavigationService;
using Presentation.Views;

namespace Presentation.Presenters;

public class UserCartPresenter : BasePresenter<IUserCartView, User>
{
    private readonly IOrderService _orderService;
    private readonly INavigationService _navigationService;

    public UserCartPresenter(
        IUserCartView view,
        IOrderService orderService,
        INavigationService navigationService) : base(view)
    {
        _orderService = orderService;
        _navigationService = navigationService;
        
        View.LoadOrders = async () => await LoadUserOrders();
        View.CreateOrder = async () => await CreateNewOrder();
        View.CancelOrder = async () => await CancelSelectedOrder();
        View.ViewOrderDetails = async () => await ShowOrderDetails();
    }

    public override void Run(User user)
    {
        View.CurrentUser = user;
        View.SearchRequest = new SearchRequest<OrderSearchParameters>(new OrderSearchParameters(), 10, 0);
        _ = LoadUserOrders();
        View.Show();
    }

    private async Task LoadUserOrders()
    {
        var result = await _orderService.GetUserOrders(View.CurrentUser, View.SearchRequest);
        if (!result.IsSuccess)
            View.ShowError(result.Message);
        else
            View.UserOrders = result.Data;
    }

    private async Task CreateNewOrder()
    {
        // Логика создания нового заказа
        // Например, можно открыть форму создания заказа
        // await _navigationService.ShowOrderCreation(View.CurrentUser);
        View.ShowInfo("Нет реализации");
    }

    private async Task CancelSelectedOrder()
    {
        if (View.SelectedOrder == null)
        {
            View.ShowError("Выберите заказ");
            return;
        }

        var result = await _orderService.DeleteOrder(View.SelectedOrder.Id, View.CurrentUser);
        if (!result.IsSuccess)
            View.ShowError(result.Message);
        else
        {
            View.ShowInfo("Заказ отменен");
            await LoadUserOrders();
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