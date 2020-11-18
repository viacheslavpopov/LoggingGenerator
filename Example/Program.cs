// © Microsoft Corporation. All rights reserved.

namespace Example
{
    using System.Text.Json;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// All the logging messages this assembly outputs.
    /// </summary>
    [LoggerExtensions]
    interface ILoggerExtensions
    {
        /// <summary>
        /// Use this when you can't open a socket
        /// </summary>
        [LoggerMessage(0, LogLevel.Critical, "Could not open socket to `{hostName}`")]
        void CouldNotOpenSocket(string hostName);

        [LoggerMessage(1, LogLevel.Critical, "Hello {name}", EventName = "Override")]
        void SayHello(string name);
    }

    class Program
    {
        static void Main()
        {
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole().AddJsonConsole(o =>
                {
                    // This will let us see the structure going to the logger
                    o.JsonWriterOptions = new JsonWriterOptions
                    {
                        Indented = true
                    };
                }); 
            });

            var logger = loggerFactory.CreateLogger("LoggingExample");

            // Approach #1: Extension method on ILogger
            logger.CouldNotOpenSocket("microsoft.com");

            // Approach #2: wrapper type around ILogger
            var d = logger.Wrap();
            d.CouldNotOpenSocket("microsoft.com");

            logger.SayHello("David");
        }
    }
}
