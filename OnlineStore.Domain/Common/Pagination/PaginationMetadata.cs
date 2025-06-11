namespace OnlineStore.Core.Common.Pagination;

public record PaginationMetadata(
    int? NextOffset = null,
    bool HasMore = false,
    int? TotalCount = null
);