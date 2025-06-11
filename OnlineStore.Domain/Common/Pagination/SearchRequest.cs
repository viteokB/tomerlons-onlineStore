namespace OnlineStore.Core.Common.Pagination;

public record SearchRequest<T>(
    T Query, 
    int Limit, 
    int? Offset = null) where T : class;
