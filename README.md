# DI Container Benchmarks

Here are the latest results as run on my workstation on June 10th 2017 using the Default workload.

## Transient
``` ini

BenchmarkDotNet=v0.10.8, OS=Windows 10.0.16215
Processor=Intel Core i7-7700HQ CPU 2.80GHz (Kaby Lake), ProcessorCount=8
Frequency=2742190 Hz, Resolution=364.6720 ns, Timer=TSC
dotnet cli version=1.0.4
  [Host]     : .NET Core 4.6.25211.01, 64bit RyuJIT
  DefaultJob : .NET Core 4.6.25211.01, 64bit RyuJIT


```
 |         Method |         Mean |       Error |      StdDev | Scaled | ScaledSD |  Gen 0 |  Gen 1 |  Gen 2 | Allocated |
 |--------------- |-------------:|------------:|------------:|-------:|---------:|-------:|-------:|-------:|----------:|
 |         Direct |     4.512 ns |   0.0941 ns |   0.0881 ns |   1.00 |     0.00 | 0.0076 |      - |      - |      24 B |
 |    LightInject |    25.315 ns |   0.4641 ns |   0.4341 ns |   5.61 |     0.14 | 0.0076 |      - |      - |      24 B |
 | SimpleInjector |    36.741 ns |   0.1401 ns |   0.1242 ns |   8.15 |     0.16 | 0.0076 |      - |      - |      24 B |
 |     AspNetCore |    56.711 ns |   0.9524 ns |   0.8909 ns |  12.57 |     0.30 | 0.0075 |      - |      - |      24 B |
 |        Autofac |   591.880 ns |  11.2693 ns |  12.0580 ns | 131.21 |     3.59 | 0.2384 |      - |      - |     752 B |
 |   StructureMap |   691.827 ns |  11.7574 ns |  10.9979 ns | 153.37 |     3.73 | 0.3271 |      - |      - |    1032 B |
 |        Ninject | 4,161.172 ns | 123.1015 ns | 353.2013 ns | 922.50 |    79.82 | 0.6411 | 0.1566 | 0.0002 |    2029 B |

## Singleton
``` ini

BenchmarkDotNet=v0.10.8, OS=Windows 10.0.16215
Processor=Intel Core i7-7700HQ CPU 2.80GHz (Kaby Lake), ProcessorCount=8
Frequency=2742190 Hz, Resolution=364.6720 ns, Timer=TSC
dotnet cli version=1.0.4
  [Host]     : .NET Core 4.6.25211.01, 64bit RyuJIT
  DefaultJob : .NET Core 4.6.25211.01, 64bit RyuJIT


```
 |         Method |         Mean |      Error |     StdDev | Scaled | ScaledSD |  Gen 0 | Allocated |
 |--------------- |-------------:|-----------:|-----------:|-------:|---------:|-------:|----------:|
 |         Direct |     3.219 ns |  0.0794 ns |  0.0743 ns |   1.00 |     0.00 |      - |       0 B |
 |    LightInject |    23.700 ns |  0.3134 ns |  0.2931 ns |   7.37 |     0.19 |      - |       0 B |
 | SimpleInjector |    33.328 ns |  0.3590 ns |  0.3358 ns |  10.36 |     0.25 |      - |       0 B |
 |     AspNetCore |    48.447 ns |  0.1155 ns |  0.1024 ns |  15.06 |     0.34 |      - |       0 B |
 |        Autofac |   428.207 ns |  2.1042 ns |  1.8653 ns | 133.09 |     3.06 | 0.2031 |     640 B |
 |   StructureMap |   554.750 ns | 11.1758 ns | 10.4538 ns | 172.42 |     5.01 | 0.3557 |    1120 B |
 |        Ninject | 1,126.700 ns |  6.0723 ns |  4.7409 ns | 350.18 |     8.04 | 0.3376 |    1064 B |

## Combined (resolving a transient containing one transient and one singleton) 
``` ini

BenchmarkDotNet=v0.10.8, OS=Windows 10.0.16215
Processor=Intel Core i7-7700HQ CPU 2.80GHz (Kaby Lake), ProcessorCount=8
Frequency=2742190 Hz, Resolution=364.6720 ns, Timer=TSC
dotnet cli version=1.0.4
  [Host]     : .NET Core 4.6.25211.01, 64bit RyuJIT
  DefaultJob : .NET Core 4.6.25211.01, 64bit RyuJIT


```
 |         Method |         Mean |       Error |      StdDev | Scaled | ScaledSD |  Gen 0 |  Gen 1 |  Gen 2 | Allocated |
 |--------------- |-------------:|------------:|------------:|-------:|---------:|-------:|-------:|-------:|----------:|
 |         Direct |     13.16 ns |   0.1354 ns |   0.1201 ns |   1.00 |     0.00 | 0.0178 |      - |      - |      56 B |
 |    LightInject |     34.42 ns |   0.3425 ns |   0.3204 ns |   2.62 |     0.03 | 0.0178 |      - |      - |      56 B |
 | SimpleInjector |     48.50 ns |   0.2947 ns |   0.2461 ns |   3.69 |     0.04 | 0.0178 |      - |      - |      56 B |
 |     AspNetCore |     71.68 ns |   0.9382 ns |   0.8317 ns |   5.45 |     0.08 | 0.0178 |      - |      - |      56 B |
 |        Autofac |  1,497.05 ns |   4.9088 ns |   4.0991 ns | 113.79 |     1.05 | 0.5741 |      - |      - |    1808 B |
 |   StructureMap |  1,882.80 ns |  37.5787 ns |  82.4862 ns | 143.11 |     6.34 | 0.6294 |      - |      - |    1984 B |
 |        Ninject | 10,557.99 ns | 213.5191 ns | 619.4577 ns | 802.48 |    47.38 | 1.7860 | 0.4425 | 0.0008 |    5666 B |
