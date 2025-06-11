using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Core.Common;
using OnlineStore.Core.Common.Pagination;
using OnlineStore.Core.Interfaces;
using OnlineStore.Repository.Models;
using Type = OnlineStore.Core.Models.Type;

namespace OnlineStore.Repository.Repository;

public class TypeRepository : ITypeRepository
{
    private readonly OnlineStoreDbContext _dbContext;
    
    private readonly DbSet<DatabaseType> _databaseTypes;

    public TypeRepository(OnlineStoreDbContext dbContext)
    {
        _dbContext = dbContext;
        _databaseTypes = dbContext.Types;
    }

    public async Task<OperationResult> AddType(Type type, CancellationToken cancellationToken)
    {
        if (type == null!)
            return OperationResult.Fail("Type cannot be null");
        
        try
        {
            await _databaseTypes.AddAsync(DatabaseType.Map(type), cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return OperationResult.Success();
        }
        catch (Exception ex)
        {
            return OperationResult.Fail(ex.InnerException?.Message ?? ex.Message);
        }
    }

    public async Task<OperationResult> DeleteType(Type type, CancellationToken cancellationToken)
    {
        if (type == null!)
            return OperationResult.Fail("Type cannot be null");
        
        try
        {
            var entity = await _databaseTypes.FindAsync(type, cancellationToken);
            _databaseTypes.Remove(entity!);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return OperationResult.Success();
        }
        catch (Exception ex)
        {
            return OperationResult.Fail(ex.InnerException?.Message ?? ex.Message);
        }
    }

    public async Task<OperationResult> UpdateType(Type type, CancellationToken cancellationToken)
    {
        if (type == null!)
            return OperationResult.Fail("Type cannot be null");
        
        try
        {
            var entity = DatabaseType.Map(type);
            _databaseTypes.Update(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return OperationResult.Success();
        }
        catch (Exception ex)
        {
            return OperationResult.Fail(ex.InnerException?.Message ?? ex.Message);
        }
    }

    public async Task<OperationResult<List<Type>>> GetTypes(CancellationToken cancellationToken)
    {
        try
        {
            var types = await _databaseTypes
                .AsNoTracking() // For read-only operations
                .Select(t => DatabaseType.Map(t)) // Assuming you have a reverse mapping method
                .ToListAsync(cancellationToken: cancellationToken);

            return OperationResult<List<Type>>.Success(types);
        }
        catch (Exception ex)
        {
            return OperationResult<List<Type>>.Fail(ex.Message)!;
        }
    }

    public async Task<OperationResult<PaginatedResult<Type>>> SearchTypes(SearchRequest<string> request,
        CancellationToken cancellationToken)
    {
        var query = _databaseTypes.AsQueryable();

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
            .Select(c => DatabaseType.Map(c))
            .ToListAsync(cancellationToken);

        var hasMore = skip + take < totalCount;
        var nextOffset = hasMore ? skip + take : new int?();
    
        return OperationResult<PaginatedResult<Type>>.Success(new PaginatedResult<Type>(
            Results: results,
            Pagination: new PaginationMetadata(
                NextOffset: nextOffset,
                HasMore: hasMore,
                TotalCount: totalCount
            )
        ));
    }
}