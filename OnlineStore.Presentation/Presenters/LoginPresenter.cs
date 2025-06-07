using Microsoft.VisualBasic.CompilerServices;
using OnlineStore.Services.Login;
using Presentation.Common;
using Presentation.Views;

namespace Presentation.Presenters;

public class LoginPresenter : BasePresenter<ILoginView>
{
    private readonly IUserService _userService;
    private readonly IPresenterFactoryMethod<MainPresenter> _mainPresenterFactory;
    
    public LoginPresenter(ILoginView view, IUserService userService,
        IPresenterFactoryMethod<MainPresenter> mainPresenterFactory) : base(view)
    {
        _userService = userService;
        _mainPresenterFactory = mainPresenterFactory;

        view.LoginAsync += async () => await Login(view.Email, view.Password);
    }

    private async Task Login(string email, string password)
    {
        if(string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            _view.ShowError("Email and password обязательны");
        
        var user = await _userService.Login(email, password);
        
        if(!user.IsSuccess)
            _view.ShowError(user.Message!);
        else
        {
            _mainPresenterFactory.CreatePresenter()
                .Run();
        }
    }
}