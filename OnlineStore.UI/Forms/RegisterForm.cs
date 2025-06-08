using Presentation.Views;

namespace OnlineStore.UI.Forms;

public partial class RegisterForm : Form, IRegisterView
{
    private readonly ApplicationContext _context;
    
    public RegisterForm(ApplicationContext applicationContext)
    {
        InitializeComponent();
        _context = applicationContext;
    }
}