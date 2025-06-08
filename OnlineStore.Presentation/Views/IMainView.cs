using OnlineStore.Core;
using Presentation.Common;

namespace Presentation.Views;

public interface IMainView : IView
{
    public event Action  OpenModalLoginDialog;
    
    public event Action  OpenModalRegisterDialog;
    
    public User User { get; set; }
    
    void ShowError(string message);
    
    void ShowMessage(string message);
}