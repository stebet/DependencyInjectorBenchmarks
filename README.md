# DI Container Benchmarks

Here are the latest results as run on my workstation on March 14th June2018 using the Default workload.

## Transient
``` ini

BenchmarkDotNet=v0.10.13, OS=Windows 10.0.17120
Intel Core i7-7700HQ CPU 2.80GHz (Kaby Lake), 1 CPU, 8 logical cores and 4 physical cores
.NET Core SDK=2.1.101
  [Host]     : .NET Core 2.0.6 (CoreCLR 4.6.26212.01, CoreFX 4.6.26212.01), 64bit RyuJIT
  DefaultJob : .NET Core 2.0.6 (CoreCLR 4.6.26212.01, CoreFX 4.6.26212.01), 64bit RyuJIT


```
|         Method |         Mean |       Error |      StdDev |   Scaled | ScaledSD |  Gen 0 |  Gen 1 | Allocated |
|--------------- |-------------:|------------:|------------:|---------:|---------:|-------:|-------:|----------:|
|         Direct |     3.195 ns |   0.1027 ns |   0.0960 ns |     1.00 |     0.00 | 0.0076 |      - |      24 B |
|         DryIoc |    13.335 ns |   0.2037 ns |   0.1905 ns |     4.18 |     0.13 | 0.0076 |      - |      24 B |
|  MicroResolver |    16.943 ns |   0.2175 ns |   0.1928 ns |     5.31 |     0.16 | 0.0076 |      - |      24 B |
|    LightInject |    20.331 ns |   0.2693 ns |   0.2519 ns |     6.37 |     0.20 | 0.0076 |      - |      24 B |
| SimpleInjector |    33.023 ns |   0.6436 ns |   0.5705 ns |    10.35 |     0.34 | 0.0076 |      - |      24 B |
|     AspNetCore |    51.367 ns |   0.5381 ns |   0.5034 ns |    16.09 |     0.49 | 0.0076 |      - |      24 B |
|    FsContainer |   477.072 ns |   4.2279 ns |   3.5305 ns |   149.45 |     4.45 | 0.1040 |      - |     328 B |
|        Autofac |   517.324 ns |   5.9056 ns |   5.5241 ns |   162.06 |     4.97 | 0.2384 |      - |     752 B |
|          Unity |   619.830 ns |   7.0641 ns |   6.2621 ns |   194.17 |     5.92 | 0.3271 |      - |    1032 B |
|   StructureMap |   629.680 ns |   7.1003 ns |   5.9291 ns |   197.26 |     5.97 | 0.3271 |      - |    1032 B |
|  CastleWindsor | 1,666.698 ns |  18.7414 ns |  17.5307 ns |   522.13 |    15.99 | 0.3262 |      - |    1032 B |
|        Ninject | 4,148.708 ns | 127.9779 ns | 371.2870 ns | 1,299.67 |   121.69 | 0.6180 | 0.1526 |    1968 B |

