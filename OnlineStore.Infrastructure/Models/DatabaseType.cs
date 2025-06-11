using OnlineStore.Core.Models;

namespace OnlineStore.Repository.Models;

public class DatabaseType
{
    public int Id { get; set; }
    
    public string Name { get; set; } = null!;
    
    public string Description { get; set; } = null!;
    
    public ICollection<DatabaseProduct> Products { get; set; } = new List<DatabaseProduct>();
}