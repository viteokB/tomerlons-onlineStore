using Presentation.Common;
using Presentation.Presenters;

namespace Presentation.NavigationService;

public class NavigationService : INavigationService
{
    private readonly Func<LoginPresenter> _loginPresenterFactory;
    private readonly Func<RegisterPresenter> _registerPresenterFactory;
    private readonly Func<MainPresenter> _mainPresenterFactory;

    public NavigationService(
        Func<LoginPresenter> loginPresenterFactory,
        Func<RegisterPresenter> registerPresenterFactory,
        Func<MainPresenter> mainPresenterFactory)
    {
        _loginPresenterFactory = loginPresenterFactory;
        _registerPresenterFactory = registerPresenterFactory;
        _mainPresenterFactory = mainPresenterFactory;
    }

    public ModalResult NavigateToLogin()
    {
        var presenter = _loginPresenterFactory();
        presenter.Run();
        return presenter.View.ModalResult;
    }

    public ModalResult NavigateToRegister(List<string> roles)
    {
        var presenter = _registerPresenterFactory();
        presenter.Run(roles);
        return presenter.View.ModalResult;
    }
    
    public void NavigateToMain()
        => _mainPresenterFactory().Run();
}