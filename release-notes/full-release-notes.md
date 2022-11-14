# Full Release Notes

## Version 1.1.0

Date: Monday, 14 November, 2022 at 20:25:38 +00:00

### Miscellaneous

- Add support for .NET 6.0 & .NET 7.0
- Add [Source Link](https://github.com/dotnet/sourcelink) to allow easier debugging of the package in consuming applications. This will allow developers to step into the source code of this package when debugging their own code that uses this package.

### Packages

- .netstandard2.0
  - Bump Microsoft.Extensions.DependencyInjection.Abstractions to 3.1.31
  - Bump Microsoft.Extensions.Logging.Abstractions to 3.1.31
  - Bump Microsoft.Extensions.Options to 3.1.31
  - Bump Microsoft.Extensions.Options.ConfigurationExtensions to 3.1.31
- .NET 6.0
  - Introduce Microsoft.Extensions.DependencyInjection.Abstractions 6.0.0
  - Introduce Microsoft.Extensions.Logging.Abstractions to 6.0.3
  - Introduce Microsoft.Extensions.Options to 6.0.0
  - Introduce Microsoft.Extensions.Options.ConfigurationExtensions to 6.0.0
- .NET 7.0
  - Introduce Microsoft.Extensions.DependencyInjection.Abstractions 7.0.0
  - Introduce Microsoft.Extensions.Logging.Abstractions to 7.0.0
  - Introduce Microsoft.Extensions.Options to 7.0.0
  - Introduce Microsoft.Extensions.Options.ConfigurationExtensions to 7.0.0

## Version 1.0.4

Date: Wednesday, 17 November, 2021 at 21:51:34 +00:00

### Dependencies

- netstandard2.0 dependencies
  - Bump Microsoft.Extensions.DependencyInjection.Abstractions to 3.1.21
  - Bump Microsoft.Extensions.Logging.Abstractions to 3.1.21
  - Bump Microsoft.Extensions.Options to 3.1.21
  - Bump Microsoft.Extensions.Options.ConfigurationExtensions to 3.1.21 
- General
  - Bump Microsoft.NET.Test.Sdk to 17.0.0
  - Bump NUnit3TestAdapter to 4.1.0
  - Bump Stravaig.Extensions.Logging.Diagnostics to 1.1.4
## Version 1.0.3

Date: Tuesday, 14 September, 2021 at 22:34:48 +00:00

### Dependencies

- .NET Standard 2.0
  - Bump Microsoft.Extensions.DependencyInjection.Abstractions to 3.1.19
  - Bump Microsoft.Extensions.Logging.Abstractions to 3.1.19
  - Bump Microsoft.Extensions.Options to 3.1.19
  - Bump Microsoft.Extensions.Options.ConfigurationExtensions to 3.1.19
- General 
  - Bump BenchmarkDotNet from 0.12.1 to 0.13.1
  - Bump Stravaig.Extensions.Logging.Diagnostics to 1.1.2
## Version 1.0.2

Date: Wednesday, 11 August, 2021 at 23:03:09 +00:00

### Bugs

### Features

### Miscellaneous

### Dependencies

- .netstandard 2.0
  - Bump Microsoft.Extensions.DependencyInjection.Abstractions to 3.1.18
  - Bump Microsoft.Extensions.Logging.Abstractions to 3.1.18
  - Bump Microsoft.Extensions.Options to 3.1.18
  - Bump Microsoft.Extensions.Options.ConfigurationExtensions to 3.1.18
- General
  - Bump Stravaig.Extensions.Logging.Diagnostics from 1.0.1 to 1.1.1


## Version 1.0.1

Date: Wednesday, 14 July, 2021 at 16:35:18 +00:00

### Dependencies

- General
  - Bump Stravaig.Extensions.Logging.Diagnostics to 1.0.1
- .NET Standard 2.0
  - Bump Microsoft.Extensions.Logging.Abstractions to 3.1.17
  - Bump Microsoft.Extensions.DependencyInjection.Abstractions to 3.1.17
  - Bump Microsoft.Extensions.Options to 3.1.17
  - Bump Microsoft.Extensions.Options.ConfigurationExtensions to 3.1.17
- .NET 5.0
  - Bump Microsoft.Extensions.DependencyInjection to 5.0.2
## Version 1.0.0

Date: Wednesday, 30 June, 2021 at 14:13:01 +00:00

### Miscellaneous

- Prepare for V1 release

### Dependencies

- .NET Standard 2.0
  - Bump Microsoft.Extensions.DependencyInjection.Abstractions to 3.1.16
  - Bump Microsoft.Extensions.Logging.Abstractions to 3.1.16
  - Bump Microsoft.Extensions.Options to 3.1.16
  - Bump Microsoft.Extensions.Options.ConfigurationExtensions to 3.1.16
- .NET 5.0
  - Bump Microsoft.Extensions.DependencyInjection.Abstractions to 5.0.0
  - Bump Microsoft.Extensions.Logging.Abstractions to 5.0.0
  - Bump Microsoft.Extensions.Options to 5.0.0
  - Bump Microsoft.Extensions.Options.ConfigurationExtensions to 5.0.0
- General
  - Bump Microsoft.NET.Test.Sdk to 16.10.0
  - Bump NUnit3TestAdapter to 4.0.0
  - Bump Stravaig.Extensions.Logging.Diagnostics to 1.0.0
## Version 0.4.1

Date: Saturday, 15 May, 2021 at 16:49:19 +00:00

### Dependencies

- Bump Microsoft.Extensions.Configuration.Json from 3.1.11 to 3.1.15
- Bump Microsoft.Extensions.DependencyInjection.Abstractions from 3.1.11 to 3.1.15
- Bump Microsoft.Extensions.Logging.Abstractions from 3.1.11 to 3.1.15
- Bump Microsoft.Extensions.Options from 3.1.11 to 3.1.15
- Bump Microsoft.Extensions.Options.ConfigurationExtensions from 3.1.11 to 3.1.15
- Bump Microsoft.NET.Test.Sdk from 16.8.3 to 16.9.1
- Bump NUnit from 3.13.0 to 3.13.2
- Bump Moq from 4.16.0 to 4.16.1
- Bump Stravaig.Extensions.Logging.Diagnostics from 0.3.1 to 0.4.2

## Version 0.3.0

Date: Sunday, 24 January, 2021 at 16:24:43 +00:00

### Features

* #22: Static methods for accessing Short codes more easily

### Miscellaneous

* Remove "IsDraft" flag from release task in the build.

### Dependabot

* Bump Moq from 4.15.2 to 4.16.0

## Version 0.2.2

Date: Saturday, 16 January, 2021 at 14:09:57 +00:00

### Miscellaneous

* #19: Fix release process.
  * Bump SDK version
  * Create release to PowerShell/GitHub CLI
  * Release notes now includes a Dependabots section

### Dependabot

* Bump `NUnit` from 3.12.0 to 3.13.0
* Bump `Microsoft.Extensions.Configuration.Json` from 3.1.10 to 3.1.11
* Bump `Microsoft.Extensions.DependencyInjection.Abstractions` from 3.1.10 to 3.1.11
* Bump `Microsoft.Extensions.Logging.Abstractions` from 3.1.10 to 3.1.11
* Bump `Microsoft.Extensions.Options` from 3.1.10 to 3.1.11
* Bump `Microsoft.Extensions.Options.ConfigurationExtensions` from 3.1.10 to 3.1.11
* Bump `Stravaig.Extensions.Logging.Diagnostics` from 0.3.0 to 0.3.1
## Version 0.2.1

Date: Wednesday, 6 January, 2021 at 23:33:35 +00:00

### Bugs

* #11: Have sensible defaults & validation on the `ShortCodeOptions`

### Features

* Add ability to take options from the configuration.
* Add performance optimisations to the encoder.

### Miscellaneous

* Add additional benchmarks.
* Update contributors script & call from build.

## Version 0.1.0

Date: Friday, 1 January, 2021 at 22:15:52 +00:00

### Features

Initial Release
