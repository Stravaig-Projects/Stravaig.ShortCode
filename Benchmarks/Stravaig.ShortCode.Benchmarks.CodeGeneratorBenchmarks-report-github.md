``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.18363.1256 (1909/November2018Update/19H2)
Intel Core i7-4790K CPU 4.00GHz (Haswell), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=5.0.101
  [Host] : .NET Core 3.1.10 (CoreCLR 4.700.20.51601, CoreFX 4.700.20.51901), X64 RyuJIT

Toolchain=InProcessEmitToolchain  

```
|                           Method |     Mean |    Error |   StdDev |
|--------------------------------- |---------:|---------:|---------:|
|                  RandomGenerator | 70.99 ns | 0.751 ns | 0.666 ns |
|                    GuidGenerator | 80.57 ns | 0.155 ns | 0.138 ns |
|              SequentialGenerator | 14.64 ns | 0.062 ns | 0.052 ns |
| CryptographicallyRandomGenerator | 87.06 ns | 0.765 ns | 0.678 ns |
