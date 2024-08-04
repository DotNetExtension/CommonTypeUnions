[![GitHub license](https://img.shields.io/github/license/DotNetExtension/CommonTypeUnions?style=for-the-badge&color=00bb00)](https://github.com/DotNetExtension/CommonTypeUnions/blob/main/LICENSE.txt)
[![Contributor Covenant](https://img.shields.io/badge/Contributor%20Covenant-2.0-4baaaa?style=for-the-badge)](CODE_OF_CONDUCT.md)
[![GitHub issues](https://img.shields.io/github/issues/DotNetExtension/CommonTypeUnions?style=for-the-badge)](https://github.com/DotNetExtension/CommonTypeUnions/issues)

# Common Union Types
This library contains a set of commonly used type unions.

Type unions are an upcoming feature that is [proposed](https://github.com/dotnet/csharplang/blob/main/proposals/TypeUnions.md) for a future version of C#.
We try our best to keep the types in this library as close as possible to the proposal as possible to make a transition to future Type Unions as easy as possible.

> [!WARNING]
> Type Unions are in the early proposal stage and will likely see changes as time goes on, we plan to keep up with these changes as
> much as possible to ensure the easiest migration path once type unions make it into a stable .net version.

# Option&lt;TValue&gt;

Option is a struct union found in many languages, it can either represent a value that is something (`Some`) or nothing (`None`).

```csharp
using CommonTypeUnions.Unions;
using static CommonTypeUnions.Extensions.OptionExtensions;

Option<string> x = Some("text");
Option<string> y = None();

if (x.IsSome(out var value))
{
    Console.WriteLine($"Value: {value}");
}

var isNone = y.IsNone();

Console.WriteLine($"Is None: {isNone}");
```

Output:
```powershell
Value: text
Is None: True
```

# Result&lt;TValue, TError&gt;

Option is a struct union found in many languages, it is used to either represent a successful result (`Success`) or error (`Failure`) from a function.

```csharp
using CommonTypeUnions.Unions;
using static CommonTypeUnions.Extensions.ResultExtensions;

Result<int, string> x = Success(42);
Result<int, string> y = Failure("Oh no");

if (x.IsSuccess(out var value))
{
    Console.WriteLine($"Value: {value}");
}

if (y.IsFailure(out var error))
{
    Console.WriteLine($"Failure: {error}");
}
```

Output:
```powershell
Value: 42
Failure: Oh no
```
