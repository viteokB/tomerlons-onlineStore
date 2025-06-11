using OnlineStore.Core.Models;
using Type = System.Type;

namespace OnlineStore.Repository.Models;

public class DatabaseProduct
{
    public int Id { get; set; }
    
    public int? TypeId { get; set; }
    
    public DatabaseType? Type { get; set; } = null!;
    
    public int? CountryId { get; set; }
    
    public DatabaseCountry? Country { get; set; } = null!;
    
    public int? ChangedById { get; set; }
    
    public DatabaseUser? ChangedBy { get; set; } = null!;
    
    public int? BrandId { get; set; }
    
    public DatabaseBrand? Brand { get; set; } = null!;
    
    public string Name { get; set; } = null!;

    public string? PhotoPath { get; set; }

    public string CatalogNumber { get; set; } = null!;

    public float BasePrice { get; set; }
    
    public bool IsActive { get; set; }
    
    public DateTime ChangedAt { get; set; }
    
    public ICollection<DatabaseWharehouseProducts> WhProducts { get; set; } = new List<DatabaseWharehouseProducts>();
    
    public ICollection<DatabaseOrder> Orders { get; set; } = new List<DatabaseOrder>();
}