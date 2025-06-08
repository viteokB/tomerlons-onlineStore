namespace Presentation.NavigationService;

public interface INavigationService
{
    void NavigateToLogin();
    void NavigateToRegister(List<string> roles);
    void NavigateToMain();
}