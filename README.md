# LoggingGenerator

This is an example showing how we can arrange to have strongly typed logging APIs.

The point of this exercise is to create a logging model which:

* Is delightful for service developers
* Eliminates string formatting
* Eliminates memory allocations
* Enables output in a dense binary format
* Enables more effective auditing of log data

Use is pretty simple. A service developer creates an interface type which lists all of the log messages that the assembly can produce.
Once this is done, a new type is generated automatically which the developer uses to interactively with an ILogger instance. 

The Microsoft.Extensions.Logging.Generators project uses C# 9.0 source generators. This is magic voodoo invoked at compile time. This code is
responsible for finding types annotated with the [LoggerExtensions] attribute and automatically generating the strongly-typed
logging methods.

The strongly-typed methods are generated in two forms:

* As extension methods on ILogger. So a developer does logger.MyCustomLoggingMethod(arg1, arg2, arg3) throughout their code.

* As an implementations of the interface type defined by the developer. This effectively encapsulates the ILogger and allows
the developer to use their interface type for logging throughout their code. The good part about this approach is that it 
systematically prevents code from using the non-strongly-type methods on ILogger. Using the interface type also tends to
produce a better IntelliSense experience overall.

## Design Issues

The fact this uses types generated dynamically at compile-time means
that symbols aren't available at edit-time. Smart IDEs like VS 2019+
handle this automatically. But editors which aren't tightly integrated
with Roslyn will show red squiggles to the developer, which is sad.

## Implementation Todos

* Transpose doc comments from source interface to the generated type to improve IntelliSense experience.
* Add nuget packaging voodoo
* Localize error messages?

## Example

Here is an example interface written by a developer, followed by the code being auto-generated.

```csharp
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
```

And the resulting generated code:


```csharp
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


            public override string ToString() => $"Could not open socket to `{hostName}`";


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
                var message = new __CouldNotOpenSocketStruct__(hostName);
                logger.Log((LogLevel)5, __CouldNotOpenSocketEventId__, message, null, (s, _) => s.ToString());
            }
        }

        private readonly struct __SayHelloStruct__ : IReadOnlyList<KeyValuePair<string, object>>
        {
            private readonly string name;


            public __SayHelloStruct__(string name)
            {
                this.name = name;

            }


            public override string ToString() => $"Hello {name}";


            public int Count => 1;

            public KeyValuePair<string, object> this[int index]
            {
                get
                {
                    switch (index)
                    {
                        case 0:
                            return new KeyValuePair<string, object>(nameof(name), name);

                        default:
                            throw new ArgumentOutOfRangeException(nameof(index));
                    }
                }
            }

            public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
            {
                yield return new KeyValuePair<string, object>(nameof(name), name);

            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
        private static readonly EventId __SayHelloEventId__ = new(1, "Override");

        
        public static void SayHello(this ILogger logger, string name)
        {
            if (logger.IsEnabled((LogLevel)5))
            {
                var message = new __SayHelloStruct__(name);
                logger.Log((LogLevel)5, __SayHelloEventId__, message, null, (s, _) => s.ToString());
            }
        }

        public static ILoggerExtensions Wrap(this ILogger logger) => new __Wrapper__(logger);
        
        private sealed class __Wrapper__ : ILoggerExtensions
        {
            private readonly ILogger __logger;

            public __Wrapper__(ILogger logger) => __logger = logger;
            
            public void CouldNotOpenSocket(string hostName) =>  __logger.CouldNotOpenSocket(hostName);

            public void SayHello(string name) =>  __logger.SayHello(name);

        }

    }
}
```
