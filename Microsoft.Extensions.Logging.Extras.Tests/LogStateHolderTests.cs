// © Microsoft Corporation. All rights reserved.

namespace Microsoft.Extensions.Logging.Tests
{
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using Xunit;

    public class LogStateHolderTests
    {
        [Fact]
        public void NoType()
        {
            var kvp = Array.Empty<KeyValuePair<string, object?>>();

            var s = new LogStateHolder();
            TestCollection(kvp, s);
            Assert.Equal(string.Empty, LogStateHolder.Format(new LogStateHolder(), null));
        }

        [Fact]
        public void OneType()
        {
            var kvp = new KeyValuePair<string, object?>[]
            {
                new KeyValuePair<string, object?>("name1", 1),
            };

            Func<LogStateHolder<int>, Exception?, string> f = (_, _) => string.Empty;
            var s = new LogStateHolder<int>(f, "name1", 1);
            TestCollection(kvp, s);
            Assert.Equal(kvp[0].Value, s.Value);
        }

        [Fact]
        public void TwoTypes()
        {
            var kvp = new KeyValuePair<string, object?>[]
            {
                new KeyValuePair<string, object?>("name1", 1),
                new KeyValuePair<string, object?>("name2", 2),
            };

            Func<LogStateHolder<int, int>, Exception?, string> f = (_, _) => string.Empty;
            var s = new LogStateHolder<int, int>(f, new[] { "name1", "name2" }, 1, 2);
            TestCollection(kvp, s);
            Assert.Equal(kvp[0].Value, s.Value1);
            Assert.Equal(kvp[1].Value, s.Value2);
        }

        [Fact]
        public void ThreeTypes()
        {
            var kvp = new KeyValuePair<string, object?>[]
            {
                new KeyValuePair<string, object?>("name1", 1),
                new KeyValuePair<string, object?>("name2", 2),
                new KeyValuePair<string, object?>("name3", 3),
            };

            Func<LogStateHolder<int, int, int>, Exception?, string> f = (_, _) => string.Empty;
            var s = new LogStateHolder<int, int, int>(f, new[] { "name1", "name2", "name3" }, 1, 2, 3);
            TestCollection(kvp, s);
            Assert.Equal(kvp[0].Value, s.Value1);
            Assert.Equal(kvp[1].Value, s.Value2);
            Assert.Equal(kvp[2].Value, s.Value3);
        }

        [Fact]
        public void FourTypes()
        {
            var kvp = new KeyValuePair<string, object?>[]
            {
                new KeyValuePair<string, object?>("name1", 1),
                new KeyValuePair<string, object?>("name2", 2),
                new KeyValuePair<string, object?>("name3", 3),
                new KeyValuePair<string, object?>("name4", 4),
            };

            Func<LogStateHolder<int, int, int, int>, Exception?, string> f = (_, _) => string.Empty;
            var s = new LogStateHolder<int, int, int, int>(f, new[] { "name1", "name2", "name3", "name4" }, 1, 2, 3, 4);
            TestCollection(kvp, s);
            Assert.Equal(kvp[0].Value, s.Value1);
            Assert.Equal(kvp[1].Value, s.Value2);
            Assert.Equal(kvp[2].Value, s.Value3);
            Assert.Equal(kvp[3].Value, s.Value4);
        }

        [Fact]
        public void FiveTypes()
        {
            var kvp = new KeyValuePair<string, object?>[]
            {
                new KeyValuePair<string, object?>("name1", 1),
                new KeyValuePair<string, object?>("name2", 2),
                new KeyValuePair<string, object?>("name3", 3),
                new KeyValuePair<string, object?>("name4", 4),
                new KeyValuePair<string, object?>("name5", 5),
            };

            Func<LogStateHolder<int, int, int, int, int>, Exception?, string> f = (_, _) => string.Empty;
            var s = new LogStateHolder<int, int, int, int, int>(f, new[] { "name1", "name2", "name3", "name4", "name5" }, 1, 2, 3, 4, 5);
            TestCollection(kvp, s);
            Assert.Equal(kvp[0].Value, s.Value1);
            Assert.Equal(kvp[1].Value, s.Value2);
            Assert.Equal(kvp[2].Value, s.Value3);
            Assert.Equal(kvp[3].Value, s.Value4);
            Assert.Equal(kvp[4].Value, s.Value5);
        }

        [Fact]
        public void SixTypes()
        {
            var kvp = new KeyValuePair<string, object?>[]
            {
                new KeyValuePair<string, object?>("name1", 1),
                new KeyValuePair<string, object?>("name2", 2),
                new KeyValuePair<string, object?>("name3", 3),
                new KeyValuePair<string, object?>("name4", 4),
                new KeyValuePair<string, object?>("name5", 5),
                new KeyValuePair<string, object?>("name6", 6),
            };

            Func<LogStateHolder<int, int, int, int, int, int>, Exception?, string> f = (_, _) => string.Empty;
            var s = new LogStateHolder<int, int, int, int, int, int>(f, new[] { "name1", "name2", "name3", "name4", "name5", "name6" }, 1, 2, 3, 4, 5, 6);
            TestCollection(kvp, s);
            Assert.Equal(kvp[0].Value, s.Value1);
            Assert.Equal(kvp[1].Value, s.Value2);
            Assert.Equal(kvp[2].Value, s.Value3);
            Assert.Equal(kvp[3].Value, s.Value4);
            Assert.Equal(kvp[4].Value, s.Value5);
            Assert.Equal(kvp[5].Value, s.Value6);
        }

        private static void TestCollection(
            IReadOnlyList<KeyValuePair<string, object?>> expected,
            IReadOnlyList<KeyValuePair<string, object?>> actual)
        {
            Assert.Equal(expected, actual);
            Assert.Equal(expected.Count, actual.Count);

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.Equal(expected[i], actual[i]);
            }

            Assert.Throws<ArgumentOutOfRangeException>(() => _ = actual[expected.Count]);
        }
    }
}
