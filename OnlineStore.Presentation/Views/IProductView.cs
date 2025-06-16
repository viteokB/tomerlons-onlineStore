using OnlineStore.Core.Common.Pagination;
using OnlineStore.Core.Models;
using Presentation.Common;
using Type = OnlineStore.Core.Models.Type;

namespace Presentation.Views
{
    public interface IProductView : IView
    {
        ProductsParamets SearchParameters { get; set; }
        PaginatedResult<Product> PaginatedProducts { get; set; }
        Product? SelectedProduct { get; }
        User? CurrentUser { get; set; }
        
        // Selected items
        Type? SelectedType { get; set; }
        Brand? SelectedBrand { get; set; }
        Country? SelectedCountry { get; set; }
        
        // ComboBox data sources
        PaginatedResult<Type> PaginatedTypes { get; set; }
        PaginatedResult<Brand> PaginatedBrands { get; set; }
        PaginatedResult<Country> PaginatedCountries { get; set; }
        
        // Search requests
        SearchRequest<string> SearchTypesRequest { get; set; }
        SearchRequest<string> SearchBrandsRequest { get; set; }
        SearchRequest<string> SearchCountriesRequest { get; set; }
        
        // Events
        event Func<Task> SearchProducts;
        event Func<Task> SearchTypes;
        event Func<Task> SearchBrands;
        event Func<Task> SearchCountries;
        event Func<Task> PurchaseProduct;
        event Func<Task> NextPage;
        event Func<Task> PrevPage;
        
        // ComboBox events
        event EventHandler TypeSelectedIndexChanged;
        event EventHandler BrandSelectedIndexChanged;
        event EventHandler CountrySelectedIndexChanged;
        
        // Methods
        void ShowError(string message);
        void ShowSuccess(string message);
        void UpdatePaginationControls(bool canGoBack, bool canGoForward, int currentPage);
        void UpdateSearchControls();
    }
}