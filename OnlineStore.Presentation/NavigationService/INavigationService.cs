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
    
    ModalResult NavigateToBrandRedactor(User user);
    
    ModalResult NavigateToProductRedactor(User user);
    
    ModalResult NavigateToWarehouseRedactor(User user);
    
    ModalResult NavigateToUserCart(User user);
    
    ModalResult NavigateToAdminOrders(User user);
    
    ModalResult NavigateToProductsForm(User user);
    
    ModalResult NavigateToPurchase((Product product, User user) arg);
    
    void NavigateToMain();
}