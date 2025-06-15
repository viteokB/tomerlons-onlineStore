using OnlineStore.Core.Common;
using OnlineStore.Core.Common.Pagination;
using OnlineStore.Core.Models.WhareHouse;

namespace OnlineStore.Core.Interfaces;

public interface IWarehouseRepository
{
    public Task<OperationResult> AddWarehouse(Warehouse warehouse, CancellationToken cancellationToken);
    
    public Task<OperationResult> UpdateWarehouse(int updateWhId, Warehouse warehouse, CancellationToken cancellationToken);
    
    public Task<OperationResult> DeleteWarehouse(int deleteWhId, CancellationToken cancellationToken);
    
    public Task<OperationResult<List<Warehouse>>> GetWarehouses(CancellationToken cancellationToken);
    
    public Task<OperationResult<PaginatedResult<Warehouse>>> SearchWarehouses(
        SearchRequest<string> searchRequest, CancellationToken cancellationToken); 
    
    public Task<OperationResult> UpdateWarehouseProductCount(
        int warehouseId, int productId, int changedBy, int count, CancellationToken cancellationToken);
}