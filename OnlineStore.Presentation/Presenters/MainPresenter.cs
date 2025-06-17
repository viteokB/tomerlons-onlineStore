using OnlineStore.Core.Models;
using OnlineStore.Services.Login;
using Presentation.Common;
using Presentation.NavigationService;
using Presentation.Views;

namespace Presentation.Presenters;

public class MainPresenter : BasePresenter<IMainView>
{
    private readonly INavigationService _navigationService;
    private readonly IUserService _userService;

    public MainPresenter(IMainView view,
        INavigationService navigationService,
        IUserService userService) : base(view)
    {
        // Пока не вошли
        View.User = null;
        
        _navigationService = navigationService;
        _userService = userService;
        SubscribeToViewEvents();
    }
    
    private void SubscribeToViewEvents()
    {
        View.OpenModalLoginDialog += OnOpenModalLoginDialog;
        View.OpenModalRegisterDialog += OnOpenModalRegisterDialog;
        View.OpenModalAuthorDialog += OnOpenModalAuthorDialog;
        View.OpenTypesRedactorDialog += OnOpenTypesRedactorDialog;
        View.OpenCountryRedactorDialog += OnOpenCountryRedactorDialog;
        View.OpenBrandRedactorDialog += OnOpenBrandRedactorDialog;
        View.OpenProductRedactorDialog += OnOpenProductRedactorDialog;
        View.OpenWarehouseRedactorDialog += OnOpenWarehouseRedactorDialog;

        View.OpenUserCartDialog += OnOpenUserCartDialog;
        View.OpenAdminOrdersDialog += OnOpenAdminDialog;
        View.OpenProducts += OnOpenProducts;
        View.OpenStatistics += OnOpenStatistics;
    }

    private void OnOpenStatistics()
    {
        if (View.User != null)
        {
            _navigationService.NavigateToStatisticForm(View.User);
        }
        else
        {
            View.ShowMessage("Невозможно открыть дэшборд, вы не вошли");
        }
    }

    private void OnOpenProducts()
    {
        if (View.User != null)
        {
            _navigationService.NavigateToProductsForm(View.User);
        }
        else
        {
            View.ShowMessage("Невозможно открыть редактор, вы не вошли");
        }
    }

    private void OnOpenAdminDialog()
    {
        if (View.User == null)
        {
            View.ShowMessage("Невозможно открыть редактор, вы не вошли");
            return;
        }
        else if(!IsAdmin(View.User) || !IsAdmin(View.User))
        {
            View.ShowMessage("Невозможно открыть редактор, не достаточно прав");
            return;
        }

        var result = _navigationService.NavigateToAdminOrders(View.User);
    }

    private void OnOpenUserCartDialog()
    {
        if (View.User != null)
        {
            var result = _navigationService.NavigateToUserCart(View.User);
        }
        else
        {
            View.ShowMessage("Невозможно открыть редактор, вы не вошли");
        }
    } 

    private void OnOpenWarehouseRedactorDialog()
    {
        if (View.User != null)
        {
            var result = _navigationService.NavigateToWarehouseRedactor(View.User);
        }
        else
        {
            View.ShowMessage("Невозможно открыть редактор, вы не вошли");
        }
    }

    private void OnOpenProductRedactorDialog()
    {
        if (View.User != null)
        {
            var result = _navigationService.NavigateToProductRedactor(View.User);
        }
        else
        {
            View.ShowMessage("Невозможно открыть редактор, вы не вошли");
        }
    }

    private void OnOpenBrandRedactorDialog()
    {
        if (View.User != null)
        {
            var result = _navigationService.NavigateToBrandRedactor(View.User);
        }
        else
        {
            View.ShowMessage("Невозможно открыть редактор, вы не вошли");
        }
    }

    private void OnOpenCountryRedactorDialog()
    {
        if (View.User != null)
        {
            var result = _navigationService.NavigateToCountryRedactor(View.User);
        }
        else
        {
            View.ShowMessage("Невозможно открыть редактор, вы не вошли");
        }
    }

    private void OnOpenTypesRedactorDialog()
    {
        if (View.User != null)
        {
            var result = _navigationService.NavigateToTypeRedactor(View.User);
        }
        else
        {
            View.ShowMessage("Невозможно открыть редактор, вы не вошли");
        }
    }

    private void OnOpenModalLoginDialog()
    {
        var modalResult = _navigationService.NavigateToLogin();
        
        if (modalResult.ModalResult == ModalResult.Yes)
        {
            View.ShowMessage("Вход выполнен успешно!");
            View.User = modalResult.ModalResultData;
        }
        else
        {
            View.ShowMessage($"Вход выполнен не успешно! Результат = {modalResult.ModalResult.ToString()}");
        }
    }

    private void OnOpenModalAuthorDialog()
    {
        var result = _navigationService.NavigateToAuthor();
    }

    private async void OnOpenModalRegisterDialog()
    {
        var userRoles = await _userService.GetUserRoles();

        if (!userRoles.IsSuccess)
            throw new ApplicationException("Приложение не может получить список всех ролей пользователя");
        
        var result = _navigationService
            .NavigateToRegister(
                userRoles.Data
                    .Select(u => u.Name)
                    .ToList());
        
        if (result == ModalResult.Ok)
        {
            View.ShowMessage("Регистрация завершена успешно!");
        }
    }
    
    private bool IsAdmin(User user)
    {
        return user?.Role?.Name?.ToLower() == "админ";
    }

    private bool IsManager(User user)
    {
        return user?.Role?.Name?.ToLower() == "менеджер";
    }
}