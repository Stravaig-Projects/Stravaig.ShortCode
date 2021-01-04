``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.18363.1256 (1909/November2018Update/19H2)
Intel Core i7-4790K CPU 4.00GHz (Haswell), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=5.0.101
  [Host] : .NET Core 3.1.10 (CoreCLR 4.700.20.51601, CoreFX 4.700.20.51901), X64 RyuJIT

Toolchain=InProcessEmitToolchain  

```
|                                               Method |     Mean |   Error |  StdDev | Ratio |
|----------------------------------------------------- |---------:|--------:|--------:|------:|
| &#39;The version that is currently in the main project.&#39; | 131.8 ns | 0.55 ns | 0.52 ns |  1.00 |
|                                &#39;03/Jan/2021 Variant&#39; | 158.5 ns | 1.02 ns | 0.95 ns |  1.20 |
|                                &#39;04/Jan/2021 Variant&#39; | 131.9 ns | 0.67 ns | 0.63 ns |  1.00 |
|                               &#39;Repeat the baseline.&#39; | 132.8 ns | 0.61 ns | 0.54 ns |  1.01 |
