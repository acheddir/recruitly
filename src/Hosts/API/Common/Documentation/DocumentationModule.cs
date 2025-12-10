namespace Recruitly.API.Common.Documentation;

internal static class DocumentationModule
{
    extension(IServiceCollection services)
    {
        internal IServiceCollection AddDocumentation()
        {
            services.AddOpenApi(options => options.AddScalarTransformers());

            return services;
        }
    }
}
