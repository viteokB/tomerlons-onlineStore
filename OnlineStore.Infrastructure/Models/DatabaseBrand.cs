using OnlineStore.Core.Models;

namespace OnlineStore.Repository.Models;

public class DatabaseBrand
{
    public int Id { get; set; }
    
    public int CountryId { get; set; }
    
    public DatabaseCountry Country { get; set; } = null!;
    
    public string Name { get; set; } = null!;
    
    public ICollection<DatabaseProduct> Products { get; set; } = new List<DatabaseProduct>();
}