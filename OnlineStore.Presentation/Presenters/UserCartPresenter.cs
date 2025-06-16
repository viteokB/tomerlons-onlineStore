using OnlineStore.Core.Common.Pagination;
using OnlineStore.Core.Models;
using OnlineStore.Services.Orders;
using Presentation.Common;
using Presentation.NavigationService;
using Presentation.Views;

namespace Presentation.Presenters
{
    public class UserCartPresenter : BasePresenter<IUserCartView, User>
    {
        private readonly IOrderService _orderService;

        public UserCartPresenter(
            IUserCartView view,
            IOrderService orderService) : base(view)
        {
            _orderService = orderService;
            
            View.LoadOrders += async () => await LoadUserOrders();
            View.CancelOrder += async () => await CancelSelectedOrder();
        }

        public override async void Run(User user)
        {
            View.CurrentUser = user;
            await LoadUserOrders();
            View.Show();
        }

        private async Task LoadUserOrders()
        {
            try
            {
                var request = new SearchRequest<OrderSearchParameters>(
                    new OrderSearchParameters(),
                    100, 0); // Получаем все заказы в корзине
                
                var result = await _orderService.GetUserOrders(View.CurrentUser, request);
                
                if (result.IsSuccess)
                {
                    View.UserOrders = result.Data;
                    View.UpdateOrdersList();
                }
                else
                {
                    View.ShowError(result.Message);
                }
            }
            catch (Exception ex)
            {
                View.ShowError($"Ошибка загрузки заказов: {ex.Message}");
            }
        }

        private async Task CancelSelectedOrder()
        {
            if (View.SelectedOrder == null)
            {
                View.ShowError("Выберите заказ для отмены");
                return;
            }

            try
            {
                var result = await _orderService.DeleteOrder(View.SelectedOrder.Id, View.CurrentUser);
                
                if (result.IsSuccess)
                {
                    View.ShowSuccess("Заказ успешно отменен");
                    await LoadUserOrders(); // Обновляем список
                }
                else
                {
                    View.ShowError(result.Message);
                }
            }
            catch (Exception ex)
            {
                View.ShowError($"Ошибка отмены заказа: {ex.Message}");
            }
        }
    }
}