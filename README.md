# DI Container Benchmarks

Here are the latest results as run on my workstation on June 10th 2017 using RyuJit and Core workloads running the "Combined" benchmark (resolving a transient that references one transient and one singleton) benchmark.

``` ini

BenchmarkDotNet=v0.10.8, OS=Windows 10.0.16215
Processor=Intel Core i7-7700HQ CPU 2.80GHz (Kaby Lake), ProcessorCount=8
Frequency=2742190 Hz, Resolution=364.6720 ns, Timer=TSC
dotnet cli version=1.0.4
  [Host]    : .NET Core 4.6.25211.01, 64bit RyuJIT
  RyuJitX64 : .NET Core 4.6.25211.01, 64bit RyuJIT
  Core      : .NET Core 4.6.25211.01, 64bit RyuJIT

Jit=RyuJit  Platform=X64  Runtime=Core  

```
 |         Method |       Job |         Mean |       Error |      StdDev |       Median | Scaled | ScaledSD |  Gen 0 |  Gen 1 |  Gen 2 | Allocated |
 |--------------- |---------- |-------------:|------------:|------------:|-------------:|-------:|---------:|-------:|-------:|-------:|----------:|
 |         Direct | RyuJitX64 |     14.37 ns |   0.3679 ns |   0.6346 ns |     14.25 ns |   1.00 |     0.00 | 0.0178 |      - |      - |      56 B |
 |         Direct |      Core |     14.53 ns |   0.1014 ns |   0.0899 ns |     14.50 ns |   1.00 |     0.00 | 0.0178 |      - |      - |      56 B |
 |    LightInject | RyuJitX64 |     32.63 ns |   0.7339 ns |   0.9542 ns |     32.45 ns |   2.27 |     0.12 | 0.0178 |      - |      - |      56 B |
 |    LightInject |      Core |     37.42 ns |   0.8077 ns |   0.7160 ns |     37.44 ns |   2.58 |     0.05 | 0.0178 |      - |      - |      56 B |
 | SimpleInjector |      Core |     47.18 ns |   1.0107 ns |   1.9473 ns |     46.26 ns |   3.25 |     0.13 | 0.0178 |      - |      - |      56 B |
 | SimpleInjector | RyuJitX64 |     51.75 ns |   1.0910 ns |   1.3797 ns |     51.76 ns |   3.61 |     0.18 | 0.0178 |      - |      - |      56 B |
 |     AspNetCore | RyuJitX64 |     68.85 ns |   1.7865 ns |   1.6711 ns |     68.37 ns |   4.80 |     0.23 | 0.0178 |      - |      - |      56 B |
 |     AspNetCore |      Core |     87.89 ns |   1.8422 ns |   2.8681 ns |     87.42 ns |   6.05 |     0.20 | 0.0178 |      - |      - |      56 B |
 |        Autofac | RyuJitX64 |  1,435.01 ns |  30.1377 ns |  77.2545 ns |  1,403.05 ns | 100.02 |     6.86 | 0.5741 |      - |      - |    1808 B |
 |   StructureMap | RyuJitX64 |  1,629.65 ns |  32.5803 ns |  38.7846 ns |  1,632.17 ns | 113.59 |     5.53 | 0.6294 |      - |      - |    1984 B |
 |        Autofac |      Core |  1,659.83 ns |  42.4448 ns | 125.1494 ns |  1,637.49 ns | 114.28 |     8.60 | 0.5741 |      - |      - |    1808 B |
 |   StructureMap |      Core |  1,778.43 ns |  34.5790 ns |  47.3321 ns |  1,775.77 ns | 122.44 |     3.28 | 0.6294 |      - |      - |    1984 B |
 |        Ninject |      Core |  9,833.52 ns | 224.0126 ns | 649.9011 ns |  9,755.40 ns | 677.03 |    44.70 | 1.7857 | 0.4422 | 0.0005 |    5666 B |
 |        Ninject | RyuJitX64 | 10,875.71 ns | 254.3944 ns | 738.0443 ns | 10,863.87 ns | 758.05 |    60.64 | 1.7857 | 0.4424 | 0.0005 |    5675 B |
