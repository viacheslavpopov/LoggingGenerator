// © Microsoft Corporation. All rights reserved.

namespace Microsoft.Extensions.Logging.Tests
{
    using Microsoft.Extensions.Logging;
    using System;
    using Xunit;

    public class LoggerMessageAttributeTests
    {
        [Fact]
        public void Basic()
        {
            var a = new LoggerMessageAttribute(42, LogLevel.Trace, "Foo");
            Assert.Equal(42, a.EventId);
            Assert.Equal(LogLevel.Trace, a.Level);
            Assert.Equal("Foo", a.Message);
            Assert.Equal((string ?)null, a.EventName);

            a.EventId = 3_1415;
            a.Level = LogLevel.Debug;
            a.Message = "Bar";
            a.EventName = "Name";

            Assert.Equal(3_1415, a.EventId);
            Assert.Equal(LogLevel.Debug, a.Level);
            Assert.Equal("Bar", a.Message);
            Assert.Equal("Name", a.EventName);
        }
    }
}
