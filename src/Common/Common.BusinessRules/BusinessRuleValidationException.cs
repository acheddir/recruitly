namespace Recruitly.Common.BusinessRules;

/// <summary>
/// Exception that is thrown when a business rule is violated.
/// </summary>
public class BusinessRuleValidationException(string message) : InvalidOperationException(message)
{
}
