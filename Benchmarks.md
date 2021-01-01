``` ini

BenchmarkDotNet=v0.12.1, OS=ubuntu 18.04
Intel Xeon Platinum 8171M CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET Core SDK=3.1.404
  [Host]     : .NET Core 3.1.10 (CoreCLR 4.700.20.51601, CoreFX 4.700.20.51901), X64 RyuJIT
  DefaultJob : .NET Core 3.1.10 (CoreCLR 4.700.20.51601, CoreFX 4.700.20.51901), X64 RyuJIT


```
|                           Method |        Mean |     Error |    StdDev |
|--------------------------------- |------------:|----------:|----------:|
|                  RandomGenerator |   117.14 ns |  1.510 ns |  1.179 ns |
|                    GuidGenerator | 1,006.88 ns | 18.590 ns | 17.390 ns |
|              SequentialGenerator |    21.90 ns |  0.430 ns |  0.402 ns |
| CryptographicallyRandomGenerator | 2,111.15 ns | 35.727 ns | 33.419 ns |
