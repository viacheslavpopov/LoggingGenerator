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

        public int Count => 0;
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public override string ToString() => string.Empty;
        public static readonly Func<LogStateHolder, Exception?, string> Format = (s, _) => s.ToString();
    }

    public readonly struct LogStateHolder<T>
    {
        private readonly string _name;
        private readonly T _value;

        public LogStateHolder(string name, T value)
        {
            _name = name;
            _value = value;
        }

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

        public T Value => _value;
    }

    public readonly struct LogStateHolder<T1, T2>
    {
        private readonly string[] _names;
        private readonly T1 _value1;
        private readonly T2 _value2;

        public LogStateHolder(string[] names, T1 value1, T2 value2)
        {
            _names = names;
            _value1 = value1;
            _value2 = value2;
        }

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

        public T1 Value1 => _value1;
        public T2 Value2 => _value2;
    }

    public readonly struct LogStateHolder<T1, T2, T3>
    {
        private readonly string[] _names;
        private readonly T1 _value1;
        private readonly T2 _value2;
        private readonly T3 _value3;

        public LogStateHolder(string[] names, T1 value1, T2 value2, T3 value3)
        {
            _names = names;
            _value1 = value1;
            _value2 = value2;
            _value3 = value3;
        }

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

        public T1 Value1 => _value1;
        public T2 Value2 => _value2;
        public T3 Value3 => _value3;
    }

    public readonly struct LogStateHolder<T1, T2, T3, T4>
    {
        private readonly string[] _names;
        private readonly T1 _value1;
        private readonly T2 _value2;
        private readonly T3 _value3;
        private readonly T4 _value4;

        public LogStateHolder(string[] names, T1 value1, T2 value2, T3 value3, T4 value4)
        {
            _names = names;
            _value1 = value1;
            _value2 = value2;
            _value3 = value3;
            _value4 = value4;
        }

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

        public T1 Value1 => _value1;
        public T2 Value2 => _value2;
        public T3 Value3 => _value3;
        public T4 Value4 => _value4;
    }

    public readonly struct LogStateHolder<T1, T2, T3, T4, T5>
    {
        private readonly string[] _names;
        private readonly T1 _value1;
        private readonly T2 _value2;
        private readonly T3 _value3;
        private readonly T4 _value4;
        private readonly T5 _value5;

        public LogStateHolder(string[] names, T1 value1, T2 value2, T3 value3, T4 value4, T5 value5)
        {
            _names = names;
            _value1 = value1;
            _value2 = value2;
            _value3 = value3;
            _value4 = value4;
            _value5 = value5;
        }

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

        public T1 Value1 => _value1;
        public T2 Value2 => _value2;
        public T3 Value3 => _value3;
        public T4 Value4 => _value4;
        public T5 Value5 => _value5;
    }

    public readonly struct LogStateHolder<T1, T2, T3, T4, T5, T6>
    {
        private readonly string[] _names;
        private readonly T1 _value1;
        private readonly T2 _value2;
        private readonly T3 _value3;
        private readonly T4 _value4;
        private readonly T5 _value5;
        private readonly T6 _value6;

        public LogStateHolder(string[] names, T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6)
        {
            _names = names;
            _value1 = value1;
            _value2 = value2;
            _value3 = value3;
            _value4 = value4;
            _value5 = value5;
            _value6 = value6;
        }

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

        public T1 Value1 => _value1;
        public T2 Value2 => _value2;
        public T3 Value3 => _value3;
        public T4 Value4 => _value4;
        public T5 Value5 => _value5;
        public T6 Value6 => _value6;
    }
}
