using OnlineStore.Core.Common.Pagination;
using OnlineStore.Core.Models;
using OnlineStore.UI.Forms.Common;
using Presentation.Views;
using Type = OnlineStore.Core.Models.Type;

namespace OnlineStore.UI.Forms;

public partial class TypeRedactorForm : BaseModalForm, ITypeRedactorView
{
    private const int PageSize = 10; // Количество элементов на странице.
    private bool _isLoadingData = false;
    
    public User? User { get; set; }
    
    public string TypeName
    {
        get => nameTextBox.Text.Trim().ToLower(); 
        set => nameTextBox.Text = value.Trim().ToLower();
    }
    
    public string TypeDescription
    {
        get => description.Text.Trim(); 
        set => description.Text = value.Trim();
    }
    
    public Type? SelectedType 
    {
        get => comboBox.SelectedItem as Type; 
        set => comboBox.SelectedItem = value;
    }
    
    public Func<Task> CreateNewType { get; set; }
    
    public Func<Task> UpdateType { get; set; }
    
    public Func<Task> DeleteType { get; set; }
    
    public Func<Task> SearchType { get; set; }
    
    public SearchRequest<string> SearchRequest { get; set; }
    
    public PaginatedResult<Type> PaginatedTypes { get; set; }
    
    public TypeRedactorForm()
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
        Console.WriteLine("Create Type");
        await ExecuteOperation(() => CreateNewType.Invoke(), createBtn);
    }

    private async void updateButton_Click(object sender, EventArgs e)
    {
        Console.WriteLine("Update Type");
        await ExecuteOperation(() => UpdateType.Invoke(), updateBtn);
    }

    private async void removeButton_Click(object sender, EventArgs e)
    {
        Console.WriteLine("Remove Type");
        await ExecuteOperation(() => DeleteType.Invoke(), deleteBtn);
    }

    private async void comboBox_TextChanged(object sender, EventArgs e)
    {
        Console.WriteLine("TextChanged Type");
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
        Console.WriteLine("PerformSearch Type");
        if (_isLoadingData) return;
        
        try
        {
            _isLoadingData = true;
            comboBox.Items.Clear();
            SearchRequest = new SearchRequest<string>(comboBox.Text, PageSize, 0);
            await SearchType.Invoke();
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
        
        if (PaginatedTypes?.Results != null)
        {
            foreach (var type in PaginatedTypes.Results)
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
        if (PaginatedTypes is { Pagination.HasMore: true } && !_isLoadingData)
        {
            try
            {
                _isLoadingData = true;
                SearchRequest = new SearchRequest<string>(
                    SearchRequest.Query, PageSize, PaginatedTypes.Pagination.NextOffset); // Запрос следующей страницы
                await SearchType.Invoke();  // Загрузка следующей страницы
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
        if (SelectedType != null)
        {
            TypeName = SelectedType.Name;
            TypeDescription = SelectedType.Description;
        }
        else
        {
            TypeName = "";
            TypeDescription = "";
        }
    }

    private void comboBox_Leave(object sender, EventArgs e)
    {
        Console.WriteLine("comboBox_Leave Type");
        // Если пользователь ввел текст, которого нет в списке, сбрасываем выбранный элемент
        if (!comboBox.Items.Contains(comboBox.Text))
        {
            SelectedType = null;
            TypeName = "";
            TypeDescription = "";
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