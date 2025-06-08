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
        _navigationService = navigationService;
        _userService = userService;
        SubscribeToViewEvents();
    }
    
    private void SubscribeToViewEvents()
    {
        View.OpenModalLoginDialog += OnOpenModalLoginDialog;
        View.OpenModalRegisterDialog += OnOpenModalRegisterDialog;
    }

    private void OnOpenModalLoginDialog()
    {
        var result = _navigationService.NavigateToLogin();
        
        if (result == ModalResult.Ok)
        {
            View.ShowMessage("Вход выполнен успешно!");
        }
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
}