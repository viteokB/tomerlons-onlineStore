using OnlineStore.Core.Models.WhareHouse;

namespace OnlineStore.Repository.Models;

public class DatabaseDeliveryZones
{
    public int Id { get; set; }
    
    public int WharehouseId { get; set; }
    
    public Wharehouse Wharehouse { get; set; }
    
    public string Name { get; set; }
    
    public string MinDistance { get; set; }
    
    public string MaxDistance { get; set; }
    
    public float DeliveryPrice { get; set; }
    
    public int DeliveryDays { get; set; }
}