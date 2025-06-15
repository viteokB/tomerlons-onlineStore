using NetTopologySuite.Geometries;
using OnlineStore.Core.Interfaces;
using OnlineStore.Core.Models;
using Coordinate = OnlineStore.Core.Models.Coordinate;

namespace OnlineStore.Repository.Models;

public class DatabaseAddress : 
    IMapWith<DatabaseAddress, Address>,
    IMapWith<Address, DatabaseAddress>
{
    public int Id { get; set; }
    
    public string? Country { get; set; }
    
    public required string City { get; set; }
    
    public required string Street { get; set; }
    
    public required string HouseNumber { get; set; }
    
    public string? ApartmentNumber { get; set; }
    
    public required Point Coordinate { get; set; }
    
    public ICollection<DatabaseOrderHistory> Orders { get; set; } = new List<DatabaseOrderHistory>();
    
    public ICollection<DatabaseWharehouse> Wharehouses { get; set; } = new List<DatabaseWharehouse>();
    
    public static Address Map(DatabaseAddress from)
    {
        return new Address
        {
            Id = from.Id,
            Country = from.Country,
            City = from.City,
            Street = from.Street,
            HouseNumber = from.HouseNumber,
            ApartmentNumber = from.ApartmentNumber,
            Coordinate = new Coordinate(from.Coordinate.Y, from.Coordinate.X),
        };
    }

    public static DatabaseAddress Map(Address from)
    {
        return new DatabaseAddress
        {
            Id = from.Id,
            Country = from.Country,
            City = from.City,
            Street = from.Street,
            HouseNumber = from.HouseNumber,
            ApartmentNumber = from.ApartmentNumber,
            Coordinate = new Point(from.Coordinate.Longitude, from.Coordinate.Latitude)
        };
    }
}