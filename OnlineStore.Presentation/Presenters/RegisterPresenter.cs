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
        
        RedactorView.ModalResult = ModalResult.None;
        RedactorView.IsValidRepeatedPassword += () => ValidateRepeatedPassword(RedactorView.Password, RedactorView.RepeatedPassword);
        RedactorView.IsValidEmail += () => ValidateEmail(RedactorView.Email);
        RedactorView.IsValidRole += () => ValidateRole(RedactorView.Role);
        RedactorView.OpenLoginForm += OpenLoginForm;
        RedactorView.RegisterAsync += async () => await RegisterAsync(RedactorView.Role, RedactorView.Email, RedactorView.Password);
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
            RedactorView.ShowError("Пароль и/или повторенный пароль не должны быть пустыми");
            return false;
        }
        else if (password != repeatedPassword)
        {
            RedactorView.ShowError("Пароль и повторенный пароль должны быть равны");
            return false;
        }
        
        return true;
    }

    private bool ValidateEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            RedactorView.ShowError("Email не может быть пустым");
            return false;
        }

        // Простое регулярное выражение для проверки email
        string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        bool isValid = Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase);
    
        if (!isValid)
        {
            RedactorView.ShowError("Некорректный формат email");
        }
    
        return isValid;
    }

    private bool ValidateRole(string role)
    {
        if (string.IsNullOrEmpty(role) || !RedactorView.UserRolesList.Contains(role))
        {
            RedactorView.ShowError("Роль должна быть выбрана");
            return false;
        }

        return true;
    }

    private async Task RegisterAsync(string role, string email, string password)
    {
        var register = await _userService.Register(email, password, role);

        if (!register.IsSuccess)
        {
            RedactorView.ShowError(register.Message!);
        }
        else
        {
            RedactorView.ShowGoodInfo($"Регистрация пользователя '{email}' - выполнена успешно");
            RedactorView.ModalResult = ModalResult.Yes;
            RedactorView.Close();
        }
    }

    public override void Run(List<string> arg)
    {
        RedactorView.UserRolesList = arg;
        RedactorView.Show();
    }
}