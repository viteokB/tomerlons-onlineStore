namespace OnlineStore.Core.Models.WhareHouse;

public class Warehouse
{
    public int Id { get; set; }
    
    public required Address Address { get; set; }
    
    public required string Name { get; set; }
    
    public bool IsActive { get; set; }
}