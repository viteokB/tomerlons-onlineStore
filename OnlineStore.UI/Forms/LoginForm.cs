using OnlineStore.Core.Models;
using OnlineStore.UI.Forms.Common;
using Presentation.Common;
using Presentation.Views;

namespace OnlineStore.UI.Forms;

public partial class LoginForm : BaseModalForm<User>, ILoginView
{
    public string Email
    {
        get => emailTextBox.Text.Trim();
        set => emailTextBox.Text = value;
    }

    public string Password
    {
        get => passwordTextBox.Text;
        set => passwordTextBox.Text = value;
    }

    public event Func<Task> LoginAsync = null!;
    
    public event Action OpenRegisterForm;

    public LoginForm()
    {
        InitializeComponent();
    }

    public void ShowError(string message)
    {
        MessageBox.Show(this, message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    public void ShowInformation(string message)
    {
        MessageBox.Show(this, message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private async void LoginButton_Click(object sender, EventArgs e)
    {
        try
        {
            // Отключаем кнопку на время выполнения
            loginButton.Enabled = false;
                
            if (LoginAsync != null)
            {
                await LoginAsync.Invoke();
            }
        }
        catch (Exception ex)
        {
            ShowError($"Ошибка авторизации: {ex.Message}");
        }
        finally
        {
            // Включаем кнопку обратно
            loginButton.Enabled = true;
        }
    }

    private void registerOpenButton_Click(object sender, EventArgs e)
    {
        OpenRegisterForm.Invoke();
    }

    public ComplexModalResult<User> ModalResult { get; set; }
}