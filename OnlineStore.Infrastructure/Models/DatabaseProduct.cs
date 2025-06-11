using OnlineStore.Core.Interfaces;
using OnlineStore.Core.Models;
using Type = System.Type;

namespace OnlineStore.Repository.Models;

public class DatabaseProduct : IMapWith<DatabaseProduct, Product>, IMapWith<Product, DatabaseProduct>
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
    
    public static Product Map(DatabaseProduct from)
    {
        return new Product
        {
            Id = from.Id,
            Type = DatabaseType.Map(from.Type!),
            Country = DatabaseCountry.Map(from.Country!),
            ChangedBy = DatabaseUser.Map(from.ChangedBy!),
            Brand = DatabaseBrand.Map(from.Brand!),
            Name = from.Name,
            PhotoPath = from.PhotoPath,
            CatalogNumber = from.CatalogNumber,
            BasePrice = from.BasePrice,
            IsActive = from.IsActive,
            ChangedAt = from.ChangedAt,
        };
    }

    public static DatabaseProduct Map(Product from)
    {
        return new DatabaseProduct
        {
            Id = from.Id,
            Type = DatabaseType.Map(from.Type!),
            Country = DatabaseCountry.Map(from.Country!),
            ChangedBy = DatabaseUser.Map(from.ChangedBy!),
            Brand = DatabaseBrand.Map(from.Brand!),
            Name = from.Name,
            PhotoPath = from.PhotoPath,
            CatalogNumber = from.CatalogNumber,
            BasePrice = from.BasePrice,
            IsActive = from.IsActive,
            ChangedAt = from.ChangedAt,
        };
    }
}