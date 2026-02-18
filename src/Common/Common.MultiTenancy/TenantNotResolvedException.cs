namespace Recruitly.Common.MultiTenancy;

/// <summary>
/// Exception thrown when a tenant-scoped operation is attempted without a valid tenant context.
/// </summary>
public sealed class TenantNotResolvedException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TenantNotResolvedException"/> class.
    /// </summary>
    public TenantNotResolvedException()
        : base("A valid tenant context is required for this operation, but no tenant was resolved.")
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="TenantNotResolvedException"/> class
    /// with a custom message.
    /// </summary>
    /// <param name="message">The error message.</param>
    public TenantNotResolvedException(string message)
        : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="TenantNotResolvedException"/> class
    /// with a custom message and inner exception.
    /// </summary>
    /// <param name="message">The error message.</param>
    /// <param name="innerException">The inner exception.</param>
    public TenantNotResolvedException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}
