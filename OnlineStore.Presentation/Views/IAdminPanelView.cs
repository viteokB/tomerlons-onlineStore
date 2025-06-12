namespace Presentation.Views;

public interface IAdminPanelView
{
    public event Func<Task> CreateNewUser;
    
    public event Func<Task> BanUser;
    
    public event Func<Task> DeleteUser;
    
    public event Func<Task> CreateNewProduct;
    
    public event Func<Task> UpdateProduct;
    
    public event Func<Task> DeleteProduct;
    
    public event Func<Task> OpenDashboard;
    
    public event Func<Task> UpdateWarehouse;
}