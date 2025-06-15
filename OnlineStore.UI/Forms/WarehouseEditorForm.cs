using OnlineStore.Core.Common.Pagination;
using OnlineStore.Core.Models;
using OnlineStore.Core.Models.WhareHouse;
using OnlineStore.UI.Forms.Common;
using Presentation.Views;
using System;
using System.Windows.Forms;

namespace OnlineStore.UI.Forms
{
    public partial class WarehouseEditorForm : BaseModalForm, IWarehouseEditorView
    {
        private const int PageSize = 10;
        private bool _isLoadingData;

        public User? CurrentUser { get; set; }
        public Warehouse? SelectedWarehouse { get; set; }
        public Product? SelectedProduct { get; set; }
        public int ProductCount
        {
            get => (int)productCountNumeric.Value;
            set => productCountNumeric.Value = value;
        }

        public string WarehouseName
        {
            get => warehouseNameTextBox.Text;
            set => warehouseNameTextBox.Text = value;
        }

        public bool IsActive
        {
            get => isActiveCheckBox.Checked;
            set => isActiveCheckBox.Checked = value;
        }

        public Address CurrentAddress { get; set; } = new Address();

        public PaginatedResult<Warehouse> PaginatedWarehouses { get; set; }
        public PaginatedResult<Product> PaginatedProducts { get; set; }

        public Func<Task> SearchWarehouses { get; set; }
        public Func<Task> SearchProducts { get; set; }
        public Func<Task> AddNewWarehouse { get; set; }
        public Func<Task> DeleteWarehouse { get; set; }
        public Func<Task> UpdateWarehouse { get; set; }
        public Func<Task> UpdateProductCount { get; set; }
        
        public event Action? OnWarehouseSelected;
        
        public event Action? OnProductSelected;

        public WarehouseEditorForm()
        {
            InitializeComponent();
            InitializeDataGrids();
            SetupEventHandlers();
            InitializeControls();
        }

        private void InitializeDataGrids()
        {
            warehousesDataGridView.AutoGenerateColumns = false;
            warehousesDataGridView.Columns.AddRange(
                new DataGridViewTextBoxColumn { Name = "Id", DataPropertyName = "Id", HeaderText = "ID", Visible = false },
                new DataGridViewTextBoxColumn { Name = "Name", DataPropertyName = "Name", HeaderText = "Название" },
                new DataGridViewCheckBoxColumn { Name = "IsActive", DataPropertyName = "IsActive", HeaderText = "Активен" }
            );

            productsDataGridView.AutoGenerateColumns = false;
            productsDataGridView.Columns.AddRange(
                new DataGridViewTextBoxColumn { Name = "Id", DataPropertyName = "Id", HeaderText = "ID", Visible = false },
                new DataGridViewTextBoxColumn { Name = "Name", DataPropertyName = "Name", HeaderText = "Название" },
                new DataGridViewTextBoxColumn { Name = "CatalogNumber", DataPropertyName = "CatalogNumber", HeaderText = "Артикул" }
            );
        }

        private void SetupEventHandlers()
        {
            warehouseSearchButton.Click += async (s, e) => await SearchWarehousesHandler();
            productSearchButton.Click += async (s, e) => await SearchProductsHandler();
            warehousesDataGridView.SelectionChanged += WarehousesDataGridView_SelectionChanged;
            productsDataGridView.SelectionChanged += ProductsDataGridView_SelectionChanged;
            btnAddWarehouse.Click += async (s, e) => await AddNewWarehouseHandler();
            btnDeleteWarehouse.Click += async (s, e) => await DeleteWarehouseHandler();
            btnUpdateWarehouse.Click += async (s, e) => await UpdateWarehouseHandler();
            updateProductCountButton.Click += async (s, e) => await UpdateProductCountHandler();
        }

        private void InitializeControls()
        {
            // Все поля всегда доступны для редактирования
            warehouseNameTextBox.ReadOnly = false;
            isActiveCheckBox.Enabled = true;
            countryTextBox.ReadOnly = false;
            cityTextBox.ReadOnly = false;
            streetTextBox.ReadOnly = false;
            houseNumberTextBox.ReadOnly = false;
            apartmentTextBox.ReadOnly = false;
            coordinateLatitudeNumeric.Enabled = true;
            coordinateLongitudeNumeric.Enabled = true;
            productCountNumeric.Enabled = true;
        }

