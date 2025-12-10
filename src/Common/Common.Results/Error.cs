namespace Recruitly.Common.Results;

/// <summary>
/// Represents details about an error that occurred in an operation.
/// </summary>
public record Error(string Code, string Description, ErrorType Type)
{
    /// <summary>
    /// Represents a predefined instance of <see cref="Error"/> with no error.
    /// </summary>
    /// <remarks>
    /// Used to indicate the absence of any error in successful operations.
    /// This instance contains an empty error code, description, and is of type <see cref="ErrorType.Failure"/>.
    /// </remarks>
    public static readonly Error None = new(string.Empty, string.Empty, ErrorType.Failure);

    /// <summary>
    /// Represents a predefined instance of <see cref="Error"/> indicating that a null value
    /// was provided where it is not allowed or expected.
    /// </summary>
    /// <remarks>
    /// This instance has a specific error code "General.Null", a description "Null value was provided",
    /// and is of type <see cref="ErrorType.Failure"/>.
    /// </remarks>
    public static readonly Error NullValue = new(
        "General.Null",
        "Null value was provided",
        ErrorType.Failure);

    /// <summary>
    /// Creates an <see cref="Error"/> instance with the specified code and description indicating a failure type error.
    /// </summary>
    /// <param name="code">The error code representing the failure.</param>
    /// <param name="description">A detailed description of the failure.</param>
    /// <returns>An instance of <see cref="Error"/> with type <see cref="ErrorType.Failure"/>.</returns>
    public static Error Failure(string code, string description) =>
        new(code, description, ErrorType.Failure);

    /// <summary>
    /// Creates an <see cref="Error"/> instance with the specified code and description,
    /// indicating a not found type error.
    /// </summary>
    /// <param name="code">The error code representing the not found error.</param>
    /// <param name="description">A detailed description of the not found error.</param>
    /// <returns>An instance of <see cref="Error"/> with type <see cref="ErrorType.NotFound"/>.</returns>
    public static Error NotFound(string code, string description) =>
        new(code, description, ErrorType.NotFound);

    /// <summary>
    /// Creates an <see cref="Error"/> instance with the specified code and description,
    /// indicating a problem type error.
    /// </summary>
    /// <param name="code">The error code representing the problem.</param>
    /// <param name="description">A detailed description of the problem encountered.</param>
    /// <returns>An instance of <see cref="Error"/> with type <see cref="ErrorType.Problem"/>.</returns>
    public static Error Problem(string code, string description) =>
        new(code, description, ErrorType.Problem);

    /// <summary>
    /// Creates an <see cref="Error"/> instance with the specified code and description,
    /// indicating a conflict type error.
    /// </summary>
    /// <param name="code">The error code representing the conflict.</param>
    /// <param name="description">A detailed description of the conflict.</param>
    /// <returns>An instance of <see cref="Error"/> with type <see cref="ErrorType.Conflict"/>.</returns>
    public static Error Conflict(string code, string description) =>
        new(code, description, ErrorType.Conflict);
}
