using OnlineStore.Core.Models;
using OnlineStore.Services.Orders;
using OnlineStore.Services.WarehouseService;
using Presentation.Common;
using Presentation.Views;

namespace Presentation.Presenters
{
    public class PurchasePresenter : BasePresenter<IPurchaseView, (Product product, User user)>
    {
        private readonly IOrderService _orderService;
        private readonly IWarehouseService _warehouseService;

        public PurchasePresenter(
            IPurchaseView view,
            IOrderService orderService,
            IWarehouseService warehouseService) : base(view)
        {
            _orderService = orderService;
            _warehouseService = warehouseService;

            View.PurchaseConfirmed += async () => await PurchaseProduct();
            View.LoadWarehouses += async () => await LoadWarehouses();
            View.WarehouseSelected += async (warehouseId) => await CheckProductAvailability(warehouseId);
        }

        public override void Run((Product product, User user) arg)
        {
            View.SelectedProduct = arg.product;
            View.CurrentUser = arg.user;
            View.Show();
        }

        private async Task LoadWarehouses()
        {
            try
            {
                var result = await _warehouseService.GetWarehouses(View.CurrentUser);
                if (result.IsSuccess)
                {
                    View.ShowWarehouses(result.Data);
                    if (result.Data.Count > 0)
                    {
                        await CheckProductAvailability(result.Data[0].Id);
                    }
                }
                else
                {
                    View.ShowError(result.Message);
                }
            }
            catch (Exception ex)
            {
                View.ShowError($"Ошибка при загрузке складов: {ex.Message}");
            }
        }

        private async Task CheckProductAvailability(int warehouseId)
        {
            try
            {
                var result = await _warehouseService.GetWarehouseProducts(
                    warehouseId,
                    View.SelectedProduct.Id,
                    default);

                if (result.IsSuccess)
                {
                    View.AvailableQuantity = result.Data;
                    View.UpdateProductAvailabilityInfo();
                }
                else
                {
                    View.ShowError(result.Message);
                }
            }
            catch (Exception ex)
            {
                View.ShowError($"Ошибка проверки наличия: {ex.Message}");
            }
        }

        private async Task PurchaseProduct()
        {
            try
            {
                if (View.AvailableQuantity <= 0)
                {
                    View.ShowError("Товара нет в наличии на выбранном складе");
                    return;
                }

                if (View.Quantity > View.AvailableQuantity)
                {
                    View.ShowError($"Недостаточно товара. Доступно: {View.AvailableQuantity}");
                    return;
                }

                var createParams = new OrderCreateParameters
                {
                    ProductId = View.SelectedProduct.Id,
                    WarehouseId = View.SelectedWarehouseId,
                    Count = View.Quantity,
                    User = View.CurrentUser,
                    Address = View.DeliveryAddress,
                    Description = View.Description
                };

                var result = await _orderService.PutOrderInUserCard(createParams, default);
                
                if (result.IsSuccess)
                {
                    View.ShowSuccess("Товар добавлен в корзину");
                    View.Close();
                }
                else
                {
                    View.ShowError(result.Message);
                }
            }
            catch (Exception ex)
            {
                View.ShowError($"Ошибка при оформлении заказа: {ex.Message}");
            }
        }
    }
}