## Singleton
``` ini

BenchmarkDotNet=v0.10.13, OS=Windows 10.0.17120
Intel Core i7-7700HQ CPU 2.80GHz (Kaby Lake), 1 CPU, 8 logical cores and 4 physical cores
.NET Core SDK=2.1.101
  [Host]     : .NET Core 2.0.6 (CoreCLR 4.6.26212.01, CoreFX 4.6.26212.01), 64bit RyuJIT
  DefaultJob : .NET Core 2.0.6 (CoreCLR 4.6.26212.01, CoreFX 4.6.26212.01), 64bit RyuJIT


```
|         Method |         Mean |      Error |     StdDev | Scaled | ScaledSD |  Gen 0 | Allocated |
|--------------- |-------------:|-----------:|-----------:|-------:|---------:|-------:|----------:|
|         Direct |     2.404 ns |  0.0529 ns |  0.0495 ns |   1.00 |     0.00 |      - |       0 B |
|         DryIoc |    11.411 ns |  0.0938 ns |  0.0784 ns |   4.75 |     0.10 |      - |       0 B |
|  MicroResolver |    14.159 ns |  0.1073 ns |  0.0896 ns |   5.89 |     0.12 |      - |       0 B |
|    LightInject |    17.815 ns |  0.2047 ns |  0.1914 ns |   7.41 |     0.17 |      - |       0 B |
| SimpleInjector |    30.325 ns |  0.1318 ns |  0.1233 ns |  12.62 |     0.26 |      - |       0 B |
|     AspNetCore |    52.003 ns |  0.3158 ns |  0.2800 ns |  21.64 |     0.45 |      - |       0 B |
|    FsContainer |   171.787 ns |  3.3404 ns |  3.1246 ns |  71.47 |     1.91 | 0.0634 |     200 B |
|  CastleWindsor |   289.855 ns |  4.7062 ns |  4.4022 ns | 120.60 |     3.00 | 0.1092 |     344 B |
|        Autofac |   416.878 ns |  4.7939 ns |  4.4842 ns | 173.45 |     3.93 | 0.2031 |     640 B |
|          Unity |   541.201 ns |  8.5350 ns |  7.9836 ns | 225.17 |     5.55 | 0.3834 |    1208 B |
|   StructureMap |   555.625 ns |  8.0762 ns |  6.7440 ns | 231.17 |     5.38 | 0.3834 |    1208 B |
|        Ninject | 1,225.033 ns | 19.3328 ns | 18.0839 ns | 509.69 |    12.57 | 0.3376 |    1064 B |

## Combined (resolving a transient containing one transient and one singleton) 
``` ini

BenchmarkDotNet=v0.10.13, OS=Windows 10.0.17120
Intel Core i7-7700HQ CPU 2.80GHz (Kaby Lake), 1 CPU, 8 logical cores and 4 physical cores
.NET Core SDK=2.1.101
  [Host]     : .NET Core 2.0.6 (CoreCLR 4.6.26212.01, CoreFX 4.6.26212.01), 64bit RyuJIT
  DefaultJob : .NET Core 2.0.6 (CoreCLR 4.6.26212.01, CoreFX 4.6.26212.01), 64bit RyuJIT


```
|         Method |         Mean |       Error |      StdDev | Scaled | ScaledSD |  Gen 0 |  Gen 1 | Allocated |
|--------------- |-------------:|------------:|------------:|-------:|---------:|-------:|-------:|----------:|
|         Direct |     12.49 ns |   0.2079 ns |   0.1944 ns |   1.00 |     0.00 | 0.0178 |      - |      56 B |
|         DryIoc |     24.35 ns |   0.3008 ns |   0.2666 ns |   1.95 |     0.04 | 0.0178 |      - |      56 B |
|    LightInject |     28.87 ns |   0.4784 ns |   0.4475 ns |   2.31 |     0.05 | 0.0178 |      - |      56 B |
|  MicroResolver |     29.81 ns |   0.2379 ns |   0.1857 ns |   2.39 |     0.04 | 0.0178 |      - |      56 B |
| SimpleInjector |     46.78 ns |   0.6450 ns |   0.6033 ns |   3.75 |     0.07 | 0.0178 |      - |      56 B |
|     AspNetCore |     61.54 ns |   0.7182 ns |   0.6367 ns |   4.93 |     0.09 | 0.0178 |      - |      56 B |
|    FsContainer |  1,027.39 ns |  13.1911 ns |  12.3390 ns |  82.25 |     1.57 | 0.2327 |      - |     736 B |
|        Autofac |  1,411.27 ns |  24.7593 ns |  21.9485 ns | 112.98 |     2.41 | 0.5741 |      - |    1808 B |
|          Unity |  1,664.15 ns |  19.5121 ns |  18.2516 ns | 133.22 |     2.47 | 0.6580 |      - |    2072 B |
|   StructureMap |  1,684.32 ns |  33.0940 ns |  27.6350 ns | 134.84 |     2.96 | 0.6580 |      - |    2072 B |
|  CastleWindsor |  7,149.85 ns | 107.4464 ns | 100.5055 ns | 572.38 |    11.68 | 0.8316 |      - |    2632 B |
|        Ninject | 10,228.69 ns | 265.0937 ns | 769.0850 ns | 818.85 |    62.51 | 1.7700 | 0.4272 |    5584 B |
