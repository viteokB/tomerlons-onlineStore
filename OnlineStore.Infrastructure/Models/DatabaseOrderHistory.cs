using OnlineStore.Core.Models;

namespace OnlineStore.Repository.Models;

public class DatabaseOrderHistory
{
    public int Id { get; set; }
    
    public int OrderId { get; set; }
    
    public DatabaseOrder Order { get; set; }

    public int? UserId { get; set; }

    public DatabaseUser? User { get; set; } = null!;

    public int DeliveryAddressId { get; set; }
    
    public DatabaseAddress DeliveryAddress { get; set; } = null!;

    public int DeliveryStatusId { get; set; }
    
    public DatabaseDeliveryStatus DeliveryStatus { get; set; } = null!;

    public int ProductId { get; set; }
    
    public DatabaseProduct Product { get; set; } = null!;

    public int WharehouseId { get; set; }
    
    public DatabaseWharehouse Wharehouse { get; set; } = null!;

    public int? ChangedById { get; set; }
    
    public DatabaseUser ChangedByUser { get; set; } = null!;
    
    public int Count { get; set; }

    public float ProductPrice { get; set; }

    public float DeliveryPrice { get; set; }

    public int DeliveryDays { get; set; }

    public string Description { get; set; } = null!;
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime UpdatedAt { get; set; }

    public static DatabaseOrderHistory CreateHistory(DatabaseOrder from)
    {
        return new DatabaseOrderHistory()
        {
            Id = from.Id,
            UserId = from.UserId,
            DeliveryStatusId = from.DeliveryStatusId,
            DeliveryAddressId = from.DeliveryAddressId,
            ProductId = from.ProductId,
            WharehouseId = from.WharehouseId,
            ChangedById = from.ChangedById,
            Count = from.Count,
            ProductPrice = from.ProductPrice,
            DeliveryPrice = from.DeliveryPrice,
            DeliveryDays = from.DeliveryDays,
            Description = from.Description,
            CreatedAt = from.CreatedAt,
            UpdatedAt = from.UpdatedAt,
        };
    }
    
    public static DatabaseOrderHistory CreateHistory(Order from)
    {
        return new DatabaseOrderHistory()
        {
            Id = from.Id,
            UserId = from.User.Id,
            DeliveryStatusId = from.DeliveryStatus.Id,
            DeliveryAddressId = from.DeliveryAddress.Id,
            ProductId = from.Product.Id,
            WharehouseId = from.Warehouse.Id,
            ChangedById = from.ChangedBy.Id,
            Count = from.Count,
            ProductPrice = from.ProductPrice,
            DeliveryPrice = from.DeliveryPrice,
            DeliveryDays = from.DeliveryDays,
            Description = from.Description,
            CreatedAt = from.CreatedAt,
            UpdatedAt = from.UpdatedAt,
        };
    }
}