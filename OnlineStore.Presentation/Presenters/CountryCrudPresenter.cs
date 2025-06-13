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
        ICountryRedactorView view,
        IProductService productService, 
        INavigationService navigationService) : base(view)
    {
        _productService = productService;
        _navigationService = navigationService;
        
        View.CreateNewCountry += async () => await CreateNewCountry(
            View.CountryName, View.CountryCode);
        View.UpdateCountry += async () => await UpdateType(
            View.SelectedCountry, View.CountryName, View.CountryCode);
        View.DeleteCountry += async () => await DeleteType(View.SelectedCountry);
        View.SearchCountry += async () => await SearchType(View.SearchRequest);
    }
    
    private async Task CreateNewCountry(string countryName, string countryCode)
    {
        if (string.IsNullOrWhiteSpace(countryName))
        {
            View.ShowError("Создаваемый тип не должен быть пустой строкой");
        }
        if (View.User is null)
        {
            View.ShowError("Пользователь не задан");
        }

        var newCountry = new Country()
        {
            Name = countryName,
            Code = countryCode
        };
        
        var operation = await _productService.AddCountry(newCountry, View.User!);

        if (!operation.IsSuccess)
        {
            View.ShowError($"Ошибка при создании нового типа: `{operation.Message}`");
        }
        else
        {
            View.ShowGoodInfo($"Страна `{countryName}` создана успешно");
        }
    }
    
    private async Task DeleteType(Country? selectedCountry)
    {
        if (selectedCountry == null)
        {
            View.ShowError("Удаляемая `Страна` должна быть выбрана");
        }
        
        var operation = await _productService.DeleteCountry(selectedCountry?.Id, View.User!);

        if (!operation.IsSuccess)
        {
            View.ShowError($"Ошибка при удалении страны: `{operation.Message}`");
        }
        else
        {
            View.ShowGoodInfo($"Страна `{selectedCountry?.Name}` удалена успешно");
        }
    }
    
    private async Task UpdateType(Country? selectedCountry, string newName, string newCode)
    {
        if (selectedCountry == null)
        {
            View.ShowError("Обновляемая `Страна` должна быть выбрана");
        }
        
        var operation = await _productService.UpdateCountry(selectedCountry!.Id,
            new Country() { Name = newName, Code = newCode}, View.User!);

        if (!operation.IsSuccess)
        {
            View.ShowError($"Ошибка при обновлении страны: `{operation.Message}`");
        }
        else
        {
            View.ShowGoodInfo($"Страна `{selectedCountry?.Name}` обновлена успешно");
        }
    }

    private async Task SearchType(SearchRequest<string> searchRequest)
    {
        var operation = await _productService.SearchCountries(searchRequest, View.User!);

        if (!operation.IsSuccess)
        {
            View.ShowError($"Ошибка при поиске типов `{operation.Message}`");
        }
        else
        {
            var paginatedResult = operation.Data;
            View.PaginatedCountries = paginatedResult;
        }
    }

    public override void Run(User arg)
    {
        View.User = arg;
        View.Show();
    }
}