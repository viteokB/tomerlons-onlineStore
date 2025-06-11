using OnlineStore.Core.Models.WhareHouse;

namespace OnlineStore.Repository.Models;

public class DatabaseDeliveryZonesHistory
{
    public int Id { get; set; }
    
    public int DeliveryZoneId { get; set; }
    
    public DatabaseDeliveryZones DeliveryZone { get; set; } = null!;
    
    public int WharehouseId { get; set; }
    
    public Wharehouse Wharehouse { get; set; } = null!;
    
    public string Name { get; set; } = null!;
    
    public string MinDistance { get; set; } = null!;
    
    public string MaxDistance { get; set; } = null!;
    
    public float DeliveryPrice { get; set; }
    
    public int DeliveryDays { get; set; }
}