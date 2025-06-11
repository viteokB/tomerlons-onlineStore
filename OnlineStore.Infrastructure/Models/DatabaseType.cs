using OnlineStore.Core.Interfaces;
using OnlineStore.Core.Models;
using Type = OnlineStore.Core.Models.Type;

namespace OnlineStore.Repository.Models;

public class DatabaseType : IMapWith<Type, DatabaseType>, IMapWith<DatabaseType, Type>
{
    public int Id { get; set; }
    
    public string Name { get; set; } = null!;
    
    public string Description { get; set; } = null!;
    
    public ICollection<DatabaseProduct> Products { get; set; } = new List<DatabaseProduct>();
    
    public static DatabaseType Map(Type from)
    {
        return new DatabaseType
        {
            Id = from.Id,
            Name = from.Name,
            Description = from.Description
        };
    }

    public static Type Map(DatabaseType from)
    {
        return new Type
        {
            Id = from.Id,
            Name = from.Name,
            Description = from.Description
        };
    }
}