# DI Container Benchmarks

Here are the latest results as run on my workstation at 2016-05-25 using all JITs runnign the Combined (resolving a transient that references one transient and one singleton) benchmark.

```ini

BenchmarkDotNet=v0.9.6.0
OS=Microsoft Windows NT 6.2.9200.0
Processor=Intel(R) Core(TM) i7-4790 CPU @ 3.60GHz, ProcessorCount=8
Frequency=3515622 ticks, Resolution=284.4447 ns, Timer=TSC
HostCLR=MS.NET 4.0.30319.42000, Arch=32-bit RELEASE
JitModules=clrjit-v4.6.1569.0

Type=CombinedBenchmark  Mode=Throughput  

```

|        Method | Platform |       Jit |         Median |        StdDev |   Scaled |  Gen 0 |  Gen 1 | Bytes Allocated/Op |
--------------: |--------: |---------: |--------------: |-------------: |--------: |------: |------: |------------------: |
|        Direct |      X86 | LegacyJit |      8.8984 ns |     0.4488 ns |     1.00 |   2,07 |      - |              11,59 |
|        Direct |      X64 | LegacyJit |     11.4305 ns |     0.6357 ns |     1.00 |   4,38 |      - |              24,60 |
|        Direct |      X64 |    RyuJit |     11.7696 ns |     0.6237 ns |     1.00 |   4,14 |      - |              23,23 |
|   LightInject |      X64 | LegacyJit |     48.3260 ns |     1.7137 ns |     4.23 |   3,97 |      - |              22,24 |
|   LightInject |      X86 | LegacyJit |     48.9094 ns |     2.1049 ns |     5.50 |   2,04 |      - |              11,46 |
|SimpleInjector |      X86 | LegacyJit |     50.5816 ns |     2.7148 ns |     5.68 |   2,19 |      - |              12,28 |
|   LightInject |      X64 |    RyuJit |     50.6391 ns |     2.0431 ns |     4.30 |   4,25 |      - |              23,80 |
|SimpleInjector |      X64 |    RyuJit |     52.3029 ns |     2.2497 ns |     4.44 |   4,21 |      - |              23,59 |
|SimpleInjector |      X64 | LegacyJit |     58.9125 ns |     2.0578 ns |     5.15 |   4,06 |      - |              22,74 |
|    AspNetCore |      X64 |    RyuJit |    138.6760 ns |     5.0656 ns |    11.78 |   4,19 |      - |              23,56 |
|    AspNetCore |      X64 | LegacyJit |    138.7441 ns |     6.1214 ns |    12.14 |   4,45 |      - |              25,01 |
|          Mef2 |      X64 | LegacyJit |    145.9691 ns |     7.1460 ns |    12.77 |  13,82 |      - |              77,37 |
|          Mef2 |      X64 |    RyuJit |    165.5297 ns |     4.2805 ns |    14.06 |  12,38 |      - |              69,36 |
|    AspNetCore |      X86 | LegacyJit |    166.6729 ns |     5.5438 ns |    18.73 |   1,99 |      - |              11,24 |
|          Mef2 |      X86 | LegacyJit |    174.7647 ns |     8.3608 ns |    19.64 |   6,59 |      - |              36,94 |
|  StructureMap |      X64 |    RyuJit |  1,713.2089 ns |    90.1093 ns |   145.56 | 117,63 |      - |             664,43 |
|  StructureMap |      X64 | LegacyJit |  1,728.9186 ns |   108.4528 ns |   151.25 | 150,58 |      - |             849,43 |
|  StructureMap |      X86 | LegacyJit |  1,775.3672 ns |    76.8703 ns |   199.51 |  77,85 |      - |             438,11 |
|         Unity |      X64 | LegacyJit |  2,220.8906 ns |    68.2213 ns |   194.29 |  87,71 |      - |             492,55 |
|         Unity |      X86 | LegacyJit |  2,313.1432 ns |   107.1883 ns |   259.95 |  43,80 |      - |             250,04 |
|       Autofac |      X86 | LegacyJit |  2,499.7634 ns |   101.9467 ns |   280.92 | 118,05 |      - |             670,74 |
|       Autofac |      X64 | LegacyJit |  2,532.2092 ns |   106.4606 ns |   221.53 | 210,91 |      - |           1.193,92 |
|       Autofac |      X64 |    RyuJit |  2,554.3202 ns |    85.9504 ns |   217.03 | 222,33 |      - |           1.257,88 |
|         Unity |      X64 |    RyuJit |  2,641.0559 ns |    52.4601 ns |   224.40 |  79,99 |      - |             450,28 |
| CastleWindsor |      X86 | LegacyJit |  3,171.7703 ns |   224.4807 ns |   356.44 |  76,10 |      - |             448,81 |
| CastleWindsor |      X64 |    RyuJit |  3,354.4365 ns |   171.8344 ns |   285.01 | 145,82 |      - |             822,22 |
| CastleWindsor |      X64 | LegacyJit |  3,470.1245 ns |   264.6467 ns |   303.58 | 133,89 |      - |             756,46 |
|           Mef |      X64 |    RyuJit | 12,316.7249 ns |   402.7941 ns | 1,046.48 | 385,89 |  10,73 |           2.258,20 |
|           Mef |      X64 | LegacyJit | 12,992.9061 ns |   927.7415 ns | 1,136.68 | 307,28 |  17,17 |           1.896,95 |
|           Mef |      X86 | LegacyJit | 13,684.4735 ns |   424.6272 ns | 1,537.85 | 186,98 |  20,87 |           1.272,53 |
|       Ninject |      X86 | LegacyJit | 21,491.4333 ns |   538.8099 ns | 2,415.20 | 241,50 | 272,17 |           2.965,98 |
|       Ninject |      X64 |    RyuJit | 22,183.2307 ns |   467.4054 ns | 1,884.79 | 666,00 | 213,00 |           5.068,61 |
|       Ninject |      X64 | LegacyJit | 24,173.2585 ns | 1,373.1142 ns | 2,114.79 | 797,14 | 256,78 |           6.066,04 ||
