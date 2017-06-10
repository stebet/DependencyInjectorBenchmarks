using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using DependencyInjectorBenchmarks.Containers;
using DependencyInjectorBenchmarks.Scenarios;

namespace DependencyInjectorBenchmarks
{
    [Config(typeof(Config))]
    [OrderProvider(SummaryOrderPolicy.FastestToSlowest, MethodOrderPolicy.Declared)]
    public class SingletonBenchmark
    {
        [Benchmark(Baseline = true)]
        public ISingleton Direct() => DirectBenchmark.Instance.ResolveSingleton();

        [Benchmark]
        public ISingleton SimpleInjector() => SimpleInjectorBenchmark.Instance.ResolveSingleton();

        [Benchmark]
        public ISingleton Ninject() => NinjectBenchmark.Instance.ResolveSingleton();

        [Benchmark]
        public ISingleton Autofac() => AutofacBenchmark.Instance.ResolveSingleton();

        [Benchmark]
        public ISingleton AspNetCore() => AspNetCoreBenchmark.Instance.ResolveSingleton();

        [Benchmark]
        public ISingleton LightInject() => LightInjectBenchmark.Instance.ResolveSingleton();

        [Benchmark]
        public ISingleton StructureMap() => StructureMapBenchmark.Instance.ResolveSingleton();
    }
}
