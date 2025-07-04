﻿using OnlineStore.Core.Interfaces;
using OnlineStore.Core.Models;
using OnlineStore.Core.Models.WhareHouse;

namespace OnlineStore.Repository.Models;

public class DatabaseWharehouse : 
    IMapWith<DatabaseWharehouse, Warehouse>,
    IMapWith<Warehouse, DatabaseWharehouse>
{
    public int Id { get; set; }
    
    public int AddressId { get; set; }

    public DatabaseAddress Address { get; set; } = null!;
    
    public string Name { get; set; } = null!;
    
    public bool IsActive { get; set; }
    
    public ICollection<DatabaseWharehouseProducts> WhProducts { get; set; } = new List<DatabaseWharehouseProducts>();
    
    public ICollection<DatabaseOrder> WhOrders { get; set; } = new List<DatabaseOrder>();


    public static Warehouse Map(DatabaseWharehouse from)
    {
        return new Warehouse
        {
            Id = from.Id,
            Name = from.Name,
            Address = DatabaseAddress.Map(from.Address),
            IsActive = from.IsActive,
        };
    }

    public static DatabaseWharehouse Map(Warehouse from)
    {
        return new DatabaseWharehouse
        {
            Id = from.Id,
            Name = from.Name,
            Address = DatabaseAddress.Map(from.Address),
            IsActive = from.IsActive,
        };
    }
}