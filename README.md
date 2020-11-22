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

* Add nuget packaging voodoo
* Consider supporting generic parameters to logging methods
* Support nullable message parameter types
* Applying LoggerMessage to a non-partial method in a non-partial class doesn't produce an error, which is confusing for users'

## Example

Here is an example interface written by a developer, followed by the code being auto-generated.

```csharp
partial class Log
{
    [LoggerMessage(0, LogLevel.Critical, "Could not open socket to `{hostName}`")]
    public static partial void CouldNotOpenSocket(ILogger logger, string hostName);
}
```

And the resulting generated code:


```csharp
partial class Log
{
    private static readonly global::System.Func<global::Microsoft.Extensions.Logging.LogStateHolder<string>, global::System.Exception?, string> __CouldNotOpenSocketFormatFunc = (__holder, _) =>
    {
        var hostName = __holder.Value;
        return $"Could not open socket to `{hostName}`";
    };

    internal static partial void CouldNotOpenSocket(Microsoft.Extensions.Logging.ILogger __logger, string hostName)
    {
        if (__logger.IsEnabled((global::Microsoft.Extensions.Logging.LogLevel)5))
        {
            __logger.Log(
                (global::Microsoft.Extensions.Logging.LogLevel)5,
                new global::Microsoft.Extensions.Logging.EventId(0, nameof(CouldNotOpenSocket)),
                new global::Microsoft.Extensions.Logging.LogStateHolder<string>(nameof(hostName), hostName),
                null,
                __CouldNotOpenSocketFormatFunc);
        }
    }
}
```
