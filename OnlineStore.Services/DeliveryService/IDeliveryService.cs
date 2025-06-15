using OnlineStore.Core.Common;
using OnlineStore.Core.Common.Pagination;
using OnlineStore.Core.Models;

namespace OnlineStore.Services.DeliveryService;

public interface IDeliveryService
{
    Task<OperationResult> AddAddress(Address address, User currentUser);
    
    Task<OperationResult> UpdateAddress(int id, Address address, User currentUser);
    
    Task<OperationResult> DeleteAddress(int id, User currentUser);
    
    Task<OperationResult<List<Address>>> GetAddresses(User currentUser);
    
    Task<OperationResult<PaginatedResult<Address>>> SearchAddresses(
        SearchRequest<string> request, User currentUser);
}