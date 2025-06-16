using OnlineStore.Core.Common.Pagination;
using OnlineStore.Core.Models;
using OnlineStore.UI.Forms.Common;
using Presentation.Views;

namespace OnlineStore.UI.Forms;

public partial class AdminOrdersForm : BaseModalForm, IAdminOrdersView
{
    public User CurrentUser { get; set; }
    public Order? SelectedOrder { get; set; }
    public DeliveryStatus? SelectedStatus 
    { 
        get => cmbStatus.SelectedItem as DeliveryStatus;
        set => cmbStatus.SelectedItem = value;
    }
    public PaginatedResult<Order> Orders { get; set; }
    public SearchRequest<OrderSearchParameters> SearchRequest { get; set; }
    
    public List<DeliveryStatus> AllStatuses 
    { 
        get => statusBindingSource.DataSource as List<DeliveryStatus>;
        set 
        {
            statusBindingSource.DataSource = value;
            cmbStatus.DataSource = value;
            cmbStatus.DisplayMember = "Name";
            cmbStatus.ValueMember = "Id";
        }
    }
    
    public string StatusName
    {
        get => txtStatusName.Text;
        set => txtStatusName.Text = value;
    }
    
    public string StatusDescription
    {
        get => txtStatusDesc.Text;
        set => txtStatusDesc.Text = value;
    }
    
    public bool StatusIsActive
    {
        get => chkActive.Checked;
        set => chkActive.Checked = value;
    }
    
    public Func<Task> SearchOrders { get; set; }
    public Func<Task> UpdateOrderStatus { get; set; }
    public Func<Task> ViewOrderDetails { get; set; }
    
    public Func<Task> LoadStatuses { get; set; }
    public Func<Task> AddNewStatus { get; set; }
    public Func<Task> DeleteStatus { get; set; }

    public AdminOrdersForm()
    {
        InitializeComponent();
        ConfigureDataGridView();
        ConfigureStatusControls();
        BindEvents();
    }

    private void ConfigureStatusControls()
    {
        cmbStatus.DropDownStyle = ComboBoxStyle.DropDown;
        cmbStatus.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        cmbStatus.AutoCompleteSource = AutoCompleteSource.ListItems;
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
        // События для работы с заказами
        btnSearch.Click += async (s, e) => await SearchOrders.Invoke();
        btnUpdateStatus.Click += async (s, e) => await UpdateOrderStatus.Invoke();
        btnDetails.Click += async (s, e) => await ViewOrderDetails.Invoke();

        // События для работы со статусами
        btnLoadStatuses.Click += async (s, e) => await LoadStatuses.Invoke();
        btnAddStatus.Click += async (s, e) => await AddNewStatus.Invoke();
        btnDeleteStatus.Click += async (s, e) => await DeleteStatus.Invoke();
    }

    public void ShowError(string message)
    {
        MessageBox.Show(this, message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    public void ShowInfo(string message)
    {
        MessageBox.Show(this, message, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void AdminOrdersForm_Load(object sender, EventArgs e)
    {
        _ = Task.WhenAll(
            SearchOrders.Invoke(),
            LoadStatuses.Invoke()
        );
        BindData();
    }

    private void BindData()
    {
        if (Orders != null)
        {
            ordersDataGridView.DataSource = Orders.Results;
            lblPageInfo.Text = $"Показано {Orders.Results.Count} из {Orders.Pagination.TotalCount}";
        }

        if (AllStatuses != null)
        {
            cmbStatus.DataSource = AllStatuses;
            cmbStatus.DisplayMember = "Name";
            cmbStatus.ValueMember = "Id";
        }
    }
}