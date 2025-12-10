WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Host.AddLogging();

builder.Services
    .AddErrorHandling()
    .AddMediator(builder.Configuration, []);

WebApplication app = builder.Build();

app.UseErrorHandling();

await app.RunAsync();
