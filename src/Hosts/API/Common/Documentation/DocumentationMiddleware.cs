namespace Recruitly.API.Common.Documentation;

internal static class DocumentationMiddleware
{
    extension(IEndpointRouteBuilder builder)
    {
        internal IEndpointRouteBuilder UseApiDocumentation()
        {
            builder.MapOpenApi();
            builder.MapScalarApiReference("/docs", options =>
            {
                options.WithTitle("Recruitly API Documentation");
            });

            return builder;
        }
    }
}
