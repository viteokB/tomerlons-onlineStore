namespace OnlineStore.Core.Models;

public class User
{
    public int Id { get; set; }
    
    public required UserRole Role { get; set; }
    
    public required string Email { get; set; }
    
    public string HashedPassword { get; set; } = null!;

    public DateTime CreatedDate { get; set; }
}