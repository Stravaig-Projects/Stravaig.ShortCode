``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.18363.1256 (1909/November2018Update/19H2)
Intel Core i7-4790K CPU 4.00GHz (Haswell), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=5.0.101
  [Host] : .NET Core 3.1.10 (CoreCLR 4.700.20.51601, CoreFX 4.700.20.51901), X64 RyuJIT

Toolchain=InProcessEmitToolchain  

```
|  Method | FixedLength |                 Code |              Encoder |       Char Space | Encoder Class |      Mean |    Error |   StdDev |
|-------- |------------ |--------------------- |--------------------- |----------------- |-------------- |----------:|---------:|---------:|
| **Convert** |           **3** | **12335633962698440504** |      **Encoder(Digits)** |           **Digits** |       **Encoder** |  **64.77 ns** | **0.648 ns** | **0.606 ns** |
| **Convert** |           **3** | **12335633962698440504** | **Encod(...)gits) [25]** | **LettersAndDigits** |       **Encoder** |  **67.63 ns** | **0.676 ns** | **0.600 ns** |
| **Convert** |           **3** | **12335633962698440504** | **Encod(...)uity) [25]** | **ReducedAmbiguity** |       **Encoder** |  **66.71 ns** | **0.964 ns** | **0.805 ns** |
| **Convert** |           **3** |                    **5** |      **Encoder(Digits)** |           **Digits** |       **Encoder** |  **37.30 ns** | **0.436 ns** | **0.408 ns** |
| **Convert** |           **3** |                    **5** | **Encod(...)gits) [25]** | **LettersAndDigits** |       **Encoder** |  **37.63 ns** | **0.413 ns** | **0.345 ns** |
| **Convert** |           **3** |                    **5** | **Encod(...)uity) [25]** | **ReducedAmbiguity** |       **Encoder** |  **37.03 ns** | **0.532 ns** | **0.471 ns** |
| **Convert** |           **3** |                **54321** |      **Encoder(Digits)** |           **Digits** |       **Encoder** |  **55.31 ns** | **0.463 ns** | **0.433 ns** |
| **Convert** |           **3** |                **54321** | **Encod(...)gits) [25]** | **LettersAndDigits** |       **Encoder** |  **55.19 ns** | **0.186 ns** | **0.174 ns** |
| **Convert** |           **3** |                **54321** | **Encod(...)uity) [25]** | **ReducedAmbiguity** |       **Encoder** |  **55.19 ns** | **0.259 ns** | **0.216 ns** |
| **Convert** |           **3** |             **16109257** |      **Encoder(Digits)** |           **Digits** |       **Encoder** |  **55.15 ns** | **0.330 ns** | **0.293 ns** |
| **Convert** |           **3** |             **16109257** | **Encod(...)gits) [25]** | **LettersAndDigits** |       **Encoder** |  **55.62 ns** | **0.179 ns** | **0.149 ns** |
| **Convert** |           **3** |             **16109257** | **Encod(...)uity) [25]** | **ReducedAmbiguity** |       **Encoder** |  **54.84 ns** | **0.434 ns** | **0.406 ns** |
| **Convert** |           **3** |            **905021721** |      **Encoder(Digits)** |           **Digits** |       **Encoder** |  **56.91 ns** | **0.797 ns** | **0.666 ns** |
| **Convert** |           **3** |            **905021721** | **Encod(...)gits) [25]** | **LettersAndDigits** |       **Encoder** |  **55.35 ns** | **0.362 ns** | **0.283 ns** |
| **Convert** |           **3** |            **905021721** | **Encod(...)uity) [25]** | **ReducedAmbiguity** |       **Encoder** |  **56.12 ns** | **0.172 ns** | **0.143 ns** |
| **Convert** |           **5** | **12335633962698440504** |      **Encoder(Digits)** |           **Digits** |       **Encoder** | **107.56 ns** | **1.360 ns** | **1.206 ns** |
| **Convert** |           **5** | **12335633962698440504** | **Encod(...)gits) [25]** | **LettersAndDigits** |       **Encoder** | **101.98 ns** | **0.456 ns** | **0.404 ns** |
| **Convert** |           **5** | **12335633962698440504** | **Encod(...)uity) [25]** | **ReducedAmbiguity** |       **Encoder** | **102.62 ns** | **1.223 ns** | **1.144 ns** |
| **Convert** |           **5** |                    **5** |      **Encoder(Digits)** |           **Digits** |       **Encoder** |  **39.22 ns** | **0.644 ns** | **0.602 ns** |
| **Convert** |           **5** |                    **5** | **Encod(...)gits) [25]** | **LettersAndDigits** |       **Encoder** |  **38.83 ns** | **0.139 ns** | **0.116 ns** |
| **Convert** |           **5** |                    **5** | **Encod(...)uity) [25]** | **ReducedAmbiguity** |       **Encoder** |  **38.81 ns** | **0.751 ns** | **0.702 ns** |
| **Convert** |           **5** |                **54321** |      **Encoder(Digits)** |           **Digits** |       **Encoder** |  **86.67 ns** | **1.046 ns** | **0.978 ns** |
| **Convert** |           **5** |                **54321** | **Encod(...)gits) [25]** | **LettersAndDigits** |       **Encoder** |  **65.22 ns** | **1.013 ns** | **0.947 ns** |
| **Convert** |           **5** |                **54321** | **Encod(...)uity) [25]** | **ReducedAmbiguity** |       **Encoder** |  **77.67 ns** | **1.045 ns** | **0.873 ns** |
| **Convert** |           **5** |             **16109257** |      **Encoder(Digits)** |           **Digits** |       **Encoder** |  **87.61 ns** | **1.072 ns** | **1.003 ns** |
| **Convert** |           **5** |             **16109257** | **Encod(...)gits) [25]** | **LettersAndDigits** |       **Encoder** |  **86.34 ns** | **0.528 ns** | **0.468 ns** |
| **Convert** |           **5** |             **16109257** | **Encod(...)uity) [25]** | **ReducedAmbiguity** |       **Encoder** |  **87.02 ns** | **0.800 ns** | **0.709 ns** |
| **Convert** |           **5** |            **905021721** |      **Encoder(Digits)** |           **Digits** |       **Encoder** |  **88.06 ns** | **0.620 ns** | **0.518 ns** |
| **Convert** |           **5** |            **905021721** | **Encod(...)gits) [25]** | **LettersAndDigits** |       **Encoder** |  **87.90 ns** | **0.675 ns** | **0.598 ns** |
| **Convert** |           **5** |            **905021721** | **Encod(...)uity) [25]** | **ReducedAmbiguity** |       **Encoder** |  **88.74 ns** | **0.922 ns** | **0.862 ns** |
| **Convert** |           **7** | **12335633962698440504** |      **Encoder(Digits)** |           **Digits** |       **Encoder** | **145.08 ns** | **0.828 ns** | **0.734 ns** |
| **Convert** |           **7** | **12335633962698440504** | **Encod(...)gits) [25]** | **LettersAndDigits** |       **Encoder** | **135.58 ns** | **0.340 ns** | **0.265 ns** |
| **Convert** |           **7** | **12335633962698440504** | **Encod(...)uity) [25]** | **ReducedAmbiguity** |       **Encoder** | **140.58 ns** | **0.685 ns** | **0.572 ns** |
| **Convert** |           **7** |                    **5** |      **Encoder(Digits)** |           **Digits** |       **Encoder** |  **41.00 ns** | **0.571 ns** | **0.506 ns** |
| **Convert** |           **7** |                    **5** | **Encod(...)gits) [25]** | **LettersAndDigits** |       **Encoder** |  **41.11 ns** | **0.273 ns** | **0.256 ns** |
| **Convert** |           **7** |                    **5** | **Encod(...)uity) [25]** | **ReducedAmbiguity** |       **Encoder** |  **41.65 ns** | **0.385 ns** | **0.341 ns** |
| **Convert** |           **7** |                **54321** |      **Encoder(Digits)** |           **Digits** |       **Encoder** |  **94.62 ns** | **0.257 ns** | **0.200 ns** |
| **Convert** |           **7** |                **54321** | **Encod(...)gits) [25]** | **LettersAndDigits** |       **Encoder** |  **65.92 ns** | **0.080 ns** | **0.063 ns** |
| **Convert** |           **7** |                **54321** | **Encod(...)uity) [25]** | **ReducedAmbiguity** |       **Encoder** |  **80.19 ns** | **0.400 ns** | **0.374 ns** |
| **Convert** |           **7** |             **16109257** |      **Encoder(Digits)** |           **Digits** |       **Encoder** | **119.32 ns** | **0.604 ns** | **0.565 ns** |
| **Convert** |           **7** |             **16109257** | **Encod(...)gits) [25]** | **LettersAndDigits** |       **Encoder** |  **95.92 ns** | **0.508 ns** | **0.475 ns** |
| **Convert** |           **7** |             **16109257** | **Encod(...)uity) [25]** | **ReducedAmbiguity** |       **Encoder** |  **96.82 ns** | **1.150 ns** | **1.076 ns** |
| **Convert** |           **7** |            **905021721** |      **Encoder(Digits)** |           **Digits** |       **Encoder** | **123.18 ns** | **1.386 ns** | **1.158 ns** |
| **Convert** |           **7** |            **905021721** | **Encod(...)gits) [25]** | **LettersAndDigits** |       **Encoder** |  **96.78 ns** | **0.964 ns** | **0.902 ns** |
| **Convert** |           **7** |            **905021721** | **Encod(...)uity) [25]** | **ReducedAmbiguity** |       **Encoder** | **119.27 ns** | **1.144 ns** | **0.955 ns** |
| **Convert** |           **9** | **12335633962698440504** |      **Encoder(Digits)** |           **Digits** |       **Encoder** | **180.73 ns** | **0.805 ns** | **0.753 ns** |
| **Convert** |           **9** | **12335633962698440504** | **Encod(...)gits) [25]** | **LettersAndDigits** |       **Encoder** | **169.24 ns** | **0.867 ns** | **0.677 ns** |
| **Convert** |           **9** | **12335633962698440504** | **Encod(...)uity) [25]** | **ReducedAmbiguity** |       **Encoder** | **174.08 ns** | **0.985 ns** | **0.873 ns** |
| **Convert** |           **9** |                    **5** |      **Encoder(Digits)** |           **Digits** |       **Encoder** |  **43.53 ns** | **0.046 ns** | **0.043 ns** |
| **Convert** |           **9** |                    **5** | **Encod(...)gits) [25]** | **LettersAndDigits** |       **Encoder** |  **44.32 ns** | **0.217 ns** | **0.181 ns** |
| **Convert** |           **9** |                    **5** | **Encod(...)uity) [25]** | **ReducedAmbiguity** |       **Encoder** |  **45.02 ns** | **0.671 ns** | **0.595 ns** |
| **Convert** |           **9** |                **54321** |      **Encoder(Digits)** |           **Digits** |       **Encoder** |  **97.96 ns** | **0.466 ns** | **0.413 ns** |
| **Convert** |           **9** |                **54321** | **Encod(...)gits) [25]** | **LettersAndDigits** |       **Encoder** |  **68.39 ns** | **0.272 ns** | **0.254 ns** |
| **Convert** |           **9** |                **54321** | **Encod(...)uity) [25]** | **ReducedAmbiguity** |       **Encoder** |  **87.62 ns** | **0.598 ns** | **0.530 ns** |
| **Convert** |           **9** |             **16109257** |      **Encoder(Digits)** |           **Digits** |       **Encoder** | **145.33 ns** | **1.094 ns** | **0.913 ns** |
| **Convert** |           **9** |             **16109257** | **Encod(...)gits) [25]** | **LettersAndDigits** |       **Encoder** |  **99.79 ns** | **0.181 ns** | **0.161 ns** |
| **Convert** |           **9** |             **16109257** | **Encod(...)uity) [25]** | **ReducedAmbiguity** |       **Encoder** |  **98.94 ns** | **0.435 ns** | **0.385 ns** |
| **Convert** |           **9** |            **905021721** |      **Encoder(Digits)** |           **Digits** |       **Encoder** | **154.01 ns** | **1.593 ns** | **1.491 ns** |
| **Convert** |           **9** |            **905021721** | **Encod(...)gits) [25]** | **LettersAndDigits** |       **Encoder** | **100.76 ns** | **0.531 ns** | **0.443 ns** |
| **Convert** |           **9** |            **905021721** | **Encod(...)uity) [25]** | **ReducedAmbiguity** |       **Encoder** | **132.43 ns** | **1.282 ns** | **1.199 ns** |
