namespace OnlineStore.Repository.Models;

public class DatabaseCountry
{
    public int Id { get; set; }
    
    public string Name { get; set; } = null!;
    
    public string Code { get; set; } = null!;
    
    public ICollection<DatabaseProduct> Products { get; set; } = new List<DatabaseProduct>();
    
    public ICollection<DatabaseBrand> Brands { get; set; } = new List<DatabaseBrand>();
}