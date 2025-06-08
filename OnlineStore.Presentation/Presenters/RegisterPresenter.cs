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
        
        _view.IsValidRepeatedPassword += () => ValidateRepeatedPassword(_view.Password, _view.RepeatedPassword);
        _view.IsValidEmail += () => ValidateEmail(_view.Email);
        _view.IsValidRole += () => ValidateRole(_view.Role);
        _view.OpenLoginForm += OpenLoginForm;
        _view.RegisterAsync += async () => await RegisterAsync(_view.Role, _view.Email, _view.Password);
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
            _view.ShowError("Пароль и/или повторенный пароль не должны быть пустыми");
            return false;
        }
        else if (password != repeatedPassword)
        {
            _view.ShowError("Пароль и повторенный пароль должны быть равны");
            return false;
        }
        
        return true;
    }

    private bool ValidateEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            _view.ShowError("Email не может быть пустым");
            return false;
        }

        // Простое регулярное выражение для проверки email
        string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        bool isValid = Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase);
    
        if (!isValid)
        {
            _view.ShowError("Некорректный формат email");
        }
    
        return isValid;
    }

    private bool ValidateRole(string role)
    {
        if (string.IsNullOrEmpty(role))
        {
            _view.ShowError("Роль должна быть выбрана");
            return false;
        }

        return true;
    }

    private async Task RegisterAsync(string role, string email, string password)
    {
        var register = await _userService.Register(role, email, password);

        if (!register.IsSuccess)
        {
            _view.ShowError(register.Message!);
        }
        else
        {
            _view.ShowGoodInfo($"Регистрация пользователя '{email}' - выполнена успешно");
            OpenLoginForm();
        }
    }

    public override void Run(List<string> arg)
    {
        _view.UserRolesList = arg;
        _view.Show();
    }
}