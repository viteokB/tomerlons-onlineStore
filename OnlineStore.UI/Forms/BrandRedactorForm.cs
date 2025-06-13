using OnlineStore.Core.Common.Pagination;
using OnlineStore.Core.Models;
using OnlineStore.UI.Forms.Common;
using Presentation.Views;

namespace OnlineStore.UI.Forms;

public partial class BrandRedactorForm :  BaseModalForm, IBrandRedactorView
{
private const int PageSize = 10;
    private bool _isLoadingData = false;

    public User? User { get; set; }
    
    public string BrandName
    {
        get => nameTextBox.Text.Trim().ToLower();
        set => nameTextBox.Text = value.Trim().ToLower();
    }
    
    public Country? SelectedCountry
    {
        get => countryComboBox.SelectedItem as Country;
        set => countryComboBox.SelectedItem = value;
    }
    
    public Brand? SelectedBrand
    {
        get => brandComboBox.SelectedItem as Brand;
        set => brandComboBox.SelectedItem = value;
    }
    
    public Func<Task> CreateNewBrand { get; set; }
    public Func<Task> UpdateBrand { get; set; }
    public Func<Task> DeleteBrand { get; set; }
    public Func<Task> SearchCountry { get; set; }
    public Func<Task> SearchBrand { get; set; }
    
    public SearchRequest<string> SearchCountryRequest { get; set; }
    public SearchRequest<string> SearchBrandRequest { get; set; }
    
    public PaginatedResult<Brand> PaginatedBrands { get; set; }
    public PaginatedResult<Country> PaginatedCountries { get; set; }
    
    public BrandRedactorForm()
    {
        InitializeComponent();
        
        // Настройка ComboBox для стран
        countryComboBox.DropDownStyle = ComboBoxStyle.DropDown;
        countryComboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        countryComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
        
        // Настройка ComboBox для брендов
        brandComboBox.DropDownStyle = ComboBoxStyle.DropDown;
        brandComboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        brandComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
    }
    
    public void ShowError(string message)
    {
        MessageBox.Show(this, message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    public void ShowGoodInfo(string message)
    {
        MessageBox.Show(this, message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private async void createButton_Click(object sender, EventArgs e)
    {
        await ExecuteOperation(() => CreateNewBrand.Invoke(), createBtn);
    }

    private async void updateButton_Click(object sender, EventArgs e)
    {
        await ExecuteOperation(() => UpdateBrand.Invoke(), updateBtn);
    }

    private async void deleteButton_Click(object sender, EventArgs e)
    {
        await ExecuteOperation(() => DeleteBrand.Invoke(), deleteBtn);
    }

    private async void countryComboBox_TextChanged(object sender, EventArgs e)
    {
        await Task.Delay(300);
        
        if (countryComboBox.Text != SearchCountryRequest?.Query)
        {
            await PerformCountrySearch();
        }
    }

    private async void brandComboBox_TextChanged(object sender, EventArgs e)
    {
        await Task.Delay(300);
        
        if (brandComboBox.Text != SearchBrandRequest?.Query)
        {
            await PerformBrandSearch();
        }
    }

    private async Task PerformCountrySearch()
    {
        if (_isLoadingData) return;
        
        try
        {
            _isLoadingData = true;
            countryComboBox.Items.Clear();
            SearchCountryRequest = new SearchRequest<string>(countryComboBox.Text, PageSize, 0);
            await SearchCountry.Invoke();
            PopulateCountryComboBox();
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

    private async Task PerformBrandSearch()
    {
        if (_isLoadingData) return;
        
        try
        {
            _isLoadingData = true;
            brandComboBox.Items.Clear();
            SearchBrandRequest = new SearchRequest<string>(brandComboBox.Text, PageSize, 0);
            await SearchBrand.Invoke();
            PopulateBrandComboBox();
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

    private async void countryComboBox_DropDown(object sender, EventArgs e)
    {
        if (PaginatedCountries is { Pagination.HasMore: true } && !_isLoadingData)
        {
            try
            {
                _isLoadingData = true;
                SearchCountryRequest = new SearchRequest<string>(
                    SearchCountryRequest.Query, PageSize, PaginatedCountries.Pagination.NextOffset);
                await SearchCountry.Invoke();
                PopulateCountryComboBox();
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

    private async void brandComboBox_DropDown(object sender, EventArgs e)
    {
        if (PaginatedBrands is { Pagination.HasMore: true } && !_isLoadingData)
        {
            try
            {
                _isLoadingData = true;
                SearchBrandRequest = new SearchRequest<string>(
                    SearchBrandRequest.Query, PageSize, PaginatedBrands.Pagination.NextOffset);
                await SearchBrand.Invoke();
                PopulateBrandComboBox();
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

    private void countryComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (SelectedCountry != null)
        {
            // Можно добавить логику, если нужно
        }
    }

    private void brandComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (SelectedBrand != null)
        {
            BrandName = SelectedBrand.Name;
            SelectedCountry = SelectedBrand.Country;
            labelCountry.Text = SelectedBrand?.Country.Name;
        }
        else
        {
            BrandName = "";
            SelectedCountry = null;
        }
    }

    private void countryComboBox_Leave(object sender, EventArgs e)
    {
        if (!countryComboBox.Items.Contains(countryComboBox.Text))
        {
            SelectedCountry = null;
        }
    }

    private void brandComboBox_Leave(object sender, EventArgs e)
    {
        if (!brandComboBox.Items.Contains(brandComboBox.Text))
        {
            SelectedBrand = null;
            BrandName = "";
            SelectedCountry = null;
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
}