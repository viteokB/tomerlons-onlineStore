using Presentation.Common;
using Presentation.Presenters;
using Presentation.Views;

namespace Presentation.PresenterFactoryMethods;

public class RegisterPresenterFactoryMethod : IPresenterFactoryMethod<RegisterPresenter>
{
    private readonly IRegisterView _registerView;

    public RegisterPresenterFactoryMethod(IRegisterView registerView)
    {
        this._registerView = registerView;
    }
    
    public RegisterPresenter CreatePresenter()
    {
        return new RegisterPresenter(_registerView);
    }
}