namespace Recruitly.Common.Endpoints;

public static class EndpointsModule
{
    public static IServiceCollection AddEndpoints(this IServiceCollection services, Assembly assembly)
    {
        Assembly[] assemblies = [assembly];

        ServiceDescriptor[] serviceDescriptors =
        [
            ..assemblies
                .SelectMany(a => a.GetTypes())
                .Where(t => t is { IsAbstract: false, IsInterface: false } &&
                            t.IsAssignableTo(typeof(IEndpoint)))
                .Select(t => ServiceDescriptor.Transient(typeof(IEndpoint), t))
        ];

        services.TryAddEnumerable(serviceDescriptors);

        return services;
    }
}

