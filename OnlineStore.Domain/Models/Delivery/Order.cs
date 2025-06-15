using OnlineStore.Core.Models.WhareHouse;

namespace OnlineStore.Core.Models;

public class Order
{
    public int Id { get; set; }
    
    public User User { get; set; } = null!;
    
    public Address DeliveryAddress { get; set; } = null!;

    public DeliveryStatus DeliveryStatus { get; set; } = null!;
    
    public Product Product { get; set; } = null!;

    public Warehouse Warehouse { get; set; } = null!;
    
    public User? ChangedBy { get; set; }
    
    public int Count { get; set; }
    
    public float ProductPrice { get; set; }
    
    public float DeliveryPrice { get; set; }
    
    public int DeliveryDays { get; set; }
    
    public string Description { get; set; } = null!;
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime UpdatedAt { get; set; }
}