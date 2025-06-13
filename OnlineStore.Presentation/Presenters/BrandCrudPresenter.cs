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
        IBrandRedactorView redactorView,
        IProductService productService, 
        INavigationService navigationService) : base(redactorView)
    {
        _productService = productService;
        _navigationService = navigationService;
        
        // Инициализация событий для брендов
        RedactorView.CreateNewBrand += async () => await CreateNewBrand();
        RedactorView.UpdateBrand += async () => await UpdateBrand();
        RedactorView.DeleteBrand += async () => await DeleteBrand();
        RedactorView.SearchBrand += async () => await SearchBrand();
        
        // Инициализация событий для стран
        RedactorView.SearchCountry += async () => await SearchCountry();
    }

    private async Task CreateNewBrand()
    {
        if (string.IsNullOrWhiteSpace(RedactorView.BrandName))
        {
            RedactorView.ShowError("Название бренда не может быть пустым");
            return;
        }
        
        if (RedactorView.SelectedCountry == null)
        {
            RedactorView.ShowError("Страна должна быть выбрана");
            return;
        }
        
        if (RedactorView.User is null)
        {
            RedactorView.ShowError("Пользователь не задан");
            return;
        }

        var newBrand = new Brand()
        {
            Name = RedactorView.BrandName,
            Country = RedactorView.SelectedCountry
        };
        
        var operation = await _productService.AddBrand(newBrand, RedactorView.User);

        if (!operation.IsSuccess)
        {
            RedactorView.ShowError($"Ошибка при создании бренда: {operation.Message}");
        }
        else
        {
            RedactorView.ShowGoodInfo($"Бренд '{RedactorView.BrandName}' успешно создан");
        }
    }
    
    private async Task DeleteBrand()
    {
        if (RedactorView.SelectedBrand == null)
        {
            RedactorView.ShowError("Бренд должен быть выбран");
            return;
        }
        
        var operation = await _productService.DeleteBrand(
            RedactorView.SelectedBrand.Id, 
            RedactorView.User!);

        if (!operation.IsSuccess)
        {
            RedactorView.ShowError($"Ошибка при удалении бренда: {operation.Message}");
        }
        else
        {
            RedactorView.ShowGoodInfo($"Бренд '{RedactorView.SelectedBrand.Name}' успешно удалён");
        }
    }
    
    private async Task UpdateBrand()
    {
        if (RedactorView.SelectedBrand == null)
        {
            RedactorView.ShowError("Бренд должен быть выбран");
            return;
        }
        
        if (RedactorView.SelectedCountry == null)
        {
            RedactorView.ShowError("Страна должна быть выбрана");
            return;
        }

        var updatedBrand = new Brand()
        {
            Id = RedactorView.SelectedBrand.Id,
            Name = RedactorView.BrandName,
            Country = RedactorView.SelectedCountry
        };
        
        var operation = await _productService.UpdateBrand(
            RedactorView.SelectedBrand.Id, 
            updatedBrand, 
            RedactorView.User!);

        if (!operation.IsSuccess)
        {
            RedactorView.ShowError($"Ошибка при обновлении бренда: {operation.Message}");
        }
        else
        {
            RedactorView.ShowGoodInfo($"Бренд '{RedactorView.BrandName}' успешно обновлён");
        }
    }

    private async Task SearchBrand()
    {
        var operation = await _productService.SearchBrands(
            RedactorView.SearchBrandRequest, 
            RedactorView.User!);

        if (!operation.IsSuccess)
        {
            RedactorView.ShowError($"Ошибка при поиске брендов: {operation.Message}");
        }
        else
        {
            RedactorView.PaginatedBrands = operation.Data;
        }
    }

    private async Task SearchCountry()
    {
        var operation = await _productService.SearchCountries(
            RedactorView.SearchCountryRequest, 
            RedactorView.User!);

        if (!operation.IsSuccess)
        {
            RedactorView.ShowError($"Ошибка при поиске стран: {operation.Message}");
        }
        else
        {
            RedactorView.PaginatedCountries = operation.Data;
        }
    }

    public override void Run(User arg)
    {
        RedactorView.User = arg;
        RedactorView.Show();
    }
}