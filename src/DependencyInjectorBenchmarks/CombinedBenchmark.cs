using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using DependencyInjectorBenchmarks.Containers;
using DependencyInjectorBenchmarks.Scenarios;

namespace DependencyInjectorBenchmarks
{
    [Config(typeof(Config))]
    [OrderProvider(SummaryOrderPolicy.FastestToSlowest, MethodOrderPolicy.Declared)]
    public class CombinedBenchmark
    {
        [Benchmark(Baseline = true)]
        public ICombined Direct() => DirectBenchmark.Instance.ResolveCombined();

        [Benchmark]
        public ICombined SimpleInjector() => SimpleInjectorBenchmark.Instance.ResolveCombined();

        [Benchmark]
        public ICombined Ninject() => NinjectBenchmark.Instance.ResolveCombined();

        [Benchmark]
        public ICombined Autofac() => AutofacBenchmark.Instance.ResolveCombined();

        [Benchmark]
        public ICombined AspNetCore() => AspNetCoreBenchmark.Instance.ResolveCombined();

        [Benchmark]
        public ICombined LightInject() => LightInjectBenchmark.Instance.ResolveCombined();

        [Benchmark]
        public ICombined StructureMap() => StructureMapBenchmark.Instance.ResolveCombined();
    }
}
