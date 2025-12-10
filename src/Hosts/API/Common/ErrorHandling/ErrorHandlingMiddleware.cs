namespace Recruitly.API.Common.ErrorHandling;

internal static class ErrorHandlingMiddleware
{
    extension(IApplicationBuilder builder)
    {
        internal IApplicationBuilder UseErrorHandling()
        {
            builder.UseExceptionHandler();

            return builder;
        }
    }
}
