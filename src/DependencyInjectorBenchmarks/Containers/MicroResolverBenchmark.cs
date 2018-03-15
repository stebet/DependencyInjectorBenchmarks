using System;
using System.Collections.Generic;
using System.Text;
using DependencyInjectorBenchmarks.Scenarios;

namespace DependencyInjectorBenchmarks.Containers
{
    public class MicroResolverBenchmark : IContainerBenchmark
    {
        public static MicroResolverBenchmark Instance { get; } = new MicroResolverBenchmark();

        MicroResolver.ObjectResolver container = MicroResolver.ObjectResolver.Create();

        public MicroResolverBenchmark()
        {
            container.Register<ISingleton, Singleton>(MicroResolver.Lifestyle.Singleton);
            container.Register<ITransient, Transient>(MicroResolver.Lifestyle.Transient);
            container.Register<ICombined, Combined>(MicroResolver.Lifestyle.Transient);
            container.Compile();
        }

        public ICombined ResolveCombined()
        {
            return container.Resolve<ICombined>();
        }

        public ISingleton ResolveSingleton()
        {
            return container.Resolve<ISingleton>();
        }

        public ITransient ResolveTransient()
        {
            return container.Resolve<ITransient>();
        }
    }
}
