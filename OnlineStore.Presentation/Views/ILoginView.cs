using System.ComponentModel.DataAnnotations;
using Presentation.Common;

namespace Presentation.Views;

public interface ILoginView : IView
{
    public string Email { get; set; }
    
    public string Password { get; set; }

    public event Func<Task> LoginAsync;

    public event Action  OpenRegisterForm;
    
    void ShowError(string message);
}