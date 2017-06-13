using DependencyInjectorBenchmarks.Scenarios;
using Fs.Container.Core;
using Fs.Container.Core.Lifetime;

namespace DependencyInjectorBenchmarks.Containers {
    public class FsContainerBenchmark : IContainerBenchmark
    {
        public static readonly FsContainerBenchmark Instance = new FsContainerBenchmark();

        private readonly IFsContainer container = new FsContainer();

        public FsContainerBenchmark()
        {
            container.For<ISingleton>().Use<Singleton>(new ContainerControlledLifetimeManager());
            container.For<ITransient>().Use<Transient>(new TransientLifetimeManager());
            container.For<ICombined>().Use<Combined>(new TransientLifetimeManager());
        }

        public ISingleton ResolveSingleton() => container.Resolve<ISingleton>();

        public ITransient ResolveTransient() => container.Resolve<ITransient>();

        public ICombined ResolveCombined() => container.Resolve<ICombined>();
    }
}