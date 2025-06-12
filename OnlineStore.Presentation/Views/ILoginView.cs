using System.ComponentModel.DataAnnotations;
using OnlineStore.Core.Models;
using Presentation.Common;

namespace Presentation.Views;

public interface ILoginView : IModalView<User>
{
    public string Email { get; set; }
    
    public string Password { get; set; }

    public event Func<Task> LoginAsync;

    public event Action  OpenRegisterForm;
    
    void ShowError(string message);
    
    void ShowInformation(string message);
}