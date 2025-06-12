using Microsoft.EntityFrameworkCore.Metadata;
using OnlineStore.Core.Models;
using IView = Presentation.Common.IView;
using Type = OnlineStore.Core.Models.Type;

namespace Presentation.Views;

public interface IAddProductView : IView
{
    public Type? Type { get; set; }
    
    public Country? Country { get; set; }
    
    public User? ChangedBy { get; set; }
    
    public Brand? Brand { get; set; }
    
    public string Name { get; set; }
    
    public string? PhotoPath { get; set; }
    
    public string CatalogNumber { get; set; }
    
    public float BasePrice { get; set; }
    
    public bool IsActive { get; set; }
    
    public Func<Task> CreateNewProduct { get; set; }
    
    public Func<Task> CreateNewCountry { get; set; }
    
    public Func<Task> CreateNewBrand { get; set; }
    
    void ShowError(string message);
    
    void ShowGoodInfo(string message);
}