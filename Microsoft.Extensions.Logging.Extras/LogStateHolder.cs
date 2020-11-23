// © Microsoft Corporation. All rights reserved.

namespace Microsoft.Extensions.Logging
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

#pragma warning disable CA1815 // Override equals and operator equals on value types

    /// <summary>
    /// Implementation detail of the logging source generator.
    /// </summary>
    public readonly struct LogStateHolder : IReadOnlyList<KeyValuePair<string, object?>>
    {
        public int Count => 0;

        public KeyValuePair<string, object?> this[int index]
        {
            get
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
        }

        public IEnumerator<KeyValuePair<string, object?>> GetEnumerator()
        {
            yield break;
        }

        public override string ToString() => string.Empty;
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public static readonly Func<LogStateHolder, Exception?, string> Format = (s, _) => string.Empty;
    }

    public readonly struct LogStateHolder<T> : IReadOnlyList<KeyValuePair<string, object?>>
    {
        private readonly Func<LogStateHolder<T>, Exception?, string> _formatFunc;
        private readonly Exception? _ex;
        private readonly string _name;
        private readonly T _value;

        public LogStateHolder(Func<LogStateHolder<T>, Exception?, string> formatFunc, Exception? ex, string name, T value)
        {
            _formatFunc = formatFunc;
            _ex = ex;
            _name = name;
            _value = value;
        }

        public int Count => 1;

        public KeyValuePair<string, object?> this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return new KeyValuePair<string, object?>(_name, _value);

                    default:
                        throw new ArgumentOutOfRangeException(nameof(index));
                }
            }
        }

        public IEnumerator<KeyValuePair<string, object?>> GetEnumerator()
        {
            yield return this[0];
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public override string ToString() => _formatFunc(this, _ex);

        public T Value => _value;
    }

    public readonly struct LogStateHolder<T1, T2> : IReadOnlyList<KeyValuePair<string, object?>>
    {
        private readonly Func<LogStateHolder<T1, T2>, Exception?, string> _formatFunc;
        private readonly Exception? _ex;
        private readonly string[] _names;
        private readonly T1 _value1;
        private readonly T2 _value2;

        public LogStateHolder(Func<LogStateHolder<T1, T2>, Exception?, string> formatFunc, Exception? ex, string[] names, T1 value1, T2 value2)
        {
            _formatFunc = formatFunc;
            _ex = ex;
            _names = names;
            _value1 = value1;
            _value2 = value2;
        }

        public int Count => 2;

        public KeyValuePair<string, object?> this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return new KeyValuePair<string, object?>(_names[0], _value1);

                    case 1:
                        return new KeyValuePair<string, object?>(_names[1], _value2);

                    default:
                        throw new ArgumentOutOfRangeException(nameof(index));
                }
            }
        }

        public IEnumerator<KeyValuePair<string, object?>> GetEnumerator()
        {
            for (int i = 0; i < 2; i++)
            {
                yield return this[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public override string ToString() => _formatFunc(this, _ex);

        public T1 Value1 => _value1;
        public T2 Value2 => _value2;
    }

    public readonly struct LogStateHolder<T1, T2, T3> : IReadOnlyList<KeyValuePair<string, object?>>
    {
        private readonly Func<LogStateHolder<T1, T2, T3>, Exception?, string> _formatFunc;
        private readonly Exception? _ex;
        private readonly string[] _names;
        private readonly T1 _value1;
        private readonly T2 _value2;
        private readonly T3 _value3;

        public LogStateHolder(Func<LogStateHolder<T1, T2, T3>, Exception?, string> formatFunc, Exception? ex, string[] names, T1 value1, T2 value2, T3 value3)
        {
            _formatFunc = formatFunc;
            _ex = ex;
            _names = names;
            _value1 = value1;
            _value2 = value2;
            _value3 = value3;
        }

        public int Count => 3;

        public KeyValuePair<string, object?> this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return new KeyValuePair<string, object?>(_names[0], _value1);

                    case 1:
                        return new KeyValuePair<string, object?>(_names[1], _value2);

                    case 2:
                        return new KeyValuePair<string, object?>(_names[2], _value3);

                    default:
                        throw new ArgumentOutOfRangeException(nameof(index));
                }
            }
        }

        public IEnumerator<KeyValuePair<string, object?>> GetEnumerator()
        {
            for (int i = 0; i < 3; i++)
            {
                yield return this[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public override string ToString() => _formatFunc(this, _ex);

        public T1 Value1 => _value1;
        public T2 Value2 => _value2;
        public T3 Value3 => _value3;
    }

    public readonly struct LogStateHolder<T1, T2, T3, T4> : IReadOnlyList<KeyValuePair<string, object?>>
    {
        private readonly Func<LogStateHolder<T1, T2, T3, T4>, Exception?, string> _formatFunc;
        private readonly Exception? _ex;
        private readonly string[] _names;
        private readonly T1 _value1;
        private readonly T2 _value2;
        private readonly T3 _value3;
        private readonly T4 _value4;

        public LogStateHolder(Func<LogStateHolder<T1, T2, T3, T4>, Exception?, string> formatFunc, Exception? ex, string[] names, T1 value1, T2 value2, T3 value3, T4 value4)
        {
            _formatFunc = formatFunc;
            _ex = ex;
            _names = names;
            _value1 = value1;
            _value2 = value2;
            _value3 = value3;
            _value4 = value4;
        }

        public int Count => 4;

        public KeyValuePair<string, object?> this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return new KeyValuePair<string, object?>(_names[0], _value1);

                    case 1:
                        return new KeyValuePair<string, object?>(_names[1], _value2);

                    case 2:
                        return new KeyValuePair<string, object?>(_names[2], _value3);

                    case 3:
                        return new KeyValuePair<string, object?>(_names[3], _value4);

                    default:
                        throw new ArgumentOutOfRangeException(nameof(index));
                }
            }
        }

        public IEnumerator<KeyValuePair<string, object?>> GetEnumerator()
        {
            for (int i = 0; i < 4; i++)
            {
                yield return this[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public override string ToString() => _formatFunc(this, _ex);

        public T1 Value1 => _value1;
        public T2 Value2 => _value2;
        public T3 Value3 => _value3;
        public T4 Value4 => _value4;
    }

    public readonly struct LogStateHolder<T1, T2, T3, T4, T5> : IReadOnlyList<KeyValuePair<string, object?>>
    {
        private readonly Func<LogStateHolder<T1, T2, T3, T4, T5>, Exception?, string> _formatFunc;
        private readonly Exception? _ex;
        private readonly string[] _names;
        private readonly T1 _value1;
        private readonly T2 _value2;
        private readonly T3 _value3;
        private readonly T4 _value4;
        private readonly T5 _value5;

        public LogStateHolder(Func<LogStateHolder<T1, T2, T3, T4, T5>, Exception?, string> formatFunc, Exception? ex, string[] names, T1 value1, T2 value2, T3 value3, T4 value4, T5 value5)
        {
            _formatFunc = formatFunc;
            _ex = ex;
            _names = names;
            _value1 = value1;
            _value2 = value2;
            _value3 = value3;
            _value4 = value4;
            _value5 = value5;
        }

        public int Count => 5;

        public KeyValuePair<string, object?> this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return new KeyValuePair<string, object?>(_names[0], _value1);

                    case 1:
                        return new KeyValuePair<string, object?>(_names[1], _value2);

                    case 2:
                        return new KeyValuePair<string, object?>(_names[2], _value3);

                    case 3:
                        return new KeyValuePair<string, object?>(_names[3], _value4);

                    case 4:
                        return new KeyValuePair<string, object?>(_names[4], _value5);

                    default:
                        throw new ArgumentOutOfRangeException(nameof(index));
                }
            }
        }

        public IEnumerator<KeyValuePair<string, object?>> GetEnumerator()
        {
            for (int i = 0; i < 5; i++)
            {
                yield return this[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public override string ToString() => _formatFunc(this, _ex);

        public T1 Value1 => _value1;
        public T2 Value2 => _value2;
        public T3 Value3 => _value3;
        public T4 Value4 => _value4;
        public T5 Value5 => _value5;
    }

    public readonly struct LogStateHolder<T1, T2, T3, T4, T5, T6> : IReadOnlyList<KeyValuePair<string, object?>>
    {
        private readonly Func<LogStateHolder<T1, T2, T3, T4, T5, T6>, Exception?, string> _formatFunc;
        private readonly Exception? _ex;
        private readonly string[] _names;
        private readonly T1 _value1;
        private readonly T2 _value2;
        private readonly T3 _value3;
        private readonly T4 _value4;
        private readonly T5 _value5;
        private readonly T6 _value6;

        public LogStateHolder(Func<LogStateHolder<T1, T2, T3, T4, T5, T6>, Exception?, string> formatFunc, Exception? ex, string[] names, T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6)
        {
            _formatFunc = formatFunc;
            _ex = ex;
            _names = names;
            _value1 = value1;
            _value2 = value2;
            _value3 = value3;
            _value4 = value4;
            _value5 = value5;
            _value6 = value6;
        }

        public int Count => 6;

        public KeyValuePair<string, object?> this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return new KeyValuePair<string, object?>(_names[0], _value1);

                    case 1:
                        return new KeyValuePair<string, object?>(_names[1], _value2);

                    case 2:
                        return new KeyValuePair<string, object?>(_names[2], _value3);

                    case 3:
                        return new KeyValuePair<string, object?>(_names[3], _value4);

                    case 4:
                        return new KeyValuePair<string, object?>(_names[4], _value5);

                    case 5:
                        return new KeyValuePair<string, object?>(_names[5], _value6);

                    default:
                        throw new ArgumentOutOfRangeException(nameof(index));
                }
            }
        }

        public IEnumerator<KeyValuePair<string, object?>> GetEnumerator()
        {
            for (int i = 0; i < 6; i++)
            {
                yield return this[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public override string ToString() => _formatFunc(this, _ex);

        public T1 Value1 => _value1;
        public T2 Value2 => _value2;
        public T3 Value3 => _value3;
        public T4 Value4 => _value4;
        public T5 Value5 => _value5;
        public T6 Value6 => _value6;
    }
}
