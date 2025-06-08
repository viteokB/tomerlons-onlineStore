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
    private readonly IPresenterFactoryMethod<RegisterPresenter> _registerPresenterFactory;

    public LoginPresenterFactoryMethod(ILoginView view, IUserService service,
        IPresenterFactoryMethod<MainPresenter> mainPresenterFactory,
        IPresenterFactoryMethod<RegisterPresenter> registerPresenterFactory)
    {
        _view = view;
        _service = service;
        _factoryMethod = mainPresenterFactory;
        _registerPresenterFactory = registerPresenterFactory;
    }
    
    public LoginPresenter CreatePresenter()
    {
        return new LoginPresenter(_view, _service, _factoryMethod, 
            _registerPresenterFactory);
    }
}