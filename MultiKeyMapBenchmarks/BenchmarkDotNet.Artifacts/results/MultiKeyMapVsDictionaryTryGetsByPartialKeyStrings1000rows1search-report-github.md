``` ini

BenchmarkDotNet=v0.10.6, OS=Windows 10 Redstone 2 (10.0.15063)
Processor=Intel Core i7-4790 CPU 3.60GHz (Haswell), ProcessorCount=8
Frequency=3507520 Hz, Resolution=285.1017 ns, Timer=TSC
dotnet cli version=1.0.4
  [Host]     : .NET Core 4.6.25211.01, 64bit RyuJIT
  DefaultJob : .NET Core 4.6.25211.01, 64bit RyuJIT


```
 |                                                  Method |                        Strategy | SubKeyEqualityByRef | KeyEqualityByRef |        Mean |      Error |     StdDev | Scaled | ScaledSD |  Gen 0 | Allocated |
 |-------------------------------------------------------- |-------------------------------- |-------------------- |----------------- |------------:|-----------:|-----------:|-------:|---------:|-------:|----------:|
 |                  **MultiKeyMap_TryGetFullKeysByPartialKey** | **OptimizedForNonPositionalSearch** |               **False** |            **False** |    **94.11 ns** |  **0.3647 ns** |  **0.3411 ns** |   **0.12** |     **0.00** | **0.0190** |      **80 B** |
 | MultiKeyMap_Mixed_Positional_TryGetFullKeysByPartialKey | OptimizedForNonPositionalSearch |               False |            False |   128.98 ns |  1.0667 ns |  0.9978 ns |   0.17 |     0.00 | 0.0284 |     120 B |
 |  MultiKeyMap_Only_Positional_TryGetFullKeysByPartialKey | OptimizedForNonPositionalSearch |               False |            False |   128.73 ns |  0.8304 ns |  0.7768 ns |   0.17 |     0.00 | 0.0284 |     120 B |
 |                                  Dictionary_TryGetValue | OptimizedForNonPositionalSearch |               False |            False |   776.77 ns |  4.2016 ns |  3.9302 ns |   1.00 |     0.00 | 0.0591 |     248 B |
 |                  **MultiKeyMap_TryGetFullKeysByPartialKey** | **OptimizedForNonPositionalSearch** |               **False** |             **True** |    **93.58 ns** |  **0.3798 ns** |  **0.3172 ns** |   **0.74** |     **0.00** | **0.0190** |      **80 B** |
 | MultiKeyMap_Mixed_Positional_TryGetFullKeysByPartialKey | OptimizedForNonPositionalSearch |               False |             True |   128.09 ns |  0.7851 ns |  0.7344 ns |   1.01 |     0.01 | 0.0284 |     120 B |
 |  MultiKeyMap_Only_Positional_TryGetFullKeysByPartialKey | OptimizedForNonPositionalSearch |               False |             True |   128.19 ns |  0.6311 ns |  0.5903 ns |   1.01 |     0.01 | 0.0284 |     120 B |
 |                                  Dictionary_TryGetValue | OptimizedForNonPositionalSearch |               False |             True |   126.94 ns |  0.5962 ns |  0.5285 ns |   1.00 |     0.00 | 0.0303 |     128 B |
 |                  **MultiKeyMap_TryGetFullKeysByPartialKey** | **OptimizedForNonPositionalSearch** |                **True** |            **False** |    **94.11 ns** |  **0.5755 ns** |  **0.5383 ns** |   **0.12** |     **0.00** | **0.0190** |      **80 B** |
 | MultiKeyMap_Mixed_Positional_TryGetFullKeysByPartialKey | OptimizedForNonPositionalSearch |                True |            False |   128.34 ns |  0.3655 ns |  0.3052 ns |   0.16 |     0.00 | 0.0284 |     120 B |
 |  MultiKeyMap_Only_Positional_TryGetFullKeysByPartialKey | OptimizedForNonPositionalSearch |                True |            False |   133.57 ns |  0.5891 ns |  0.5510 ns |   0.17 |     0.00 | 0.0284 |     120 B |
 |                                  Dictionary_TryGetValue | OptimizedForNonPositionalSearch |                True |            False |   780.39 ns |  1.3961 ns |  1.2376 ns |   1.00 |     0.00 | 0.0591 |     248 B |
 |                  **MultiKeyMap_TryGetFullKeysByPartialKey** | **OptimizedForNonPositionalSearch** |                **True** |             **True** |    **93.50 ns** |  **0.4616 ns** |  **0.3854 ns** |   **0.74** |     **0.00** | **0.0190** |      **80 B** |
 | MultiKeyMap_Mixed_Positional_TryGetFullKeysByPartialKey | OptimizedForNonPositionalSearch |                True |             True |   129.06 ns |  1.0729 ns |  1.0036 ns |   1.02 |     0.01 | 0.0284 |     120 B |
 |  MultiKeyMap_Only_Positional_TryGetFullKeysByPartialKey | OptimizedForNonPositionalSearch |                True |             True |   128.36 ns |  0.4293 ns |  0.4016 ns |   1.01 |     0.01 | 0.0284 |     120 B |
 |                                  Dictionary_TryGetValue | OptimizedForNonPositionalSearch |                True |             True |   126.98 ns |  0.6728 ns |  0.6294 ns |   1.00 |     0.00 | 0.0303 |     128 B |
 |                  **MultiKeyMap_TryGetFullKeysByPartialKey** |    **OptimizedForPositionalSearch** |               **False** |            **False** |   **168.40 ns** |  **0.5302 ns** |  **0.4700 ns** |   **0.22** |     **0.00** | **0.0379** |     **160 B** |
 | MultiKeyMap_Mixed_Positional_TryGetFullKeysByPartialKey |    OptimizedForPositionalSearch |               False |            False |   152.34 ns |  0.7536 ns |  0.7050 ns |   0.20 |     0.00 | 0.0379 |     160 B |
 |  MultiKeyMap_Only_Positional_TryGetFullKeysByPartialKey |    OptimizedForPositionalSearch |               False |            False | 2,205.17 ns | 10.9153 ns | 10.2102 ns |   2.86 |     0.01 | 0.2975 |    1256 B |
 |                                  Dictionary_TryGetValue |    OptimizedForPositionalSearch |               False |            False |   770.26 ns |  1.6987 ns |  1.4185 ns |   1.00 |     0.00 | 0.0591 |     248 B |
 |                  **MultiKeyMap_TryGetFullKeysByPartialKey** |    **OptimizedForPositionalSearch** |               **False** |             **True** |   **170.42 ns** |  **0.8010 ns** |  **0.7493 ns** |   **1.32** |     **0.03** | **0.0379** |     **160 B** |
 | MultiKeyMap_Mixed_Positional_TryGetFullKeysByPartialKey |    OptimizedForPositionalSearch |               False |             True |   150.08 ns |  0.8369 ns |  0.7829 ns |   1.16 |     0.02 | 0.0379 |     160 B |
 |  MultiKeyMap_Only_Positional_TryGetFullKeysByPartialKey |    OptimizedForPositionalSearch |               False |             True | 2,210.81 ns | 11.5640 ns | 10.8170 ns |  17.09 |     0.35 | 0.2975 |    1256 B |
 |                                  Dictionary_TryGetValue |    OptimizedForPositionalSearch |               False |             True |   129.40 ns |  2.5691 ns |  2.6383 ns |   1.00 |     0.00 | 0.0303 |     128 B |
 |                  **MultiKeyMap_TryGetFullKeysByPartialKey** |    **OptimizedForPositionalSearch** |                **True** |            **False** |   **170.00 ns** |  **1.9322 ns** |  **1.7128 ns** |   **0.22** |     **0.00** | **0.0379** |     **160 B** |
 | MultiKeyMap_Mixed_Positional_TryGetFullKeysByPartialKey |    OptimizedForPositionalSearch |                True |            False |   153.50 ns |  0.6835 ns |  0.6394 ns |   0.20 |     0.00 | 0.0379 |     160 B |
 |  MultiKeyMap_Only_Positional_TryGetFullKeysByPartialKey |    OptimizedForPositionalSearch |                True |            False | 2,210.94 ns | 10.7384 ns | 10.0447 ns |   2.83 |     0.01 | 0.2975 |    1256 B |
 |                                  Dictionary_TryGetValue |    OptimizedForPositionalSearch |                True |            False |   780.29 ns |  2.6158 ns |  2.3188 ns |   1.00 |     0.00 | 0.0591 |     248 B |
 |                  **MultiKeyMap_TryGetFullKeysByPartialKey** |    **OptimizedForPositionalSearch** |                **True** |             **True** |   **169.05 ns** |  **0.8364 ns** |  **0.7823 ns** |   **1.30** |     **0.02** | **0.0379** |     **160 B** |
 | MultiKeyMap_Mixed_Positional_TryGetFullKeysByPartialKey |    OptimizedForPositionalSearch |                True |             True |   149.32 ns |  0.4967 ns |  0.4646 ns |   1.15 |     0.01 | 0.0379 |     160 B |
 |  MultiKeyMap_Only_Positional_TryGetFullKeysByPartialKey |    OptimizedForPositionalSearch |                True |             True | 2,274.80 ns | 24.1369 ns | 22.5776 ns |  17.49 |     0.27 | 0.2975 |    1256 B |
 |                                  Dictionary_TryGetValue |    OptimizedForPositionalSearch |                True |             True |   130.07 ns |  1.7044 ns |  1.5943 ns |   1.00 |     0.00 | 0.0303 |     128 B |