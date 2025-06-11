using Microsoft.EntityFrameworkCore;
using OnlineStore.Core.Common;
using OnlineStore.Core.Common.Pagination;
using OnlineStore.Core.Interfaces;
using OnlineStore.Core.Models;
using OnlineStore.Repository.Models;

namespace OnlineStore.Repository.Repository;

public class BrandRepository : IBrandRepository
{
    private readonly OnlineStoreDbContext _dbContext;
    
    private readonly DbSet<DatabaseBrand> _databaseBrands;

    public BrandRepository(OnlineStoreDbContext dbContext)
    {
        _dbContext = dbContext;
        _databaseBrands = dbContext.Brands;
    }

    public async Task<OperationResult> AddBrand(Brand type, CancellationToken cancellationToken)
    {
        if (type == null!)
            return OperationResult.Fail("Type cannot be null");
        
        try
        {
            await _databaseBrands.AddAsync(DatabaseBrand.Map(type), cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return OperationResult.Success();
        }
        catch (Exception ex)
        {
            return OperationResult.Fail(ex.InnerException?.Message ?? ex.Message);
        }
    }

    public async Task<OperationResult> DeleteBrand(Brand type, CancellationToken cancellationToken)
    {
        if (type == null!)
            return OperationResult.Fail("Type cannot be null");
        
        try
        {
            var entity = await _databaseBrands.FindAsync(type, cancellationToken);
            _databaseBrands.Remove(entity!);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return OperationResult.Success();
        }
        catch (Exception ex)
        {
            return OperationResult.Fail(ex.InnerException?.Message ?? ex.Message);
        }
    }

    public async Task<OperationResult> UpdateBrand(Brand type, CancellationToken cancellationToken)
    {
        if (type == null!)
            return OperationResult.Fail("Type cannot be null");
        
        try
        {
            var entity = DatabaseBrand.Map(type);
            _databaseBrands.Update(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return OperationResult.Success();
        }
        catch (Exception ex)
        {
            return OperationResult.Fail(ex.InnerException?.Message ?? ex.Message);
        }
    }

    public async Task<OperationResult<List<Brand>>> GetBrands(CancellationToken cancellationToken)
    {
        try
        {
            var types = await _databaseBrands
                .AsNoTracking() // For read-only operations
                .Select(t => DatabaseBrand.Map(t)) // Assuming you have a reverse mapping method
                .ToListAsync(cancellationToken: cancellationToken);

            return OperationResult<List<Brand>>.Success(types);
        }
        catch (Exception ex)
        {
            return OperationResult<List<Brand>>.Fail(ex.Message)!;
        }
    }

    public async Task<OperationResult<PaginatedResult<Brand>>> SearchBrand(
        SearchRequest<string> request, CancellationToken cancellationToken)
    {
        var query = _databaseBrands.AsQueryable();

        if (!string.IsNullOrEmpty(request.Query))
        {
            var searchTerm = $"{request.Query.ToLower()}%";
            query = query
                .Where(c =>
                    EF.Functions.Like(c.Name, searchTerm));
        }

        var totalCount = await query.CountAsync(cancellationToken);
        var skip = request.Offset ?? 0;
        
        skip = Math.Min(skip, Math.Max(totalCount - 1, 0)); // Не выходим за границы
        var take = Math.Min(request.Limit, totalCount - skip); // Не берем лишнего

        var results = await query
            .Skip(skip)
            .Take(take)
            .Select(c => DatabaseBrand.Map(c))
            .ToListAsync(cancellationToken);

        var hasMore = skip + take < totalCount;
        var nextOffset = hasMore ? skip + take : new int?();
    
        return OperationResult<PaginatedResult<Brand>>.Success(new PaginatedResult<Brand>(
            Results: results,
            Pagination: new PaginationMetadata(
                NextOffset: nextOffset,
                HasMore: hasMore,
                TotalCount: totalCount
            )
        ));
    }
}