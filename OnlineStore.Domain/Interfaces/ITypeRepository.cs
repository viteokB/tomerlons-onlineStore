using OnlineStore.Core.Common;
using OnlineStore.Core.Common.Pagination;

namespace OnlineStore.Core.Interfaces;

public interface ITypeRepository
{
    public Task<OperationResult> AddType(Models.Type type,
        CancellationToken cancellationToken);
    
    public Task<OperationResult> DeleteType(Models.Type type,
        CancellationToken cancellationToken);
    
    public Task<OperationResult> UpdateType(Models.Type type,
        CancellationToken cancellationToken);

    public Task<OperationResult<List<Models.Type>>> GetTypes(CancellationToken cancellationToken);
    
    public Task<OperationResult<PaginatedResult<Models.Type>>> SearchTypes(
        SearchRequest<string> searchRequest, CancellationToken cancellationToken);
}