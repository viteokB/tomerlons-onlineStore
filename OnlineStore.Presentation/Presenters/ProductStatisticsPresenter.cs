using OnlineStore.Core.Common.Pagination;
using OnlineStore.Core.Interfaces.HistoryParameters;
using OnlineStore.Core.Models;
using OnlineStore.Services.HistoryService;
using OnlineStore.Services.Products;
using Presentation.Common;
using Presentation.Views;

namespace Presentation.Presenters
{
    public class ProductStatisticsPresenter : BasePresenter<IProductStatisticsView, User>
    {
        private readonly IHistoryService _historyService;
        private readonly IProductService _productService;
        private DateTime _minDate;
        private DateTime _maxDate;
        
        public ProductStatisticsPresenter(
            IProductStatisticsView view,
            IHistoryService historyService,
            IProductService productService) : base(view)
        {
            _historyService = historyService;
            _productService = productService;

            View.LoadData += async () => await LoadStatistics();
            View.ApplyDateFilter += async () => await LoadStatistics();
            View.SearchProduct += async () => await SearchProducts(); // Новый обработчик
        }
        
        public override void Run(User arg)
        {
            View.CurrentUser = arg;
            View.ProductsParamets = new ProductsParamets();
            View.SearchProductRequest = new SearchRequest<ProductsParamets>(View.ProductsParamets, 10, 0);
            
            _ = LoadStatistics(true);
            View.Show();
        }
        
        private async Task SearchProducts()
        {
            if (View.CurrentUser == null) return;

            var operation = await _productService.SearchProducts(
                View.SearchProductRequest,
                View.CurrentUser);

            if (!operation.IsSuccess)
            {
                View.ShowError($"Ошибка при поиске продуктов: {operation.Message}");
            }
            else
            {
                View.PaginatedProducts = operation.Data;
            }
        }

        private async Task LoadStatistics(bool initialLoad = false)
        {
            if (View.SelectedProduct == null) return;

            View.ShowLoading();

            try
            {
                var productId = View.SelectedProduct.Id;
                var startDate = View.StartDate;
                var endDate = View.EndDate;

                // Загрузка истории цен
                var priceHistoryRequest = new SearchRequest<ProductHistorySearchParameters>(
                    new ProductHistorySearchParameters(startDate, endDate), 1000, 0);
                var priceHistoryResult = await _historyService.GetProductHistory(
                    productId, priceHistoryRequest, View.CurrentUser);

                // Загрузка истории склада
                var warehouseHistoryRequest = new SearchRequest<WarehouseProductHistorySearchParameters>(
                    new WarehouseProductHistorySearchParameters(startDate, endDate), 1000, 0);
                var warehouseHistoryResult = await _historyService.GetWarehouseProductHistory(
                    1, productId, warehouseHistoryRequest, View.CurrentUser);

                // Загрузка истории заказов
                var orderHistoryRequest = new SearchRequest<OrderHistorySearchParameters>(
                    new OrderHistorySearchParameters(startDate, endDate), 1000, 0);
                var orderHistoryResult = await _historyService.GetOrderHistory(
                    productId, orderHistoryRequest, View.CurrentUser);

                if (initialLoad)
                {
                    // Определяем минимальную и максимальную даты из всех данных
                    var allDates = priceHistoryResult.Data?.Results.Select(x => x.ChangedAt)
                        .Concat(warehouseHistoryResult.Data?.Results.Select(x => x.ChangedAt) ?? Array.Empty<DateTime>())
                        .Concat(orderHistoryResult.Data?.Results.Select(x => x.CreatedAt) ?? Array.Empty<DateTime>())
                        .ToList();

                    if (allDates?.Any() == true)
                    {
                        _minDate = allDates.Min();
                        _maxDate = allDates.Max();
                        View.SetDateRange(_minDate, _maxDate);
                    }
                }

                // Обновляем графики
                if (priceHistoryResult.IsSuccess)
                {
                    View.UpdatePriceHistoryChart(priceHistoryResult.Data);
                }

                if (warehouseHistoryResult.IsSuccess)
                {
                    View.UpdateWarehousesHistoryChart(warehouseHistoryResult.Data);
                }

                if (orderHistoryResult.IsSuccess)
                {
                    View.UpdateOrdersHistoryChart(orderHistoryResult.Data);
                }
            }
            catch (Exception ex)
            {
                View.ShowError($"Ошибка при загрузке статистики: {ex.Message}");
            }
            finally
            {
                View.HideLoading();
            }
        }
    }
}