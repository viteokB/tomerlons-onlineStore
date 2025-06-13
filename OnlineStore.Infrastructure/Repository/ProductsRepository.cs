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
            var exsist = await _databaseProducts
                .FirstOrDefaultAsync(p => p.CatalogNumber == product.CatalogNumber, cancellationToken);

            if (exsist != null)
            {
                return OperationResult.Fail("С таким артикулом товар уже есть");
            }
            // DatabaseBrand? dbBrand = null;
            // if (product.Brand != null)
            // {
            //     dbBrand = await _dbContext.Brands
            //         .FirstOrDefaultAsync(b => b.Id == product.Brand.Id, cancellationToken);
            // }
            // DatabaseType? dbType = null;
            // if (product.Type != null)
            // {
            //     dbType = await _dbContext.Types
            //         .FirstOrDefaultAsync(t => t.Id == product.Type.Id, cancellationToken);
            // }
            // DatabaseCountry? dbCountry = null;
            // if (product.Country != null)
            // {
            //     dbCountry = await _dbContext.Countries
            //         .FirstOrDefaultAsync(t => t.Id == product.Country.Id, cancellationToken);
            // }
            //
            // var newProduct = new DatabaseProduct
            // {
            //     Type = dbType,
            //     Country = dbCountry,
            //     ChangedBy = DatabaseUser.Map(product.ChangedBy!),
            //     Brand = dbBrand,
            //     Name = product.Name,
            //     PhotoPath = product.PhotoPath,
            //     CatalogNumber = product.CatalogNumber,
            //     BasePrice = product.BasePrice,
            //     IsActive = product.IsActive,
            //     ChangedAt = product.ChangedAt
            // };
            
            var newProduct = new DatabaseProduct
            {
                TypeId = product.Type?.Id,
                CountryId = product.Country?.Id,
                BrandId = product.Brand?.Id,
                Name = product.Name,
                PhotoPath = product.PhotoPath,
                CatalogNumber = product.CatalogNumber,
                BasePrice = product.BasePrice,
                IsActive = product.IsActive,
                ChangedById = product.ChangedBy?.Id,
                ChangedAt = product.ChangedAt
            };
            
            await _databaseProducts.AddAsync(newProduct, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return OperationResult.Success();
        }
        catch (Exception ex)
        {
            return OperationResult.Fail(ex.InnerException?.Message ?? ex.Message);
        }
    }

    public async Task<OperationResult> UpdateProduct(int? id, Product product, CancellationToken cancellationToken)
    {
        if (id == null!)
            return OperationResult.Fail("Id of product cannot be null");
        if (product == null!)
            return OperationResult.Fail("Product cannot be null");
        
        try
        {
            var entity = await _databaseProducts
                .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);

            entity.TypeId = product.Type.Id;
            entity.BrandId = product.Brand.Id;
            entity.CountryId = product.Country.Id;
            entity.ChangedById = product.ChangedBy.Id;
            entity.Name = product.Name;
            entity.PhotoPath = product.PhotoPath;
            entity.CatalogNumber = product.CatalogNumber;
            entity.BasePrice = product.BasePrice;
            entity.IsActive = product.IsActive;
            entity.ChangedAt = DateTime.Now;
            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return OperationResult.Success();
        }
        catch (Exception ex)
        {
            return OperationResult.Fail(ex.InnerException?.Message ?? ex.Message);
        }
    }

    public async Task<OperationResult> DeleteProduct(int? id, CancellationToken cancellationToken)
    {
        if (id == null!)
            return OperationResult.Fail("Product id cannot be null");
        
        try
        {
            var entity = await _databaseProducts
                .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
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