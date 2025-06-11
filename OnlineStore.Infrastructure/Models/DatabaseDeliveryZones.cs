namespace OnlineStore.Repository.Models;

public class DatabaseDeliveryZones
{
    public int Id { get; set; }
    
    public int WharehouseId { get; set; }
    
    public DatabaseWharehouse Wharehouse { get; set; }
    
    public string Name { get; set; }
    
    public string MinDistance { get; set; }
    
    public string MaxDistance { get; set; }
    
    public float DeliveryPrice { get; set; }
    
    public int DeliveryDays { get; set; }
}