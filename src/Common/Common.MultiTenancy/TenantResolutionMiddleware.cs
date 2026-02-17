namespace Recruitly.Common.MultiTenancy;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Primitives;

/// <summary>
/// Middleware that resolves the tenant identifier from incoming HTTP requests.
/// The tenant ID is extracted from the <c>X-Tenant-Id</c> header and stored in <see cref="HttpContext.Items"/>
/// for consumption by <see cref="ITenantContext"/>.
/// </summary>
internal sealed class TenantResolutionMiddleware(RequestDelegate next)
{
    /// <summary>
    /// Processes the HTTP request to extract and store the tenant identifier.
    /// </summary>
    /// <param name="context">The HTTP context for the current request.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public Task InvokeAsync(HttpContext context)
    {
        if (context.Request.Headers.TryGetValue(TenantContext.TenantIdHeaderName, out StringValues tenantIdHeader))
        {
            string? tenantId = tenantIdHeader.FirstOrDefault();
            if (!string.IsNullOrWhiteSpace(tenantId))
            {
                context.Items[TenantContext.TenantIdItemKey] = tenantId;
            }
        }

        return next(context);
    }
}

/// <summary>
/// Extension methods for configuring tenant resolution middleware.
/// </summary>
public static class TenantResolutionMiddlewareExtensions
{
    /// <summary>
    /// Adds the tenant resolution middleware to the application pipeline.
    /// This middleware extracts the tenant ID from the <c>X-Tenant-Id</c> header
    /// and makes it available through <see cref="ITenantContext"/>.
    /// </summary>
    /// <param name="app">The application builder.</param>
    /// <returns>The application builder for chaining.</returns>
    public static IApplicationBuilder UseTenantResolution(this IApplicationBuilder app)
    {
        return app.UseMiddleware<TenantResolutionMiddleware>();
    }
}
