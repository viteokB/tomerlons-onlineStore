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
            RedactorView.ShowError("Создаваемый тип не должен быть пустой строкой");
        }
        if (RedactorView.ChangedBy is null)
        {
            RedactorView.ShowError("Создаваемый тип не должен быть пустой строкой");
        }

        var newType = new Type
        {
            Name = typeName,
            Description = description
        };
        
        var operation = await _productService.AddType(newType, RedactorView.ChangedBy!);

        if (!operation.IsSuccess)
        {
            RedactorView.ShowError($"Ошибка при создании нового типа: `{operation.Message}`");
        }
        RedactorView.ShowGoodInfo($"Тип `{typeName}` создан успешно");
    }

    public override void Run(User arg)
    {
        RedactorView.ChangedBy = arg;
    }
}