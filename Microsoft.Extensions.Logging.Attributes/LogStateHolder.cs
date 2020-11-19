// © Microsoft Corporation. All rights reserved.

namespace Microsoft.Extensions.Logging
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

#pragma warning disable CA1815 // Override equals and operator equals on value types

    /// <summary>
    /// Implementation detail of the logging source generator
    /// </summary>
    /// <remarks>
    /// This should be move to an out-of-the-way corner somewhere...
    /// </remarks>
    public readonly struct LogStateHolder : IReadOnlyList<KeyValuePair<string, object>>
    {
        public int Count => 0;

        public KeyValuePair<string, object> this[int index]
        {
            get
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
        }

        public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
        {
            yield break;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
