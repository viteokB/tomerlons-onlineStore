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

    public void NavigateToLogin() 
        => _loginPresenterFactory().Run();
    public void NavigateToRegister(List<string> roles)
        => _registerPresenterFactory().Run(roles);
    public void NavigateToMain()
        => _mainPresenterFactory().Run();
}