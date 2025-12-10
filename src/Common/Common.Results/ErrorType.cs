namespace Recruitly.Common.Results;

/// <summary>
/// Represents the type of error that occurred in the system.
/// </summary>
public enum ErrorType
{
    Failure = 0,
    Validation = 1,
    Problem = 2,
    NotFound = 3,
    Conflict = 4
}

