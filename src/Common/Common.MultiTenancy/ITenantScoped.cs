namespace Recruitly.Common.MultiTenancy;

/// <summary>
/// Marker interface indicating that a request (command or query) requires a valid tenant context.
/// Requests implementing this interface will be validated by the tenant validation pipeline behavior
/// to ensure a tenant has been resolved before the request handler is executed.
/// </summary>
public interface ITenantScoped;
