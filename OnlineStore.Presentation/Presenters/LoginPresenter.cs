using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.VisualBasic.CompilerServices;
using OnlineStore.Core.Models;
using OnlineStore.Services.Login;
using Presentation.Common;
using Presentation.NavigationService;
using Presentation.Views;

namespace Presentation.Presenters;

public class LoginPresenter : BasePresenter<ILoginView>
{
    private readonly IUserService _userService;
    private readonly INavigationService _navigationService;
    
    public LoginPresenter(ILoginView view, IUserService userService,
        INavigationService navigationService) : base(view)
    {
        _userService = userService;
        _navigationService = navigationService;

        View.ModalResult = ModalResult.None;
        View.ModalResultData =  null!; // пока нет результата выполнения
        
        View.LoginAsync += async () => await Login(view.Email, view.Password);
        View.OpenRegisterForm += OpenRegisterForm;
    }

    private async Task Login(string email, string password)
    {
        if(string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            View.ShowError("Email and password обязательны");
        
        var user = await _userService.Login(email, password);

        if (!user.IsSuccess)
        {
            View.ShowError(user.Message!);
            View.SetModalResult(ModalResult.No);
        }
        else
        {
            View.ShowInformation("Авторизация успешна");
            View.SetModalResult(ModalResult.Yes);
            View.ModalResultData =  user.Data;
            View.Close();
        }
    }
    
    private async void OpenRegisterForm()
    {
        var userRoles = await _userService.GetUserRoles();

        if (!userRoles.IsSuccess)
            throw new ApplicationException("Приложение не может получить список всех ролей пользователя");
        
        _navigationService
            .NavigateToRegister(
                userRoles.Data
                .Select(u => u.Name)
                .ToList());
    }
}