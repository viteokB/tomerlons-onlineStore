﻿using Microsoft.EntityFrameworkCore;
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
    
    private readonly DbSet<DatabaseProductHistory> _productHistory;

    public ProductsRepository(OnlineStoreDbContext dbContext)
    {
        _dbContext = dbContext;
        _databaseProducts = dbContext.Products;
        _productHistory = dbContext.ProductsHistory;
    }
    
    public async Task<OperationResult> AddProduct(Product product, CancellationToken cancellationToken)
    {
        if (product == null!)
            return OperationResult.Fail("Product cannot be null");
        
        try
        {
            // Проверка существования товара с таким артикулом
            var exist = await _databaseProducts
                .FirstOrDefaultAsync(p => p.CatalogNumber == product.CatalogNumber, cancellationToken);
            
            if (exist != null)
            {
                return OperationResult.Fail("Товар с таким артикулом уже существует");
            }
            
            // Проверка существования связанных объектов
            if (product.Type?.Id != null && !await _dbContext.Types.AnyAsync(t => t.Id == product.Type.Id, cancellationToken))
            {
                return OperationResult.Fail("Указанный тип не существует");
            }
            
            if (product.Country?.Id != null && !await _dbContext.Countries.AnyAsync(c => c.Id == product.Country.Id, cancellationToken))
            {
                return OperationResult.Fail("Указанная страна не существует");
            }
            
            if (product.Brand?.Id != null && !await _dbContext.Brands.AnyAsync(b => b.Id == product.Brand.Id, cancellationToken))
            {
                return OperationResult.Fail("Указанный бренд не существует");
            }
            
            if (product.ChangedBy?.Id != null && !await _dbContext.Users.AnyAsync(u => u.Id == product.ChangedBy.Id, cancellationToken))
            {
                return OperationResult.Fail("Указанный пользователь не существует");
            }
            
            // Создание нового продукта
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
                ChangedAt = DateTime.UtcNow // Используем текущее время
            };
            
            // Добавление продукта
            await _databaseProducts.AddAsync(newProduct, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            
            // После сохранения продукта (когда у него появится ID) добавляем историю
            var history = new DatabaseProductHistory
            {
                ProductId = newProduct.Id, // Теперь ID существует
                TypeId = newProduct.TypeId,
                CountryId = newProduct.CountryId,
                BrandId = newProduct.BrandId,
                Name = newProduct.Name,
                PhotoPath = newProduct.PhotoPath,
                CatalogNumber = newProduct.CatalogNumber,
                BasePrice = newProduct.BasePrice,
                IsActive = newProduct.IsActive,
                ChangedById = newProduct.ChangedById,
                ChangedAt = newProduct.ChangedAt
            };
            
            await _productHistory.AddAsync(history, cancellationToken);
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
            // Добавление истории изменений
            await _productHistory.AddAsync(DatabaseProductHistory.CreateHistory(product), cancellationToken);
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

    public async Task<OperationResult<Product>> GetProductById(int id, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _databaseProducts
                .AsNoTracking() // Recommended for read-only operations
                .Include(p => p.Country)
                .Include(p => p.Brand)
                .Include(p => p.Type)
                .Include(p => p.ChangedBy)
                .Include(p => p.ChangedBy.Role)
                .Include(p => p.Brand.Country)
                .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);

            if (entity == null)
            {
                OperationResult<Product>.Fail($"Продукт с id {id} не найден");
            }
            
            return OperationResult<Product>.Success(DatabaseProduct.Map(entity));
        }
        catch (Exception ex)
        {
            return OperationResult<Product>.Fail(ex.InnerException?.Message ?? ex.Message);
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
                .Include(p => p.ChangedBy)
                .Include(p => p.ChangedBy.Role)
                .Include(p => p.Brand.Country)
                .Where(p => p.IsActive == searchRequest.Query.IsActive); // Filter out inactive products by default

            var count = await query.CountAsync(cancellationToken);
            
            // Apply filters if parameters are provided
            if (searchRequest.Query != null!)
            {
                if (searchRequest.Query.ProductName != null)
                {
                    var searchTerm = $"{searchRequest.Query.ProductName}%";
                    query = query
                        .Where(c =>
                            EF.Functions.Like(c.Name, searchTerm));
                }
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