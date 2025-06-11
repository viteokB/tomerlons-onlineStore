using OnlineStore.Core.Models;
using OnlineStore.Core.Models.WhareHouse;

namespace OnlineStore.Repository.Models;

public class DatabaseWharehouseProdHistory
{
    public int Id { get; set; }
    
    public int WarehouseProdId { get; set; }
    
    public WharehouseProducts WharehouseProducts { get; set; } = null!;

    public int ProductId { get; set; }
    
    public Product Product { get; set; } = null!;
    
    public int WharehouseId { get; set; }
    
    public Wharehouse Wharehouse { get; set; } = null!;
    
    public int ChangedById { get; set; }
    
    public User ChangedBy { get; set; } = null!;
    
    public int Count { get; set; }
    
    public DateTime ChangedAt { get; set; }
}