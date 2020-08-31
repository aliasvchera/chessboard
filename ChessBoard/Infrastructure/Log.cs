using Microsoft.Extensions.Logging;

namespace ChessBoard.Infrastructure
{
    public class Log
    {
        internal static ILoggerFactory LoggerFactory { get; set; }
        internal static ILogger CreateLogger<t>() => LoggerFactory.CreateLogger<t>();
        internal static ILogger CreateLogger(string categoryName) => LoggerFactory.CreateLogger(categoryName);
    }
}
