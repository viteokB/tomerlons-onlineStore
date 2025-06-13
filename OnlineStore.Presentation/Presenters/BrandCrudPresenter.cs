using OnlineStore.Core.Common.Pagination;
using OnlineStore.Core.Models;
using OnlineStore.Services.Products;
using Presentation.Common;
using Presentation.NavigationService;
using Presentation.Views;

namespace Presentation.Presenters;

public class BrandCrudPresenter : BasePresenter<IBrandRedactorView, User>
{
    private readonly IProductService _productService;
    private readonly INavigationService _navigationService;

    public BrandCrudPresenter(
        IBrandRedactorView View,
        IProductService productService, 
        INavigationService navigationService) : base(View)
    {
        _productService = productService;
        _navigationService = navigationService;
        
        // Инициализация событий для брендов
        View.CreateNewBrand += async () => await CreateNewBrand();
        View.UpdateBrand += async () => await UpdateBrand();
        View.DeleteBrand += async () => await DeleteBrand();
        View.SearchBrand += async () => await SearchBrand();
        
        // Инициализация событий для стран
        View.SearchCountry += async () => await SearchCountry();
    }

    private async Task CreateNewBrand()
    {
        if (string.IsNullOrWhiteSpace(View.BrandName))
        {
            View.ShowError("Название бренда не может быть пустым");
            return;
        }
        
        if (View.SelectedCountry == null)
        {
            View.ShowError("Страна должна быть выбрана");
            return;
        }
        
        if (View.User is null)
        {
            View.ShowError("Пользователь не задан");
            return;
        }

        var newBrand = new Brand()
        {
            Name = View.BrandName,
            Country = View.SelectedCountry
        };
        
        var operation = await _productService.AddBrand(newBrand, View.User);

        if (!operation.IsSuccess)
        {
            View.ShowError($"Ошибка при создании бренда: {operation.Message}");
        }
        else
        {
            View.ShowGoodInfo($"Бренд '{View.BrandName}' успешно создан");
        }
    }
    
    private async Task DeleteBrand()
    {
        if (View.SelectedBrand == null)
        {
            View.ShowError("Бренд должен быть выбран");
            return;
        }
        
        var operation = await _productService.DeleteBrand(
            View.SelectedBrand.Id, 
            View.User!);

        if (!operation.IsSuccess)
        {
            View.ShowError($"Ошибка при удалении бренда: {operation.Message}");
        }
        else
        {
            View.ShowGoodInfo($"Бренд '{View.SelectedBrand.Name}' успешно удалён");
        }
    }
    
    private async Task UpdateBrand()
    {
        if (View.SelectedBrand == null)
        {
            View.ShowError("Бренд должен быть выбран");
            return;
        }
        
        if (View.SelectedCountry == null)
        {
            View.ShowError("Страна должна быть выбрана");
            return;
        }

        var updatedBrand = new Brand()
        {
            Id = View.SelectedBrand.Id,
            Name = View.BrandName,
            Country = View.SelectedCountry
        };
        
        var operation = await _productService.UpdateBrand(
            View.SelectedBrand.Id, 
            updatedBrand, 
            View.User!);

        if (!operation.IsSuccess)
        {
            View.ShowError($"Ошибка при обновлении бренда: {operation.Message}");
        }
        else
        {
            View.ShowGoodInfo($"Бренд '{View.BrandName}' успешно обновлён");
        }
    }

    private async Task SearchBrand()
    {
        var operation = await _productService.SearchBrands(
            View.SearchBrandRequest, 
            View.User!);

        if (!operation.IsSuccess)
        {
            View.ShowError($"Ошибка при поиске брендов: {operation.Message}");
        }
        else
        {
            View.PaginatedBrands = operation.Data;
        }
    }

    private async Task SearchCountry()
    {
        var operation = await _productService.SearchCountries(
            View.SearchCountryRequest, 
            View.User!);

        if (!operation.IsSuccess)
        {
            View.ShowError($"Ошибка при поиске стран: {operation.Message}");
        }
        else
        {
            View.PaginatedCountries = operation.Data;
        }
    }

    public override void Run(User arg)
    {
        View.User = arg;
        View.Show();
    }
}