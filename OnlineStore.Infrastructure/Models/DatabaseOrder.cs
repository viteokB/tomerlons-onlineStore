using OnlineStore.Core.Interfaces;
using OnlineStore.Core.Models;

namespace OnlineStore.Repository.Models;

public class DatabaseOrder : 
    IMapWith<DatabaseOrder, Order>,
    IMapWith<Order, DatabaseOrder>
{
    public int Id { get; set; }

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
    
    public DatabaseUser? ChangedByUser { get; set; } = null!;
    
    public int Count { get; set; }

    public float ProductPrice { get; set; }

    public float DeliveryPrice { get; set; }

    public int DeliveryDays { get; set; }

    public string Description { get; set; } = null!;
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime UpdatedAt { get; set; }
    
    public static Order Map(DatabaseOrder from)
    {
        if (from == null!) return null!;

        return new Order
        {
            Id = from.Id,
            User = DatabaseUser.Map(from.User),
            DeliveryStatus = DatabaseDeliveryStatus.Map(from.DeliveryStatus),
            DeliveryAddress = DatabaseAddress.Map(from.DeliveryAddress),
            Product = DatabaseProduct.Map(from.Product),
            Warehouse = DatabaseWharehouse.Map(from.Wharehouse),
            ChangedBy = from.ChangedByUser == null? null : DatabaseUser.Map(from.ChangedByUser),
            Count = from.Count,
            ProductPrice = from.ProductPrice,
            DeliveryPrice = from.DeliveryPrice,
            DeliveryDays = from.DeliveryDays,
            Description = from.Description,
            CreatedAt = from.CreatedAt,
            UpdatedAt = from.UpdatedAt
        };
    }

    public static DatabaseOrder Map(Order from)
    {
        if (from == null!) return null!;

        return new DatabaseOrder
        {
            Id = from.Id,
            UserId = from.User?.Id,
            User = DatabaseUser.Map(from.User),
            DeliveryStatusId = from.DeliveryStatus?.Id ?? 0,
            DeliveryStatus = DatabaseDeliveryStatus.Map(from.DeliveryStatus),
            DeliveryAddressId = from.DeliveryAddress?.Id ?? 0,
            DeliveryAddress = DatabaseAddress.Map(from.DeliveryAddress),
            ProductId = from.Product?.Id ?? 0,
            Product = DatabaseProduct.Map(from.Product),
            WharehouseId = from.Warehouse?.Id ?? 0,
            Wharehouse = DatabaseWharehouse.Map(from.Warehouse),
            ChangedById = from.ChangedBy?.Id,
            ChangedByUser = DatabaseUser.Map(from.ChangedBy),
            Count = from.Count,
            ProductPrice = from.ProductPrice,
            DeliveryPrice = from.DeliveryPrice,
            DeliveryDays = from.DeliveryDays,
            Description = from.Description,
            CreatedAt = from.CreatedAt,
            UpdatedAt = from.UpdatedAt
        };
    }
}