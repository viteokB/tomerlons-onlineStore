using Presentation.Views;

namespace OnlineStore.UI.Forms;

public partial class LoginForm : Form, ILoginView
{
    private readonly ApplicationContext _context;
    
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

    public LoginForm(ApplicationContext applicationContext)
    {
        InitializeComponent();
        _context = applicationContext;
    }

    public new void Show()
    {
        _context.MainForm = this;
        Application.Run(_context);
    }

    public void ShowError(string message)
    {
        MessageBox.Show(this, message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
}