namespace Recruitly.API.Common.Logging;

using Microsoft.Extensions.Logging;

internal static partial class Log
{
    private static class Messages
    {
        public const string ErrorOccuredMsg = "An error occurred while processing your request.";
    }

    [LoggerMessage(
        EventId = 100,
        Level = LogLevel.Information,
        Message = "Processing request {RequestName}")]
    internal static partial void ProcessingRequest(ILogger logger, string requestName);

    [LoggerMessage(
        EventId = 101,
        Level = LogLevel.Information,
        Message = "Completed request {RequestName}")]
    internal static partial void CompletedRequest(ILogger logger, string requestName);

    [LoggerMessage(
        EventId = 501,
        Level = LogLevel.Error,
        Message = "Completed request {RequestName} with error")]
    internal static partial void CompletedRequestWithError(ILogger logger, string requestName);

    [LoggerMessage(
        EventId = 502,
        Level = LogLevel.Error,
        Message = "Unhandled exception for {RequestName}")]
    internal static partial void UnhandledExceptionFor(ILogger logger, string requestName);

    [LoggerMessage(
        EventId = 500,
        Level = LogLevel.Error,
        Message = Messages.ErrorOccuredMsg)]
    internal static partial void ErrorOccured(ILogger logger);
}
