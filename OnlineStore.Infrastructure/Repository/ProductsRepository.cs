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
            var query = _databaseProducts
                .AsNoTracking() // Recommended for read-only operations
                .Include(p => p.Country)
                .Include(p => p.Brand)
                .Include(p => p.Type)
                .Where(p => p.IsActive); // Filter out inactive products by default

            // Apply filters if parameters are provided
            if (searchRequest.Query != null!)
            {
                if (searchRequest.Query.ProductType != null)
                {
                    query = query.Where(p => p.TypeId == searchRequest.Query.ProductType.Id);
                }

                if (searchRequest.Query.Brand != null)
                {
                    query = query.Where(p => p.BrandId == searchRequest.Query.Brand.Id);
                }

                if (searchRequest.Query.Country != null)
                {
                    query = query.Where(p => p.CountryId == searchRequest.Query.Country.Id);
                }
            }

            var totalCount = await query.CountAsync(cancellationToken);
            
            var offset = searchRequest.Offset ?? 0;
            var limit = searchRequest.Limit;
            
            offset = Math.Max(0, offset);
            limit = Math.Clamp(limit, 1, 100);
            
            if (offset >= totalCount && totalCount > 0)
            {
                offset = totalCount - 1;
            }
            
            var results = await query
                .OrderBy(p => p.Name)
                .Skip(offset)
                .Take(limit)
                .Select(p => DatabaseProduct.Map(p))
                .ToListAsync(cancellationToken);
            
            var hasMore = offset + limit < totalCount;
            var nextOffset = hasMore ? offset + limit : (int?)null;

            return OperationResult<PaginatedResult<Product>>.Success(
                new PaginatedResult<Product>(
                    Results: results,
                    Pagination: new PaginationMetadata(
                        NextOffset: nextOffset,
                        HasMore: hasMore,
                        TotalCount: totalCount
                    )
                ));
        }
        catch (OperationCanceledException)
        {
            return OperationResult<PaginatedResult<Product>>.Fail("Operation was canceled")!;
        }
        catch (Exception ex)
        {
            return OperationResult<PaginatedResult<Product>>.Fail(ex.Message)!;
        }
    }
}