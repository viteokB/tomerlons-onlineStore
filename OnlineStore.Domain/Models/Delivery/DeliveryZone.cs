using OnlineStore.Core.Models.WhareHouse;

namespace OnlineStore.Core.Models;

public class DeliveryZone
{
    public int Id { get; set; }
    
    public required Wharehouse Wharehouse { get; set; }
}