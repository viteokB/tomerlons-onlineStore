using System.Globalization;
using OnlineStore.Core.Common.Pagination;
using OnlineStore.Core.Models;
using OnlineStore.UI.Forms.Common;
using Presentation.Views;
using Type = OnlineStore.Core.Models.Type;

namespace OnlineStore.UI.Forms;

public partial class ProductRedactorForm : BaseModalForm, IAddProductView
{
    private const int PageSize = 10;
    private bool _isLoadingData = false;

    public User? ChangedBy { get; set; }
    public Product? SelectedProduct { get; set; }
    public ProductsParamets? ProductsParamets { get; set; } = new ProductsParamets();
    
    // Реализация остальных свойств интерфейса
    public string Name
    {
        get => nameTextBox.Text;
        set => nameTextBox.Text = value;
    }
    
    public string? PhotoPath { get; set; }
    public string CatalogNumber
    {
        get => numberTextBox.Text;
        set => numberTextBox.Text = value;
    }
    
    public float BasePrice
    {
        get
        {
            if (float.TryParse(priceTextBox.Text, out float result))
            {
                return result;
            }
            else
            {
                ShowError("Введите цену в виде числа");
            }
            return 0f; // или другое значение по умолчанию при ошибке парсинга
        }
        set => priceTextBox.Text = value.ToString(CultureInfo.InvariantCulture);
    }

    public bool IsActive { get; set; }
    
    public Type? Type { get; set; }
    public Country? Country { get; set; }
    public Brand? Brand { get; set; }
    
    public Func<Task> CreateNewProduct { get; set; }
    public Func<Task> UpdateProduct { get; set; }
    public Func<Task> DisactivateProduct { get; set; }
    public Func<Task> DeleteProduct { get; set; }
    public Func<Task> SearchBrands { get; set; }
    public SearchRequest<string> SearchBrandRequest { get; set; }
    public PaginatedResult<Brand> PaginatedBrands { get; set; }
    public Func<Task> SearchCountry { get; set; }
    public SearchRequest<string> SearchCountriesRequest { get; set; }
    public PaginatedResult<Country> PaginatedCountries { get; set; }
    public Func<Task> SearchType { get; set; }
    public SearchRequest<string> SearchTypesRequest { get; set; }
    public PaginatedResult<Type> PaginatedTypes { get; set; }
    public Func<Task> SearchProduct { get; set; }
    public SearchRequest<ProductsParamets> SearchProductRequest { get; set; }
    public PaginatedResult<Product> PaginatedProducts { get; set; }

    public ProductRedactorForm()
    {
        InitializeComponent();
        
        // Настройка ComboBox'ов
        ConfigureComboBox(typeComboBox);
        ConfigureComboBox(countryComboBox);
        ConfigureComboBox(brandComboBox);
        ConfigureComboBox(productsComboBox);
        
        // Инициализация параметров поиска
        ProductsParamets = new ProductsParamets();
    }
    
    private void ConfigureComboBox(ComboBox comboBox)
    {
        comboBox.DropDownStyle = ComboBoxStyle.DropDown;
        comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        comboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
    }

