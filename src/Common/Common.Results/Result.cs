namespace Recruitly.Common.Results;

/// <summary>
/// Represents the result of an operation that can either succeed or fail.
/// </summary>
public class Result
{
    /// <summary>
    /// Represents the result of an operation, encapsulating success or failure state
    /// and any associated error information.
    /// </summary>
    protected Result(bool isSuccess, Error error)
    {
        if ((isSuccess && error != Error.None) ||
            (!isSuccess && error == Error.None))
        {
            throw new ArgumentException("Invalid error", nameof(error));
        }

        IsSuccess = isSuccess;
        Error = error;
    }

    /// <summary>
    /// Gets a value indicating whether the operation was successful.
    /// </summary>
    /// <remarks>
    /// If <c>true</c>, the operation succeeded. If <c>false</c>, the operation failed,
    /// and additional error information can be found in the <see cref="Error"/> property.
    /// </remarks>
    public bool IsSuccess { get; }

    /// <summary>
    /// Gets a value indicating whether the operation has failed.
    /// </summary>
    /// <remarks>
    /// If <c>true</c>, the operation was not successful. If <c>false</c>, the operation succeeded,
    /// and the result can be accessed if applicable.
    /// </remarks>
    public bool IsFailure => !IsSuccess;

    /// <summary>
    /// Gets the error details associated with the operation, if any.
    /// </summary>
    /// <remarks>
    /// If the operation failed (<see cref="IsSuccess"/> is <c>false</c>), this property provides
    /// additional information about the failure. If the operation succeeded, the value is <see cref="Error.None"/>.
    /// </remarks>
    public Error Error { get; }

    /// <summary>
    /// Creates a successful result indicating that the operation completed without errors.
    /// </summary>
    /// <returns>A successful <see cref="Result"/> instance.</returns>
    public static Result Success() => new(true, Error.None);

    /// <summary>
    /// Returns a <see cref="Result"/> instance indicating a successful operation.
    /// </summary>
    /// <typeparam name="TValue">The type of the value associated with the operation.</typeparam>
    /// <param name="value">The value associated with the operation.</param>
    /// <returns>A <see cref="Result{TValue}"/> instance representing a successful operation with the specified value.</returns>
    public static Result<TValue> Success<TValue>(TValue value) => new(value, true, Error.None);

    /// <summary>
    /// Creates a failed result with the provided error information.
    /// </summary>
    /// <param name="error">The error details associated with the failure.</param>
    /// <returns>A <see cref="Result"/> indicating a failure, encapsulating the specified error details.</returns>
    public static Result Failure(Error error) => new(false, error);

    /// <summary>
    /// Creates a failed result with the provided error information.
    /// </summary>
    /// <typeparam name="TValue">The type of the value associated with the result.</typeparam>
    /// <param name="error">The error information describing the failure reason.</param>
    /// <returns>A <see cref="Result"/> indicating a failure, encapsulating the specified error details.</returns>
    public static Result<TValue> Failure<TValue>(Error error) => new(default, false, error);

    /// <summary>
    /// Creates a failed result representing a  validation error.
    /// </summary>
    /// <typeparam name="TValue">The type of value the result is handling.</typeparam>
    /// <param name="error">The error result containing details of the validation failure.</param>
    /// <returns>A <see cref="Result"/> containing the specified validation error.</returns>
    public static Result<TValue> ValidationFailure<TValue>(Error error) => new(default, false, error);
}

/// <inheritdoc />
public class Result<TValue>(TValue? value, bool isSuccess, Error error) : Result(isSuccess, error)
{
    /// <summary>
    /// Gets the value associated with the operation result.
    /// </summary>
    /// <remarks>
    /// This property returns the value if the operation was successful.
    /// Attempting to access this property when the result represents a failure will throw an <see cref="InvalidOperationException"/>.
    /// </remarks>
    public TValue Value => IsSuccess
        ? value!
        : throw new InvalidOperationException("Cannot access value of a failed result");

    /// <summary>
    /// Defines an implicit conversion from a value of type <typeparamref name="TValue"/> to a <see cref="Result{TValue}"/>,
    /// automatically creating a successful or failed result based on whether the value is null.
    /// </summary>
    /// <param name="value">The value to be converted into a <see cref="Result{TValue}"/>. If the value is null, a failure result is created.</param>
    /// <returns>
    /// A <see cref="Result{TValue}"/> instance that represents either a successful result if the value is non-null,
    /// or a failure result with an appropriate error if the value is null.
    /// </returns>
    public static implicit operator Result<TValue>(TValue value) =>
        value is not null ? Success(value) : Failure<TValue>(Error.NullValue);
}
