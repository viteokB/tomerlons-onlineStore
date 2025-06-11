using OnlineStore.Core.Interfaces;
using OnlineStore.Core.Models;

namespace OnlineStore.Repository.Models;

public class DatabaseBrand : IMapWith<DatabaseBrand, Brand>, IMapWith<Brand, DatabaseBrand>
{
    public int Id { get; set; }
    
    public int CountryId { get; set; }
    
    public DatabaseCountry Country { get; set; } = null!;
    
    public string Name { get; set; } = null!;
    
    public ICollection<DatabaseProduct> Products { get; set; } = new List<DatabaseProduct>();
    
    public static Brand Map(DatabaseBrand from)
    {
        return new Brand
        {
            Id = from.Id,
            Country = DatabaseCountry.Map(from.Country),
            Name = from.Name
        };
    }

    public static DatabaseBrand Map(Brand from)
    {
        return new DatabaseBrand
        {
            Id = from.Id,
            Country = DatabaseCountry.Map(from.Country),
            Name = from.Name
        };
    }
}