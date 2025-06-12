using Microsoft.VisualBasic;
using OnlineStore.Core.Common.Pagination;
using OnlineStore.Core.Models;
using OnlineStore.Services.Products;
using Presentation.Common;
using Presentation.NavigationService;
using Presentation.Views;
using Type = OnlineStore.Core.Models.Type;

namespace Presentation.Presenters;

public class TypeCrudPresenter : BasePresenter<ITypeRedactorView, User>
{
    private readonly IProductService _productService;
    private readonly INavigationService _navigationService;

    public TypeCrudPresenter(
        ITypeRedactorView view,
        IProductService productService, 
        INavigationService navigationService) : base(view)
    {
        _productService = productService;
        _navigationService = navigationService;
        
        View.CreateNewType += async () => await CreateNewType(View.TypeName, View.TypeDescription);
        View.UpdateType += async () => await UpdateType(View.SelectedType, View.TypeName, View.TypeDescription);
        View.DeleteType += async () => await DeleteType(View.SelectedType);
        View.SearchType += async () => await SearchType(View.SearchRequest);
    }
    
    private async Task CreateNewType(string typeName, string description)
    {
        if (string.IsNullOrWhiteSpace(typeName))
        {
            View.ShowError("Создаваемый тип не должен быть пустой строкой");
        }
        if (View.User is null)
        {
            View.ShowError("Пользователь не задан");
        }

        var newType = new Type
        {
            Name = typeName,
            Description = description
        };
        
        var operation = await _productService.AddType(newType, View.User!);

        if (!operation.IsSuccess)
        {
            View.ShowError($"Ошибка при создании нового типа: `{operation.Message}`");
        }
        View.ShowGoodInfo($"Тип `{typeName}` создан успешно");
    }
    
    private async Task DeleteType(Type? selectedType)
    {
        if (selectedType == null)
        {
            View.ShowError("Удаляемый `Тип` должен быть выбран");
        }
        
        var operation = await _productService.DeleteType(selectedType!, View.User!);

        if (!operation.IsSuccess)
        {
            View.ShowError($"Ошибка при удалении типа: `{operation.Message}`");
        }
        View.ShowGoodInfo($"Тип `{selectedType?.Name}` удален успешно");
    }
    
    private async Task UpdateType(Type? selectedType, string newName, string newDescription)
    {
        if (selectedType == null)
        {
            View.ShowError("Удаляемый `Тип` должен быть выбран");
        }
        
        var operation = await _productService.UpdateType(selectedType!.Id, 
            new Type { Name = newName, Description = newDescription}, View.User!);

        if (!operation.IsSuccess)
        {
            View.ShowError($"Ошибка при удалении типа: `{operation.Message}`");
        }
        View.ShowGoodInfo($"Тип `{selectedType?.Name}` удален успешно");
    }

    private async Task SearchType(SearchRequest<string> searchRequest)
    {
        var operation = await _productService.SearchTypes(searchRequest, View.User!);

        if (!operation.IsSuccess)
        {
            View.ShowError($"Ошибка при поиске типов `{operation.Message}`");
        }
        else
        {
            var paginatedResult = operation.Data;
            View.PaginatedTypes = paginatedResult;
        }
    }

    public override void Run(User arg)
    {
        View.User = arg;
    }
}