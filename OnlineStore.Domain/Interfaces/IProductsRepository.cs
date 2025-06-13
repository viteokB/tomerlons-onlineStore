using OnlineStore.Core.Common;
using OnlineStore.Core.Common.Pagination;
using OnlineStore.Core.Models;

namespace OnlineStore.Core.Interfaces;

public interface IProductsRepository
{
    public Task<OperationResult> AddProduct(Product product, CancellationToken cancellationToken);
    
    public Task<OperationResult> UpdateProduct(int? id, Product product, CancellationToken cancellationToken);
    
    public Task<OperationResult> DeleteProduct(int? id, CancellationToken cancellationToken);
    
    public Task<OperationResult<PaginatedResult<Product>>> SearchProducts(
        SearchRequest<ProductsParamets> searchRequest, CancellationToken cancellationToken);
}