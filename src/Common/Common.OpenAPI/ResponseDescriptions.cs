namespace Recruitly.Common.OpenAPI;

/// <summary>
/// Standard response descriptions for OpenAPI documentation.
/// </summary>
public static class ResponseDescriptions
{
    /// <summary>
    /// Standard descriptions for common HTTP status codes.
    /// </summary>
    public static class Common
    {
        public const string Unauthorized = "Unauthorized. Authentication credentials are missing or invalid.";
        public const string Forbidden = "Forbidden. The authenticated user does not have permission to perform this operation.";
        public const string InternalServerError = "Internal server error. An unexpected error occurred while processing the request.";
    }

    /// <summary>
    /// Descriptions for resource creation operations (POST).
    /// </summary>
    public static class Create
    {
        public const string Success = "Resource created successfully. Returns the unique identifier of the newly created resource.";
        public const string BadRequest = "Bad request. The request body failed validation.";
        public const string Conflict = "Conflict. A resource with the specified identifier already exists.";
    }

    /// <summary>
    /// Descriptions for resource retrieval operations (GET).
    /// </summary>
    public static class Get
    {
        public const string Success = "Resource retrieved successfully.";
        public const string NotFound = "Not found. The requested resource does not exist.";
        public const string BadRequest = "Bad request. The request parameters are invalid.";
    }

    /// <summary>
    /// Descriptions for resource update operations (PUT/PATCH).
    /// </summary>
    public static class Update
    {
        public const string Success = "Resource updated successfully.";
        public const string NotFound = "Not found. The requested resource does not exist.";
        public const string BadRequest = "Bad request. The request body failed validation.";
        public const string Conflict = "Conflict. The update cannot be completed due to a conflict with the current state.";
    }

    /// <summary>
    /// Descriptions for resource deletion operations (DELETE).
    /// </summary>
    public static class Delete
    {
        public const string Success = "Resource deleted successfully.";
        public const string NotFound = "Not found. The requested resource does not exist.";
        public const string Conflict = "Conflict. The resource cannot be deleted due to existing dependencies.";
    }
}
