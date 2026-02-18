namespace Recruitly.Common.MultiTenancy;

/// <summary>
/// Extension methods for registering multi-tenancy services.
/// </summary>
public static class MultiTenancyModule
{
    /// <summary>
    /// Adds multi-tenancy services to the dependency injection container.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <returns>The service collection for chaining.</returns>
    public static IServiceCollection AddMultiTenancy(this IServiceCollection services)
    {
        services.AddScoped<ITenantContext, TenantContext>();
        return services;
    }
}
