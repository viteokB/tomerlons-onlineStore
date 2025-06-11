namespace OnlineStore.Core.Models;

public class Address
{
    public int Id { get; set; }
    
    public string? Country { get; set; }
    
    public required string City { get; set; }
    
    public required string Street { get; set; }
    
    public required string HouseNumber { get; set; }
    
    public string? ApartmentNumber { get; set; }
    
    public required Coordinate Coordinate { get; set; }
}