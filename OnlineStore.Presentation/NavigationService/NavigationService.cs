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

    public NavigationService(
        Func<LoginPresenter> loginPresenterFactory,
        Func<RegisterPresenter> registerPresenterFactory,
        Func<MainPresenter> mainPresenterFactory,
        Func<AuthorPresenter> authorPresenterFactory,
        Func<TypeCrudPresenter> typeCrudPresenterFactory)
    {
        _loginPresenterFactory = loginPresenterFactory;
        _registerPresenterFactory = registerPresenterFactory;
        _mainPresenterFactory = mainPresenterFactory;
        _authorPresenterFactory = authorPresenterFactory;
        _typeCrudPresenterFactory = typeCrudPresenterFactory;
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

    public void NavigateToMain()
        => _mainPresenterFactory().Run();
}