namespace Recruitly.Common.MultiTenancy;

/// <summary>
/// Provides access to the current tenant context within the application.
/// </summary>
public interface ITenantContext
{
    /// <summary>
    /// Gets the unique identifier of the current tenant.
    /// </summary>
    /// <value>The tenant identifier, or <c>null</c> if no tenant context is available.</value>
    string? TenantId { get; }

    /// <summary>
    /// Gets a value indicating whether a tenant context has been established.
    /// </summary>
    /// <value><c>true</c> if a tenant is resolved; otherwise, <c>false</c>.</value>
    bool HasTenant { get; }
}
