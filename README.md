# LoggingGenerator

This is an example showing how we can arrange to have strongly typed logging APIs.

The point of this exercise is to create a logging model which:

* Is delightful for service developers
* Eliminates string formatting
* Eliminates memory allocations
* Enables output in a dense binary format
* Enables more effective auditing of log data

Use is pretty simple. A service developer creates a class which lists all of the log messages that the assembly can produce.
Once this is done, new methods are generated automatically which the developer uses to interact with an ILogger instance. 

The Microsoft.Extensions.Logging.Generators project uses C# 9.0 source generators. This is magic voodoo invoked at compile time. This code is
responsible for finding types annotated with the [LoggerExtensions] attribute and automatically generating the strongly-typed
logging methods.

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
* The Microsoft.Extensions.Logging.Extras assembly is only temporary. The types in here should go to the Microsoft.Extensions.Logging.Abstractions assembly

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
