using Presentation.Common;

namespace Presentation.Views;

public interface IRegisterView : IModalView
{
    public List<string> UserRolesList { get; set; }
    
    public string Role { get; }
    
    public string Email { get; set; }
    
    public string Password { get; set; }
    
    public string RepeatedPassword { get; set; }
    
    public event Func<bool> IsValidRepeatedPassword;
    
    public event Func<bool> IsValidEmail;
    
    public event Func<bool> IsValidRole;

    public event Action OpenLoginForm;
    
    public event Func<Task> RegisterAsync;
    
    void ShowError(string message);
    
    void ShowGoodInfo(string message);
}