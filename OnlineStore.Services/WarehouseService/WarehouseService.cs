using OnlineStore.Core.Common;
using OnlineStore.Core.Common.Pagination;
using OnlineStore.Core.Interfaces;
using OnlineStore.Core.Models;
using OnlineStore.Core.Models.WhareHouse;

namespace OnlineStore.Services.WarehouseService;

public class WarehouseService : IWarehouseService
{
    private readonly IWarehouseRepository _warehouseRepository;
    private readonly IUserRepository _userRepository;

    public WarehouseService(
        IWarehouseRepository warehouseRepository,
        IUserRepository userRepository)
    {
        _warehouseRepository = warehouseRepository;
        _userRepository = userRepository;
    }

    #region Warehouse Operations

    public async Task<OperationResult> AddWarehouse(Warehouse warehouse, User currentUser)
    {
        if (!IsAdmin(currentUser) && !IsManager(currentUser))
            return OperationResult.Fail("Недостаточно прав для выполнения операции");

        return await _warehouseRepository.AddWarehouse(warehouse, CancellationToken.None);
    }

    public async Task<OperationResult> UpdateWarehouse(int id, Warehouse warehouse, User currentUser)
    {
        if (!IsAdmin(currentUser) && !IsManager(currentUser))
            return OperationResult.Fail("Недостаточно прав для выполнения операции");

        return await _warehouseRepository.UpdateWarehouse(id, warehouse, CancellationToken.None);
    }

    public async Task<OperationResult> DeleteWarehouse(int id, User currentUser)
    {
        if (!IsAdmin(currentUser))
            return OperationResult.Fail("Недостаточно прав для выполнения операции");

        return await _warehouseRepository.DeleteWarehouse(id, CancellationToken.None);
    }

    public async Task<OperationResult<List<Warehouse>>> GetWarehouses(User currentUser)
    {
        // Все пользователи могут просматривать склады
        return await _warehouseRepository.GetWarehouses(CancellationToken.None);
    }

    public async Task<OperationResult<PaginatedResult<Warehouse>>> SearchWarehouses(
        SearchRequest<string> request, User currentUser)
    {
        // Все пользователи могут искать склады
        return await _warehouseRepository.SearchWarehouses(request, CancellationToken.None);
    }

    public async Task<OperationResult> UpdateWarehouseProductCount(
        int warehouseId, int productId, int changedBy, int count, User currentUser)
    {
        if (!IsAdmin(currentUser) && !IsManager(currentUser))
            return OperationResult.Fail("Недостаточно прав для выполнения операции");

        return await _warehouseRepository.UpdateWarehouseProductCount(
            warehouseId, productId, changedBy, count, CancellationToken.None);
    }

    #endregion

    #region Helper Methods

    private bool IsAdmin(User user)
    {
        return user?.Role?.Name?.Equals("админ", StringComparison.OrdinalIgnoreCase) ?? false;
    }

    private bool IsManager(User user)
    {
        return user?.Role?.Name?.Equals("менеджер", StringComparison.OrdinalIgnoreCase) ?? false;
    }

    private bool IsClient(User user)
    {
        return user?.Role?.Name?.Equals("клиент", StringComparison.OrdinalIgnoreCase) ?? false;
    }

    #endregion
}