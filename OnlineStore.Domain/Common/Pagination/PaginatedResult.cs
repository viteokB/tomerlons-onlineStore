namespace OnlineStore.Core.Common.Pagination;

public record PaginatedResult<T>(
    List<T> Results,
    PaginationMetadata Pagination
);