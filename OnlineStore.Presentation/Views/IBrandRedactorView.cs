using OnlineStore.Core.Common.Pagination;
using OnlineStore.Core.Models;
using Presentation.Common;

namespace Presentation.Views;

public interface IBrandRedactorView : IModalView
{
    public User? User { get; set; }
    
    public string BrandName { get; set; }
    
    public Country? SelectedCountry { get; set; }
    
    public Brand? SelectedBrand { get; set; }
    
    public Func<Task> CreateNewBrand { get; set; }
    
    public Func<Task> UpdateBrand { get; set; }
    
    public Func<Task> DeleteBrand { get; set; }
    
    public Func<Task> SearchCountry { get; set; }
    
    public Func<Task> SearchBrand { get; set; }
    
    public SearchRequest<string> SearchCountryRequest { get; set; }
    
    public SearchRequest<string> SearchBrandRequest { get; set; }
    
    public PaginatedResult<Brand> PaginatedBrands { get; set; }
    
    public PaginatedResult<Country> PaginatedCountries { get; set; }
    
    void ShowError(string message);
    
    void ShowGoodInfo(string message);
}