        private async Task SearchWarehousesHandler()
        {
            if (_isLoadingData) return;

            try
            {
                _isLoadingData = true;
                await SearchWarehouses.Invoke();
                warehousesDataGridView.DataSource = PaginatedWarehouses?.Results;
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
            finally
            {
                _isLoadingData = false;
            }
        }

        private async Task SearchProductsHandler()
        {
            if (_isLoadingData) return;

            try
            {
                _isLoadingData = true;
                await SearchProducts.Invoke();
                productsDataGridView.DataSource = PaginatedProducts?.Results;
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
            finally
            {
                _isLoadingData = false;
            }
        }

        private async Task AddNewWarehouseHandler()
        {
            try
            {
                CurrentAddress = new Address
                {
                    Country = countryTextBox.Text,
                    City = cityTextBox.Text,
                    Street = streetTextBox.Text,
                    HouseNumber = houseNumberTextBox.Text,
                    ApartmentNumber = apartmentTextBox.Text,
                    Coordinate = new Coordinate(
                        (double)coordinateLatitudeNumeric.Value,
                        (double)coordinateLongitudeNumeric.Value)
                };

                await AddNewWarehouse.Invoke();
                await SearchWarehousesHandler();
                ClearWarehouseDetails();
            }
            catch (Exception ex)
            {
                ShowError($"Ошибка при добавлении склада: {ex.Message}");
            }
        }

        private async Task UpdateWarehouseHandler()
        {
            if (SelectedWarehouse == null)
            {
                ShowError("Выберите склад для редактирования");
                return;
            }

            try
            {
                SelectedWarehouse.Name = WarehouseName;
                SelectedWarehouse.IsActive = IsActive;
                SelectedWarehouse.Address = new Address
                {
                    Id = SelectedWarehouse.Address?.Id ?? 0,
                    Country = countryTextBox.Text,
                    City = cityTextBox.Text,
                    Street = streetTextBox.Text,
                    HouseNumber = houseNumberTextBox.Text,
                    ApartmentNumber = apartmentTextBox.Text,
                    Coordinate = new Coordinate(
                        (double)coordinateLatitudeNumeric.Value,
                        (double)coordinateLongitudeNumeric.Value)
                };

                await UpdateWarehouse.Invoke();
                ShowSuccess("Склад успешно обновлен");
                await SearchWarehousesHandler();
            }
            catch (Exception ex)
            {
                ShowError($"Ошибка обновления: {ex.Message}");
            }
        }

        private async Task DeleteWarehouseHandler()
        {
            if (SelectedWarehouse == null)
            {
                ShowError("Выберите склад для удаления");
                return;
            }

            if (MessageBox.Show("Вы уверены, что хотите удалить выбранный склад?",
                "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    await DeleteWarehouse.Invoke();
                    await SearchWarehousesHandler();
                    ClearWarehouseDetails();
                }
                catch (Exception ex)
                {
                    ShowError($"Ошибка при удалении склада: {ex.Message}");
                }
            }
        }

        private async Task UpdateProductCountHandler()
        {
            if (SelectedWarehouse == null || SelectedProduct == null)
            {
                ShowError("Выберите склад и продукт");
                return;
            }

            try
            {
                await UpdateProductCount.Invoke();
                ShowSuccess($"Количество продукта обновлено: {ProductCount}");
            }
            catch (Exception ex)
            {
                ShowError($"Ошибка обновления количества: {ex.Message}");
            }
        }

        public void ShowWarehouseDetails(Warehouse warehouse)
        {
            WarehouseName = warehouse.Name;
            IsActive = warehouse.IsActive;

            if (warehouse.Address != null)
            {
                countryTextBox.Text = warehouse.Address.Country;
                cityTextBox.Text = warehouse.Address.City;
                streetTextBox.Text = warehouse.Address.Street;
                houseNumberTextBox.Text = warehouse.Address.HouseNumber;
                apartmentTextBox.Text = warehouse.Address.ApartmentNumber;
                coordinateLatitudeNumeric.Value = Convert.ToDecimal(warehouse.Address.Coordinate.Latitude);
                coordinateLongitudeNumeric.Value = Convert.ToDecimal(warehouse.Address.Coordinate.Longitude);
            }
        }

        public void ClearWarehouseDetails()
        {
            WarehouseName = string.Empty;
            IsActive = false;
            countryTextBox.Text = string.Empty;
            cityTextBox.Text = string.Empty;
            streetTextBox.Text = string.Empty;
            houseNumberTextBox.Text = string.Empty;
            apartmentTextBox.Text = string.Empty;
            coordinateLatitudeNumeric.Value = 0;
            coordinateLongitudeNumeric.Value = 0;
            productsDataGridView.DataSource = null;
            ProductCount = 0;
            SelectedWarehouse = null;
            SelectedProduct = null;
        }

        public void ShowError(string message)
        {
            MessageBox.Show(this, message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void ShowSuccess(string message)
        {
            MessageBox.Show(this, message, "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void SetProductCount(int count)
        {
            if (count < 0) count = 0;
            productCountNumeric.Value = count;
        }

        private void WarehousesDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (warehousesDataGridView.SelectedRows.Count == 0) return;

            SelectedWarehouse = warehousesDataGridView.SelectedRows[0].DataBoundItem as Warehouse;
            ShowWarehouseDetails(SelectedWarehouse!);
            OnWarehouseSelected?.Invoke();
        }

        private void ProductsDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (productsDataGridView.SelectedRows.Count == 0) return;

            SelectedProduct = productsDataGridView.SelectedRows[0].DataBoundItem as Product;
            OnProductSelected?.Invoke();
        }
    }
}