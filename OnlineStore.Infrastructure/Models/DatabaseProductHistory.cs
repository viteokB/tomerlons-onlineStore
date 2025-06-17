using OnlineStore.Core.Models;

namespace OnlineStore.Repository.Models;

public class DatabaseProductHistory
{
    public int Id { get; set; }
    
    public int? TypeId { get; set; }
    
    public DatabaseType? Type { get; set; } = null!;
    
    public int ProductId { get; set; }
    
    public DatabaseProduct Product { get; set; } = null!;
    
    public int? CountryId { get; set; }
    
    public DatabaseCountry? Country { get; set; } = null!;
    
    public int? ChangedById { get; set; }
    
    public DatabaseUser? ChangedBy { get; set; } = null!;
    
    public int? BrandId { get; set; }
    
    public DatabaseBrand? Brand { get; set; } = null!;
    
    public string Name { get; set; } = null!;

    public string? PhotoPath { get; set; } = null!;

    public string CatalogNumber { get; set; } = null!;

    public float BasePrice { get; set; }
    
    public bool IsActive { get; set; }
    
    public DateTime ChangedAt { get; set; }

    public static DatabaseProductHistory CreateHistory(DatabaseProduct product)
    {
        return new DatabaseProductHistory()
        {
            ProductId = product.Id,
            TypeId = product.Type?.Id,
            CountryId = product.Country?.Id,
            BrandId = product.Brand?.Id,
            Name = product.Name,
            PhotoPath = product.PhotoPath,
            CatalogNumber = product.CatalogNumber,
            BasePrice = product.BasePrice,
            IsActive = product.IsActive,
            ChangedById = product.ChangedBy?.Id,
            ChangedAt = product.ChangedAt,
        };
    }
    
    public static DatabaseProductHistory CreateHistory(Product product)
    {
        return new DatabaseProductHistory()
        {
            ProductId = product.Id,
            TypeId = product.Type?.Id,
            CountryId = product.Country?.Id,
            BrandId = product.Brand?.Id,
            Name = product.Name,
            PhotoPath = product.PhotoPath,
            CatalogNumber = product.CatalogNumber,
            BasePrice = product.BasePrice,
            IsActive = product.IsActive,
            ChangedById = product.ChangedBy?.Id,
            ChangedAt = product.ChangedAt,
        };
    }
}