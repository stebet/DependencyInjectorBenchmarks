using BenchmarkDotNet.Attributes;
using DependencyInjectorBenchmarks.Containers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectorBenchmarks
{
    [Config(typeof(Config))]
    public class CombinedBenchmark
    {
        [Benchmark(Baseline = true)]
        public ICombined Direct() => DirectBenchmark.Instance.ResolveCombined();

        [Benchmark]
        public ICombined SimpleInjector() => SimpleInjectorBenchmark.Instance.ResolveCombined();

        [Benchmark]
        public ICombined Mef() => MefBenchmark.Instance.ResolveCombined();

        [Benchmark]
        public ICombined Ninject() => NinjectBenchmark.Instance.ResolveCombined();

        [Benchmark]
        public ICombined Mef2() => Mef2Benchmark.Instance.ResolveCombined();

        [Benchmark]
        public ICombined CastleWindsor() => CastleWindsorBenchmark.Instance.ResolveCombined();

        [Benchmark]
        public ICombined Autofac() => AutofacBenchmark.Instance.ResolveCombined();
    }
}
