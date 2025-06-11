namespace OnlineStore.Core.Models.WhareHouse;

public class Wharehouse
{
    public int Id { get; set; }
    
    public required Address Address { get; set; }
    
    public required string Name { get; set; }
}