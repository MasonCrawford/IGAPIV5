namespace Common;

public class PaginationHelper
{
    
    public static ApiPagedResponse<List<T>> CreatePagedReponse<T>(List<T> pagedData,
        ApiPaginationFilter validFilter,
        int totalRecords,
        IUriService uriService,
        string route)
    {
        var respose = new ApiPagedResponse<List<T>>(pagedData, validFilter.PageNumber, validFilter.PageSize);
        var totalPages = ((double)totalRecords / (double)validFilter.PageSize);
        int roundedTotalPages = Convert.ToInt32(Math.Ceiling(totalPages));
        respose.NextPage =
            validFilter.PageNumber >= 1 && validFilter.PageNumber < roundedTotalPages
                ? uriService.GetPageUri(new ApiPaginationFilter(validFilter.PageNumber + 1, validFilter.PageSize), route)
                : null;
        respose.PreviousPage =
            validFilter.PageNumber - 1 >= 1 && validFilter.PageNumber <= roundedTotalPages
                ? uriService.GetPageUri(new ApiPaginationFilter(validFilter.PageNumber - 1, validFilter.PageSize), route)
                : null;
        respose.FirstPage = uriService.GetPageUri(new ApiPaginationFilter(1, validFilter.PageSize), route);
        respose.LastPage = uriService.GetPageUri(new ApiPaginationFilter(roundedTotalPages, validFilter.PageSize), route);
        respose.TotalPages = roundedTotalPages;
        respose.TotalRecords = totalRecords;
        return respose;
    }
    
}