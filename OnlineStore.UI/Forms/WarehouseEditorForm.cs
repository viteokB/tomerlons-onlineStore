using OnlineStore.Core.Common.Pagination;
using OnlineStore.Core.Models;
using OnlineStore.Core.Models.WhareHouse;
using OnlineStore.UI.Forms.Common;
using Presentation.Views;

namespace OnlineStore.UI.Forms;

public partial class WarehouseEditorForm : BaseModalForm, IWarehouseEditorView
{
    private const int PageSize = 10;
    private bool _isLoadingData;

    // Реализация интерфейса
    public User? CurrentUser { get; set; }
    public Warehouse? SelectedWarehouse { get; set; }
    public Product? SelectedProduct { get; set; }
    public int ProductCount
    {
        get => (int)productCountNumeric.Value;
        set => productCountNumeric.Value = value;
    }

    public PaginatedResult<Warehouse> PaginatedWarehouses { get; set; }
    public PaginatedResult<Product> PaginatedProducts { get; set; }

    public SearchRequest<string> WarehouseSearchRequest { get; set; }
    public SearchRequest<ProductsParamets> ProductSearchRequest { get; set; }

    public Func<Task> SearchWarehouses { get; set; }
    public Func<Task> SearchProducts { get; set; }
    public Func<Task> UpdateWarehouse { get; set; }
    public Func<Task> UpdateProductCount { get; set; }

    public WarehouseEditorForm()
    {
        InitializeComponent();
        InitializeDataGrids();
        SetupEventHandlers();
    }

    private void InitializeDataGrids()
    {
        // Настройка DataGridView для складов
        warehousesDataGridView.AutoGenerateColumns = false;
        warehousesDataGridView.Columns.AddRange(
            new DataGridViewTextBoxColumn { Name = "Id", DataPropertyName = "Id", HeaderText = "ID", Visible = false },
            new DataGridViewTextBoxColumn { Name = "Name", DataPropertyName = "Name", HeaderText = "Название" },
            new DataGridViewCheckBoxColumn { Name = "IsActive", DataPropertyName = "IsActive", HeaderText = "Активен" }
        );

        // Настройка DataGridView для продуктов
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
        updateWarehouseButton.Click += async (s, e) => await UpdateWarehouseHandler();
        updateProductCountButton.Click += async (s, e) => await UpdateProductCountHandler();
    }

    private async Task SearchWarehousesHandler()
    {
        if (_isLoadingData) return;
        
        try
        {
            _isLoadingData = true;
            WarehouseSearchRequest = new SearchRequest<string>(
                warehouseSearchTextBox.Text, 
                PageSize, 
                0);
            
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
            ProductSearchRequest = new SearchRequest<ProductsParamets>(
                new ProductsParamets { ProductName = productSearchTextBox.Text },
                PageSize,
                0);
            
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

    private void WarehousesDataGridView_SelectionChanged(object sender, EventArgs e)
    {
        if (warehousesDataGridView.SelectedRows.Count == 0) return;
        
        SelectedWarehouse = warehousesDataGridView.SelectedRows[0].DataBoundItem as Warehouse;
        ShowWarehouseDetails(SelectedWarehouse!);
    }

    private void ProductsDataGridView_SelectionChanged(object sender, EventArgs e)
    {
        if (productsDataGridView.SelectedRows.Count == 0) return;
        
        SelectedProduct = productsDataGridView.SelectedRows[0].DataBoundItem as Product;
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
            SelectedWarehouse.Name = warehouseNameTextBox.Text;
            SelectedWarehouse.IsActive = isActiveCheckBox.Checked;
            
            await UpdateWarehouse.Invoke();
            ShowSuccess("Склад успешно обновлен");
        }
        catch (Exception ex)
        {
            ShowError($"Ошибка обновления: {ex.Message}");
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

    // Реализация методов интерфейса
    public void ShowWarehouseDetails(Warehouse warehouse)
    {
        warehouseNameTextBox.Text = warehouse.Name;
        isActiveCheckBox.Checked = warehouse.IsActive;
        
        addressCountryLabel.Text = warehouse.Address.Country;
        addressCityLabel.Text = warehouse.Address.City;
        addressStreetLabel.Text = warehouse.Address.Street;
        addressHouseLabel.Text = warehouse.Address.HouseNumber;
    }

    public void ClearWarehouseDetails()
    {
        warehouseNameTextBox.Clear();
        isActiveCheckBox.Checked = false;
        
        addressCountryLabel.Text = string.Empty;
        addressCityLabel.Text = string.Empty;
        addressStreetLabel.Text = string.Empty;
        addressHouseLabel.Text = string.Empty;
    }

    public void ShowError(string message)
    {
        MessageBox.Show(this, message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    public void ShowSuccess(string message)
    {
        MessageBox.Show(this, message, "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}