namespace Recruitly.API.Common.ErrorHandling;

internal static class ErrorHandlingModule
{
    extension(IServiceCollection services)
    {
        internal IServiceCollection AddErrorHandling()
        {
            services.AddExceptionHandler<GlobalExceptionHandler>();
            services.AddProblemDetails();

            return services;
        }
    }
}
