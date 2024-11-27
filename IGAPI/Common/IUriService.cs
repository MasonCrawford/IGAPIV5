namespace Common;

public interface IUriService
{
    public Uri? GetPageUri(ApiPaginationFilter filter, string route);
}