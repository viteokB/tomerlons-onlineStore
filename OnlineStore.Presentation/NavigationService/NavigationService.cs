using OnlineStore.Core.Models;
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

    public NavigationService(
        Func<LoginPresenter> loginPresenterFactory,
        Func<RegisterPresenter> registerPresenterFactory,
        Func<MainPresenter> mainPresenterFactory,
        Func<AuthorPresenter> authorPresenterFactory,
        Func<TypeCrudPresenter> typeCrudPresenterFactory,
        Func<CountryCrudPresenter> countryCrudPresenterFactory,
        Func<BrandCrudPresenter> brandCrudPresenterFactory,
        Func<AddProductPresenter> addProductPresenterFactory)
    {
        _loginPresenterFactory = loginPresenterFactory;
        _registerPresenterFactory = registerPresenterFactory;
        _mainPresenterFactory = mainPresenterFactory;
        _authorPresenterFactory = authorPresenterFactory;
        _typeCrudPresenterFactory = typeCrudPresenterFactory;
        _countryCrudPresenterFactory = countryCrudPresenterFactory;
        _brandCrudPresenterFactory = brandCrudPresenterFactory;
        _addProductPresenterFactory = addProductPresenterFactory;
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

    public void NavigateToMain()
        => _mainPresenterFactory().Run();
}