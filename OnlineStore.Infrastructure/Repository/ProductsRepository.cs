using Microsoft.EntityFrameworkCore;
using OnlineStore.Core.Common;
using OnlineStore.Core.Common.Pagination;
using OnlineStore.Core.Interfaces;
using OnlineStore.Core.Models;
using OnlineStore.Repository.Models;

namespace OnlineStore.Repository.Repository;

public class ProductsRepository : IProductsRepository
{
    private readonly OnlineStoreDbContext _dbContext;
    
    private readonly DbSet<DatabaseProduct> _databaseProducts;

    public ProductsRepository(OnlineStoreDbContext dbContext)
    {
        _dbContext = dbContext;
        _databaseProducts = dbContext.Products;
    }
    
    public async Task<OperationResult> AddProduct(Product product, CancellationToken cancellationToken)
    {
        if (product == null!)
            return OperationResult.Fail("Product cannot be null");
        
        try
        {
            await _databaseProducts.AddAsync(DatabaseProduct.Map(product), cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return OperationResult.Success();
        }
        catch (Exception ex)
        {
            return OperationResult.Fail(ex.InnerException?.Message ?? ex.Message);
        }
    }

    public async Task<OperationResult> UpdateProduct(Product product, CancellationToken cancellationToken)
    {
        if (product == null!)
            return OperationResult.Fail("Type cannot be null");
        
        try
        {
            await _databaseProducts.AddAsync(DatabaseProduct.Map(product), cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return OperationResult.Success();
        }
        catch (Exception ex)
        {
            return OperationResult.Fail(ex.InnerException?.Message ?? ex.Message);
        }
    }

    public async Task<OperationResult> DeleteProduct(Product product, CancellationToken cancellationToken)
    {
        if (product == null!)
            return OperationResult.Fail("Type cannot be null");
        
        try
        {
            var entity = await _databaseProducts.FindAsync(product, cancellationToken);
            _databaseProducts.Remove(entity!);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return OperationResult.Success();
        }
        catch (Exception ex)
        {
            return OperationResult.Fail(ex.InnerException?.Message ?? ex.Message);
        }
    }

    public async Task<OperationResult<PaginatedResult<Product>>> SearchProducts(
        SearchRequest<ProductsParamets> searchRequest, CancellationToken cancellationToken)
    {
        try
        {
            var query = _databaseProducts.AsQueryable();
            
            if (searchRequest.Query != null!)
            {
                if (searchRequest.Query.ProductType != null)
                {
                    query = query.Where(p => p.Type!.Id == searchRequest.Query.ProductType.Id);
                }

                if (searchRequest.Query.Brand != null)
                {
                    query = query.Where(p => p.Brand!.Id == searchRequest.Query.Brand.Id);
                }

                if (searchRequest.Query.Country != null)
                {
                    query = query.Where(p => p.Country.Id == searchRequest.Query.Country.Id);
                }
            }

            var totalCount = await query.CountAsync(cancellationToken);
            var skip = searchRequest.Offset ?? 0;
        
            skip = Math.Min(skip, Math.Max(totalCount - 1, 0)); // Не выходим за границы
            var take = Math.Min(searchRequest.Limit, totalCount - skip); // Не берем лишнего

            var results = await query
                .Skip(skip)
                .Take(take)
                .Select(c => DatabaseProduct.Map(c))
                .ToListAsync(cancellationToken);

            var hasMore = skip + take < totalCount;
            var nextOffset = hasMore ? skip + take : new int?();
    
            return OperationResult<PaginatedResult<Product>>.Success(new PaginatedResult<Product>(
                Results: results,
                Pagination: new PaginationMetadata(
                    NextOffset: nextOffset,
                    HasMore: hasMore,
                    TotalCount: totalCount
                )
            ));
        }
        catch (Exception ex)
        {
            return OperationResult<PaginatedResult<Product>>.Fail(ex.Message)!;
        }
    }
}