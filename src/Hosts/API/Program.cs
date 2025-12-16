WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Host.AddLogging();

builder.Services
    .AddDocumentation()
    .AddEndpointsApiExplorer()
    .AddVersioning()
    .AddErrorHandling()
    .AddHttpContextAccessor()
    .AddMediator(builder.Configuration, []);

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseApiDocumentation();
}

app
    .UseHttpsRedirection()
    .UseRouting()
    .UseErrorHandling();

await app.RunAsync();

namespace Recruitly.API
{
    [UsedImplicitly]
    public sealed partial class Program;
}
