namespace OnlineStore.Core.Interfaces.HistoryParameters;

public record ProductHistorySearchParameters(
    DateTime? StartDate, 
    DateTime? EndDate);