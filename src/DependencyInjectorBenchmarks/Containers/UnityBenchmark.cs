using System;
using System.Collections.Generic;
using System.Text;
using DependencyInjectorBenchmarks.Scenarios;
using Unity;

namespace DependencyInjectorBenchmarks.Containers
{
    public class UnityBenchmark : IContainerBenchmark
    {
        public static readonly StructureMapBenchmark Instance = new StructureMapBenchmark();

        UnityContainer container = new UnityContainer();

        public UnityBenchmark()
        {
            container.RegisterSingleton<ISingleton, Singleton>();
            container.RegisterType<ITransient, Transient>();
            container.RegisterType<ICombined, Combined>();
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
