using OnlineStore.Core.Models;
using OnlineStore.UI.Forms.Common;
using Presentation.Views;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using OnlineStore.Core.Models.WhareHouse;

namespace OnlineStore.UI.Forms
{
    public partial class PurchaseForm : BaseModalForm, IPurchaseView
    {
        public Product SelectedProduct { get; set; }
        public User CurrentUser { get; set; }
        public int Quantity => (int)numQuantity.Value;
        public int SelectedWarehouseId => (int)cmbWarehouse.SelectedValue;
        public int AvailableQuantity { get; set; }
        public Address DeliveryAddress => new Address
        {
            Country = txtCountry.Text,
            City = txtCity.Text,
            Street = txtStreet.Text,
            HouseNumber = txtBuilding.Text,
            ApartmentNumber = txtApartment.Text,
        };
        public string Description => txtDescription.Text;

        public event Func<Task> PurchaseConfirmed;
        public event Func<Task> LoadWarehouses;
        public event Action<int> WarehouseSelected;

        public PurchaseForm()
        {
            InitializeComponent();
            InitializeEvents();
            InitializeControls();
        }

        private void InitializeEvents()
        {
            btnConfirm.Click += async (sender, e) => await PurchaseConfirmed?.Invoke();
            btnCancel.Click += (sender, e) => Close();
            this.Load += async (sender, e) => await LoadWarehouses?.Invoke();
            cmbWarehouse.SelectedIndexChanged += (s, e) =>
            {
                if (cmbWarehouse.SelectedValue != null)
                {
                    var selectedWh = cmbWarehouse.SelectedValue as Warehouse;
                    if (selectedWh != null)
                    {
                        WarehouseSelected?.Invoke(selectedWh.Id);
                    }
                    else if (cmbWarehouse.SelectedValue is int warehouseId)
                    {
                        WarehouseSelected?.Invoke(warehouseId);
                    }
                }
            };
        }

        private void InitializeControls()
        {
            numQuantity.Minimum = 1;
            numQuantity.Value = 1;
            lblAvailability.ForeColor = Color.Red;
        }

        public void ShowWarehouses(IEnumerable<Warehouse> warehouses)
        {
            cmbWarehouse.DataSource = warehouses;
            cmbWarehouse.DisplayMember = "Name";
            cmbWarehouse.ValueMember = "Id";
        }

        public void UpdateProductAvailabilityInfo()
        {
            if (AvailableQuantity <= 0)
            {
                lblAvailability.Text = "Товара нет в наличии";
                lblAvailability.ForeColor = Color.Red;
                btnConfirm.Enabled = false;
            }
            else
            {
                lblAvailability.Text = $"Доступно: {AvailableQuantity} шт.";
                lblAvailability.ForeColor = Color.Green;
                btnConfirm.Enabled = true;
                numQuantity.Maximum = AvailableQuantity;
            }
        }

        public void ShowError(string message)
        {
            MessageBox.Show(this, message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void ShowSuccess(string message)
        {
            MessageBox.Show(this, message, "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            lblProductName.Text = SelectedProduct?.Name ?? "Неизвестный продукт";
            lblPrice.Text = SelectedProduct?.BasePrice.ToString("C") ?? "0";
        }
    }
}