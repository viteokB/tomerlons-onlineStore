namespace OnlineStore.Repository.Models;

public class DatabaseWharehouseProducts
{
    public int Id { get; set; }
    
    public int ProductId { get; set; }
    
    public DatabaseProduct Product { get; set; } = null!;
    
    public int WharehouseId { get; set; }
    
    public DatabaseWharehouse Wharehouse { get; set; } = null!;
    
    public int? ChangedById { get; set; }
    
    public DatabaseUser? ChangedBy { get; set; } = null!;
    
    public int Count { get; set; }
    
    public DateTime ChangedAt { get; set; }
}