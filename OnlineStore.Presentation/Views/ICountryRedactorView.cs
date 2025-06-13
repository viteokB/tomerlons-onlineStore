using OnlineStore.Core.Common.Pagination;
using OnlineStore.Core.Models;
using Presentation.Common;

namespace Presentation.Views;

public interface ICountryRedactorView : IModalView
{
    public User? User { get; set; }
    
    public string CountryName { get; set; }
    
    public string CountryCode { get; set; }
    
    public Country? SelectedCountry { get; set; }
    
    public Func<Task> CreateNewCountry { get; set; }
    
    public Func<Task> UpdateCountry { get; set; }
    
    public Func<Task> DeleteCountry { get; set; }
    
    public Func<Task> SearchCountry { get; set; }
    
    public SearchRequest<string> SearchRequest { get; set; }
    
    public PaginatedResult<Country> PaginatedCountries { get; set; }
    
    void ShowError(string message);
    
    void ShowGoodInfo(string message);
}