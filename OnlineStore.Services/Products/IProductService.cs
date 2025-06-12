using OnlineStore.Core.Common;
using OnlineStore.Core.Common.Pagination;
using OnlineStore.Core.Models;
using Type = OnlineStore.Core.Models.Type;

namespace OnlineStore.Services.Products;

public interface IProductService
{
    #region Brand Operations
    Task<OperationResult> AddBrand(Brand brand, User currentUser);
    Task<OperationResult> UpdateBrand(Brand brand, User currentUser);
    Task<OperationResult> DeleteBrand(Brand brand, User currentUser);
    Task<OperationResult<List<Brand>>> GetBrands(User currentUser);
    Task<OperationResult<PaginatedResult<Brand>>> SearchBrands(SearchRequest<string> request, User currentUser);
    #endregion

    #region Type Operations
    Task<OperationResult> AddType(Type type, User currentUser);
    Task<OperationResult> UpdateType(int id, Type type, User currentUser);
    Task<OperationResult> DeleteType(Type type, User currentUser);
    Task<OperationResult<List<Type>>> GetTypes(User currentUser);
    Task<OperationResult<PaginatedResult<Type>>> SearchTypes(SearchRequest<string> request, User currentUser);
    #endregion

    #region Country Operations
    Task<OperationResult> AddCountry(Country country, User currentUser);
    Task<OperationResult> UpdateCountry(Country country, User currentUser);
    Task<OperationResult> DeleteCountry(Country country, User currentUser);
    Task<OperationResult<List<Country>>> GetCountries(User currentUser);
    Task<OperationResult<PaginatedResult<Country>>> SearchCountries(SearchRequest<string> request, User currentUser);
    #endregion

    #region Product Operations
    Task<OperationResult> AddProduct(Product product, User currentUser);
    Task<OperationResult> UpdateProduct(Product product, User currentUser);
    Task<OperationResult> DeleteProduct(Product product, User currentUser);
    Task<OperationResult<PaginatedResult<Product>>> SearchProducts(SearchRequest<ProductsParamets> request, User currentUser);
    #endregion
}