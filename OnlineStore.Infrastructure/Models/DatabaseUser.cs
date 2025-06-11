using OnlineStore.Core;
using OnlineStore.Core.Interfaces;
using OnlineStore.Core.Models;

namespace OnlineStore.Repository.Models;

public class DatabaseUser : IMapWith<DatabaseUser, User>, IMapWith<User, DatabaseUser>
{
    public int Id { get; set; }
    
    public int RoleId { get; set; }
    
    public DatabaseRole Role { get; set; } = null!;

    public required string Email { get; set; }
    
    public required string HashedPassword { get; set; }
    
    public DateTime CreatedDate { get; set; }
    
    public static User Map(DatabaseUser from)
    {
        return new User()
        {
            Id = from.Id,
            Role = DatabaseRole.Map(from.Role),
            Email = from.Email,
            HashedPassword = from.HashedPassword,
            CreatedDate = from.CreatedDate
        };
    }

    public static DatabaseUser Map(User from)
    {
        return new DatabaseUser()
        {
            Id = from.Id,
            Role = DatabaseRole.Map(from.Role),
            Email = from.Email,
            HashedPassword = from.HashedPassword,
            CreatedDate = from.CreatedDate
        };
    }
}