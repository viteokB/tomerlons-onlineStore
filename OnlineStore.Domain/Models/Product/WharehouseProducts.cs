using OnlineStore.Core.Models.WhareHouse;

namespace OnlineStore.Core.Models;

public class WharehouseProducts
{
    public int Id { get; set; }
    
    public Product Product { get; set; } = null!;

    public Warehouse Warehouse { get; set; } = null!;
    
    public User ChangedBy { get; set; } = null!;
    
    public int Count { get; set; }
    
    public DateTime ChangedAt { get; set; }
}