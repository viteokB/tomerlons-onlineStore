namespace OnlineStore.Core.Models;

public class Brand
{
    public int Id { get; set; }
    
    public required Country Country { get; set; }
    
    public required string Name { get; set; }
    
    public override string ToString()
        => Name;
}