namespace StoreApp.Infrastructure.Extensions;

public static class HttpContextExtensions
{
    public static string PathandQuery(this HttpRequest request)
    {
        return request.QueryString.HasValue
        ? $"{request.Path}{request.QueryString}"
        : request.Path.ToString();
    }
}