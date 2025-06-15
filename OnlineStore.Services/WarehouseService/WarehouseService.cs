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
    private readonly IAddressRepository _addressRepository;

    public WarehouseService(
        IWarehouseRepository warehouseRepository,
        IUserRepository userRepository,
        IAddressRepository addressRepository)
    {
        _warehouseRepository = warehouseRepository;
        _userRepository = userRepository;
        _addressRepository = addressRepository;
    }

    #region Warehouse Operations

    public async Task<OperationResult<Warehouse>> AddWarehouse(Warehouse warehouse, User currentUser)
    {
        if (!IsAdmin(currentUser) && !IsManager(currentUser))
            return OperationResult<Warehouse>.Fail("Недостаточно прав для выполнения операции")!;

        return await _warehouseRepository.AddWarehouse(warehouse, CancellationToken.None);
    }

    public async Task<OperationResult> UpdateWarehouse(int id, Warehouse warehouse, User currentUser)
    {
        if (!IsAdmin(currentUser) && !IsManager(currentUser))
            return OperationResult.Fail("Недостаточно прав для выполнения операции");

        try
        {
            // Получаем текущий склад из репозитория
            var existingWarehouseResult = await _warehouseRepository.GetWarehouse(id);
            if (!existingWarehouseResult.IsSuccess)
            {
                return existingWarehouseResult;
            }

            var existingWarehouse = existingWarehouseResult.Data;

            // Проверяем, изменился ли адрес
            if (warehouse.Address != null && 
                (existingWarehouse.Address == null || 
                 !AreAddressesEqual(existingWarehouse.Address, warehouse.Address)))
            {
                // Обновляем или создаем адрес
                OperationResult<Address> addressResult;
                if (warehouse.Address.Id == 0)
                {
                    addressResult = await _addressRepository.AddAddress(warehouse.Address, CancellationToken.None);
                }
                else
                {
                    addressResult = await _addressRepository.UpdateAddress(
                        warehouse.Address.Id, 
                        warehouse.Address, 
                        CancellationToken.None);
                }

                if (!addressResult.IsSuccess)
                {
                    return addressResult;
                }

                // Обновляем ссылку на адрес
                warehouse.Address = addressResult.Data;
            }

            // Обновляем сам склад
            return await _warehouseRepository.UpdateWarehouse(id, warehouse, CancellationToken.None);
        }
        catch (Exception ex)
        {
            return OperationResult.Fail($"Ошибка обновления склада: {ex.Message}");
        }
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

    public async Task<OperationResult<Address>> GetAddress(int id, CancellationToken cancellationToken)
    {
        return await _addressRepository.GetAddress(id, cancellationToken);
    }

    public async Task<OperationResult<int>> GetWarehouseProducts(int warehouseId, int productId, CancellationToken cancellationToken)
    {
        return await _warehouseRepository.GetWarehouseProductsCount(warehouseId, productId, cancellationToken);
    }

    public async Task<OperationResult> UpdateWarehouseProductCount(
        int warehouseId, int productId, User changedBy, int count)
    {
        if (!IsAdmin(changedBy) && !IsManager(changedBy))
            return OperationResult.Fail("Недостаточно прав для выполнения операции");

        return await _warehouseRepository.UpdateWarehouseProductCount(
            warehouseId, productId, changedBy.Id, count, CancellationToken.None);
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
    
    private bool AreAddressesEqual(Address a, Address b)
    {
        return a.Country == b.Country &&
               a.City == b.City &&
               a.Street == b.Street &&
               a.HouseNumber == b.HouseNumber &&
               a.ApartmentNumber == b.ApartmentNumber &&
               a.Coordinate.Latitude == b.Coordinate.Latitude &&
               a.Coordinate.Longitude == b.Coordinate.Longitude;
    }

    #endregion
}