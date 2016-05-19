using System;
using SimpleInjector;
using DependencyInjectorBenchmarks.Scenarios;

namespace DependencyInjectorBenchmarks.Containers
{
    public class SimpleInjectorBenchmark : IContainerBenchmark
    {
        public static readonly SimpleInjectorBenchmark Instance = new SimpleInjectorBenchmark();

        private readonly Container container = new Container();
        public SimpleInjectorBenchmark()
        {
            container.Register<ISingleton, Singleton>(Lifestyle.Singleton);
            container.Register<ITransient, Transient>(Lifestyle.Transient);
            container.Register<ICombined, Combined>(Lifestyle.Transient);
        }

        public ICombined ResolveCombined() => container.GetInstance<ICombined>();

        public ISingleton ResolveSingleton() => container.GetInstance<ISingleton>();

        public ITransient ResolveTransient() => container.GetInstance<ITransient>();
    }
}
