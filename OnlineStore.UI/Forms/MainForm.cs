using Presentation.Views;

namespace OnlineStore.UI.Forms;

public partial class MainForm : Form, IMainView
{
    private readonly ApplicationContext _applicationContext;
    
    public MainForm(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
        InitializeComponent();
    }

    public new void Show()
    {
        _applicationContext.MainForm = this;
        Application.Run(_applicationContext);
    }

    public event Action? OpenModalLoginDialog;
    public event Action? OpenModalRegisterDialog;
    public void ShowError(string message)
    {
        throw new NotImplementedException();
    }

    public void ShowMessage(string message)
    {
        throw new NotImplementedException();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        OpenModalLoginDialog?.Invoke();
    }

    private void button2_Click(object sender, EventArgs e)
    {
        OpenModalRegisterDialog?.Invoke();
    }
}