using OnlineStore.Core.Common.Pagination;
using OnlineStore.Core.Models;
using OnlineStore.Core.Models.WhareHouse;
using Presentation.Common;

namespace Presentation.Views;

public interface IWarehouseEditorView : IModalView
{
    // Основные свойства
    User? CurrentUser { get; set; }
    Warehouse? SelectedWarehouse { get; set; }
    Product? SelectedProduct { get; set; }
    int ProductCount { get; set; }

    // Данные для привязки
    PaginatedResult<Warehouse> PaginatedWarehouses { get; set; }
    PaginatedResult<Product> PaginatedProducts { get; set; }

    // Поисковые запросы
    SearchRequest<string> WarehouseSearchRequest { get; set; }
    SearchRequest<ProductsParamets> ProductSearchRequest { get; set; }

    // Методы управления
    void ShowWarehouseDetails(Warehouse warehouse);
    void ClearWarehouseDetails();
    void ShowError(string message);
    void ShowSuccess(string message);

    // События
    Func<Task> SearchWarehouses { get; set; }
    Func<Task> SearchProducts { get; set; }
    Func<Task> UpdateWarehouse { get; set; }
    Func<Task> UpdateProductCount { get; set; }
}