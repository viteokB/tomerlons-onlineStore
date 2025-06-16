namespace OnlineStore.Core.Models;

public class Product
{
    public int Id { get; set; }
    
    public Type? Type { get; set; }
    
    public Country? Country { get; set; }
    
    public User? ChangedBy { get; set; }
    
    public Brand? Brand { get; set; }
    
    public required string Name { get; set; }
    
    public string? PhotoPath { get; set; }
    
    public required string CatalogNumber { get; set; }
    
    public float BasePrice { get; set; }
    
    public bool IsActive { get; set; }
    
    public DateTime ChangedAt { get; set; }
    
    public override string ToString()
        => $"{Name}";
}