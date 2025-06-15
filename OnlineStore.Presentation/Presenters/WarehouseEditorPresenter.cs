using OnlineStore.Core.Common.Pagination;
using OnlineStore.Core.Models;
using OnlineStore.Services.Products;
using OnlineStore.Services.WarehouseService;
using Presentation.Common;
using Presentation.Views;

namespace Presentation.Presenters;

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

        // Инициализация событий
        View.SearchWarehouses = async () => await SearchWarehouses();
        View.SearchProducts = async () => await SearchProducts();
        View.UpdateWarehouse = async () => await UpdateWarehouse();
        View.UpdateProductCount = async () => await UpdateProductCount();
    }

    public override void Run(User user)
    {
        View.CurrentUser = user;
        View.WarehouseSearchRequest = new SearchRequest<string>("", 10, 0);
        View.ProductSearchRequest = new SearchRequest<ProductsParamets>(new ProductsParamets(), 10, 0);
        View.Show();
    }

    private async Task SearchWarehouses()
    {
        var result = await _warehouseService.SearchWarehouses(
            View.WarehouseSearchRequest, 
            View.CurrentUser!);
        
        if (result.IsSuccess)
        {
            View.PaginatedWarehouses = result.Data;
        }
        else
        {
            View.ShowError(result.Message!);
        }
    }

    private async Task SearchProducts()
    {
        var result = await _productService.SearchProducts(
            View.ProductSearchRequest, 
            View.CurrentUser!);
        
        if (result.IsSuccess)
        {
            View.PaginatedProducts = result.Data;
        }
        else
        {
            View.ShowError(result.Message!);
        }
    }

    private async Task UpdateWarehouse()
    {
        if (View.SelectedWarehouse == null) return;
        
        var result = await _warehouseService.UpdateWarehouse(
            View.SelectedWarehouse.Id, 
            View.SelectedWarehouse, 
            View.CurrentUser!);
        
        if (result.IsSuccess)
        {
            View.ShowSuccess("Склад успешно обновлен");
        }
        else
        {
            View.ShowError(result.Message!);
        }
    }

    private async Task UpdateProductCount()
    {
        if (View.SelectedWarehouse == null || View.SelectedProduct == null) return;
        
        var result = await _warehouseService.UpdateWarehouseProductCount(
            View.SelectedWarehouse.Id,
            View.SelectedProduct.Id,
            View.CurrentUser!.Id,
            View.ProductCount);
        
        if (result.IsSuccess)
        {
            View.ShowSuccess("Количество товара обновлено");
        }
        else
        {
            View.ShowError(result.Message!);
        }
    }
}