using OnlineStore.Core.Common.Pagination;
using OnlineStore.Core.Models;
using Presentation.Common;
using Type = OnlineStore.Core.Models.Type;

namespace Presentation.Views;

public interface ITypeRedactorView : IModalView
{
    public User? User { get; set; }
    
    public string TypeName { get; set; }
    
    public string TypeDescription { get; set; }
    
    public Type? SelectedType { get; set; }
    
    public Func<Task> CreateNewType { get; set; }
    
    public Func<Task> UpdateType { get; set; }
    
    public Func<Task> DeleteType { get; set; }
    
    public Func<Task> SearchType { get; set; }
    
    public SearchRequest<string> SearchRequest { get; set; }
    
    public PaginatedResult<Type> PaginatedTypes { get; set; }
    
    void ShowError(string message);
    
    void ShowGoodInfo(string message);
}