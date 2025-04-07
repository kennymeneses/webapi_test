namespace api.application.Models.Queries;

public abstract record PaginatedQuery
{
    public const int DefaultPage = 1;
    public const int DefaultPageSize = 20;
    private const char Minus = '-';
    private const char Plus = '+';

    public required int? PageNumber { get; init; } = DefaultPage;

    public required int? PageSize { get; init; } = DefaultPageSize;

    public required string? SortBy { get; init; }

    public string? SortField => SortBy?.Trim(Plus, Minus).Trim();

    public int SafePage => PageNumber ?? DefaultPage;

    public int SafePageSize => PageSize ?? DefaultPageSize;

    public SortOrder SortOrder
    {
        get
        {
            if (SortBy is null)
            {
                return SortOrder.Unsorted;
            }

            if (SortBy.StartsWith(Minus))
            {
                return SortOrder.Descending;
            }

            return SortOrder.Ascending;
        }
    }
}

public enum SortOrder
{
    Unsorted,
    Ascending,
    Descending
}