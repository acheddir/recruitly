namespace Recruitly.API.Common.ErrorHandling;

internal sealed class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
{
    private const string? ServerError = "Server Error";

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception,
        CancellationToken cancellationToken)
    {
        logger.LogError(exception, "An error occurred while processing the request.");

        ProblemDetails problemDetails = exception switch
        {
            BusinessRuleValidationException businessRuleValidationException => new ProblemDetails
            {
                Status = StatusCodes.Status409Conflict,
                Title = businessRuleValidationException.Message,
                Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.8"
            },
            TenantNotResolvedException tenantNotResolvedException => new ProblemDetails
            {
                Status = StatusCodes.Status400BadRequest,
                Title = tenantNotResolvedException.Message,
                Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1"
            },
            _ => new ProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError,
                Title = ServerError,
                Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1"
            }
        };

        httpContext.Response.StatusCode = problemDetails.Status!.Value;
        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

        return true;
    }
}

