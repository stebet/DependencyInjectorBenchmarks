using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Exporters;
using BenchmarkDotNet.Order;
using DependencyInjectorBenchmarks.Containers;
using DependencyInjectorBenchmarks.Scenarios;

namespace DependencyInjectorBenchmarks
{
    [MemoryDiagnoser]
    [OrderProvider(SummaryOrderPolicy.FastestToSlowest, MethodOrderPolicy.Declared)]
    [MarkdownExporter]
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
        public ICombined CastleWindsor() => CastleWindsorBenchmark.Instance.ResolveCombined();

        [Benchmark]
        public ICombined LightInject() => LightInjectBenchmark.Instance.ResolveCombined();

        [Benchmark]
        public ICombined StructureMap() => StructureMapBenchmark.Instance.ResolveCombined();

        [Benchmark]
        public ICombined FsContainer() => FsContainerBenchmark.Instance.ResolveCombined();

        [Benchmark]
        public ICombined DryIoc() => DryIocBenchmark.Instance.ResolveCombined();

        [Benchmark]
        public ICombined Unity() => UnityBenchmark.Instance.ResolveCombined();

        [Benchmark]
        public ICombined MicroResolver() => MicroResolverBenchmark.Instance.ResolveCombined();

        [Benchmark]
        public ICombined Grace() => GraceBenchmark.Instance.ResolveCombined();
    }
}
