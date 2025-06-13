using Microsoft.EntityFrameworkCore.Metadata;
using OnlineStore.Core.Common.Pagination;
using OnlineStore.Core.Models;
using Presentation.Common;
using IView = Presentation.Common.IView;
using Type = OnlineStore.Core.Models.Type;

namespace Presentation.Views;

public interface IAddProductView : IModalView
{
    public Product? SelectedProduct { get; set; }
        
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
    
    public Func<Task> UpdateProduct { get; set; }
    
    public Func<Task> DisactivateProduct { get; set; }
    
    public Func<Task> DeleteProduct { get; set; }
    
    public Func<Task> SearchBrands { get; set; }
    
    public SearchRequest<string> SearchBrandRequest { get; set; }
    
    public PaginatedResult<Brand> PaginatedBrands { get; set; }
    
    public Func<Task> SearchCountry { get; set; }
    
    public SearchRequest<string> SearchCountriesRequest { get; set; }
    
    public PaginatedResult<Country> PaginatedCountries { get; set; }
    
    public Func<Task> SearchType { get; set; }
    
    public SearchRequest<string> SearchTypesRequest { get; set; }
    
    public PaginatedResult<Type> PaginatedTypes { get; set; }
    
    public Func<Task> SearchProduct { get; set; }
    
    public ProductsParamets? ProductsParamets { get; set; }
    
    public SearchRequest<ProductsParamets> SearchProductRequest { get; set; }
    
    public PaginatedResult<Product> PaginatedProducts { get; set; }
    
    void ShowError(string message);
    
    void ShowGoodInfo(string message);
}