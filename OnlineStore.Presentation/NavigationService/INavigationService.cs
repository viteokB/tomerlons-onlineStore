using Presentation.Common;

namespace Presentation.NavigationService;

public interface INavigationService
{
    ModalResult NavigateToLogin();
    ModalResult NavigateToRegister(List<string> roles);
    void NavigateToMain();
}