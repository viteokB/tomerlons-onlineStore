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
    }

    private void OnOpenTypesRedactorDialog()
    {
        if (View.User != null)
        {
            var result = _navigationService.NavigateToTypeRedactor(View.User);
            View.ShowMessage(result.ToString());
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
}