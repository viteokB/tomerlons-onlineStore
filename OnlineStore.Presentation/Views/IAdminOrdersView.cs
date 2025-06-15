using OnlineStore.Core.Common.Pagination;
using OnlineStore.Core.Models;
using Presentation.Common;

namespace Presentation.Views;

public interface IAdminOrdersView : IModalView
{
    User CurrentUser { get; set; }
    Order? SelectedOrder { get; set; }
    DeliveryStatus? SelectedStatus { get; set; }
    PaginatedResult<Order> Orders { get; set; }
    SearchRequest<OrderParameters> SearchRequest { get; set; }
    
    List<DeliveryStatus> AllStatuses { get; set; }
    
    string StatusName { get; set; }
    string StatusDescription { get; set; }
    bool StatusIsActive { get; set; }
    
    Func<Task> SearchOrders { get; set; }
    Func<Task> UpdateOrderStatus { get; set; }
    Func<Task> ViewOrderDetails { get; set; }
    
    Func<Task> LoadStatuses { get; set; }
    Func<Task> AddNewStatus { get; set; }
    Func<Task> DeleteStatus { get; set; }
    
    void ShowError(string message);
    void ShowInfo(string message);
}