using OnlineStore.Core;
using OnlineStore.Core.Models;
using Presentation.Common;

namespace Presentation.Views;

public interface IMainView : IView
{
    public event Action  OpenModalLoginDialog;
    
    public event Action  OpenModalRegisterDialog;
    
    public event Action  OpenModalAuthorDialog;
    
    public event Action  OpenTypesRedactorDialog;
    
    public event Action  OpenCountryRedactorDialog;
    
    public User? User { get; set; }
    
    void ShowError(string message);
    
    void ShowMessage(string message);
}