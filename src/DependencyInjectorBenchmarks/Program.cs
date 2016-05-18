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
        public IStatefulStorage DirectTransient() => DirectBenchmark.Instance.ResolveTransient();

        [Benchmark]
        public IStatefulStorage SimpleInjectorTransient() => SimpleInjectorBenchmark.Instance.ResolveTransient();

        [Benchmark]
        public IStatefulStorage MefTransient() => MefBenchmark.Instance.ResolveTransient();

        [Benchmark]
        public IStatefulStorage Mef2Transient() => Mef2Benchmark.Instance.ResolveTransient();

        [Benchmark]
        public IStatefulStorage NinjectTransient() => NinjectBenchmark.Instance.ResolveTransient();

        [Benchmark]
        public IStatelessStorage DirectSingleton() => DirectBenchmark.Instance.ResolveSingleton();

        [Benchmark]
        public IStatelessStorage SimpleInjectorSingleton() => SimpleInjectorBenchmark.Instance.ResolveSingleton();

        [Benchmark]
        public IStatelessStorage MefSingleton() => MefBenchmark.Instance.ResolveSingleton();

        [Benchmark]
        public IStatelessStorage NinjectSingleton() => NinjectBenchmark.Instance.ResolveSingleton();

        [Benchmark]
        public IStatelessStorage Mef2Singleton() => Mef2Benchmark.Instance.ResolveSingleton();
    }
}
