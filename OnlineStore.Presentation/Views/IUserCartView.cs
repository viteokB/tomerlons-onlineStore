using OnlineStore.Core.Common.Pagination;
using OnlineStore.Core.Models;
using Presentation.Common;

namespace Presentation.Views;

public interface IUserCartView : IModalView
{
    User CurrentUser { get; set; }
    Order? SelectedOrder { get; set; }
    PaginatedResult<Order> UserOrders { get; set; }
    SearchRequest<OrderParameters> SearchRequest { get; set; }
    
    Func<Task> LoadOrders { get; set; }
    Func<Task> CreateOrder { get; set; }
    Func<Task> CancelOrder { get; set; }
    Func<Task> ViewOrderDetails { get; set; }
    
    void ShowError(string message);
    void ShowInfo(string message);
}