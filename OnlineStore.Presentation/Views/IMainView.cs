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
    
    public event Action  OpenBrandRedactorDialog;
    
    public event Action  OpenProductRedactorDialog;
    
    public event Action  OpenWarehouseRedactorDialog;
    
    public event Action  OpenUserCartDialog;
    
    public event Action  OpenAdminOrdersDialog;
    
    public event Action  OpenProducts;
    
    public event Action OpenStatistics;
    
    public User? User { get; set; }
    
    void ShowError(string message);
    
    void ShowMessage(string message);
}