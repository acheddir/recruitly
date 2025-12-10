namespace Recruitly.Common.BusinessRules;

/// <summary>
/// Represents a business rule that can be evaluated to determine if specific conditions are met
/// and provides an associated error message if the rule is violated.
/// </summary>
public interface IBusinessRule
{
    /// <summary>
    /// Determines whether the business rule is met.
    /// </summary>
    /// <returns>
    /// True if the business rule is satisfied; otherwise, false.
    /// </returns>
    bool IsMet();

    /// <summary>
    /// Gets the error message associated with the business rule violation.
    /// </summary>
    /// <remarks>
    /// This property provides a descriptive message indicating the reason why
    /// the business rule is violated, if applicable.
    /// </remarks>
    string ErrorMessage { get; }
}
