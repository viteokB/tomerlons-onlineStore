using OnlineStore.Core.Common.Pagination;
using OnlineStore.Core.Models;
using Presentation.Views;
using Type = OnlineStore.Core.Models.Type;

namespace OnlineStore.UI.Forms
{
    public partial class ProductForm : Form, IProductView
    {
        private const int PageSize = 15;
        
        public ProductsParamets SearchParameters { get; set; } = new ProductsParamets();
        public PaginatedResult<Product> PaginatedProducts { get; set; }
        public PaginatedResult<Type> PaginatedTypes { get; set; }
        public PaginatedResult<Brand> PaginatedBrands { get; set; }
        public PaginatedResult<Country> PaginatedCountries { get; set; }
        
        // Selected items
        public Type? SelectedType
        {
            get => cmbType.SelectedItem as Type;
            set => cmbType.SelectedItem = value;
        }
        
        public Brand? SelectedBrand
        {
            get => cmbBrand.SelectedItem as Brand;
            set => cmbBrand.SelectedItem = value;
        }
        
        public Country? SelectedCountry
        {
            get => cmbCountry.SelectedItem as Country;
            set => cmbCountry.SelectedItem = value;
        }
        
        public SearchRequest<string> SearchTypesRequest { get; set; }
        public SearchRequest<string> SearchBrandsRequest { get; set; }
        public SearchRequest<string> SearchCountriesRequest { get; set; }
        
        public Product? SelectedProduct => dataGridView.SelectedRows.Count > 0 
            ? dataGridView.SelectedRows[0].DataBoundItem as Product 
            : null;
            
        public User? CurrentUser { get; set; }
        
        public event Func<Task> SearchProducts;
        public event Func<Task> SearchTypes;
        public event Func<Task> SearchBrands;
        public event Func<Task> SearchCountries;
        public event Func<Task> PurchaseProduct;
        public event Func<Task> NextPage;
        public event Func<Task> PrevPage;
        
        // ComboBox events
        public event EventHandler TypeSelectedIndexChanged;
        public event EventHandler BrandSelectedIndexChanged;
        public event EventHandler CountrySelectedIndexChanged;
        
        public ProductForm()
        {
            InitializeComponent();
            ConfigureDataGridView();
            InitializeControls();
            ConfigureComboBoxes();
        }
        
        private void InitializeControls()
        {
            btnSearch.Click += async (sender, e) => await SearchProducts?.Invoke();
            btnPrevPage.Click += async (sender, e) => await PrevPage?.Invoke();
            btnNextPage.Click += async (sender, e) => await NextPage?.Invoke();
            
            // Обработка изменения текста в поисковой строке
            txtSearch.TextChanged += async (sender, e) => 
            {
                await Task.Delay(500); // Задержка для избежания частых запросов при печати
                UpdateSearchParameters();
                await SearchProducts?.Invoke();
            };
            
            cmbType.DropDown += async (sender, e) => await HandleComboBoxDropDown(cmbType, PaginatedTypes, SearchTypesRequest, SearchTypes);
            cmbBrand.DropDown += async (sender, e) => await HandleComboBoxDropDown(cmbBrand, PaginatedBrands, SearchBrandsRequest, SearchBrands);
            cmbCountry.DropDown += async (sender, e) => await HandleComboBoxDropDown(cmbCountry, PaginatedCountries, SearchCountriesRequest, SearchCountries);
            
            cmbType.TextChanged += async (sender, e) => 
            {
                if (string.IsNullOrWhiteSpace(cmbType.Text))
                {
                    SelectedType = null;
                    UpdateSearchParameters();
                    await SearchProducts?.Invoke();
                }
                await HandleComboBoxTextChanged(cmbType, SearchTypesRequest, SearchTypes);
            };
            
            cmbBrand.TextChanged += async (sender, e) => 
            {
                if (string.IsNullOrWhiteSpace(cmbBrand.Text))
                {
                    SelectedBrand = null;
                    UpdateSearchParameters();
                    await SearchProducts?.Invoke();
                }
                await HandleComboBoxTextChanged(cmbBrand, SearchBrandsRequest, SearchBrands);
            };
            
            cmbCountry.TextChanged += async (sender, e) => 
            {
                if (string.IsNullOrWhiteSpace(cmbCountry.Text))
                {
                    SelectedCountry = null;
                    UpdateSearchParameters();
                    await SearchProducts?.Invoke();
                }
                await HandleComboBoxTextChanged(cmbCountry, SearchCountriesRequest, SearchCountries);
            };
            
            // Подписка на события изменения выбранного элемента
            cmbType.SelectedIndexChanged += (sender, e) => TypeSelectedIndexChanged?.Invoke(sender, e);
            cmbBrand.SelectedIndexChanged += (sender, e) => BrandSelectedIndexChanged?.Invoke(sender, e);
            cmbCountry.SelectedIndexChanged += (sender, e) => CountrySelectedIndexChanged?.Invoke(sender, e);
        }
        
