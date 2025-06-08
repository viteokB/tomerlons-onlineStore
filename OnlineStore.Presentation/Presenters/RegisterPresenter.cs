using Presentation.Common;
using Presentation.Views;

namespace Presentation.Presenters;

public class RegisterPresenter : BasePresenter<IRegisterView>
{
    public RegisterPresenter(IRegisterView view) : base(view)
    {
    }
}