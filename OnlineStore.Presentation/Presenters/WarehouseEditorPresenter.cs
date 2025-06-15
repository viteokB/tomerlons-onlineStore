using OnlineStore.Core.Common.Pagination;
using OnlineStore.Core.Models;
using OnlineStore.Core.Models.WhareHouse;
using OnlineStore.Services.Products;
using OnlineStore.Services.WarehouseService;
using Presentation.Common;
using Presentation.Views;
using System.Threading.Tasks;

namespace Presentation.Presenters
{
    public class WarehouseEditorPresenter : BasePresenter<IWarehouseEditorView, User>
    {
        private readonly IWarehouseService _warehouseService;
        private readonly IProductService _productService;

        public WarehouseEditorPresenter(
            IWarehouseEditorView view,
            IWarehouseService warehouseService,
            IProductService productService) : base(view)
        {
            _warehouseService = warehouseService;
            _productService = productService;

            InitializeViewEvents();
        }

        private void InitializeViewEvents()
        {
            View.SearchWarehouses = SearchWarehouses;
            View.SearchProducts = SearchProducts;
            View.AddNewWarehouse = AddNewWarehouse;
            View.DeleteWarehouse = DeleteSelectedWarehouse;
            View.UpdateWarehouse = UpdateWarehouse;
            View.UpdateProductCount = UpdateProductCount;
            View.OnWarehouseSelected += async () => await UpdateProductCountDisplay();
            View.OnProductSelected += async () => await UpdateProductCountDisplay();
        }

        public override void Run(User user)
        {
            View.CurrentUser = user;
            View.Show();
        }
        
        private async Task UpdateProductCountDisplay()
        {
            if (View.SelectedWarehouse == null || View.SelectedProduct == null) 
            {
                View.SetProductCount(0);
                return;
            }

            var result = await _warehouseService.GetWarehouseProducts(
                View.SelectedWarehouse.Id,
                View.SelectedProduct.Id,
                CancellationToken.None);

            if (result.IsSuccess)
            {
                View.SetProductCount(result.Data);
            }
            else
            {
                View.SetProductCount(0);
                View.ShowError($"Не удалось получить количество: {result.Message}");
            }
        }

        private async Task SearchWarehouses()
        {
            var result = await _warehouseService.GetWarehouses(View.CurrentUser!);
            if (result.IsSuccess)
            {
                View.PaginatedWarehouses = new PaginatedResult<Warehouse>(
                    Results: result.Data,
                    new PaginationMetadata(
                        NextOffset: 0,
                        HasMore: false,
                        TotalCount: result.Data.Count));
            }
            else
            {
                View.ShowError(result.Message);
            }
        }

        private async Task SearchProducts()
        {
            var result = await _productService.SearchProducts(
                new SearchRequest<ProductsParamets>(new ProductsParamets(), 10, 0),
                View.CurrentUser);

            if (result.IsSuccess)
            {
                View.PaginatedProducts = result.Data;
            }
            else
            {
                View.ShowError(result.Message);
            }
        }

        private async Task AddNewWarehouse()
        {
            if (string.IsNullOrWhiteSpace(View.WarehouseName))
            {
                View.ShowError("Название склада не может быть пустым");
                return;
            }

            var newWarehouse = new Warehouse
            {
                Name = View.WarehouseName,
                IsActive = View.IsActive,
                Address = View.CurrentAddress // Адрес берется из формы
            };

            var result = await _warehouseService.AddWarehouse(newWarehouse, View.CurrentUser);
            if (result.IsSuccess)
            {
                View.ShowSuccess("Склад успешно добавлен");
                await SearchWarehouses();
            }
            else
            {
                View.ShowError(result.Message);
            }
        }

        private async Task DeleteSelectedWarehouse()
        {
            if (View.SelectedWarehouse == null) return;

            var result = await _warehouseService.DeleteWarehouse(
                View.SelectedWarehouse.Id,
                View.CurrentUser);

            if (result.IsSuccess)
            {
                View.ShowSuccess("Склад успешно удален");
            }
            else
            {
                View.ShowError(result.Message);
            }
        }

        private async Task UpdateWarehouse()
        {
            if (View.SelectedWarehouse == null) return;

            View.SelectedWarehouse.Name = View.WarehouseName;
            View.SelectedWarehouse.IsActive = View.IsActive;
            View.SelectedWarehouse.Address = View.CurrentAddress;

            var result = await _warehouseService.UpdateWarehouse(
                View.SelectedWarehouse.Id,
                View.SelectedWarehouse,
                View.CurrentUser);

            if (result.IsSuccess)
            {
                View.ShowSuccess("Склад успешно обновлен");
            }
            else
            {
                View.ShowError(result.Message);
            }
        }

        private async Task UpdateProductCount()
        {
            if (View.SelectedWarehouse == null || View.SelectedProduct == null) return;

            var result = await _warehouseService.UpdateWarehouseProductCount(
                View.SelectedWarehouse.Id,
                View.SelectedProduct.Id,
                View.CurrentUser,
                View.ProductCount);

            if (result.IsSuccess)
            {
                View.ShowSuccess("Количество товара обновлено");
            }
            else
            {
                View.ShowError(result.Message);
            }
        }
    }
}