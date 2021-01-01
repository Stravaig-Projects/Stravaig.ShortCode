``` ini

BenchmarkDotNet=v0.12.1, OS=macOS 11.1 (20C69) [Darwin 20.2.0]
Intel Core i5-5350U CPU 1.80GHz (Broadwell), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=3.1.301
  [Host]     : .NET Core 3.1.5 (CoreCLR 4.700.20.26901, CoreFX 4.700.20.27001), X64 RyuJIT
  DefaultJob : .NET Core 3.1.5 (CoreCLR 4.700.20.26901, CoreFX 4.700.20.27001), X64 RyuJIT


```
|                           Method |      Mean |    Error |   StdDev |
|--------------------------------- |----------:|---------:|---------:|
|                  RandomGenerator | 111.72 ns | 0.525 ns | 0.466 ns |
|                    GuidGenerator | 145.22 ns | 1.589 ns | 1.486 ns |
|              SequentialGenerator |  25.99 ns | 0.107 ns | 0.100 ns |
| CryptographicallyRandomGenerator | 131.47 ns | 1.498 ns | 1.170 ns |
