using OnlineStore.Core.Common.Pagination;
using OnlineStore.Core.Models;
using OnlineStore.UI.Forms.Common;
using Presentation.Views;

namespace OnlineStore.UI.Forms;

public partial class UserCartForm : BaseModalForm, IUserCartView
{
    public User CurrentUser { get; set; }
    public Order? SelectedOrder { get; set; }
    public PaginatedResult<Order> UserOrders { get; set; }
    public SearchRequest<OrderSearchParameters> SearchRequest { get; set; }
    
    public Func<Task> LoadOrders { get; set; }
    public Func<Task> CreateOrder { get; set; }
    public Func<Task> CancelOrder { get; set; }
    public Func<Task> ViewOrderDetails { get; set; }

    public UserCartForm()
    {
        InitializeComponent();
        ConfigureDataGridView();
        BindEvents();
    }

    private void ConfigureDataGridView()
    {
        ordersDataGridView.AutoGenerateColumns = false;
        ordersDataGridView.SelectionChanged += (s, e) => 
        {
            SelectedOrder = ordersDataGridView.CurrentRow?.DataBoundItem as Order;
        };
    }

    private void BindEvents()
    {
        btnLoad.Click += async (s, e) => await LoadOrders.Invoke();
        btnCreate.Click += async (s, e) => await CreateOrder.Invoke();
        btnCancel.Click += async (s, e) => await CancelOrder.Invoke();
        btnDetails.Click += async (s, e) => await ViewOrderDetails.Invoke();
    }

    public void ShowError(string message)
    {
        MessageBox.Show(this, message, @"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    public void ShowInfo(string message)
    {
        MessageBox.Show(this, message, @"Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void UserCartForm_Load(object sender, EventArgs e)
    {
        _ = LoadOrders.Invoke();
        BindOrdersData();
    }

    private void BindOrdersData()
    {
        if (UserOrders != null!)
        {
            ordersDataGridView.DataSource = UserOrders.Results;
            lblPageInfo.Text = @$"Показано {UserOrders.Results.Count} из {UserOrders.Pagination.TotalCount}";
        }
    }
}