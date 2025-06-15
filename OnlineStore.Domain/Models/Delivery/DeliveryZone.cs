using OnlineStore.Core.Models.WhareHouse;

namespace OnlineStore.Core.Models;

public class DeliveryZone
{
    public int Id { get; set; }
    
    public required Warehouse Warehouse { get; set; }
}