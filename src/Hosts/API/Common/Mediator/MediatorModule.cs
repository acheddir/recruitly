namespace Recruitly.API.Common.Mediator;

using Behaviors;

internal static class MediatorModule
{
    extension(IServiceCollection services)
    {
        internal IServiceCollection AddMediator(IConfiguration configuration, Assembly[] assemblies)
        {
            services.AddMediatR(config =>
            {
                config.LicenseKey = configuration["Licences:MediatR"];
                config.RegisterServicesFromAssemblies(assemblies);

                config.AddOpenBehavior(typeof(TenantValidationPipelineBehavior<,>));
                config.AddOpenBehavior(typeof(RequestLoggingPipelineBehavior<,>));
            });

            return services;
        }
    }
}
