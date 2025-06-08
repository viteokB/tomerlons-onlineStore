using System.Text.RegularExpressions;
using OnlineStore.Services.Login;
using Presentation.Common;
using Presentation.NavigationService;
using Presentation.Views;

namespace Presentation.Presenters;

public class RegisterPresenter : BasePresenter<IRegisterView, List<string>>
{
    private readonly IUserService _userService;
    private readonly INavigationService _navigationService;

    public RegisterPresenter(IRegisterView view,
        IUserService userService,
        INavigationService navigationService) : base(view)
    {
        _userService = userService;
        _navigationService = navigationService;
        
        View.ModalResult = ModalResult.None;
        View.IsValidRepeatedPassword += () => ValidateRepeatedPassword(View.Password, View.RepeatedPassword);
        View.IsValidEmail += () => ValidateEmail(View.Email);
        View.IsValidRole += () => ValidateRole(View.Role);
        View.OpenLoginForm += OpenLoginForm;
        View.RegisterAsync += async () => await RegisterAsync(View.Role, View.Email, View.Password);
    }
    
    private void OpenLoginForm()
    {
        _navigationService
            .NavigateToLogin();
    }

    private bool ValidateRepeatedPassword(string password, string repeatedPassword)
    {
        if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(repeatedPassword))
        {
            View.ShowError("Пароль и/или повторенный пароль не должны быть пустыми");
            return false;
        }
        else if (password != repeatedPassword)
        {
            View.ShowError("Пароль и повторенный пароль должны быть равны");
            return false;
        }
        
        return true;
    }

    private bool ValidateEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            View.ShowError("Email не может быть пустым");
            return false;
        }

        // Простое регулярное выражение для проверки email
        string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        bool isValid = Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase);
    
        if (!isValid)
        {
            View.ShowError("Некорректный формат email");
        }
    
        return isValid;
    }

    private bool ValidateRole(string role)
    {
        if (string.IsNullOrEmpty(role) || !View.UserRolesList.Contains(role))
        {
            View.ShowError("Роль должна быть выбрана");
            return false;
        }

        return true;
    }

    private async Task RegisterAsync(string role, string email, string password)
    {
        var register = await _userService.Register(email, password, role);

        if (!register.IsSuccess)
        {
            View.ShowError(register.Message!);
        }
        else
        {
            View.ShowGoodInfo($"Регистрация пользователя '{email}' - выполнена успешно");
            View.ModalResult = ModalResult.Yes;
            View.Close();
        }
    }

    public override void Run(List<string> arg)
    {
        View.UserRolesList = arg;
        View.Show();
    }
}