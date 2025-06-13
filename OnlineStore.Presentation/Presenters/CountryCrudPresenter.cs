using OnlineStore.Core.Common.Pagination;
using OnlineStore.Core.Models;
using OnlineStore.Services.Products;
using Presentation.Common;
using Presentation.NavigationService;
using Presentation.Views;
using Type = OnlineStore.Core.Models.Type;

namespace Presentation.Presenters;

public class CountryCrudPresenter : BasePresenter<ICountryRedactorView, User>
{
    private readonly IProductService _productService;
    private readonly INavigationService _navigationService;

    public CountryCrudPresenter(
        ICountryRedactorView redactorView,
        IProductService productService, 
        INavigationService navigationService) : base(redactorView)
    {
        _productService = productService;
        _navigationService = navigationService;
        
        RedactorView.CreateNewCountry += async () => await CreateNewCountry(
            RedactorView.CountryName, RedactorView.CountryCode);
        RedactorView.UpdateCountry += async () => await UpdateType(
            RedactorView.SelectedCountry, RedactorView.CountryName, RedactorView.CountryCode);
        RedactorView.DeleteCountry += async () => await DeleteType(RedactorView.SelectedCountry);
        RedactorView.SearchCountry += async () => await SearchType(RedactorView.SearchRequest);
    }
    
    private async Task CreateNewCountry(string countryName, string countryCode)
    {
        if (string.IsNullOrWhiteSpace(countryName))
        {
            RedactorView.ShowError("Создаваемый тип не должен быть пустой строкой");
        }
        if (RedactorView.User is null)
        {
            RedactorView.ShowError("Пользователь не задан");
        }

        var newCountry = new Country()
        {
            Name = countryName,
            Code = countryCode
        };
        
        var operation = await _productService.AddCountry(newCountry, RedactorView.User!);

        if (!operation.IsSuccess)
        {
            RedactorView.ShowError($"Ошибка при создании нового типа: `{operation.Message}`");
        }
        else
        {
            RedactorView.ShowGoodInfo($"Страна `{countryName}` создана успешно");
        }
    }
    
    private async Task DeleteType(Country? selectedCountry)
    {
        if (selectedCountry == null)
        {
            RedactorView.ShowError("Удаляемая `Страна` должна быть выбрана");
        }
        
        var operation = await _productService.DeleteCountry(selectedCountry?.Id, RedactorView.User!);

        if (!operation.IsSuccess)
        {
            RedactorView.ShowError($"Ошибка при удалении страны: `{operation.Message}`");
        }
        else
        {
            RedactorView.ShowGoodInfo($"Страна `{selectedCountry?.Name}` удалена успешно");
        }
    }
    
    private async Task UpdateType(Country? selectedCountry, string newName, string newCode)
    {
        if (selectedCountry == null)
        {
            RedactorView.ShowError("Обновляемая `Страна` должна быть выбрана");
        }
        
        var operation = await _productService.UpdateCountry(selectedCountry!.Id,
            new Country() { Name = newName, Code = newCode}, RedactorView.User!);

        if (!operation.IsSuccess)
        {
            RedactorView.ShowError($"Ошибка при обновлении страны: `{operation.Message}`");
        }
        else
        {
            RedactorView.ShowGoodInfo($"Страна `{selectedCountry?.Name}` обновлена успешно");
        }
    }

    private async Task SearchType(SearchRequest<string> searchRequest)
    {
        var operation = await _productService.SearchCountries(searchRequest, RedactorView.User!);

        if (!operation.IsSuccess)
        {
            RedactorView.ShowError($"Ошибка при поиске типов `{operation.Message}`");
        }
        else
        {
            var paginatedResult = operation.Data;
            RedactorView.PaginatedCountries = paginatedResult;
        }
    }

    public override void Run(User arg)
    {
        RedactorView.User = arg;
        RedactorView.Show();
    }
}