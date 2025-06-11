namespace OnlineStore.Repository.Models;

public class DatabaseDeliveryStatus
{
    public int Id { get; set; }
    
    public string Name { get; set; } = null!;
    
    public ICollection<DatabaseOrder> Orders { get; set; } = new List<DatabaseOrder>();
}