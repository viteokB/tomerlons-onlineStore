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
    }

    private async Task CreateNewType(string typeName, string description)
    {
        if (string.IsNullOrWhiteSpace(typeName))
        {
            View.ShowError("Создаваемый тип не должен быть пустой строкой");
        }
        if (View.ChangedBy is null)
        {
            View.ShowError("Создаваемый тип не должен быть пустой строкой");
        }

        var newType = new Type
        {
            Name = typeName,
            Description = description
        };
        
        var operation = await _productService.AddType(newType, View.ChangedBy!);

        if (!operation.IsSuccess)
        {
            View.ShowError($"Ошибка при создании нового типа: `{operation.Message}`");
        }
        View.ShowGoodInfo($"Тип `{typeName}` создан успешно");
    }

    public override void Run(User arg)
    {
        View.ChangedBy = arg;
    }
}