using DependencyInjectorBenchmarks.Scenarios;
using Microsoft.Practices.Unity;

namespace DependencyInjectorBenchmarks.Containers
{
    public class UnityBenchmarks : IContainerBenchmark
    {
        public static readonly UnityBenchmarks Instance = new UnityBenchmarks();

        UnityContainer container = new UnityContainer();
        public UnityBenchmarks()
        {
            container.RegisterType<ISingleton, Singleton>(new ContainerControlledLifetimeManager());
            container.RegisterType<ITransient, Transient>(new TransientLifetimeManager());
            container.RegisterType<ICombined, Combined>(new TransientLifetimeManager());
        }

        public ICombined ResolveCombined() => container.Resolve<ICombined>();

        public ISingleton ResolveSingleton() => container.Resolve<ISingleton>();

        public ITransient ResolveTransient() => container.Resolve<ITransient>();
    }
}
