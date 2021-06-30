# Full Release Notes

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