        private void ConfigureComboBoxes()
        {
            cmbType.DropDownStyle = ComboBoxStyle.DropDown;
            cmbType.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbType.AutoCompleteSource = AutoCompleteSource.ListItems;
            
            cmbBrand.DropDownStyle = ComboBoxStyle.DropDown;
            cmbBrand.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbBrand.AutoCompleteSource = AutoCompleteSource.ListItems;
            
            cmbCountry.DropDownStyle = ComboBoxStyle.DropDown;
            cmbCountry.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbCountry.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void ConfigureDataGridView()
        {
            dataGridView.AutoGenerateColumns = false;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            
            dataGridView.Columns.AddRange(
                new DataGridViewTextBoxColumn { Name = "Id", DataPropertyName = "Id", HeaderText = "ID", Visible = false },
                new DataGridViewTextBoxColumn { Name = "Name", DataPropertyName = "Name", HeaderText = "Название", Width = 150 },
                new DataGridViewTextBoxColumn { Name = "Price", DataPropertyName = "BasePrice", HeaderText = "Цена", Width = 80 },
                new DataGridViewTextBoxColumn { Name = "PhotoPath", DataPropertyName = "PhotoPath", HeaderText = "Путь к фото", Width = 200 }
            );
        }

        public void UpdatePaginationControls(bool canGoBack, bool canGoForward, int currentPage)
        {
            btnPrevPage.Enabled = canGoBack;
            btnNextPage.Enabled = canGoForward;
            lblPageInfo.Text = $"Страница: {currentPage}";
            
            if (PaginatedProducts != null)
            {
                dataGridView.DataSource = PaginatedProducts.Results;
            }
        }
        
        public void UpdateSearchControls()
        {
            if (PaginatedTypes?.Results != null)
            {
                cmbType.Items.Clear();
                foreach (var type in PaginatedTypes.Results)
                {
                    cmbType.Items.Add(type);
                }
            }
            
            if (PaginatedBrands?.Results != null)
            {
                cmbBrand.Items.Clear();
                foreach (var brand in PaginatedBrands.Results)
                {
                    cmbBrand.Items.Add(brand);
                }
            }
            
            if (PaginatedCountries?.Results != null)
            {
                cmbCountry.Items.Clear();
                foreach (var country in PaginatedCountries.Results)
                {
                    cmbCountry.Items.Add(country);
                }
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
        
        private void UpdateSearchParameters()
        {
            SearchParameters.ProductName = string.IsNullOrWhiteSpace(txtSearch.Text) ? null : txtSearch.Text;
            SearchParameters.ProductType = SelectedType;
            SearchParameters.Brand = SelectedBrand;
            SearchParameters.Country = SelectedCountry;
        }
        
        private async void btnApplyFilters_Click(object sender, EventArgs e)
        {
            UpdateSearchParameters();
            await SearchProducts?.Invoke();
        }
        
        private async Task HandleComboBoxTextChanged(ComboBox comboBox, SearchRequest<string> searchRequest, Func<Task> searchAction)
        {
            await Task.Delay(300);
            
            if (comboBox.Text != searchRequest?.Query)
            {
                searchRequest = new SearchRequest<string>(comboBox.Text, PageSize, 0);
                await searchAction?.Invoke();
            }
        }

        private async Task HandleComboBoxDropDown<T>(ComboBox comboBox, PaginatedResult<T> paginatedResult, 
            SearchRequest<string> searchRequest, Func<Task> searchAction)
        {
            if (paginatedResult is { Pagination.HasMore: true })
            {
                searchRequest = new SearchRequest<string>(
                    searchRequest.Query, PageSize, paginatedResult.Pagination.NextOffset);
                await searchAction?.Invoke();
            }
        }
    }
}