namespace OnlineStore.Core.Models;

public class Type
{
    public int Id { get; set; }
    
    public required string Name { get; set; }
    
    public required string Description { get; set; }

    public override string ToString()
        => Name.ToString();
}