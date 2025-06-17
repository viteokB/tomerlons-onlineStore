namespace OnlineStore.Core.Models;

public class ProductHistory
{
    public int Id { get; set; }
    
    public int ProductId { get; set; }
    
    public User? ChangedBy { get; set; }
    
    public required string Name { get; set; }
    
    public required string CatalogNumber { get; set; }
    
    public float BasePrice { get; set; }
    
    public bool IsActive { get; set; }
    
    public DateTime ChangedAt { get; set; }
}