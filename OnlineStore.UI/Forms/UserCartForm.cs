using OnlineStore.Core.Common.Pagination;
using OnlineStore.Core.Models;
using OnlineStore.UI.Forms.Common;
using Presentation.Views;

namespace OnlineStore.UI.Forms
{
    public partial class UserCartForm : BaseModalForm, IUserCartView
    {
        public User CurrentUser { get; set; }
        public Order? SelectedOrder => dataGridView.CurrentRow?.DataBoundItem as Order;
        public PaginatedResult<Order> UserOrders { get; set; }
        
        public event Func<Task> LoadOrders;
        public event Func<Task> CancelOrder;

        public UserCartForm()
        {
            InitializeComponent();
            ConfigureDataGridView();
            InitializeControls();
        }

        private void ConfigureDataGridView()
        {
            dataGridView.AutoGenerateColumns = false;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            
            dataGridView.Columns.AddRange(
                new DataGridViewTextBoxColumn { 
                    Name = "Id", 
                    DataPropertyName = "Id", 
                    HeaderText = "ID", 
                    Width = 50 
                },
                new DataGridViewTextBoxColumn { 
                    Name = "ProductName", 
                    DataPropertyName = "Product", 
                    HeaderText = "Товар", 
                    Width = 150 
                },
                new DataGridViewTextBoxColumn { 
                    Name = "Count", 
                    DataPropertyName = "Count", 
                    HeaderText = "Кол-во", 
                    Width = 60 
                },
                new DataGridViewTextBoxColumn { 
                    Name = "Price", 
                    DataPropertyName = "ProductPrice", 
                    HeaderText = "Цена", 
                    Width = 80 
                },
                new DataGridViewTextBoxColumn { 
                    Name = "CreatedAt", 
                    DataPropertyName = "CreatedAt", 
                    HeaderText = "Дата", 
                    Width = 120 
                }
            );
        }

        private void InitializeControls()
        {
            btnRefresh.Click += async (s, e) => await LoadOrders?.Invoke();
            btnCancelOrder.Click += async (s, e) => await CancelOrder?.Invoke();
        }

        public void UpdateOrdersList()
        {
            dataGridView.DataSource = UserOrders?.Results;
            lblTotal.Text = $"Всего: {UserOrders?.Results.Count ?? 0}";
        }

        public void ShowError(string message)
        {
            MessageBox.Show(this, message, "Ошибка", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void ShowSuccess(string message)
        {
            MessageBox.Show(this, message, "Успех", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void UserCartForm_Load(object sender, EventArgs e)
        {
            _ = LoadOrders?.Invoke();
        }
    }
}