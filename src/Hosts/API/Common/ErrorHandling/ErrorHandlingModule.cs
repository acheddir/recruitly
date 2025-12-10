namespace Recruitly.API.Common.ErrorHandling;

internal static class ErrorHandlingModule
{
    internal static IServiceCollection AddErrorHandling(this IServiceCollection services)
    {
        services.AddExceptionHandler<GlobalExceptionHandler>();
        services.AddProblemDetails();

        return services;
    }
}
