// © Microsoft Corporation. All rights reserved.

namespace Example
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text.Json;
    using Microsoft.Extensions.Logging;

    partial class Log
    {
        [LoggerMessage(0, LogLevel.Critical, "Could not open socket to `{hostName}`")]
        public static partial void CouldNotOpenSocket(ILogger logger, string hostName);
    }

    static partial class Log
    {
        [LoggerMessage(1, LogLevel.Debug, @"Connection id '{connectionId}' started.")]
        public static partial void ConnectionStart(ILogger logger, string connectionId);

        [LoggerMessage(2, LogLevel.Debug, @"Connection id '{connectionId}' stopped.")]
        public static partial void ConnectionStop(ILogger logger, string connectionId);

        [LoggerMessage(4, LogLevel.Debug, @"Connection id '{connectionId}' paused.")]
        public static partial void ConnectionPause(ILogger logger, string connectionId);
        
        [LoggerMessage(5, LogLevel.Debug, @"Connection id '{connectionId}' resume.")]
        public static partial void ConnectionResume(ILogger logger, string connectionId);

        [LoggerMessage(9, LogLevel.Debug, @"Connection id '{connectionId}' completed keep alive response.")]
        public static partial void ConnectionKeepAlive(ILogger logger, string connectionId);

        [LoggerMessage(38, LogLevel.Debug, @"Connection id '{connectionId}' received {type} frame for stream ID {streamId} with length {length} and flags {flags}")]
        public static partial void Http2FrameReceived(ILogger logger, string connectionId, byte type, int streamId, int length, byte flags);

        // Not a logger message
        public static void Http2FrameReceived(ILogger logger, string connectionId, Http2Frame http2Frame)
        {
            Http2FrameReceived(logger, connectionId, http2Frame.Type, http2Frame.StreamId, http2Frame.PayloadLength, http2Frame.Flags);
        }
    }

    public class Http2Frame
    {
        public int PayloadLength { get; set; }

        public byte Type { get; set; }

        public byte Flags { get; set; }

        public int StreamId { get; set; }
    }

    // example generated type
    class Log2
    {
        private readonly struct __CouldNotOpenSocketState : IReadOnlyList<KeyValuePair<string, object?>>
        {
            private readonly LogStateHolder<string> _holder;

            public __CouldNotOpenSocketState(string hostName)
            {
                _holder = new(nameof(hostName), hostName);
            }

            public override string ToString()
            {
                var hostName = _holder.Value;
                return $"Could not open socket to `{hostName}`";
            }

            public int Count => 1;
            public KeyValuePair<string, object?> this[int index] => _holder[index];
            public IEnumerator<KeyValuePair<string, object?>> GetEnumerator() => _holder.GetEnumerator();
            IEnumerator IEnumerable.GetEnumerator() => _holder.GetEnumerator();
            public static readonly Func<__CouldNotOpenSocketState, Exception?, string> Format = (s, _) => s.ToString();
        }

        public static void CouldNotOpenSocket(ILogger logger, string hostName)
        {
            if (logger.IsEnabled((LogLevel)5))
            {
                logger.Log((LogLevel)5, new EventId(0, nameof(CouldNotOpenSocket)), new __CouldNotOpenSocketState(hostName), null, __CouldNotOpenSocketState.Format);
            }
        }

        public static void FooHappened(ILogger logger)
        {
            if (logger.IsEnabled((LogLevel)5))
            {
//                logger.Log((LogLevel)5, new EventId(0, nameof(FooHappened)), new LogStateHolder(), null, LogStateHolder.Format);
            }
        }

        public static void BarHappened(ILogger logger, string arg1)
        {
            if (logger.IsEnabled((LogLevel)5))
            {
                var a = new KeyValuePair<string, object?>[] {
                    new KeyValuePair<string, object?>(nameof(arg1), arg1),
                };

                logger.Log((LogLevel)5, new EventId(0, nameof(BarHappened)), a, null, (s, _) =>
                {
                    return string.Empty;
                });
            }
        }
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

            var id = Guid.NewGuid().ToString();
            Log.ConnectionStart(logger, id);

            Log.ConnectionStop(logger, id);

            Log.Http2FrameReceived(logger, id, new Http2Frame()
            {
                Flags = 2,
                PayloadLength = 100,
                StreamId = 4,
                Type = 4
            });
        }
    }
}
