namespace OnlineStore.Core.Models;

public class DeliveryStatus
{
    public int Id { get; set; }
    
    public required string Name { get; set; }
    
    public string Description { get; set; } = string.Empty;
    
    public bool IsActive { get; set; } = true;
}