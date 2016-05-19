using System;
using Ninject;
using DependencyInjectorBenchmarks.Scenarios;

namespace DependencyInjectorBenchmarks.Containers
{
    public class NinjectBenchmark : IContainerBenchmark
    {
        public static readonly NinjectBenchmark Instance = new NinjectBenchmark();

        private readonly IKernel kernel = new StandardKernel();

        public NinjectBenchmark()
        {
            kernel.Bind<ISingleton>().To<Singleton>().InSingletonScope();
            kernel.Bind<ITransient>().To<Transient>().InTransientScope();
            kernel.Bind<ICombined>().To<Combined>().InTransientScope();
        }

        public ICombined ResolveCombined() => kernel.Get<ICombined>();

        public ISingleton ResolveSingleton() => kernel.Get<ISingleton>();

        public ITransient ResolveTransient() => kernel.Get<ITransient>();
    }
}
