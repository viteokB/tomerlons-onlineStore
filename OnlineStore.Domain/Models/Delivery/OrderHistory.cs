using OnlineStore.Core.Models.WhareHouse;

namespace OnlineStore.Core.Models;

public class OrderHistory
{
    public int Id { get; set; }
    
    public int OrderId { get; set; }

    public int ProductId { get; set; }
    
    public string ProductName { get; set; } = null!;
    
    public User? ChangedBy { get; set; }
    
    public int Count { get; set; }
    
    public float ProductPrice { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime UpdatedAt { get; set; }
}