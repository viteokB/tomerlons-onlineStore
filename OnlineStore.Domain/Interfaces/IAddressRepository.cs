using OnlineStore.Core.Common;
using OnlineStore.Core.Common.Pagination;
using OnlineStore.Core.Models;

namespace OnlineStore.Core.Interfaces;

public interface IAddressRepository
{
    Task<OperationResult> AddAddress(Address address, CancellationToken cancellationToken);
    
    Task<OperationResult> UpdateAddress(int id, Address address, CancellationToken cancellationToken);
    
    Task<OperationResult> DeleteAddress(int id, CancellationToken cancellationToken);
    
    Task<OperationResult<List<Address>>> GetAddresses(CancellationToken cancellationToken);
    
    Task<OperationResult<PaginatedResult<Address>>> SearchAddresses(
        SearchRequest<string> request, CancellationToken cancellationToken);
}