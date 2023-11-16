# Stravaig.ShortCode

Provides a short code generator that can be used to create small user accessible codes. They can be used, for example, to allow the user to retrieve insurance or finance quotes without having to fully register with a service until they are ready to take the product on offer.

- ![Stravaig Short Code](https://github.com/Stravaig-Projects/Stravaig.ShortCode/workflows/Stravaig%20Short%20Code/badge.svg)
- Stravaig.ShortCode
  - ![Nuget](https://img.shields.io/nuget/v/Stravaig.ShortCode?color=004880&label=nuget%20stable&logo=nuget) [View on NuGet](https://www.nuget.org/packages/Stravaig.ShortCode)
  - ![Nuget (with prereleases)](https://img.shields.io/nuget/vpre/Stravaig.ShortCode?color=ffffff&label=nuget%20latest&logo=nuget) [View on NuGet](https://www.nuget.org/packages/Stravaig.ShortCode)
- Stravaig.ShortCode.DependencyInjection
    - ![Nuget](https://img.shields.io/nuget/v/Stravaig.ShortCode.DependencyInjection?color=004880&label=nuget%20stable&logo=nuget) [View on NuGet](https://www.nuget.org/packages/Stravaig.ShortCode.DependencyInjection)
    - ![Nuget (with prereleases)](https://img.shields.io/nuget/vpre/Stravaig.ShortCode.DependencyInjection?color=ffffff&label=nuget%20latest&logo=nuget) [View on NuGet](https://www.nuget.org/packages/Stravaig.ShortCode.DependencyInjection)

Supported frameworks: 6.0, 7.0

For .NET Core 3.1 and .NET 5.0 projects please use v1.x of these packages.

## Package overview

There are two packages. 
* The `Stravaig.ShortCode` package contains the classes needed to generate short codes.
* The `Stravaig.ShortCode.DependencyInjection` package contains extensions for the Microsoft Dependency Injection framework that comes with .NET Core / .NET 5.0 to makes setting up in your application easier.

## Installing the packages

At the command line:
```
> dotnet add package Stravaig.ShortCode

> dotnet add package Stravaig.ShortCode.DependencyInjection
```

Or using the package manager:
```powershell
> Install-Package Stravaig.ShortCode

> Install-Package Stravaig.ShortCode.DependencyInjection
```

You can also install using the package manager.

If you are going to be using extensions for the Microsoft Dependency Injection then you only need to install the `Straviag.ShortCode.DependencyInjection` package in your application entry assembly (the assembly in which you setup the dependency injection for your application) as it has a dependency on `Stravaig.ShortCode` already. In any other assembly in your application that needs to generate short codes, you will typically only need to install the `Stravaig.ShortCode` package.

## Fastest way to get started

There is a `static ShortCode` class that is preconfigures with some _reasonable_ defaults, although they can be overridden if desired.

To get a short code:

```csharp
// To generate a 7 character random short code
ShortCode.GenerateRandomShortCode();

// To generate short code of the given length
ShortCode.GenerateRandomShortCode(int length);

// To generate a 7 character sequential short code
ShortCode.GenerateSequentialShortCode();

// To generate sequential short code of the given length
ShortCode.GenerateSequentialShortCode(int length);
```

There are some configuration methods you can call during your app's startup:

* `ShortCode.SetLength(int)` sets the default length of the short codes that you want, defaults to 7.
* `ShortCode.SetSequentialSeed(ulong)` sets the starting point for the sequential codes, otherwise it will reset to zero every time your app starts.
* `ShortCode.SetCharacterSpace(string)` sets the characters that can be used in a short code, defaults to `NamedCharacterSpaces.LettersAndDigits` which is a list of unaccented Latin letters in lower and upper case and the digits zero to nine.
* `ShortCode.Use<TGenerator>()` sets the random generator to use. `TGenerator` can be:
  - `GuidCodeGenerator`: The code is a hashed form of a GUID
  - `RandomCodeGenerator`: The code is generated from the `Random` class.
  - `CryptographicallyRandomCodeGenerator`: The code is generated using a cryptographic strength random number generator.

## Setting up Short Codes with Microsoft's Dependency Injection

If web apps this will be in your `Startup` class, somewhere in the `ConfigureServices` method. Otherwise it will go wherever you are adding your dependency to the service collection.

e.g.
```csharp
  services.AddShortCodeGenerator<GuidCodeGenerator>(options =>
  {
      options.FixedLength = 5;
      options.CharacterSpace = Encoder.LettersAndDigits;
  });
```

There are many strategies for generating codes, so you will need to specify that. The following are the current strategies that are supplied in the package:

- `GuidCodeGenerator`: The code is a hashed form of a GUID
- `RandomCodeGenerator`: The code is generated from the `Random` class.
- `SequentialCodeGenerator`: The code is a sequential increment from the previous code.
- `CryptographicallyRandomCodeGenerator`: The code is generated using a cryptographic strength random number generator.

The `options` are not required, and if missing a reasonable set of defaults will be used. If a logger is set up, a warning will be generated if the options are set up poorly but won't break.

Once set up, in your application code you need to add `IShortCodeFactory` to any class that needs to generate short codes.

### SequentialCodeGenerator

This generator takes additional options as it will reset to zero on each application run (which may not be desirable).

Any generator specific options can be added via the `Generator` options property which is a `Dictionary<string, object>`. The keys are case insensitive.

The `Seed` entry can take a string or number. (Strings will be converted to a `ulong`, so must be parseable.)

```csharp
  services.AddShortCodeGenerator<GuidCodeGenerator>(options =>
  {
      options.FixedLength = 5;
      options.CharacterSpace = Encoder.LettersAndDigits;
      options.Generator["Seed"] = 12345;
  });
```

### Getting options from the configuration

You can pass an `IConfiguration` object to the code that sets up the code generator. It will then look for the option values in the configuration in the `Stravaig:ShortCode` section.

In the Startup.cs file:
```csharp
public class Startup
{
  private IConfiguration Configuration { get; }

  public Startup(IConfiguration configuration)
  {
    Configuration = configuration;
  }
  
  public void ConfigureServices(IServiceCollection services)
  {  
    // Other services for your application.
    services.AddShortCodeGenerator<GuidCodeGenerator>(Configuration);
  }
}
```

In the appsettings.json file:
```json
{
  "Stravaig": {
    "ShortCode": {
      "CharacterSpace": "0123456789QWERTYUIOPLKJHGFDSAZXCVBNM",
      "FixedLength": 7,
      "Generator": {
        "Seed": 12345
      }
    }
  }
}
```

## Using the IShortCodeFactory

To get a short code, the `IShortCodeFactory` interface exposes two methods for to create short codes.

* `GetNextCode()` will simply get the next code.
* `GetCodes(int)` will return the number of codes specified as an `IEnumerable<string>`
