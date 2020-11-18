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

    /* Here is the code generated for the above

    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Microsoft.Extensions.Logging;

    namespace Example
    {
        static class LoggerExtensions
        {
            private readonly struct __CouldNotOpenSocketStruct__ : IReadOnlyList<KeyValuePair<string, object>>
            {
                private readonly string hostName;

                public __CouldNotOpenSocketStruct__(string hostName)
                {
                    this.hostName = hostName;
                }

                public string Format() => $"Could not open socket to `{hostName}`";

                public int Count => 1;

                public KeyValuePair<string, object> this[int index]
                {
                    get
                    {
                        switch (index)
                        {
                            case 0:
                                return new KeyValuePair<string, object>(nameof(hostName), hostName);

                            default:
                                throw new ArgumentOutOfRangeException(nameof(index));
                        }
                    }
                }

                public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
                {
                    yield return new KeyValuePair<string, object>(nameof(hostName), hostName);
                }

                IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
            }

            private static readonly EventId __CouldNotOpenSocketEventId__ = new(0, nameof(CouldNotOpenSocket));

            public static void CouldNotOpenSocket(this ILogger logger, string hostName)
            {
                if (logger.IsEnabled((LogLevel)5))
                {
                    var s = new __CouldNotOpenSocketStruct__(hostName);
                    logger.Log((LogLevel)5, __CouldNotOpenSocketEventId__, s, null, (s, _) => s.Format());
                }
            }

            public static ILoggerExtensions Wrap(this ILogger logger) => new __Wrapper__(logger);
        
            private sealed class __Wrapper__ : ILoggerExtensions
            {
                private readonly ILogger __logger;
                public __Wrapper__(ILogger logger) => __logger = logger;
                public void CouldNotOpenSocket(string hostName) =>  __logger.CouldNotOpenSocket(hostName);
            }
        }
    }

*/

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
