namespace Recruitly.Common.Endpoints;

public static class ApiResults
{
    public static IResult ApiProblem(Result result)
    {
        return result.IsSuccess
            ? throw new InvalidOperationException()
            : Microsoft.AspNetCore.Http.Results.Problem(
                title: GetTitle(result.Error),
                detail: GetDetail(result.Error),
                type: GetType(result.Error.Type),
                statusCode: GetStatusCode(result.Error.Type),
                extensions: GetErrors(result));

        static IDictionary<string, object?>? GetErrors(Result result)
        {
            return result.Error is not ValidationError validationError
                ? null
                : new Dictionary<string, object?> { { "errors", validationError.Errors } };
        }

        static string GetTitle(Error error)
        {
            return error.Type
                is ErrorType.Validation
                or ErrorType.Problem
                or ErrorType.NotFound
                or ErrorType.Conflict
                or ErrorType.Failure
                ? error.Code
                : "Server failure";
        }

        static string GetDetail(Error error)
        {
            return error.Type
                is ErrorType.Validation
                or ErrorType.Problem
                or ErrorType.NotFound
                or ErrorType.Conflict
                or ErrorType.Failure
                ? error.Description
                : "An unexpected error occurred";
        }

        static string GetType(ErrorType errorType)
        {
            return errorType switch
            {
                ErrorType.Validation => "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1",
                ErrorType.Problem => "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1",
                ErrorType.NotFound => "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.4",
                ErrorType.Conflict => "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.8",
                ErrorType.Failure => "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1",
                _ => "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1"
            };
        }

        static int GetStatusCode(ErrorType errorType)
        {
            return errorType switch
            {
                ErrorType.Validation => StatusCodes.Status400BadRequest,
                ErrorType.Problem => StatusCodes.Status400BadRequest,
                ErrorType.NotFound => StatusCodes.Status404NotFound,
                ErrorType.Conflict => StatusCodes.Status409Conflict,
                ErrorType.Failure => StatusCodes.Status500InternalServerError,
                _ => StatusCodes.Status500InternalServerError
            };
        }
    }
}
