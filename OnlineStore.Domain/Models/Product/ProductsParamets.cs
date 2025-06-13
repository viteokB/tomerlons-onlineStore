namespace OnlineStore.Core.Models;

public class ProductsParamets
{
    public string? ProductName { get; set; }
    
    public Type? ProductType { get; set; }
    
    public Brand? Brand { get; set; }
    
    public Country? Country { get; set; }

    public bool IsActive { get; set; } = true;
}