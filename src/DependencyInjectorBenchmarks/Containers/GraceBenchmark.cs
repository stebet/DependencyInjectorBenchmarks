using System;
using System.Collections.Generic;
using System.Text;
using DependencyInjectorBenchmarks.Scenarios;
using Grace.DependencyInjection;

namespace DependencyInjectorBenchmarks.Containers
{
    public class GraceBenchmark : IContainerBenchmark
    {
        public static readonly GraceBenchmark Instance = new GraceBenchmark();

        private DependencyInjectionContainer container;

        public GraceBenchmark()
        {
            container = new DependencyInjectionContainer
            {
                c =>
                {
                    c.ExportInstance(Singleton.Instance).Lifestyle.Singleton();
                    c.Export<Transient>().As<ITransient>();
                    c.Export<Combined>().As<ICombined>();
                }
            };
        }

        public ISingleton ResolveSingleton() => container.Locate<ISingleton>();

        public ITransient ResolveTransient() => container.Locate<ITransient>();

        public ICombined ResolveCombined() => container.Locate<ICombined>();
    }
}
