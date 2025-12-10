WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Host.AddLogging();

builder.Services
    .AddMediator(builder.Configuration, []);

WebApplication app = builder.Build();

app.MapGet("/", () => "Hello World!");

await app.RunAsync();
