namespace OnlineStore.Core.Interfaces.HistoryParameters;

public record WarehouseProductHistorySearchParameters(
    DateTime? StartDate, 
    DateTime? EndDate);