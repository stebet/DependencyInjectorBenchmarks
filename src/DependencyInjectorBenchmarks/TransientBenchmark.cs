﻿using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Exporters;
using BenchmarkDotNet.Order;
using DependencyInjectorBenchmarks.Containers;
using DependencyInjectorBenchmarks.Scenarios;

namespace DependencyInjectorBenchmarks
{
    [MemoryDiagnoser]
    [OrderProvider(SummaryOrderPolicy.FastestToSlowest, MethodOrderPolicy.Declared)]
    [MarkdownExporter]
    public class TransientBenchmark
    {
        [Benchmark(Baseline = true)]
        public ITransient Direct() => DirectBenchmark.Instance.ResolveTransient();

        [Benchmark]
        public ITransient SimpleInjector() => SimpleInjectorBenchmark.Instance.ResolveTransient();

        [Benchmark]
        public ITransient Ninject() => NinjectBenchmark.Instance.ResolveTransient();

        [Benchmark]
        public ITransient Autofac() => AutofacBenchmark.Instance.ResolveTransient();

        [Benchmark]
        public ITransient AspNetCore() => AspNetCoreBenchmark.Instance.ResolveTransient();

        [Benchmark]
        public ITransient CastleWindsor() => CastleWindsorBenchmark.Instance.ResolveTransient();

        [Benchmark]
        public ITransient LightInject() => LightInjectBenchmark.Instance.ResolveTransient();

        [Benchmark]
        public ITransient StructureMap() => StructureMapBenchmark.Instance.ResolveTransient();

        [Benchmark]
        public ITransient FsContainer() => FsContainerBenchmark.Instance.ResolveTransient();

        [Benchmark]
        public ITransient DryIoc() => DryIocBenchmark.Instance.ResolveTransient();

        [Benchmark]
        public ITransient Unity() => UnityBenchmark.Instance.ResolveTransient();

        [Benchmark]
        public ITransient MicroResolver() => MicroResolverBenchmark.Instance.ResolveTransient();

        [Benchmark]
        public ITransient Grace() => GraceBenchmark.Instance.ResolveTransient();
    }
}
