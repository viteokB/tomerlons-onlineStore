using Microsoft.EntityFrameworkCore;
using OnlineStore.Core.Common;
using OnlineStore.Core.Interfaces;
using OnlineStore.Core.Models;
using OnlineStore.Repository.Models;

namespace OnlineStore.Repository.Repository;

public class DeliveryStatusRepository : IDeliveryStatusRepository
{
    private readonly OnlineStoreDbContext _dbContext;
    private readonly DbSet<DatabaseDeliveryStatus> _statuses;

    public DeliveryStatusRepository(OnlineStoreDbContext dbContext)
    {
        _dbContext = dbContext;
        _statuses = dbContext.DeliveryStatuses;
    }

    public async Task<OperationResult<DeliveryStatus>> AddStatus(DeliveryStatus status,
        CancellationToken cancellationToken)
    {
        try
        {
            // Проверяем, нет ли уже статуса с таким названием
            var exists = await _statuses.AnyAsync(s => s.Name == status.Name, cancellationToken);
            if (exists)
                return OperationResult<DeliveryStatus>.Fail("Статус с таким названием уже существует")!;

            var dbStatus = DatabaseDeliveryStatus.Map(status);

            await _statuses.AddAsync(dbStatus, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return OperationResult<DeliveryStatus>.Success(DatabaseDeliveryStatus.Map(dbStatus));
        }
        catch (Exception ex)
        {
            return OperationResult<DeliveryStatus>.Fail($"Ошибка при добавлении статуса: {ex.Message}")!;
        }
    }

    public async Task<OperationResult> UpdateStatus(int id, DeliveryStatus status, CancellationToken cancellationToken)
    {
        try
        {
            var dbStatus = await _statuses.FindAsync(new object[] { id }, cancellationToken);
            if (dbStatus == null)
                return OperationResult.Fail("Статус не найден");

            // Проверяем, нет ли другого статуса с таким названием
            var nameExists = await _statuses
                .AnyAsync(s => s.Name == status.Name && s.Id != id, cancellationToken);

            if (nameExists)
                return OperationResult.Fail("Другой статус с таким названием уже существует");

            dbStatus.Name = status.Name;
            dbStatus.Description = status.Description;
            dbStatus.IsActive = status.IsActive;

            await _dbContext.SaveChangesAsync(cancellationToken);
            return OperationResult.Success();
        }
        catch (Exception ex)
        {
            return OperationResult.Fail($"Ошибка при обновлении статуса: {ex.Message}");
        }
    }

    public async Task<OperationResult> DeleteStatus(int id, CancellationToken cancellationToken)
    {
        try
        {
            var status = await _statuses.FindAsync(new object[] { id }, cancellationToken);
            if (status == null)
                return OperationResult.Fail("Статус не найден");

            // Проверяем, не используется ли статус в заказах
            var isUsed = await _dbContext.DatabaseOrders
                .AnyAsync(o => o.DeliveryStatusId == id, cancellationToken);

            if (isUsed)
                return OperationResult.Fail("Невозможно удалить статус, так как он используется в заказах");

            _statuses.Remove(status);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return OperationResult.Success();
        }
        catch (Exception ex)
        {
            return OperationResult.Fail($"Ошибка при удалении статуса: {ex.Message}");
        }
    }

    public async Task<OperationResult<List<DeliveryStatus>>> GetAllStatuses(CancellationToken cancellationToken)
    {
        try
        {
            var statuses = await _statuses
                .Select(s => DatabaseDeliveryStatus.Map(s))
                .ToListAsync(cancellationToken);

            return OperationResult<List<DeliveryStatus>>.Success(statuses);
        }
        catch (Exception ex)
        {
            return OperationResult<List<DeliveryStatus>>.Fail($"Ошибка при получении статусов: {ex.Message}");
        }
    }
}