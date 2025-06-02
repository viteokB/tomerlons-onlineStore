using OnlineStore.Core;
using OnlineStore.Core.Interfaces;

namespace OnlineStore.Repository.Models;

public class DatabaseRole : IMapWith<DatabaseRole, UserRole>
{
    public int Id { get; set; }
    
    public required string Name { get; set; }
    
    public ICollection<DatabaseUser> Users { get; set; } = new List<DatabaseUser>();
    
    public static UserRole Map(DatabaseRole from)
    {
        return new UserRole()
        {
            Id = from.Id,
            Name = from.Name
        };
    }
}