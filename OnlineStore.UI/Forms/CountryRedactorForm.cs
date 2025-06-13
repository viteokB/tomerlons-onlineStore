using OnlineStore.Core.Common.Pagination;
using OnlineStore.Core.Models;
using OnlineStore.UI.Forms.Common;
using Presentation.Views;

namespace OnlineStore.UI.Forms;

public partial class CountryRedactorForm : BaseModalForm, ICountryRedactorView
{
    private const int PageSize = 10; // Количество элементов на странице.
    private bool _isLoadingData = false;

    public User? User { get; set; }
    public string CountryName
    {
        get => nameTextBox.Text.Trim().ToLower(); 
        set => nameTextBox.Text = value.Trim().ToLower();
    }
    public string CountryCode
    {
        get => codeTextBox.Text.Trim(); 
        set => codeTextBox.Text = value.Trim();
    }
    
    public Country? SelectedCountry
    {
        get => comboBox.SelectedItem as Country; 
        set => comboBox.SelectedItem = value;
    }
    
    public Func<Task> CreateNewCountry { get; set; }
    public Func<Task> UpdateCountry { get; set; }
    public Func<Task> DeleteCountry { get; set; }
    public Func<Task> SearchCountry { get; set; }
    public SearchRequest<string> SearchRequest { get; set; }
    public PaginatedResult<Country> PaginatedCountries { get; set; }
    
    public CountryRedactorForm()
    {
        InitializeComponent();
        comboBox.DropDownStyle = ComboBoxStyle.DropDown; // Разрешить ввод текста + выбор
        comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend; // Для подсказок
        comboBox.AutoCompleteSource = AutoCompleteSource.ListItems; // Источник подсказок
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
        Console.WriteLine("Create Country");
        await ExecuteOperation(() => CreateNewCountry.Invoke(), createBtn);
    }

    private async void updateButton_Click(object sender, EventArgs e)
    {
        Console.WriteLine("Update Country");
        await ExecuteOperation(() => UpdateCountry.Invoke(), updateBtn);
    }

    private async void removeButton_Click(object sender, EventArgs e)
    {
        Console.WriteLine("Remove Country");
        await ExecuteOperation(() => DeleteCountry.Invoke(), deleteBtn);
    }

    private async void comboBox_TextChanged(object sender, EventArgs e)
    {
        Console.WriteLine("TextChanged Country");
        // Если пользователь быстро вводит текст, подождем немного, прежде чем делать запрос.
        await Task.Delay(300);
        
        // Проверяем, что текст в ComboBox изменился
        if (comboBox.Text != SearchRequest?.Query)
        {
            await PerformSearch();
        }
    }
    
    private async Task PerformSearch()
    {
        Console.WriteLine("PerformSearch Country");
        if (_isLoadingData) return;
        
        try
        {
            _isLoadingData = true;
            comboBox.Items.Clear();
            SearchRequest = new SearchRequest<string>(comboBox.Text, PageSize, 0);
            await SearchCountry.Invoke();
            PopulateComboBox();
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
    
    private void PopulateComboBox()
    {
        Console.WriteLine("PopulateComboBox Type");
        
        if (PaginatedCountries?.Results != null)
        {
            foreach (var type in PaginatedCountries.Results)
            {
                comboBox.Items.Add(type);
            }
        
            // Устанавливаем AutoCompleteSource после добавления элементов
            comboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
    }

    private async void comboBox_DropDown(object sender, EventArgs e)
    {
        Console.WriteLine("comboBox_DropDown Type");
        // Загрузка следующих страниц при открытии списка (если есть еще страницы)
        if (PaginatedCountries is { Pagination.HasMore: true } && !_isLoadingData)
        {
            try
            {
                _isLoadingData = true;
                SearchRequest = new SearchRequest<string>(
                    SearchRequest.Query, PageSize, PaginatedCountries.Pagination.NextOffset); // Запрос следующей страницы
                await SearchCountry.Invoke();  // Загрузка следующей страницы
                PopulateComboBox(); // Добавление элементов в ComboBox
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

    private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        Console.WriteLine("comboBox_SelectedIndexChanged Type");
        if (SelectedCountry != null)
        {
            CountryName = SelectedCountry.Name;
            CountryCode = SelectedCountry.Code;
        }
        else
        {
            CountryName = "";
            CountryCode = "";
        }
    }

    private void comboBox_Leave(object sender, EventArgs e)
    {
        Console.WriteLine("comboBox_Leave Country");
        // Если пользователь ввел текст, которого нет в списке, сбрасываем выбранный элемент
        if (!comboBox.Items.Contains(comboBox.Text))
        {
            SelectedCountry = null;
            CountryName = "";
            CountryCode = "";
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