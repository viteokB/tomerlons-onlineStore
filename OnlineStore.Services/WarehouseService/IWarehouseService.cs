using OnlineStore.Core.Common;
using OnlineStore.Core.Common.Pagination;
using OnlineStore.Core.Models;
using OnlineStore.Core.Models.WhareHouse;

namespace OnlineStore.Services.WarehouseService;

public interface IWarehouseService
{
    Task<OperationResult<Warehouse>> AddWarehouse(Warehouse warehouse, User currentUser);
    
    Task<OperationResult> UpdateWarehouse(int id, Warehouse warehouse, User currentUser);
    
    Task<OperationResult> DeleteWarehouse(int id, User currentUser);
    
    Task<OperationResult<List<Warehouse>>> GetWarehouses(User currentUser);
    
    Task<OperationResult<PaginatedResult<Warehouse>>> SearchWarehouses(
        SearchRequest<string> request, User currentUser);

    public Task<OperationResult<Address>> GetAddress(int id, CancellationToken cancellationToken);

    Task<OperationResult<int>>
        GetWarehouseProducts(int warehouseId, int productId, CancellationToken cancellationToken);
    
    Task<OperationResult> UpdateWarehouseProductCount(
        int warehouseId, int productId, User changedBy, int count);
    
    
}