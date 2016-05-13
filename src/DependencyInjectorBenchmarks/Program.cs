using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnostics.Windows;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using Ninject;
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

        IKernel kernel = new StandardKernel();
        Container simpleInjectorContainer = new Container();
        CompositionContainer mefContainer = new CompositionContainer(new AssemblyCatalog(Assembly.GetExecutingAssembly()));

        public DIBenchmarks()
        {
            simpleInjectorContainer.Register(typeof(IStatelessStorage), typeof(StatelessStorage), Lifestyle.Singleton);
            simpleInjectorContainer.Register(typeof(IStatefulStorage), typeof(StatefulStorage), Lifestyle.Transient);
            kernel.Bind<IStatelessStorage>().To<StatelessStorage>().InSingletonScope();
            kernel.Bind<IStatefulStorage>().To<StatefulStorage>().InTransientScope();
        }

        [Benchmark(Baseline = true)]
        public IStatefulStorage DirectTransient() => new StatefulStorage();

        [Benchmark]
        public IStatefulStorage SimpleInjectorTransient() => simpleInjectorContainer.GetInstance<IStatefulStorage>();

        [Benchmark]
        public IStatefulStorage MefTransient() => mefContainer.GetExportedValue<IStatefulStorage>();

        [Benchmark]
        public IStatefulStorage NinjectTransient() => kernel.Get<IStatefulStorage>();

        [Benchmark]
        public IStatelessStorage DirectSingleton() => StatelessStorage.Instance;

        [Benchmark]
        public IStatelessStorage SimpleInjectorSingleton() => simpleInjectorContainer.GetInstance<IStatelessStorage>();

        [Benchmark]
        public IStatelessStorage MefSingleton() => mefContainer.GetExportedValue<IStatelessStorage>();

        [Benchmark]
        public IStatelessStorage NinjectSingleton() => kernel.Get<IStatelessStorage>();
    }
}
