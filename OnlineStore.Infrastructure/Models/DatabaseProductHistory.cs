using OnlineStore.Core.Models;

namespace OnlineStore.Repository.Models;

public class DatabaseProductHistory
{
    public int Id { get; set; }
    
    public int TypeId { get; set; }
    
    public int ProductId { get; set; }
    
    public Product Product { get; set; } = null!;
    
    public DatabaseType Type { get; set; } = null!;
    
    public int CountryId { get; set; }
    
    public DatabaseCountry Country { get; set; } = null!;
    
    public int ChangedById { get; set; }
    
    public DatabaseUser ChangedBy { get; set; } = null!;
    
    public int BrandId { get; set; }
    
    public DatabaseBrand Brand { get; set; } = null!;
    
    public string Name { get; set; } = null!;

    public string PhotoPath { get; set; } = null!;

    public string CatalogNumber { get; set; } = null!;

    public float BasePrice { get; set; }
    
    public bool IsActive { get; set; }
    
    public DateTime ChangedAt { get; set; }
}