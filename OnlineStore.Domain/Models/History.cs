namespace OnlineStore.Core.Models;

public class History<T> where T : class
{
    public required T Item { get; set; }
    
    public required List<T> ItemStory { get; set; }
}