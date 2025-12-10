namespace Recruitly.API.Common.Logging;

internal static class LoggingModule
{
    extension(IHostBuilder hostBuilder)
    {
        internal IHostBuilder AddLogging()
        {
            hostBuilder.UseSerilog((ctx, config) =>
                config.ReadFrom.Configuration(ctx.Configuration));

            return hostBuilder;
        }
    }
}
