using OnlineStore.Core.Common;
using OnlineStore.Core.Common.Pagination;
using OnlineStore.Core.Models;

namespace OnlineStore.Core.Interfaces;

public interface ICountryRepository
{
    public Task<OperationResult> AddCountry(Country type, CancellationToken cancellationToken);
    
    public Task<OperationResult> DeleteCountry(Country type, CancellationToken cancellationToken);
    
    public Task<OperationResult> UpdateCountry(Country type, CancellationToken cancellationToken);

    public Task<OperationResult<List<Country>>> GetCountries(CancellationToken cancellationToken);
    
    public Task<OperationResult<PaginatedResult<Country>>> SearchTypes(
        SearchRequest<string> searchRequest, CancellationToken cancellationToken);
}