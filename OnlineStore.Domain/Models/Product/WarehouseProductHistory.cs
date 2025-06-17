using OnlineStore.Core.Models.WhareHouse;

namespace OnlineStore.Core.Models;

public class WarehouseProductHistory
{
    public int Id { get; set; }
    
    public int WarehouseProductId { get; set; }
    
    public string ProductName { get; set; } = null!;
    
    public int ProductId { get; set; }
    
    public int WarehouseId { get; set; }
    
    public User ChangedBy { get; set; } = null!;
    
    public int Count { get; set; }
    
    public DateTime ChangedAt { get; set; }
}