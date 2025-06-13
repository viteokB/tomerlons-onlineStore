using OnlineStore.Core.Models;
using Presentation.Common;

namespace Presentation.NavigationService;

public interface INavigationService
{
    ComplexModalResult<User> NavigateToLogin();
    ModalResult NavigateToRegister(List<string> roles);

    ModalResult NavigateToAuthor();
    
    ModalResult NavigateToTypeRedactor(User user);
    
    ModalResult NavigateToCountryRedactor(User user);
    
    void NavigateToMain();
}