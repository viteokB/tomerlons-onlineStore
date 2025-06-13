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
        
        RedactorView.CreateNewType += async () => await CreateNewType(RedactorView.TypeName, RedactorView.TypeDescription);
        RedactorView.UpdateType += async () => await UpdateType(RedactorView.SelectedType, RedactorView.TypeName, RedactorView.TypeDescription);
        RedactorView.DeleteType += async () => await DeleteType(RedactorView.SelectedType);
        RedactorView.SearchType += async () => await SearchType(RedactorView.SearchRequest);
    }
    
    private async Task CreateNewType(string typeName, string description)
    {
        if (string.IsNullOrWhiteSpace(typeName))
        {
            RedactorView.ShowError("Создаваемый тип не должен быть пустой строкой");
        }
        if (RedactorView.User is null)
        {
            RedactorView.ShowError("Пользователь не задан");
        }

        var newType = new Type
        {
            Name = typeName,
            Description = description
        };
        
        var operation = await _productService.AddType(newType, RedactorView.User!);

        if (!operation.IsSuccess)
        {
            RedactorView.ShowError($"Ошибка при создании нового типа: `{operation.Message}`");
        }
        else
        {
            RedactorView.ShowGoodInfo($"Тип `{typeName}` создан успешно");
        }
    }
    
    private async Task DeleteType(Type? selectedType)
    {
        if (selectedType == null)
        {
            RedactorView.ShowError("Удаляемый `Тип` должен быть выбран");
        }
        
        var operation = await _productService.DeleteType(selectedType!, RedactorView.User!);

        if (!operation.IsSuccess)
        {
            RedactorView.ShowError($"Ошибка при удалении типа: `{operation.Message}`");
        }
        else
        {
            RedactorView.ShowGoodInfo($"Тип `{selectedType?.Name}` удален успешно");
        }
    }
    
    private async Task UpdateType(Type? selectedType, string newName, string newDescription)
    {
        if (selectedType == null)
        {
            RedactorView.ShowError("Удаляемый `Тип` должен быть выбран");
        }
        
        var operation = await _productService.UpdateType(selectedType!.Id, 
            new Type { Name = newName, Description = newDescription}, RedactorView.User!);

        if (!operation.IsSuccess)
        {
            RedactorView.ShowError($"Ошибка при удалении типа: `{operation.Message}`");
        }
        else
        {
            RedactorView.ShowGoodInfo($"Тип `{selectedType?.Name}` удален успешно");
        }
    }

    private async Task SearchType(SearchRequest<string> searchRequest)
    {
        var operation = await _productService.SearchTypes(searchRequest, RedactorView.User!);

        if (!operation.IsSuccess)
        {
            RedactorView.ShowError($"Ошибка при поиске типов `{operation.Message}`");
        }
        else
        {
            var paginatedResult = operation.Data;
            RedactorView.PaginatedTypes = paginatedResult;
        }
    }

    public override void Run(User arg)
    {
        RedactorView.User = arg;
        RedactorView.Show();
    }
}