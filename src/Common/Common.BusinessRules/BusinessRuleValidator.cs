namespace Recruitly.Common.BusinessRules;

/// <summary>
/// The BusinessRuleValidator class is designed to validate business rules within the application.
/// It serves as a mechanism to enforce domain-specific rules by encapsulating validation logic
/// and ensuring the integrity of the operations tied to these rules.
/// </summary>
public static class BusinessRuleValidator
{
    /// <summary>
    /// Validates a specified business rule and throws an exception if the rule is not met.
    /// </summary>
    /// <param name="rule">
    /// The business rule to validate, implementing the <see cref="IBusinessRule"/> interface.
    /// </param>
    /// <exception cref="BusinessRuleValidationException">
    /// Thrown if the business rule is violated.
    /// </exception>
    public static void Validate(IBusinessRule rule)
    {
        if (!rule.IsMet())
        {
            throw new BusinessRuleValidationException(rule.ErrorMessage);
        }
    }
}
