namespace Recruitly.Common.Results;

/// <summary>
/// Represents a validation error containing a collection of validation issues.
/// </summary>
/// <remarks>
/// This class is a specialized form of <see cref="Error"/> designed
/// to encapsulate one or more validation errors that occur during
/// an operation or process.
/// </remarks>
/// <param name="Errors">
/// A collection of <see cref="Error"/> objects representing individual
/// validation issues.
/// </param>
public record ValidationError(Error[] Errors) : Error("General.Validation",
    "One or more validation errors occurred",
    ErrorType.Validation)
{
    /// <summary>
    /// Creates a <see cref="ValidationError"/> instance from a collection of <see cref="Result"/> objects.
    /// Only the errors associated with failed results are included in the <see cref="ValidationError"/>.
    /// </summary>
    /// <param name="results">
    /// An enumerable collection of <see cref="Result"/> objects to extract errors from.
    /// </param>
    /// <returns>
    /// A <see cref="ValidationError"/> object containing all validation errors from the failed results.
    /// </returns>
    public static ValidationError FromResults(IEnumerable<Result> results) =>
        new([.. results.Where(r => r.IsFailure).Select(r => r.Error)]);
}
