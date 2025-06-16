namespace OnlineStore.Core.Models;

public class OrderCreateParameters
{
    public int ProductId { get; set; }
    
    public int WarehouseId { get; set; }
    
    public int Count { get; set; }
    
    public User User { get; set; }
    
    public Address? Address { get; set; }
    
    public string? Description { get; set; }
}