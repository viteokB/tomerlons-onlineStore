using Presentation.Common;

namespace Presentation.Views;

public interface ILoginView : IView
{
    public string Email { get; set; }
    
    public string Password { get; set; }

    public event Action Login;
    
    void ShowError(string message);
}