using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;
using OnlineStore.Core.Common;
using OnlineStore.Core.Common.Pagination;
using OnlineStore.Core.Interfaces;
using OnlineStore.Core.Models;
using OnlineStore.Repository.Models;

namespace OnlineStore.Repository.Repository;

public class AddressRepository : IAddressRepository
{
    private readonly OnlineStoreDbContext _dbContext;
    private readonly DbSet<DatabaseAddress> _addresses;

    public AddressRepository(OnlineStoreDbContext dbContext)
    {
        _dbContext = dbContext;
        _addresses = dbContext.Addresses;
    }

    public async Task<OperationResult<Address>> AddAddress(Address address, CancellationToken cancellationToken)
    {
        if (address == null)
            return OperationResult<Address>.Fail("Address cannot be null");

        try
        {
            var dbAddress = DatabaseAddress.Map(address);
            await _addresses.AddAsync(dbAddress, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            
            // Получаем обновленный адрес с ID
            var createdAddress = DatabaseAddress.Map(dbAddress);
            return OperationResult<Address>.Success(createdAddress);
        }
        catch (Exception ex)
        {
            return OperationResult<Address>.Fail($"Failed to add address: {ex.Message}");
        }
    }

    public async Task<OperationResult<Address>> UpdateAddress(int id, Address address, CancellationToken cancellationToken)
    {
        if (address == null)
            return OperationResult<Address>.Fail("Address cannot be null");

        try
        {
            var existingAddress = await _addresses
                .FirstOrDefaultAsync(a => a.Id == id, cancellationToken);
                
            if (existingAddress == null)
                return OperationResult<Address>.Fail("Address not found");

            // Обновляем поля
            existingAddress.Country = address.Country;
            existingAddress.City = address.City;
            existingAddress.Street = address.Street;
            existingAddress.HouseNumber = address.HouseNumber;
            existingAddress.ApartmentNumber = address.ApartmentNumber;
            existingAddress.Latitude = address.Coordinate.Latitude;
            existingAddress.Longitude = address.Coordinate.Longitude;

            _addresses.Update(existingAddress);
            await _dbContext.SaveChangesAsync(cancellationToken);
            
            // Возвращаем обновленный адрес
            var updatedAddress = DatabaseAddress.Map(existingAddress);
            return OperationResult<Address>.Success(updatedAddress);
        }
        catch (Exception ex)
        {
            return OperationResult<Address>.Fail($"Failed to update address: {ex.Message}");
        }
    }

    public async Task<OperationResult> DeleteAddress(int id, CancellationToken cancellationToken)
    {
        try
        {
            var address = await _addresses.FirstOrDefaultAsync(a => a.Id == id, cancellationToken);
            if (address == null)
                return OperationResult.Fail("Address not found");

            _addresses.Remove(address);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return OperationResult.Success();
        }
        catch (Exception ex)
        {
            return OperationResult.Fail($"Failed to delete address: {ex.Message}");
        }
    }

    public async Task<OperationResult<List<Address>>> GetAddresses(CancellationToken cancellationToken)
    {
        try
        {
            var addresses = await _addresses
                .AsNoTracking()
                .Select(a => DatabaseAddress.Map(a))
                .ToListAsync(cancellationToken);

            return OperationResult<List<Address>>.Success(addresses);
        }
        catch (Exception ex)
        {
            return OperationResult<List<Address>>.Fail($"Failed to get addresses: {ex.Message}")!;
        }
    }

    public async Task<OperationResult<Address>> GetAddress(int id, CancellationToken cancellationToken)
    {
        var result = await _addresses
            .FirstOrDefaultAsync(a => a.Id == id, cancellationToken);
        
        var opResult = result == null ?
            OperationResult<Address>.Fail("Address not found")! : 
            OperationResult<Address>.Success(DatabaseAddress.Map(result));
        
        return opResult;
    }

    public async Task<OperationResult<PaginatedResult<Address>>> SearchAddresses(
        SearchRequest<string> request, CancellationToken cancellationToken)
    {
        var query = _addresses.AsQueryable();

        if (!string.IsNullOrEmpty(request.Query))
        {
            string searchTerm = $"%{request.Query.ToLower()}%";
            query = query.Where(a =>
                EF.Functions.Like(a.City.ToLower(), searchTerm) ||
                EF.Functions.Like(a.Street.ToLower(), searchTerm));
        }

        int totalCount = await query.CountAsync(cancellationToken);
        int skip = request.Offset ?? 0;
        int take = Math.Min(request.Limit, totalCount - skip);

        var results = await query
            .Skip(skip)
            .Take(take)
            .Select(a => DatabaseAddress.Map(a))
            .ToListAsync(cancellationToken);

        bool hasMore = skip + take < totalCount;
        int nextOffset = hasMore ? skip + take : 0;

        return OperationResult<PaginatedResult<Address>>.Success(
            new PaginatedResult<Address>(
                Results: results,
                Pagination: new PaginationMetadata(
                    NextOffset: nextOffset,
                    HasMore: hasMore,
                    TotalCount: totalCount)));
    }
}