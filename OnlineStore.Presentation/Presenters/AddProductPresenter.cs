using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OnlineStore.Core.Common.Pagination;
using OnlineStore.Core.Models;
using OnlineStore.Services.Products;
using Presentation.Common;
using Presentation.NavigationService;
using Presentation.Views;
using Type = OnlineStore.Core.Models.Type;

namespace Presentation.Presenters;

public class AddProductPresenter : BasePresenter<IAddProductView, User>
{
    private readonly IProductService _productService;
    private readonly INavigationService _navigationService;

    public AddProductPresenter(
        IAddProductView view,
        IProductService productService, 
        INavigationService navigationService) : base(view)
    {
        _productService = productService;
        _navigationService = navigationService;
        
        // Инициализация событий продукта
        View.CreateNewProduct += async () => await CreateProduct();
        View.UpdateProduct += async () => await UpdateProduct();
        View.DisactivateProduct += async () => await DisactivateProduct();
        View.DeleteProduct += async () => await DeleteProduct();
        
        // Инициализация событий поиска
        View.SearchBrands += async () => await SearchBrands();
        View.SearchCountry += async () => await SearchCountries();
        View.SearchType += async () => await SearchTypes();
        View.SearchProduct += async () => await SearchProducts();
    }

    public override void Run(User arg)
    {
        View.ChangedBy = arg;
        // Инициализация начальных запросов
        View.SearchBrandRequest = new SearchRequest<string>("", 10, 0);
        View.SearchCountriesRequest = new SearchRequest<string>("", 10, 0);
        View.SearchTypesRequest = new SearchRequest<string>("", 10, 0);
        View.SearchProductRequest = new SearchRequest<ProductsParamets>(new ProductsParamets(), 10, 0);
        
        // Загрузка начальных данных
        _ = SearchBrands();
        _ = SearchCountries();
        _ = SearchTypes();
        View.Show();
    }

    private async Task CreateProduct()
    {
        if (string.IsNullOrWhiteSpace(View.Name))
        {
            View.ShowError("Название продукта не может быть пустым");
            return;
        }

        if (View.Type == null)
        {
            View.ShowError("Тип продукта должен быть выбран");
            return;
        }

        if (View.Brand == null)
        {
            View.ShowError("Бренд должен быть выбран");
            return;
        }

        if (View.Country == null)
        {
            View.ShowError("Страна должна быть выбрана");
            return;
        }

        var newProduct = new Product
        {
            Name = View.Name,
            Type = View.Type,
            Brand = View.Brand,
            Country = View.Country,
            PhotoPath = View.PhotoPath,
            CatalogNumber = View.CatalogNumber,
            BasePrice = View.BasePrice,
            IsActive = View.IsActive,
            ChangedBy = View.ChangedBy,
            ChangedAt = DateTime.Now
        };

        var operation = await _productService.AddProduct(newProduct, View.ChangedBy!);

        if (!operation.IsSuccess)
        {
            View.ShowError($"Ошибка при создании продукта: {operation.Message}");
        }
        else
        {
            View.ShowGoodInfo($"Продукт '{View.Name}' успешно создан");
            ClearForm();
            await SearchProducts(); // Обновляем список продуктов
        }
    }

    private async Task UpdateProduct()
    {
        if (View.SelectedProduct == null)
        {
            View.ShowError("Продукт должен быть выбран");
            return;
        }

        if (string.IsNullOrWhiteSpace(View.Name))
        {
            View.ShowError("Название продукта не может быть пустым");
            return;
        }

        var updatedProduct = new Product
        {
            Id = View.SelectedProduct.Id,
            Name = View.Name,
            Type = View.Type,
            Brand = View.Brand,
            Country = View.Country,
            PhotoPath = View.PhotoPath,
            CatalogNumber = View.CatalogNumber,
            BasePrice = View.BasePrice,
            IsActive = View.IsActive,
            ChangedBy = View.ChangedBy,
            ChangedAt = DateTime.Now
        };

        var operation = await _productService.UpdateProduct(updatedProduct.Id, updatedProduct, View.ChangedBy!);

        if (!operation.IsSuccess)
        {
            View.ShowError($"Ошибка при обновлении продукта: {operation.Message}");
        }
        else
        {
            View.ShowGoodInfo($"Продукт '{View.Name}' успешно обновлен");
            await SearchProducts(); // Обновляем список продуктов
        }
    }

    private async Task DisactivateProduct()
    {
        if (View.SelectedProduct == null)
        {
            View.ShowError("Продукт должен быть выбран");
            return;
        }

        var product = new Product
        {
            Id = View.SelectedProduct.Id,
            IsActive = false,
            ChangedBy = View.ChangedBy,
            ChangedAt = DateTime.Now,
            Name = View.SelectedProduct.Name,
            CatalogNumber = View.SelectedProduct.CatalogNumber
        };

        var operation = await _productService.UpdateProduct(product.Id, product, View.ChangedBy!);

        if (!operation.IsSuccess)
        {
            View.ShowError($"Ошибка при деактивации продукта: {operation.Message}");
        }
        else
        {
            View.ShowGoodInfo($"Продукт '{View.SelectedProduct.Name}' деактивирован");
            View.IsActive = false;
            await SearchProducts(); // Обновляем список продуктов
        }
    }

    private async Task DeleteProduct()
    {
        if (View.SelectedProduct == null)
        {
            View.ShowError("Продукт должен быть выбран");
            return;
        }

        var operation = await _productService.DeleteProduct(View.SelectedProduct.Id, View.ChangedBy!);

        if (!operation.IsSuccess)
        {
            View.ShowError($"Ошибка при удалении продукта: {operation.Message}");
        }
        else
        {
            View.ShowGoodInfo($"Продукт '{View.SelectedProduct.Name}' удален");
            ClearForm();
            await SearchProducts(); // Обновляем список продуктов
        }
    }

    private async Task SearchBrands()
    {
        var operation = await _productService.SearchBrands(
            View.SearchBrandRequest, 
            View.ChangedBy!);

        if (!operation.IsSuccess)
        {
            View.ShowError($"Ошибка при поиске брендов: {operation.Message}");
        }
        else
        {
            View.PaginatedBrands = operation.Data;
        }
    }

    private async Task SearchCountries()
    {
        var operation = await _productService.SearchCountries(
            View.SearchCountriesRequest, 
            View.ChangedBy!);

        if (!operation.IsSuccess)
        {
            View.ShowError($"Ошибка при поиске стран: {operation.Message}");
        }
        else
        {
            View.PaginatedCountries = operation.Data;
        }
    }

    private async Task SearchTypes()
    {
        var operation = await _productService.SearchTypes(
            View.SearchTypesRequest, 
            View.ChangedBy!);

        if (!operation.IsSuccess)
        {
            View.ShowError($"Ошибка при поиске типов: {operation.Message}");
        }
        else
        {
            View.PaginatedTypes = operation.Data;
        }
    }

    private async Task SearchProducts()
    {
        var operation = await _productService.SearchProducts(
            new SearchRequest<ProductsParamets>(View.ProductsParamets!, 10, 0), 
            View.ChangedBy!);

        if (!operation.IsSuccess)
        {
            View.ShowError($"Ошибка при поиске продуктов: {operation.Message}");
        }
        else
        {
            View.PaginatedProducts = operation.Data;
        }
    }

    private void ClearForm()
    {
        View.Name = string.Empty;
        View.CatalogNumber = string.Empty;
        View.BasePrice = 0;
        View.PhotoPath = null;
        View.Type = null;
        View.Brand = null;
        View.Country = null;
        View.IsActive = true;
        View.SelectedProduct = null;
    }
}