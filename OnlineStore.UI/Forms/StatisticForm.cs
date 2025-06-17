using LiveChartsCore.SkiaSharpView.WinForms;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using OnlineStore.Core.Common.Pagination;
using OnlineStore.Core.Models;
using OnlineStore.UI.Forms.Common;
using Presentation.Views;

namespace OnlineStore.UI.Forms;

public partial class StatisticForm : BaseModalForm<IProductStatisticsView>, IProductStatisticsView
{
    public User? CurrentUser { get; set; }

    public Product? SelectedProduct
    {
        get => productsComboBox.SelectedItem as Product;
        set => productsComboBox.SelectedItem = value;
    }

    public CartesianChart PriceHistoryChart => priceHistoryChart;
    public CartesianChart WarehouseHistoryChart => warehouseHistoryChart;
    public CartesianChart OrdersHistoryChart => ordersHistoryChart;

    public DateTime StartDate => dtpStartDate.Value;
    public DateTime EndDate => dtpEndDate.Value;

    // Реализация новых свойств
    public SearchRequest<ProductsParamets> SearchProductRequest { get; set; }
    public PaginatedResult<Product> PaginatedProducts { get; set; }
    public ProductsParamets? ProductsParamets { get; set; } = new ProductsParamets();

    public event Func<Task> LoadData;
    public event Func<Task> ApplyDateFilter;
    public event Func<Task> SearchProduct;

    private const int PageSize = 10;
    private bool _isLoadingData = false;

    public StatisticForm()
    {
        InitializeComponent();
        InitializeControls();
        InitializeCharts();
        ConfigureComboBox(productsComboBox);
    }

    private void ConfigureComboBox(ComboBox comboBox)
    {
        comboBox.DropDownStyle = ComboBoxStyle.DropDown;
        comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        comboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
    }

    private void InitializeControls()
    {
        Load += async (sender, e) =>
        {
            SearchProductRequest = new SearchRequest<ProductsParamets>(ProductsParamets, PageSize, 0);
            await SearchProduct?.Invoke();
            PopulateProductsComboBox();
            await LoadData?.Invoke();
        };

        btnApplyFilter.Click += async (sender, e) => await ApplyDateFilter?.Invoke();

        productsComboBox.SelectedIndexChanged += async (sender, e) =>
        {
            if (SelectedProduct != null)
            {
                await LoadData?.Invoke();
            }
        };

        productsComboBox.TextChanged += async (sender, e) =>
        {
            await Task.Delay(300);
            if (productsComboBox.Text != SearchProductRequest?.Query.ToString())
            {
                ProductsParamets.ProductName = productsComboBox.Text;
                SearchProductRequest = new SearchRequest<ProductsParamets>(ProductsParamets, PageSize, 0);
                await PerformProductSearch();
            }
        };

        productsComboBox.DropDown += async (sender, e) =>
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
        };

        // Настройка DateTimePicker
        dtpStartDate.Value = DateTime.Now.AddMonths(-1);
        dtpEndDate.Value = DateTime.Now;
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

    public void UpdatePriceHistoryChart(PaginatedResult<ProductHistory> paginatedResult)
    {
        if (paginatedResult?.Results == null) return;

        var series = new LineSeries<ProductHistory>
        {
            Values = paginatedResult.Results.OrderBy(x => x.ChangedAt).ToList(),
            Mapping = (history, index) => new(history.ChangedAt.ToOADate(), history.BasePrice),
            Name = "Цена",
            DataLabelsFormatter = point => $"{DateTime.FromOADate(point.Model.ChangedAt.ToOADate()):dd.MM.yyyy}: {point.Model.BasePrice:C}",
            GeometrySize = 8
        };

        PriceHistoryChart.Series = new ISeries[] { series };
    }

    public void UpdateWarehousesHistoryChart(PaginatedResult<WarehouseProductHistory> paginatedResult)
    {
        if (paginatedResult?.Results == null) return;

        var series = new ColumnSeries<WarehouseProductHistory>
        {
            Values = paginatedResult.Results.OrderBy(x => x.ChangedAt).ToList(),
            Mapping = (history, index) => new(history.ChangedAt.ToOADate(), history.Count),
            Name = "Количество",
            DataLabelsFormatter = point => $"{DateTime.FromOADate(point.Model.ChangedAt.ToOADate()):dd.MM.yyyy}: {point.Model.Count} шт."
        };

        WarehouseHistoryChart.Series = new ISeries[] { series };
    }

    public void UpdateOrdersHistoryChart(PaginatedResult<OrderHistory> paginatedResult)
    {
        if (paginatedResult?.Results == null) return;

        var series = new ColumnSeries<OrderHistory>
        {
            Values = paginatedResult.Results.OrderBy(x => x.CreatedAt).ToList(),
            Mapping = (history, index) => new(history.CreatedAt.ToOADate(), history.Count),
            Name = "Заказы",
            DataLabelsFormatter = point => $"{DateTime.FromOADate(point.Model.UpdatedAt.ToOADate()):dd.MM.yyyy}: {point.Model.Count} шт."
        };

        OrdersHistoryChart.Series = new ISeries[] { series };
    }

    public void ShowError(string message)
    {
        MessageBox.Show(this, message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    public void ShowLoading()
    {
        Cursor = Cursors.WaitCursor;
        btnApplyFilter.Enabled = false;
    }

    public void HideLoading()
    {
        Cursor = Cursors.Default;
        btnApplyFilter.Enabled = true;
    }

    public void SetDateRange(DateTime minDate, DateTime maxDate)
    {
        dtpStartDate.MinDate = minDate;
        dtpStartDate.MaxDate = maxDate;
        dtpEndDate.MinDate = minDate;
        dtpEndDate.MaxDate = maxDate;

        dtpStartDate.Value = minDate;
        dtpEndDate.Value = maxDate;
    }

    private void InitializeCharts()
    {
        PriceHistoryChart.Series = new ISeries[]
        {
            new LineSeries<ProductHistory>
            {
                Values = null,
                Mapping = (history, index) => new(history.ChangedAt.ToOADate(), history.BasePrice),
                Name = "Цена",
                DataLabelsFormatter = point => $"{DateTime.FromOADate(point.Model.ChangedAt.ToOADate()):dd.MM.yyyy}: {point.Model.BasePrice:C}",
                GeometrySize = 8
            }
        };

        WarehouseHistoryChart.Series = new ISeries[]
        {
            new ColumnSeries<WarehouseProductHistory>
            {
                Values = null,
                Mapping = (history, index) => new(history.ChangedAt.ToOADate(), history.Count),
                Name = "Количество",
                DataLabelsFormatter = point => $"{DateTime.FromOADate(point.Model.ChangedAt.ToOADate()):dd.MM.yyyy}: {point.Model.Count} шт."
            }
        };

        OrdersHistoryChart.Series = new ISeries[]
        {
            new ColumnSeries<OrderHistory>
            {
                Values = null,
                Mapping = (history, index) => new(history.CreatedAt.ToOADate(), history.Count),
                Name = "Заказы",
                DataLabelsFormatter = point => $"{DateTime.FromOADate(point.Model.UpdatedAt.ToOADate()):dd.MM.yyyy}: {point.Model.Count} шт."
            }
        };

        // Настройка осей для отображения дат
        var dateAxis = new Axis
        {
            Labeler = value => DateTime.FromOADate(value).ToString("dd.MM.yyyy"),
            LabelsRotation = 45
        };

        PriceHistoryChart.XAxes = new[] { dateAxis };
        WarehouseHistoryChart.XAxes = new[] { dateAxis };
        OrdersHistoryChart.XAxes = new[] { dateAxis };
    }
}