using OnlineStore.Core.Common;
using OnlineStore.Core.Common.Pagination;
using OnlineStore.Core.Models;

namespace OnlineStore.Core.Interfaces;

public interface IBrandRepository
{
    public Task<OperationResult> AddBrand(Brand type, CancellationToken cancellationToken);
    
    public Task<OperationResult> DeleteBrand(Brand type, CancellationToken cancellationToken);
    
    public Task<OperationResult> UpdateBrand(Brand type, CancellationToken cancellationToken);

    public Task<OperationResult<List<Brand>>> GetBrands(CancellationToken cancellationToken);
    
    public Task<OperationResult<PaginatedResult<Brand>>> SearchBrand(
        SearchRequest<string> searchRequest, CancellationToken cancellationToken);
}