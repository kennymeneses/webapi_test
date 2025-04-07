using api.application.Models.Queries;

namespace api.application.Models.Requests;

public abstract record PaginatedRequest
{
    public const int DefaultPage = 1;
    public const int DefaultPageSize = 20;
    private const char Minus = '-';
    private const char Plus = '+';
    public int? PageNumber { get; set; } = DefaultPage;

    public int? PageSize { get; set; } = DefaultPageSize;

    public string? SortBy { get; set; }

    protected string? SortField => SortBy?.Trim(Plus, Minus).Trim();

    protected int SafePage => PageNumber ?? DefaultPage;

    protected int SafePageSize => PageSize ?? DefaultPageSize;

    protected SortOrder SortOrder
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