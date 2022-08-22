using System.Net.Http.Headers;

namespace ApiBureau.Edays.Api.Core;

public class Pager
{
    private const string PaginationPage = "edays-pagination-page";
    private const string PaginationSize = "edays-pagination-page-size";
    private const string PaginationReturned = "edays-pagination-returned";
    private const string PaginationTotal = "edays-pagination-total";

    public Pager(HttpHeaders? headers = null)
    {
        if (headers == null) return;

        if (!headers.Contains(PaginationPage) && !headers.Contains(PaginationSize) &&
            !headers.Contains(PaginationReturned) && !headers.Contains(PaginationTotal))
            return;

        Total = GetValue(PaginationTotal);
        Returned = GetValue(PaginationReturned);
        PageSize = GetValue(PaginationSize);
        Page = GetValue(PaginationPage);

        int GetValue(string key)
        {
            headers.TryGetValues(key, out var value);

            return int.Parse(value?.FirstOrDefault() ?? "0");
        }
    }

    public int Total { get; set; }
    public int Returned { get; set; }
    public int PageSize { get; set; }
    public int Page { get; set; }
    public int TotalPages => PageSize > 0 ?
        Total % PageSize == 0 ? Total / PageSize : Total / PageSize + 1
        :
        Total > 0 ? 1 : 0;
    public bool IsPager => Total > PageSize;
}
