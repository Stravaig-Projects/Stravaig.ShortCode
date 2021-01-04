``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.18363.1256 (1909/November2018Update/19H2)
Intel Core i7-4790K CPU 4.00GHz (Haswell), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=5.0.101
  [Host] : .NET Core 3.1.10 (CoreCLR 4.700.20.51601, CoreFX 4.700.20.51901), X64 RyuJIT

Toolchain=InProcessEmitToolchain  

```
|                           Method |     Mean |    Error |   StdDev |
|--------------------------------- |---------:|---------:|---------:|
|                  RandomGenerator | 67.07 ns | 0.301 ns | 0.267 ns |
|                    GuidGenerator | 79.22 ns | 0.302 ns | 0.282 ns |
|              SequentialGenerator | 14.57 ns | 0.055 ns | 0.052 ns |
| CryptographicallyRandomGenerator | 82.68 ns | 0.280 ns | 0.262 ns |
