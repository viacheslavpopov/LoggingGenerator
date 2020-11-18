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

## Design Issues

The fact this uses types generated dynamically at compile-time means
that symbols aren't available at edit-time. Smart IDEs like VS 2019+
handle this automatically. But editors which aren't tightly integrated
with Roslyn will show red squiggles to the developer, which is sad.

## Implementation Todos

* Transpose doc comments from source interface to the generated type to improve IntelliSense experience.
* Add nuget packaging voodoo
* Localize error messages?
