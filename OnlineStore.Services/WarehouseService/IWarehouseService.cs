using OnlineStore.Core.Common;
using OnlineStore.Core.Common.Pagination;
using OnlineStore.Core.Models;
using OnlineStore.Core.Models.WhareHouse;

namespace OnlineStore.Services.WarehouseService;

public interface IWarehouseService
{
    Task<OperationResult> AddWarehouse(Warehouse warehouse, User currentUser);
    
    Task<OperationResult> UpdateWarehouse(int id, Warehouse warehouse, User currentUser);
    
    Task<OperationResult> DeleteWarehouse(int id, User currentUser);
    
    Task<OperationResult<List<Warehouse>>> GetWarehouses(User currentUser);
    
    Task<OperationResult<PaginatedResult<Warehouse>>> SearchWarehouses(
        SearchRequest<string> request, User currentUser);
    
    Task<OperationResult> UpdateWarehouseProductCount(
        int warehouseId, int productId, int changedBy, int count);
}