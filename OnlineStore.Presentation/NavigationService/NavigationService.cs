﻿using OnlineStore.Core.Models;
using Presentation.Common;
using Presentation.Presenters;

namespace Presentation.NavigationService;

public class NavigationService : INavigationService
{
    private readonly Func<LoginPresenter> _loginPresenterFactory;
    private readonly Func<RegisterPresenter> _registerPresenterFactory;
    private readonly Func<MainPresenter> _mainPresenterFactory;
    private readonly Func<AuthorPresenter> _authorPresenterFactory;
    private readonly Func<TypeCrudPresenter> _typeCrudPresenterFactory;
    private readonly Func<CountryCrudPresenter> _countryCrudPresenterFactory;
    private readonly Func<BrandCrudPresenter> _brandCrudPresenterFactory;
    private readonly Func<AddProductPresenter> _addProductPresenterFactory;
    private readonly Func<WarehouseEditorPresenter> _warehouseEditorPresenterFactory;
    private readonly Func<UserCartPresenter> _userCartPresenterFactory;
    private readonly Func<AdminOrdersPresenter> _adminOrdersPresenterFactory;
    private readonly Func<ProductPresenter> _productPresenterFactory;
    private readonly Func<PurchasePresenter> _purchasePresenterFactory;
    private readonly Func<ProductStatisticsPresenter> _productStatisticFactory;

    public NavigationService(
        Func<LoginPresenter> loginPresenterFactory,
        Func<RegisterPresenter> registerPresenterFactory,
        Func<MainPresenter> mainPresenterFactory,
        Func<AuthorPresenter> authorPresenterFactory,
        Func<TypeCrudPresenter> typeCrudPresenterFactory,
        Func<CountryCrudPresenter> countryCrudPresenterFactory,
        Func<BrandCrudPresenter> brandCrudPresenterFactory,
        Func<AddProductPresenter> addProductPresenterFactory,
        Func<WarehouseEditorPresenter> warehouseEditorPresenterFactory,
        Func<UserCartPresenter> userCartPresenterFactory,
        Func<AdminOrdersPresenter> adminOrdersPresenterFactory,
        Func<ProductPresenter> productPresenterFactory,
        Func<PurchasePresenter> purchasePresenterFactory,
        Func<ProductStatisticsPresenter> productStatisticFactory)
    {
        _loginPresenterFactory = loginPresenterFactory;
        _registerPresenterFactory = registerPresenterFactory;
        _mainPresenterFactory = mainPresenterFactory;
        _authorPresenterFactory = authorPresenterFactory;
        _typeCrudPresenterFactory = typeCrudPresenterFactory;
        _countryCrudPresenterFactory = countryCrudPresenterFactory;
        _brandCrudPresenterFactory = brandCrudPresenterFactory;
        _addProductPresenterFactory = addProductPresenterFactory;
        _warehouseEditorPresenterFactory = warehouseEditorPresenterFactory;
        _userCartPresenterFactory = userCartPresenterFactory;
        _adminOrdersPresenterFactory = adminOrdersPresenterFactory;
        _productPresenterFactory = productPresenterFactory;
        _purchasePresenterFactory = purchasePresenterFactory;
        _productStatisticFactory = productStatisticFactory;
    }

    public ComplexModalResult<User> NavigateToLogin()
    {
        var presenter = _loginPresenterFactory();
        presenter.Run();
        
        return new ComplexModalResult<User>(
            presenter.View.ModalResult,
            presenter.View.ModalResultData);
    }

    public ModalResult NavigateToRegister(List<string> roles)
    {
        var presenter = _registerPresenterFactory();
        presenter.Run(roles);
        
        return presenter.View.ModalResult;
    }

    public ModalResult NavigateToAuthor()
    {
        var presenter = _authorPresenterFactory();
        presenter.Run();
        return presenter.View.ModalResult;
    }

    public ModalResult NavigateToTypeRedactor(User user)
    {
        var presenter = _typeCrudPresenterFactory();
        presenter.Run(user);
        return presenter.View.ModalResult;
    }

    public ModalResult NavigateToCountryRedactor(User user)
    {
        var presenter = _countryCrudPresenterFactory();
        presenter.Run(user);
        return presenter.View.ModalResult;
    }

    public ModalResult NavigateToBrandRedactor(User user)
    {
        var presenter = _brandCrudPresenterFactory();
        presenter.Run(user);
        return presenter.View.ModalResult;
    }

    public ModalResult NavigateToProductRedactor(User user)
    {
        var presenter = _addProductPresenterFactory();
        presenter.Run(user);
        return presenter.View.ModalResult;
    }

    public ModalResult NavigateToWarehouseRedactor(User user)
    {
        var presenter = _warehouseEditorPresenterFactory();
        presenter.Run(user);
        return presenter.View.ModalResult;
    }

    public ModalResult NavigateToUserCart(User user)
    {
        var presenter = _userCartPresenterFactory();
        presenter.Run(user);
        return presenter.View.ModalResult;
    }

    public ModalResult NavigateToAdminOrders(User user)
    {
        var presenter = _adminOrdersPresenterFactory();
        presenter.Run(user);
        return presenter.View.ModalResult;
    }

    public ModalResult NavigateToProductsForm(User user)
    {
        var presenter = _productPresenterFactory();
        presenter.Run(user);
        return presenter.View.ModalResult;
    }

    public ModalResult NavigateToPurchase((Product product, User user) arg)
    {
        var presenter = _purchasePresenterFactory();
        presenter.Run(new ValueTuple<Product, User>(arg.product, arg.user));
        return presenter.View.ModalResult;
    }

    public void NavigateToMain()
        => _mainPresenterFactory().Run();

    public ModalResult NavigateToStatisticForm(User user)
    {
        var presenter = _productStatisticFactory();
        presenter.Run(user);
        return presenter.View.ModalResult;
    }
}