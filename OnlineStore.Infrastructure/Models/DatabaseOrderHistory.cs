using OnlineStore.Core.Models;

namespace OnlineStore.Repository.Models;

public class DatabaseOrderHistory
{
    public int Id { get; set; }
    
    public int OrderId { get; set; }
    
    public DatabaseOrderHistory OrderHistory { get; set; }

    public int? UserId { get; set; }

    public DatabaseUser? User { get; set; } = null!;

    public int DeliveryAddressId { get; set; }
    
    public Address DeliveryAddress { get; set; } = null!;

    public DatabaseType Type { get; set; } = null!;

    public int DeliveryStatusId { get; set; }
    
    public DatabaseDeliveryStatus DeliveryStatus { get; set; } = null!;

    public int ProductId { get; set; }
    
    public DatabaseProduct Product { get; set; } = null!;

    public int WharehouseId { get; set; }
    
    public DatabaseWharehouse Wharehouse { get; set; } = null!;

    public int ChangedById { get; set; }
    
    public DatabaseUser ChangedByUser { get; set; } = null!;
    
    public int Count { get; set; }

    public float ProductPrice { get; set; }

    public float DeliveryPrice { get; set; }

    public int DeliveryDays { get; set; }

    public string Description { get; set; } = null!;
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime UpdatedAt { get; set; }
}