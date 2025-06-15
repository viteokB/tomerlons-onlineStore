using OnlineStore.Core.Common;
using OnlineStore.Core.Models;

namespace OnlineStore.Core.Interfaces;

public interface IDeliveryStatusRepository
{
    Task<OperationResult<DeliveryStatus>> AddStatus(DeliveryStatus status, CancellationToken cancellationToken);
    Task<OperationResult> UpdateStatus(int id, DeliveryStatus status, CancellationToken cancellationToken);
    Task<OperationResult> DeleteStatus(int id, CancellationToken cancellationToken);
    Task<OperationResult<List<DeliveryStatus>>> GetAllStatuses(CancellationToken cancellationToken);
}