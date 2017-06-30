using System;
using System.Collections.Generic;
using System.Text;
using DependencyInjectorBenchmarks.Scenarios;
using DryIoc;

namespace DependencyInjectorBenchmarks.Containers
{
    public class DryIocBenchmark : IContainerBenchmark
    {
        public static readonly DryIocBenchmark Instance = new DryIocBenchmark();

        private Container container;

        public DryIocBenchmark()
        {
            container = new Container();

            container.Register<ISingleton>(Reuse.Singleton, Made.Of(() => Singleton.Instance));
            container.Register<ITransient, Transient>();
            container.Register<ICombined, Combined>();
        }

        public ICombined ResolveCombined()
            => container.Resolve<ICombined>();

        public ISingleton ResolveSingleton()
            => container.Resolve<ISingleton>();

        public ITransient ResolveTransient()
            => container.Resolve<ITransient>();
    }
}
