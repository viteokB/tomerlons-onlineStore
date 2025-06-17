using OnlineStore.Core.Common.Pagination;
using OnlineStore.Core.Models;
using Presentation.Common;

namespace Presentation.Views
{
    public interface IProductStatisticsView : IModalView
    {
        User? CurrentUser { get; set; }
        Product? SelectedProduct { get; set; }
        
        DateTime StartDate { get; }
        DateTime EndDate { get; }
        
        SearchRequest<ProductsParamets> SearchProductRequest { get; set; }
        PaginatedResult<Product> PaginatedProducts { get; set; }
        ProductsParamets? ProductsParamets { get; set; }
        
        event Func<Task> LoadData;
        event Func<Task> ApplyDateFilter;
        event Func<Task> SearchProduct; // Новое событие для поиска продуктов

        void UpdatePriceHistoryChart(PaginatedResult<ProductHistory> paginatedResult);
        void UpdateWarehousesHistoryChart(PaginatedResult<WarehouseProductHistory> paginatedResult);
        
        void ShowError(string message);
        void ShowLoading();
        void HideLoading();
        void SetDateRange(DateTime minDate, DateTime maxDate);
    }
}