    public void ShowError(string message)
    {
        MessageBox.Show(this, message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    public void ShowGoodInfo(string message)
    {
        MessageBox.Show(this, message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private async void searchButton_Click(object sender, EventArgs e)
    {
        // Обновляем параметры фильтрации перед поиском
        UpdateSearchParameters();
        await PerformProductSearch();
    }

    private void UpdateSearchParameters()
    {
        ProductsParamets.ProductType = Type;
        ProductsParamets.Brand = Brand;
        ProductsParamets.Country = Country;
        
        SearchProductRequest = new SearchRequest<ProductsParamets>(
            ProductsParamets, 
            PageSize, 
            0);
    }
    
    private async Task PerformProductSearch()
    {
        if (_isLoadingData) return;
        
        try
        {
            _isLoadingData = true;
            productsComboBox.Items.Clear();
            await SearchProduct.Invoke();
            PopulateProductsComboBox();
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

    private async void productsComboBox_DropDown(object sender, EventArgs e)
    {
        if (PaginatedProducts is { Pagination.HasMore: true } && !_isLoadingData)
        {
            try
            {
                _isLoadingData = true;
                SearchProductRequest = new SearchRequest<ProductsParamets>(
                    ProductsParamets, 
                    PageSize, 
                    PaginatedProducts.Pagination.NextOffset);
                await SearchProduct.Invoke();
                PopulateProductsComboBox();
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
    }
    
    private async void createButton_Click(object sender, EventArgs e)
    {
        await ExecuteOperation(() => CreateNewProduct.Invoke(), createBtn);
    }

    private async void updateButton_Click(object sender, EventArgs e)
    {
        await ExecuteOperation(() => UpdateProduct.Invoke(), updateBtn);
    }

    private async void disactivateButton_Click(object sender, EventArgs e)
    {
        await ExecuteOperation(() => DisactivateProduct.Invoke(), disactivateBtn);
    }

    private async void deleteButton_Click(object sender, EventArgs e)
    {
        await ExecuteOperation(() => DeleteProduct.Invoke(), deleteBtn);
    }

    private async void typeComboBox_TextChanged(object sender, EventArgs e)
    {
        await HandleComboBoxTextChanged(typeComboBox, SearchTypesRequest, SearchType, PopulateTypeComboBox);
    }

    private async void countryComboBox_TextChanged(object sender, EventArgs e)
    {
        await HandleComboBoxTextChanged(countryComboBox, SearchCountriesRequest, SearchCountry, PopulateCountryComboBox);
    }

    private async void brandComboBox_TextChanged(object sender, EventArgs e)
    {
        await HandleComboBoxTextChanged(brandComboBox, SearchBrandRequest, SearchBrands, PopulateBrandComboBox);
    }

    private async void productsComboBox_TextChanged(object sender, EventArgs e)
    {
        await Task.Delay(300);
        
        if (productsComboBox.Text != SearchProductRequest?.Query.ToString())
        {
            UpdateSearchParameters();
            await PerformProductSearch();
        }
    }

    private async Task HandleComboBoxTextChanged(
        ComboBox comboBox,
        SearchRequest<string> searchRequest,
        Func<Task> searchAction,
        Action populateAction)
    {
        await Task.Delay(300);
        
        if (comboBox.Text != searchRequest?.Query)
        {
            await PerformSearch(comboBox, searchRequest, searchAction, populateAction);
        }
    }

    private async Task PerformSearch(
        ComboBox comboBox,
        SearchRequest<string> searchRequest,
        Func<Task> searchAction,
        Action populateAction)
    {
        if (_isLoadingData) return;
        
        try
        {
            _isLoadingData = true;
            comboBox.Items.Clear();
            searchRequest = new SearchRequest<string>(comboBox.Text, PageSize, 0);
            await searchAction.Invoke();
            populateAction();
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

    private void PopulateTypeComboBox()
    {
        if (PaginatedTypes?.Results != null)
        {
            foreach (var type in PaginatedTypes.Results)
            {
                typeComboBox.Items.Add(type);
            }
            typeComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
    }

    private void PopulateCountryComboBox()
    {
        if (PaginatedCountries?.Results != null)
        {
            foreach (var country in PaginatedCountries.Results)
            {
                countryComboBox.Items.Add(country);
            }
            countryComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
    }

    private void PopulateBrandComboBox()
    {
        if (PaginatedBrands?.Results != null)
        {
            foreach (var brand in PaginatedBrands.Results)
            {
                brandComboBox.Items.Add(brand);
            }
            brandComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
    }

    private void PopulateProductsComboBox()
    {
        if (PaginatedProducts?.Results != null)
        {
            foreach (var product in PaginatedProducts.Results)
            {
                productsComboBox.Items.Add(product);
            }
            productsComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
    }

    private async void typeComboBox_DropDown(object sender, EventArgs e)
    {
        await HandleComboBoxDropDown(typeComboBox, PaginatedTypes, SearchTypesRequest, SearchType, PopulateTypeComboBox);
    }

    private async void countryComboBox_DropDown(object sender, EventArgs e)
    {
        await HandleComboBoxDropDown(countryComboBox, PaginatedCountries, SearchCountriesRequest, SearchCountry, PopulateCountryComboBox);
    }

    private async void brandComboBox_DropDown(object sender, EventArgs e)
    {
        await HandleComboBoxDropDown(brandComboBox, PaginatedBrands, SearchBrandRequest, SearchBrands, PopulateBrandComboBox);
    }

    private async Task HandleComboBoxDropDown<T>(
        ComboBox comboBox,
        PaginatedResult<T> paginatedResult,
        SearchRequest<string> searchRequest,
        Func<Task> searchAction,
        Action populateAction)
    {
        if (paginatedResult is { Pagination.HasMore: true } && !_isLoadingData)
        {
            try
            {
                _isLoadingData = true;
                searchRequest = new SearchRequest<string>(
                    searchRequest.Query, PageSize, paginatedResult.Pagination.NextOffset);
                await searchAction.Invoke();
                populateAction();
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
    }

    private void productsComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        SelectedProduct = productsComboBox.SelectedItem as Product;
        
        if (SelectedProduct != null)
        {
            Name = SelectedProduct.Name;
            Type = SelectedProduct.Type;
            Brand = SelectedProduct.Brand;
            Country = SelectedProduct.Country;
            PhotoPath = SelectedProduct.PhotoPath;
            CatalogNumber = SelectedProduct.CatalogNumber;
            BasePrice = SelectedProduct.BasePrice;
            IsActive = SelectedProduct.IsActive;
            
            // Обновляем параметры фильтрации
            ProductsParamets!.ProductType = Type;
            ProductsParamets!.Brand = Brand;
            ProductsParamets!.Country = Country;
        }
        else
        {
            ClearForm();
        }
    }

    private void browsePhotoButton_Click(object sender, EventArgs e)
    {
        using var openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = @"Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
        
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            PhotoPath = openFileDialog.FileName;
            photoPathTextBox.Text = PhotoPath;
        }
    }

    private async Task ExecuteOperation(Func<Task> operation, Control button)
    {
        try
        {
            button.Enabled = false;
            await operation.Invoke();
        }
        catch (Exception ex)
        {
            ShowError(ex.Message);
        }
        finally
        {
            button.Enabled = true;
        }
    }
    
    private void ClearForm()
    {
        Name = string.Empty;
        CatalogNumber = string.Empty;
        BasePrice = 0;
        PhotoPath = null;
        Type = null;
        Brand = null;
        Country = null;
        IsActive = true;
        SelectedProduct = null;
        ProductsParamets = new ProductsParamets();
    }
}