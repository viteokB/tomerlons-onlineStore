using NetTopologySuite.Geometries;

namespace OnlineStore.Repository.Models;

public class DatabaseAddress
{
    public int Id { get; set; }
    
    public string? Country { get; set; }
    
    public required string City { get; set; }
    
    public required string Street { get; set; }
    
    public required string HouseNumber { get; set; }
    
    public string? ApartmentNumber { get; set; }
    
    public required Point Coordinate { get; set; }
    
    // public required float Latitude { get; set; }
    //
    // public required float Longtitude { get; set; }
    
    public ICollection<DatabaseOrderHistory> Orders { get; set; } = new List<DatabaseOrderHistory>();
    
    public ICollection<DatabaseWharehouse> Wharehouses { get; set; } = new List<DatabaseWharehouse>();
}