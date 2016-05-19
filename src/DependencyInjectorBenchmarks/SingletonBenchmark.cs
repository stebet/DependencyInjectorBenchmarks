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
    public class SingletonBenchmark
    {
        [Benchmark(Baseline = true)]
        public ISingleton Direct() => DirectBenchmark.Instance.ResolveSingleton();

        [Benchmark]
        public ISingleton SimpleInjector() => SimpleInjectorBenchmark.Instance.ResolveSingleton();

        [Benchmark]
        public ISingleton Mef() => MefBenchmark.Instance.ResolveSingleton();

        [Benchmark]
        public ISingleton Ninject() => NinjectBenchmark.Instance.ResolveSingleton();

        [Benchmark]
        public ISingleton Mef2() => Mef2Benchmark.Instance.ResolveSingleton();

        [Benchmark]
        public ISingleton CastleWindsor() => CastleWindsorBenchmark.Instance.ResolveSingleton();

        [Benchmark]
        public ISingleton Autofac() => AutofacBenchmark.Instance.ResolveSingleton();
    }
}
