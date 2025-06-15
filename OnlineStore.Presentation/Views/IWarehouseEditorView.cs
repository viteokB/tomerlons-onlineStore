using OnlineStore.Core.Common.Pagination;
using OnlineStore.Core.Models;
using OnlineStore.Core.Models.WhareHouse;
using Presentation.Common;

namespace Presentation.Views
{
    public interface IWarehouseEditorView : IModalView
    {
        User? CurrentUser { get; set; }
        Warehouse? SelectedWarehouse { get; set; }
        Product? SelectedProduct { get; set; }
        int ProductCount { get; set; }
        
        string WarehouseName { get; set; }
        bool IsActive { get; set; }
        Address CurrentAddress { get; set; }

        PaginatedResult<Warehouse> PaginatedWarehouses { get; set; }
        PaginatedResult<Product> PaginatedProducts { get; set; }

        void ShowWarehouseDetails(Warehouse warehouse);
        void ClearWarehouseDetails();

        Func<Task> SearchWarehouses { get; set; }
        Func<Task> SearchProducts { get; set; }
        Func<Task> AddNewWarehouse { get; set; }
        Func<Task> DeleteWarehouse { get; set; }
        Func<Task> UpdateWarehouse { get; set; }
        Func<Task> UpdateProductCount { get; set; }
        
        void ShowError(string message);
        
        void ShowSuccess(string message);
    
        void SetProductCount(int count);
        
        event Action OnWarehouseSelected;
        event Action OnProductSelected;
    }
}