using OnlineStore.Core.Common.Pagination;
using OnlineStore.Core.Models;
using Presentation.Common;

namespace Presentation.Views
{
    public interface IUserCartView : IModalView
    {
        User CurrentUser { get; set; }
        Order? SelectedOrder { get; }
        PaginatedResult<Order> UserOrders { get; set; }
        
        event Func<Task> LoadOrders;
        event Func<Task> CancelOrder;
        
        void ShowError(string message);
        void ShowSuccess(string message);
        void UpdateOrdersList();
    }
}