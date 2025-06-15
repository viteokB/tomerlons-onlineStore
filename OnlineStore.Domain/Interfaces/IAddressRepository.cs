using OnlineStore.Core.Common;
using OnlineStore.Core.Common.Pagination;
using OnlineStore.Core.Models;

namespace OnlineStore.Core.Interfaces;

public interface IAddressRepository
{
    Task<OperationResult<Address>> AddAddress(Address address, CancellationToken cancellationToken);
    
    Task<OperationResult<Address>> UpdateAddress(int id, Address address, CancellationToken cancellationToken);
    
    Task<OperationResult> DeleteAddress(int id, CancellationToken cancellationToken);
    
    Task<OperationResult<List<Address>>> GetAddresses(CancellationToken cancellationToken);
    
    Task<OperationResult<Address>> GetAddress(int id, CancellationToken cancellationToken);
    
    Task<OperationResult<PaginatedResult<Address>>> SearchAddresses(
        SearchRequest<string> request, CancellationToken cancellationToken);
}