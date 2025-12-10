namespace Recruitly.Common.OpenAPI;

/// <summary>
/// Provides example ProblemDetails objects for OpenAPI documentation.
/// </summary>
public static class ProblemDetailsExamples
{
    /// <summary>
    /// Common error response examples.
    /// </summary>
    public static class Common
    {
        public static readonly ProblemDetails Unauthorized = new()
        {
            Type = "https://tools.ietf.org/html/rfc7235#section-3.1",
            Title = "Unauthorized",
            Status = StatusCodes.Status401Unauthorized,
            Detail = "Authorization header is missing or invalid"
        };

        public static readonly ProblemDetails Forbidden = new()
        {
            Type = "https://tools.ietf.org/html/rfc7231#section-6.5.3",
            Title = "Forbidden",
            Status = StatusCodes.Status403Forbidden,
            Detail = "You do not have permission to perform this action"
        };

        public static readonly ProblemDetails InternalServerError = new()
        {
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1",
            Title = "Server failure",
            Status = StatusCodes.Status500InternalServerError,
            Detail = "An unexpected error occurred"
        };
    }

    /// <summary>
    /// Error examples for create operations.
    /// </summary>
    public static class Create
    {
        public static readonly ValidationProblemDetails BadRequest = new()
        {
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1",
            Title = "Validation.Error",
            Status = StatusCodes.Status400BadRequest,
            Detail = "One or more validation errors occurred",
            Errors = new Dictionary<string, string[]>
            {
                ["Name"] = ["Name is required"],
                ["Slug"] = ["Slug must contain only lowercase letters, numbers, and hyphens"]
            }
        };

        public static readonly ProblemDetails Conflict = new()
        {
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.8",
            Title = "Resource.AlreadyExists",
            Status = StatusCodes.Status409Conflict,
            Detail = "A resource with the specified identifier already exists"
        };
    }

    /// <summary>
    /// Error examples for get operations.
    /// </summary>
    public static class Get
    {
        public static readonly ProblemDetails NotFound = new()
        {
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.4",
            Title = "Resource.NotFound",
            Status = StatusCodes.Status404NotFound,
            Detail = "The resource with the specified identifier was not found"
        };

        public static readonly ValidationProblemDetails BadRequest = new()
        {
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1",
            Title = "Validation.Error",
            Status = StatusCodes.Status400BadRequest,
            Detail = "One or more validation errors occurred",
            Errors = new Dictionary<string, string[]>
            {
                ["Id"] = ["Invalid identifier format"]
            }
        };
    }

    /// <summary>
    /// Error examples for update operations.
    /// </summary>
    public static class Update
    {
        public static readonly ProblemDetails NotFound = new()
        {
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.4",
            Title = "Resource.NotFound",
            Status = StatusCodes.Status404NotFound,
            Detail = "The resource with the specified identifier was not found"
        };

        public static readonly ValidationProblemDetails BadRequest = new()
        {
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1",
            Title = "Validation.Error",
            Status = StatusCodes.Status400BadRequest,
            Detail = "One or more validation errors occurred",
            Errors = new Dictionary<string, string[]>
            {
                ["Name"] = ["Name is required"]
            }
        };

        public static readonly ProblemDetails Conflict = new()
        {
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.8",
            Title = "Resource.Conflict",
            Status = StatusCodes.Status409Conflict,
            Detail = "The update conflicts with the current state of the resource"
        };
    }

    /// <summary>
    /// Error examples for delete operations.
    /// </summary>
    public static class Delete
    {
        public static readonly ProblemDetails NotFound = new()
        {
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.4",
            Title = "Resource.NotFound",
            Status = StatusCodes.Status404NotFound,
            Detail = "The resource with the specified identifier was not found"
        };

        public static readonly ProblemDetails Conflict = new()
        {
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.8",
            Title = "Resource.CannotDelete",
            Status = StatusCodes.Status409Conflict,
            Detail = "The resource cannot be deleted because it has dependent resources"
        };
    }
}
