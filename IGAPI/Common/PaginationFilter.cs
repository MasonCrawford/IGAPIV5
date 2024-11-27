namespace Common;

public class ApiPaginationFilter
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public ApiPaginationFilter()
    {
        this.PageNumber = 1;
        this.PageSize = 50;
    }
    public ApiPaginationFilter(int pageNumber, int pageSize)
    {
        this.PageNumber = pageNumber < 1 ? 1 : pageNumber;
        this.PageSize = pageSize;
    }
}