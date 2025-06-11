using OnlineStore.Core.Models;

namespace OnlineStore.Repository.Models;

public class DatabaseWharehouse
{
    public int Id { get; set; }
    
    public int AddressId { get; set; }

    public DatabaseAddress Address { get; set; } = null!;
    
    public string Name { get; set; } = null!;
    
    public ICollection<DatabaseWharehouseProducts> WhProducts { get; set; } = new List<DatabaseWharehouseProducts>();
    
    public ICollection<DatabaseOrder> WhOrders { get; set; } = new List<DatabaseOrder>();
}