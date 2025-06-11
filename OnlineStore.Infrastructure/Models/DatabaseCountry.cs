using OnlineStore.Core.Interfaces;
using OnlineStore.Core.Models;

namespace OnlineStore.Repository.Models;

public class DatabaseCountry : IMapWith<DatabaseCountry, Country>, IMapWith<Country, DatabaseCountry>
{
    public int Id { get; set; }
    
    public string Name { get; set; } = null!;
    
    public string Code { get; set; } = null!;
    
    public ICollection<DatabaseProduct> Products { get; set; } = new List<DatabaseProduct>();
    
    public ICollection<DatabaseBrand> Brands { get; set; } = new List<DatabaseBrand>();
    
    public static Country Map(DatabaseCountry from)
    {
        return new Country
        {
            Id = from.Id,
            Name = from.Name,
            Code = from.Code, 
        };
    }

    public static DatabaseCountry Map(Country from)
    {
        return new DatabaseCountry
        {
            Id = from.Id,
            Name = from.Name,
            Code = from.Code, 
        };
    }
}