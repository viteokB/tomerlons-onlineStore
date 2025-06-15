using OnlineStore.Core.Common;
using OnlineStore.Core.Common.Pagination;
using OnlineStore.Core.Interfaces;
using OnlineStore.Core.Models;

namespace OnlineStore.Services.DeliveryService;

public class DeliveryService : IDeliveryService
{
    private readonly IAddressRepository _addressRepository;
    private readonly IUserRepository _userRepository;

    public DeliveryService(
        IAddressRepository addressRepository,
        IUserRepository userRepository)
    {
        _addressRepository = addressRepository;
        _userRepository = userRepository;
    }

    public async Task<OperationResult> AddAddress(Address address, User currentUser)
    {
        if (!IsAdmin(currentUser) && !IsManager(currentUser))
            return OperationResult.Fail("Insufficient permissions");

        return await _addressRepository.AddAddress(address, CancellationToken.None);
    }

    public async Task<OperationResult> UpdateAddress(int id, Address address, User currentUser)
    {
        if (!IsAdmin(currentUser) && !IsManager(currentUser))
            return OperationResult.Fail("Insufficient permissions");

        return await _addressRepository.UpdateAddress(id, address, CancellationToken.None);
    }

    public async Task<OperationResult> DeleteAddress(int id, User currentUser)
    {
        if (!IsAdmin(currentUser))
            return OperationResult.Fail("Insufficient permissions");

        return await _addressRepository.DeleteAddress(id, CancellationToken.None);
    }

    public async Task<OperationResult<List<Address>>> GetAddresses(User currentUser)
    {
        // Все пользователи могут просматривать адреса
        return await _addressRepository.GetAddresses(CancellationToken.None);
    }

    public async Task<OperationResult<PaginatedResult<Address>>> SearchAddresses(
        SearchRequest<string> request, User currentUser)
    {
        // Все пользователи могут искать адреса
        return await _addressRepository.SearchAddresses(request, CancellationToken.None);
    }

    private bool IsAdmin(User user)
    {
        return user?.Role?.Name?.Equals("admin", StringComparison.OrdinalIgnoreCase) ?? false;
    }

    private bool IsManager(User user)
    {
        return user?.Role?.Name?.Equals("manager", StringComparison.OrdinalIgnoreCase) ?? false;
    }
}