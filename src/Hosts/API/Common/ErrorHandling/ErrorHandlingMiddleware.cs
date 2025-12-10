namespace Recruitly.API.Common.ErrorHandling;

internal static class ErrorHandlingMiddleware
{
    internal static IApplicationBuilder UseErrorHandling(this IApplicationBuilder builder)
    {
        builder.UseExceptionHandler();

        return builder;
    }
}
