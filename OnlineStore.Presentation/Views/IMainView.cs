using Presentation.Common;

namespace Presentation.Views;

public interface IMainView : IView
{
    public event Action  OpenModalLoginDialog;
    
    public event Action  OpenModalRegisterDialog;
    
    void ShowError(string message);
    
    void ShowMessage(string message);
}