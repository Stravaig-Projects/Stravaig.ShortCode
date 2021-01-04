``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.18363.1256 (1909/November2018Update/19H2)
Intel Core i7-4790K CPU 4.00GHz (Haswell), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=5.0.101
  [Host] : .NET Core 3.1.10 (CoreCLR 4.700.20.51601, CoreFX 4.700.20.51901), X64 RyuJIT

Toolchain=InProcessEmitToolchain  

```
|  Method | FixedLength |                 Code |              Encoder |       Char Space | Encoder Class |      Mean |    Error |   StdDev |
|-------- |------------ |--------------------- |--------------------- |----------------- |-------------- |----------:|---------:|---------:|
| **Convert** |           **3** | **12335633962698440504** |      **Encoder(Digits)** |           **Digits** |       **Encoder** |  **75.44 ns** | **0.273 ns** | **0.242 ns** |
| **Convert** |           **3** | **12335633962698440504** | **Encod(...)gits) [25]** | **LettersAndDigits** |       **Encoder** |  **73.99 ns** | **0.159 ns** | **0.141 ns** |
| **Convert** |           **3** | **12335633962698440504** | **Encod(...)uity) [25]** | **ReducedAmbiguity** |       **Encoder** |  **74.79 ns** | **0.259 ns** | **0.242 ns** |
| **Convert** |           **3** |                    **5** |      **Encoder(Digits)** |           **Digits** |       **Encoder** |  **49.84 ns** | **0.234 ns** | **0.196 ns** |
| **Convert** |           **3** |                    **5** | **Encod(...)gits) [25]** | **LettersAndDigits** |       **Encoder** |  **50.09 ns** | **0.148 ns** | **0.138 ns** |
| **Convert** |           **3** |                    **5** | **Encod(...)uity) [25]** | **ReducedAmbiguity** |       **Encoder** |  **49.58 ns** | **0.129 ns** | **0.114 ns** |
| **Convert** |           **3** |                **54321** |      **Encoder(Digits)** |           **Digits** |       **Encoder** |  **66.65 ns** | **0.191 ns** | **0.159 ns** |
| **Convert** |           **3** |                **54321** | **Encod(...)gits) [25]** | **LettersAndDigits** |       **Encoder** |  **66.60 ns** | **0.257 ns** | **0.240 ns** |
| **Convert** |           **3** |                **54321** | **Encod(...)uity) [25]** | **ReducedAmbiguity** |       **Encoder** |  **66.42 ns** | **0.136 ns** | **0.120 ns** |
| **Convert** |           **3** |             **16109257** |      **Encoder(Digits)** |           **Digits** |       **Encoder** |  **66.61 ns** | **0.123 ns** | **0.103 ns** |
| **Convert** |           **3** |             **16109257** | **Encod(...)gits) [25]** | **LettersAndDigits** |       **Encoder** |  **69.41 ns** | **1.261 ns** | **1.180 ns** |
| **Convert** |           **3** |             **16109257** | **Encod(...)uity) [25]** | **ReducedAmbiguity** |       **Encoder** |  **66.57 ns** | **0.071 ns** | **0.063 ns** |
| **Convert** |           **3** |            **905021721** |      **Encoder(Digits)** |           **Digits** |       **Encoder** |  **67.05 ns** | **0.129 ns** | **0.115 ns** |
| **Convert** |           **3** |            **905021721** | **Encod(...)gits) [25]** | **LettersAndDigits** |       **Encoder** |  **66.89 ns** | **0.371 ns** | **0.347 ns** |
| **Convert** |           **3** |            **905021721** | **Encod(...)uity) [25]** | **ReducedAmbiguity** |       **Encoder** |  **67.10 ns** | **0.301 ns** | **0.267 ns** |
| **Convert** |           **5** | **12335633962698440504** |      **Encoder(Digits)** |           **Digits** |       **Encoder** | **120.92 ns** | **0.284 ns** | **0.237 ns** |
| **Convert** |           **5** | **12335633962698440504** | **Encod(...)gits) [25]** | **LettersAndDigits** |       **Encoder** | **117.47 ns** | **0.233 ns** | **0.182 ns** |
| **Convert** |           **5** | **12335633962698440504** | **Encod(...)uity) [25]** | **ReducedAmbiguity** |       **Encoder** | **119.06 ns** | **0.287 ns** | **0.269 ns** |
| **Convert** |           **5** |                    **5** |      **Encoder(Digits)** |           **Digits** |       **Encoder** |  **60.43 ns** | **0.072 ns** | **0.064 ns** |
| **Convert** |           **5** |                    **5** | **Encod(...)gits) [25]** | **LettersAndDigits** |       **Encoder** |  **60.50 ns** | **0.281 ns** | **0.235 ns** |
| **Convert** |           **5** |                    **5** | **Encod(...)uity) [25]** | **ReducedAmbiguity** |       **Encoder** |  **60.68 ns** | **0.219 ns** | **0.205 ns** |
| **Convert** |           **5** |                **54321** |      **Encoder(Digits)** |           **Digits** |       **Encoder** | **102.68 ns** | **0.344 ns** | **0.322 ns** |
| **Convert** |           **5** |                **54321** | **Encod(...)gits) [25]** | **LettersAndDigits** |       **Encoder** |  **82.97 ns** | **0.082 ns** | **0.073 ns** |
| **Convert** |           **5** |                **54321** | **Encod(...)uity) [25]** | **ReducedAmbiguity** |       **Encoder** |  **96.57 ns** | **0.437 ns** | **0.409 ns** |
| **Convert** |           **5** |             **16109257** |      **Encoder(Digits)** |           **Digits** |       **Encoder** | **103.13 ns** | **0.284 ns** | **0.265 ns** |
| **Convert** |           **5** |             **16109257** | **Encod(...)gits) [25]** | **LettersAndDigits** |       **Encoder** | **102.27 ns** | **0.057 ns** | **0.050 ns** |
| **Convert** |           **5** |             **16109257** | **Encod(...)uity) [25]** | **ReducedAmbiguity** |       **Encoder** | **102.71 ns** | **0.210 ns** | **0.175 ns** |
| **Convert** |           **5** |            **905021721** |      **Encoder(Digits)** |           **Digits** |       **Encoder** | **105.73 ns** | **0.414 ns** | **0.345 ns** |
| **Convert** |           **5** |            **905021721** | **Encod(...)gits) [25]** | **LettersAndDigits** |       **Encoder** | **105.13 ns** | **2.067 ns** | **2.212 ns** |
| **Convert** |           **5** |            **905021721** | **Encod(...)uity) [25]** | **ReducedAmbiguity** |       **Encoder** | **103.88 ns** | **0.132 ns** | **0.117 ns** |
| **Convert** |           **7** | **12335633962698440504** |      **Encoder(Digits)** |           **Digits** |       **Encoder** | **166.18 ns** | **0.514 ns** | **0.481 ns** |
| **Convert** |           **7** | **12335633962698440504** | **Encod(...)gits) [25]** | **LettersAndDigits** |       **Encoder** | **157.84 ns** | **0.488 ns** | **0.432 ns** |
| **Convert** |           **7** | **12335633962698440504** | **Encod(...)uity) [25]** | **ReducedAmbiguity** |       **Encoder** | **161.32 ns** | **0.151 ns** | **0.126 ns** |
| **Convert** |           **7** |                    **5** |      **Encoder(Digits)** |           **Digits** |       **Encoder** |  **71.18 ns** | **0.089 ns** | **0.074 ns** |
| **Convert** |           **7** |                    **5** | **Encod(...)gits) [25]** | **LettersAndDigits** |       **Encoder** |  **71.37 ns** | **0.190 ns** | **0.169 ns** |
| **Convert** |           **7** |                    **5** | **Encod(...)uity) [25]** | **ReducedAmbiguity** |       **Encoder** |  **71.60 ns** | **0.316 ns** | **0.296 ns** |
| **Convert** |           **7** |                **54321** |      **Encoder(Digits)** |           **Digits** |       **Encoder** | **120.48 ns** | **0.183 ns** | **0.153 ns** |
| **Convert** |           **7** |                **54321** | **Encod(...)gits) [25]** | **LettersAndDigits** |       **Encoder** |  **94.81 ns** | **0.209 ns** | **0.174 ns** |
| **Convert** |           **7** |                **54321** | **Encod(...)uity) [25]** | **ReducedAmbiguity** |       **Encoder** | **106.42 ns** | **0.462 ns** | **0.361 ns** |
| **Convert** |           **7** |             **16109257** |      **Encoder(Digits)** |           **Digits** |       **Encoder** | **141.51 ns** | **0.170 ns** | **0.142 ns** |
| **Convert** |           **7** |             **16109257** | **Encod(...)gits) [25]** | **LettersAndDigits** |       **Encoder** | **121.08 ns** | **0.454 ns** | **0.425 ns** |
| **Convert** |           **7** |             **16109257** | **Encod(...)uity) [25]** | **ReducedAmbiguity** |       **Encoder** | **120.04 ns** | **0.286 ns** | **0.268 ns** |
| **Convert** |           **7** |            **905021721** |      **Encoder(Digits)** |           **Digits** |       **Encoder** | **142.71 ns** | **0.236 ns** | **0.197 ns** |
| **Convert** |           **7** |            **905021721** | **Encod(...)gits) [25]** | **LettersAndDigits** |       **Encoder** | **120.84 ns** | **0.327 ns** | **0.306 ns** |
| **Convert** |           **7** |            **905021721** | **Encod(...)uity) [25]** | **ReducedAmbiguity** |       **Encoder** | **141.90 ns** | **0.358 ns** | **0.335 ns** |
| **Convert** |           **9** | **12335633962698440504** |      **Encoder(Digits)** |           **Digits** |       **Encoder** | **208.66 ns** | **0.576 ns** | **0.539 ns** |
| **Convert** |           **9** | **12335633962698440504** | **Encod(...)gits) [25]** | **LettersAndDigits** |       **Encoder** | **196.95 ns** | **1.074 ns** | **0.897 ns** |
| **Convert** |           **9** | **12335633962698440504** | **Encod(...)uity) [25]** | **ReducedAmbiguity** |       **Encoder** | **201.38 ns** | **0.062 ns** | **0.058 ns** |
| **Convert** |           **9** |                    **5** |      **Encoder(Digits)** |           **Digits** |       **Encoder** |  **83.45 ns** | **0.360 ns** | **0.337 ns** |
| **Convert** |           **9** |                    **5** | **Encod(...)gits) [25]** | **LettersAndDigits** |       **Encoder** |  **83.30 ns** | **0.165 ns** | **0.138 ns** |
| **Convert** |           **9** |                    **5** | **Encod(...)uity) [25]** | **ReducedAmbiguity** |       **Encoder** |  **83.08 ns** | **0.133 ns** | **0.118 ns** |
| **Convert** |           **9** |                **54321** |      **Encoder(Digits)** |           **Digits** |       **Encoder** | **130.97 ns** | **0.301 ns** | **0.281 ns** |
| **Convert** |           **9** |                **54321** | **Encod(...)gits) [25]** | **LettersAndDigits** |       **Encoder** | **105.88 ns** | **0.202 ns** | **0.179 ns** |
| **Convert** |           **9** |                **54321** | **Encod(...)uity) [25]** | **ReducedAmbiguity** |       **Encoder** | **117.83 ns** | **0.132 ns** | **0.103 ns** |
| **Convert** |           **9** |             **16109257** |      **Encoder(Digits)** |           **Digits** |       **Encoder** | **171.09 ns** | **0.199 ns** | **0.176 ns** |
| **Convert** |           **9** |             **16109257** | **Encod(...)gits) [25]** | **LettersAndDigits** |       **Encoder** | **131.06 ns** | **0.284 ns** | **0.266 ns** |
| **Convert** |           **9** |             **16109257** | **Encod(...)uity) [25]** | **ReducedAmbiguity** |       **Encoder** | **131.45 ns** | **0.248 ns** | **0.219 ns** |
| **Convert** |           **9** |            **905021721** |      **Encoder(Digits)** |           **Digits** |       **Encoder** | **181.47 ns** | **0.319 ns** | **0.299 ns** |
| **Convert** |           **9** |            **905021721** | **Encod(...)gits) [25]** | **LettersAndDigits** |       **Encoder** | **131.63 ns** | **0.141 ns** | **0.125 ns** |
| **Convert** |           **9** |            **905021721** | **Encod(...)uity) [25]** | **ReducedAmbiguity** |       **Encoder** | **159.29 ns** | **0.207 ns** | **0.184 ns** |