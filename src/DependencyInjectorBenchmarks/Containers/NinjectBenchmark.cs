using System;
using Ninject;
using DependencyInjectorBenchmarks.Scenarios;

namespace DependencyInjectorBenchmarks.Containers
{
    public class NinjectBenchmark : IContainerBenchmark
    {
        public static readonly NinjectBenchmark Instance = new NinjectBenchmark();

        private readonly IReadOnlyKernel kernel;

        public NinjectBenchmark()
        {
            var config = new KernelConfiguration();
            config.Bind<ISingleton>().To<Singleton>().InSingletonScope();
            config.Bind<ITransient>().To<Transient>().InTransientScope();
            config.Bind<ICombined>().To<Combined>().InTransientScope();
            kernel = config.BuildReadonlyKernel();
        }

        public ICombined ResolveCombined() => kernel.Get<ICombined>();

        public ISingleton ResolveSingleton() => kernel.Get<ISingleton>();

        public ITransient ResolveTransient() => kernel.Get<ITransient>();
    }
}
