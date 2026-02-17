namespace Recruitly.API.Common.Mediator.Behaviors;

using Recruitly.Common.MultiTenancy;

/// <summary>
/// Pipeline behavior that validates tenant context for requests implementing <see cref="ITenantScoped"/>.
/// If a request requires a tenant context but none is available, a <see cref="TenantNotResolvedException"/>
/// is thrown before the request handler is executed.
/// </summary>
/// <typeparam name="TRequest">The type of the request.</typeparam>
/// <typeparam name="TResponse">The type of the response.</typeparam>
internal sealed class TenantValidationPipelineBehavior<TRequest, TResponse>(ITenantContext tenantContext)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : class
    where TResponse : Result
{
    /// <summary>
    /// Handles the request by validating tenant context for tenant-scoped requests.
    /// </summary>
    /// <param name="request">The request instance.</param>
    /// <param name="next">The delegate for the next action in the pipeline.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The response from the next handler in the pipeline.</returns>
    /// <exception cref="TenantNotResolvedException">
    /// Thrown when the request implements <see cref="ITenantScoped"/> but no tenant context is available.
    /// </exception>
    public Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (request is ITenantScoped && !tenantContext.HasTenant)
        {
            throw new TenantNotResolvedException(
                $"Request '{typeof(TRequest).Name}' requires a tenant context, but no tenant was resolved. " +
                $"Ensure the '{TenantContext.TenantIdHeaderName}' header is provided in the request.");
        }

        return next(cancellationToken);
    }
}
