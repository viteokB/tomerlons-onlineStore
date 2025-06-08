using Presentation.Common;
using Presentation.Views;

namespace OnlineStore.UI.Forms;

public partial class RegisterForm : Form, IRegisterView
{
    #region Fields

    public List<string> UserRolesList
    {
        get => roleComboBox.Items.Cast<string>().ToList();
        set
        {
            roleComboBox.Items.Clear();
            if (value != null!)
            {
                roleComboBox.Items.AddRange(value.ToArray());
            }
        }
    }
    
    public string Role
    {
        get => roleComboBox.Text;
    }
    
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
    
    public string RepeatedPassword 
    {
        get => repeatPasswordTextBox.Text;
        set => repeatPasswordTextBox.Text = value;
    }
    
    public event Func<bool> IsValidRepeatedPassword = null!;
    public event Func<bool>? IsValidEmail;
    public event Func<bool>? IsValidRole;
    public event Action? OpenLoginForm;
    public event Func<Task>? RegisterAsync;
    
    #endregion

    public RegisterForm()
    {
        InitializeComponent();
    }
    
    public void ShowError(string message)
    {
        MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    public void ShowGoodInfo(string message)
    {
        MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private async void registerButton_Click(object sender, EventArgs e)
    {
        try
        {
            if (!IsValidRepeatedPassword() || !IsValidRole!() || !IsValidEmail!())
            {
                return;
            }
            registerButton.Enabled = false;

            if (RegisterAsync != null)
            {
                await RegisterAsync.Invoke();
            }
        }
        catch (Exception ex)
        {
            ShowError(ex.Message);
        }
        finally
        {
            registerButton.Enabled = true;
        }
    }

    private void goLoginButton_Click(object sender, EventArgs e)
    {
        OpenLoginForm?.Invoke();
    }

    public ModalResult ModalResult { get; set; }
}