using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnostics.Windows;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using DependencyInjectorBenchmarks.Containers;

namespace DependencyInjectorBenchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<DIBenchmarks>();
        }
    }

    [Config(typeof(Config))]
    public class DIBenchmarks
    {
        private class Config : ManualConfig
        {
            public Config()
            {
                Add(Job.Default
                    .WithLaunchCount(3)     // benchmark process will be launched only once
                    .WithIterationTime(100) // 100ms per iteration
                    .WithWarmupCount(3)     // 3 warmup iteration
                    .WithTargetCount(3)     // 3 target iteration
                    );

                Add(new MemoryDiagnoser());
            }
        }


        public DIBenchmarks()
        {
        }

        [Benchmark(Baseline = true)]
        public ITransient DirectTransient() => DirectBenchmark.Instance.ResolveTransient();

        [Benchmark]
        public ITransient SimpleInjectorTransient() => SimpleInjectorBenchmark.Instance.ResolveTransient();

        [Benchmark]
        public ITransient MefTransient() => MefBenchmark.Instance.ResolveTransient();

        [Benchmark]
        public ITransient Mef2Transient() => Mef2Benchmark.Instance.ResolveTransient();

        [Benchmark]
        public ITransient NinjectTransient() => NinjectBenchmark.Instance.ResolveTransient();

        [Benchmark]
        public ISingleton DirectSingleton() => DirectBenchmark.Instance.ResolveSingleton();

        [Benchmark]
        public ISingleton SimpleInjectorSingleton() => SimpleInjectorBenchmark.Instance.ResolveSingleton();

        [Benchmark]
        public ISingleton MefSingleton() => MefBenchmark.Instance.ResolveSingleton();

        [Benchmark]
        public ISingleton NinjectSingleton() => NinjectBenchmark.Instance.ResolveSingleton();

        [Benchmark]
        public ISingleton Mef2Singleton() => Mef2Benchmark.Instance.ResolveSingleton();

        [Benchmark]
        public ICombined DirectCombined() => DirectBenchmark.Instance.ResolveCombined();

        [Benchmark]
        public ICombined SimpleInjectorCombined() => SimpleInjectorBenchmark.Instance.ResolveCombined();

        [Benchmark]
        public ICombined MefCombined() => MefBenchmark.Instance.ResolveCombined();

        [Benchmark]
        public ICombined NinjectCombined() => NinjectBenchmark.Instance.ResolveCombined();

        [Benchmark]
        public ICombined Mef2Combined() => Mef2Benchmark.Instance.ResolveCombined();
    }
}
