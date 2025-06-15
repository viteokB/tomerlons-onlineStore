using OnlineStore.Core.Interfaces;
using OnlineStore.Core.Models;

namespace OnlineStore.Repository.Models;

public class DatabaseDeliveryStatus : 
    IMapWith<DatabaseDeliveryStatus, DeliveryStatus>,
    IMapWith<DeliveryStatus, DatabaseDeliveryStatus>
{
    public int Id { get; set; }
    
    public required string Name { get; set; }
    
    public string Description { get; set; } = string.Empty;
    
    public bool IsActive { get; set; } = true;
    
    public ICollection<DatabaseOrder> Orders { get; set; } = new List<DatabaseOrder>();
    
    public static DeliveryStatus Map(DatabaseDeliveryStatus from)
    {
        return new DeliveryStatus
        {
            Id = from.Id,
            Name = from.Name,
            Description = from.Description,
            IsActive = from.IsActive,
        };
    }

    public static DatabaseDeliveryStatus Map(DeliveryStatus from)
    {
        return new DatabaseDeliveryStatus
        {
            Id = from.Id,
            Name = from.Name,
            Description = from.Description,
            IsActive = from.IsActive
        };
    }
}