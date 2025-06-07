using OnlineStore.Services.Login;
using Presentation.Common;
using Presentation.Presenters;
using Presentation.Views;
using SQLitePCL;

namespace Presentation.PresenterFactoryMethods;

public class LoginPresenterFactoryMethod : IPresenterFactoryMethod<LoginPresenter>
{
    private readonly ILoginView _view;
    private readonly IUserService _service;
    private readonly IPresenterFactoryMethod<MainPresenter> _factoryMethod;

    public LoginPresenterFactoryMethod(ILoginView view, IUserService service,
        IPresenterFactoryMethod<MainPresenter> mainPresenterFactory)
    {
        _view = view;
        _service = service;
        _factoryMethod = mainPresenterFactory;
    }
    
    public LoginPresenter CreatePresenter()
    {
        return new LoginPresenter(_view, _service, _factoryMethod);
    }
}