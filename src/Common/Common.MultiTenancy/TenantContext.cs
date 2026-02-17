namespace Recruitly.Common.MultiTenancy;

/// <summary>
/// Default implementation of <see cref="ITenantContext"/> that retrieves tenant information
/// from the current HTTP context.
/// </summary>
internal sealed class TenantContext(IHttpContextAccessor httpContextAccessor) : ITenantContext
{
    /// <summary>
    /// The HTTP header name used to identify the tenant.
    /// </summary>
    public const string TenantIdHeaderName = "X-Tenant-Id";

    /// <summary>
    /// The key used to store the tenant ID in HttpContext.Items.
    /// </summary>
    internal const string TenantIdItemKey = "TenantId";

    /// <inheritdoc />
    public string? TenantId => GetTenantIdFromContext();

    /// <inheritdoc />
    public bool HasTenant => !string.IsNullOrWhiteSpace(TenantId);

    private string? GetTenantIdFromContext()
    {
        HttpContext? httpContext = httpContextAccessor.HttpContext;
        if (httpContext is null)
        {
            return null;
        }

        // First, check if tenant ID was already resolved and stored in Items
        if (httpContext.Items.TryGetValue(TenantIdItemKey, out object? storedTenantId) &&
            storedTenantId is string tenantId)
        {
            return tenantId;
        }

        return null;
    }
}
