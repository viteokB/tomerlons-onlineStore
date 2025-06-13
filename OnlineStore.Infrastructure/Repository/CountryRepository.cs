using Microsoft.EntityFrameworkCore;
using OnlineStore.Core.Common;
using OnlineStore.Core.Common.Pagination;
using OnlineStore.Core.Interfaces;
using OnlineStore.Core.Models;
using OnlineStore.Repository.Models;

namespace OnlineStore.Repository.Repository;

public class CountryRepository : ICountryRepository
{
    private readonly OnlineStoreDbContext _dbContext;
    
    private readonly DbSet<DatabaseCountry> _databaseCountry;

    public CountryRepository(OnlineStoreDbContext dbContext)
    {
        _dbContext = dbContext;
        _databaseCountry = dbContext.Countries;
    }
    
    public async Task<OperationResult> AddCountry(Country type, CancellationToken cancellationToken)
    {
        if (type == null!)
            return OperationResult.Fail("Country cannot be null");
        
        try
        {
            var existCountry = await _databaseCountry
                .FirstOrDefaultAsync(t => t.Name == type.Name, cancellationToken);
            
            if (existCountry != null)
            {
                return OperationResult.Fail($"Страна \"{existCountry.Name}\" уже существует ");
            }
            
            await _databaseCountry.AddAsync(DatabaseCountry.Map(type), cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return OperationResult.Success();
        }
        catch (Exception ex)
        {
            return OperationResult.Fail(ex.InnerException?.Message ?? ex.Message);
        }
    }

    public async Task<OperationResult> DeleteCountry(int? id, CancellationToken cancellationToken)
    {
        if (id == null!)
            return OperationResult.Fail("Country cannot be null");
        
        try
        {
            var entity = await _databaseCountry
                .FirstOrDefaultAsync(t => t.Id == id, cancellationToken);
            _databaseCountry.Remove(entity!);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return OperationResult.Success();
        }
        catch (Exception ex)
        {
            return OperationResult.Fail(ex.InnerException?.Message ?? ex.Message);
        }
    }

    public async Task<OperationResult> UpdateCountry(int id, Country type, CancellationToken cancellationToken)
    {
        if (type == null!)
            return OperationResult.Fail("Country cannot be null");
        
        try
        {
            var toUpdate = await _databaseCountry
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            if (toUpdate == null)
            {
                return OperationResult.Fail("Страна для обновления не обнаружена");
            }
            toUpdate.Name = type.Name;
            toUpdate.Code = type.Code;
            _databaseCountry.Update(toUpdate);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return OperationResult.Success();
        }
        catch (Exception ex)
        {
            return OperationResult.Fail(ex.InnerException?.Message ?? ex.Message);
        }
    }

    public async Task<OperationResult<List<Country>>> GetCountries(CancellationToken cancellationToken)
    {
        try
        {
            var types = await _databaseCountry
                .AsNoTracking() // For read-only operations
                .Select(t => DatabaseCountry.Map(t)) // Assuming you have a reverse mapping method
                .ToListAsync(cancellationToken: cancellationToken);

            return OperationResult<List<Country>>.Success(types);
        }
        catch (Exception ex)
        {
            return OperationResult<List<Country>>.Fail(ex.Message)!;
        }
    }

    public async Task<OperationResult<PaginatedResult<Country>>> SearchTypes(
        SearchRequest<string> request, CancellationToken cancellationToken)
    {
        var query = _databaseCountry.AsQueryable();

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
            .Select(c => DatabaseCountry.Map(c))
            .ToListAsync(cancellationToken);

        var hasMore = skip + take < totalCount;
        var nextOffset = hasMore ? skip + take : new int?();
    
        return OperationResult<PaginatedResult<Country>>.Success(new PaginatedResult<Country>(
            Results: results,
            Pagination: new PaginationMetadata(
                NextOffset: nextOffset,
                HasMore: hasMore,
                TotalCount: totalCount
            )
        ));
    }
}