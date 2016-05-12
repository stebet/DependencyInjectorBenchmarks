using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnostics.Windows;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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

        Container simpleInjectorContainer = new Container();
        CompositionContainer mefContainer = new CompositionContainer(new AssemblyCatalog(Assembly.GetExecutingAssembly()));

        public DIBenchmarks()
        {
            simpleInjectorContainer.Register(typeof(IStorage), typeof(Storage), Lifestyle.Transient);
        }

        [Benchmark(Baseline = true)]
        public int DirectTransient()
        {
            IStorage storage = new Storage();
            return storage.Add(1, 2);
        }

        [Benchmark]
        public int DirectSingleton()
        {
            IStorage storage = SingletonStorage.Instance;
            return storage.Add(1, 2);
        }

        [Benchmark]
        public int SimpleInjectorTransient()
        {
            IStorage storage = simpleInjectorContainer.GetInstance<IStorage>();
            return storage.Add(1, 2);
        }

        [Benchmark]
        public int MefTransient()
        {
            IStorage storage = mefContainer.GetExportedValue<IStorage>();
            return storage.Add(1, 2);
        }
    }
}
