using OnlineStore.Core;
using OnlineStore.Core.Interfaces;
using OnlineStore.Core.Models;

namespace OnlineStore.Repository.Models;

public class DatabaseRole 
    : IMapWith<DatabaseRole, UserRole>, IMapWith<UserRole, DatabaseRole>
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

    public static DatabaseRole Map(UserRole from)
    {
        return new DatabaseRole
        {
            Id = from.Id,
            Name = from.Name
        };
    }
}