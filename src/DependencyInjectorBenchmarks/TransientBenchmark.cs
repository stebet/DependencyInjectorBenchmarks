using BenchmarkDotNet.Attributes;
using DependencyInjectorBenchmarks.Containers;
using DependencyInjectorBenchmarks.Scenarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectorBenchmarks
{
    [Config(typeof(Config))]
    public class TransientBenchmark
    {
        [Benchmark(Baseline = true)]
        public ITransient Direct() => DirectBenchmark.Instance.ResolveTransient();

        [Benchmark]
        public ITransient SimpleInjector() => SimpleInjectorBenchmark.Instance.ResolveTransient();

        [Benchmark]
        public ITransient Mef() => MefBenchmark.Instance.ResolveTransient();

        [Benchmark]
        public ITransient Ninject() => NinjectBenchmark.Instance.ResolveTransient();

        [Benchmark]
        public ITransient Mef2() => Mef2Benchmark.Instance.ResolveTransient();

        [Benchmark]
        public ITransient CastleWindsor() => CastleWindsorBenchmark.Instance.ResolveTransient();

        [Benchmark]
        public ITransient Autofac() => AutofacBenchmark.Instance.ResolveTransient();

        [Benchmark]
        public ITransient Unity() => UnityBenchmarks.Instance.ResolveTransient();

        [Benchmark]
        public ITransient LightInject() => LightInjectBenchmark.Instance.ResolveTransient();
    }
}
