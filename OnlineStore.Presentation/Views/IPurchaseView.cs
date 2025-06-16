using OnlineStore.Core.Models;
using OnlineStore.Core.Models.WhareHouse;
using Presentation.Common;

namespace Presentation.Views
{
    public interface IPurchaseView : IModalView
    {
        Product SelectedProduct { get; set; }
        User CurrentUser { get; set; }
        int Quantity { get; }
        int SelectedWarehouseId { get; }
        Address DeliveryAddress { get; }
        string Description { get; }
        
        int AvailableQuantity { get; set; } // Новое свойство

        event Func<Task> PurchaseConfirmed;
        event Func<Task> LoadWarehouses;
        event Action<int> WarehouseSelected; // Новое событие

        void ShowWarehouses(IEnumerable<Warehouse> warehouses);
        void ShowError(string message);
        void ShowSuccess(string message);
        void UpdateProductAvailabilityInfo(); // Новый метод
    }
}