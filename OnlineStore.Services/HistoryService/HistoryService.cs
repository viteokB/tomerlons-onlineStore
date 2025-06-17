using OnlineStore.Core.Common;
using OnlineStore.Core.Common.Pagination;
using OnlineStore.Core.Interfaces;
using OnlineStore.Core.Interfaces.HistoryParameters;
using OnlineStore.Core.Models;

namespace OnlineStore.Services.HistoryService;

public class HistoryService : IHistoryService
{
    private readonly IHistoryRepository _historyRepository;
    private readonly IProductsRepository _productsRepository;
    private readonly IWarehouseRepository _warehouseRepository;

    public HistoryService(
        IHistoryRepository historyRepository,
        IProductsRepository productsRepository,
        IWarehouseRepository warehouseRepository)
    {
        _historyRepository = historyRepository;
        _productsRepository = productsRepository;
        _warehouseRepository = warehouseRepository;
    }

    public async Task<OperationResult<PaginatedResult<OrderHistory>>> GetOrderHistory(
        int productId, SearchRequest<OrderHistorySearchParameters> request, User currentUser)
    {
        var productResult = await _productsRepository
            .GetProductById(productId, CancellationToken.None);
        
        if (!productResult.IsSuccess)
            return OperationResult<PaginatedResult<OrderHistory>>.Fail("Продукт не найден")!;

        return await _historyRepository
            .GetOrderHistory(productId, request, CancellationToken.None);
    }

    public async Task<OperationResult<PaginatedResult<ProductHistory>>> GetProductHistory(
        int productId, SearchRequest<ProductHistorySearchParameters> request, User currentUser)
    {
        var productResult = await _productsRepository
            .GetProductById(productId, CancellationToken.None);
        
        if (!productResult.IsSuccess)
            return OperationResult<PaginatedResult<ProductHistory>>.Fail("Продукт не найден")!;

        return await _historyRepository
            .GetProductHistory(productId, request, CancellationToken.None);
    }

    public async Task<OperationResult<PaginatedResult<WarehouseProductHistory>>> GetWarehouseProductHistory(
        int warehouseId, int productId, SearchRequest<WarehouseProductHistorySearchParameters> request, User currentUser)
    {
        var warehouseResult = await _warehouseRepository.GetWarehouse(warehouseId);
        
        if (!warehouseResult.IsSuccess)
            return OperationResult<PaginatedResult<WarehouseProductHistory>>.Fail("Склад не найден")!;
        
        var productResult = await _productsRepository
            .GetProductById(productId, CancellationToken.None);
        
        if (!productResult.IsSuccess)
            return OperationResult<PaginatedResult<WarehouseProductHistory>>.Fail("Продукт не найден")!;

        return await _historyRepository
            .GetWarehouseProductHistory(warehouseId, productId, request, CancellationToken.None);
    }
}