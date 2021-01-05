``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.18363.1256 (1909/November2018Update/19H2)
Intel Core i7-4790K CPU 4.00GHz (Haswell), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=5.0.101
  [Host] : .NET Core 3.1.10 (CoreCLR 4.700.20.51601, CoreFX 4.700.20.51901), X64 RyuJIT

Toolchain=InProcessEmitToolchain  

```
|                                               Method |     Mean |   Error |  StdDev | Ratio |
|----------------------------------------------------- |---------:|--------:|--------:|------:|
| &#39;The version that is currently in the main project.&#39; | 132.3 ns | 0.76 ns | 0.71 ns |  1.00 |
|                                &#39;03/Jan/2021 Variant&#39; | 157.2 ns | 0.35 ns | 0.31 ns |  1.19 |
|                                &#39;04/Jan/2021 Variant&#39; | 131.5 ns | 0.63 ns | 0.59 ns |  0.99 |
|                               &#39;Repeat the baseline.&#39; | 130.2 ns | 0.15 ns | 0.14 ns |  0.98 |
