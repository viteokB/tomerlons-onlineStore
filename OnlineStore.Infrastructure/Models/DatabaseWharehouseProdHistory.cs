using OnlineStore.Core.Models;

namespace OnlineStore.Repository.Models;

public class DatabaseWharehouseProdHistory
{
    public int Id { get; set; }
    
    public int WarehouseProdId { get; set; }
    
    public DatabaseWharehouseProducts WharehouseProducts { get; set; } = null!;

    public int WharehouseId { get; set; }
    
    public DatabaseWharehouseProducts Wharehouse { get; set; } = null!;
    
    public int ProductId { get; set; }
    
    public DatabaseProduct Product { get; set; } = null!;
    
    public int? ChangedById { get; set; }
    
    public DatabaseUser? ChangedBy { get; set; } = null!;
    
    public int Count { get; set; }
    
    public DateTime ChangedAt { get; set; }
    
    public ICollection<DatabaseProduct> Products { get; set; } = new List<DatabaseProduct>();

    public static DatabaseWharehouseProdHistory CreateHistory(DatabaseWharehouseProducts whProducts)
    {
        return new DatabaseWharehouseProdHistory()
        {
            ProductId = whProducts.ProductId,
            WharehouseId = whProducts.WharehouseId,
            ChangedById = whProducts.ChangedById,
            Count = whProducts.Count,
            ChangedAt = DateTime.Now,
        };
    }
}