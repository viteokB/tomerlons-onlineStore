namespace OnlineStore.Core.Interfaces.HistoryParameters;

public record OrderHistorySearchParameters(
    DateTime? StartDate, 
    DateTime? EndDate);