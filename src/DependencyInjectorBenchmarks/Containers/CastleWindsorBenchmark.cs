using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using DependencyInjectorBenchmarks.Scenarios;

namespace DependencyInjectorBenchmarks.Containers
{
    public class CastleWindsorBenchmark : IContainerBenchmark
    {
        public static readonly CastleWindsorBenchmark Instance = new CastleWindsorBenchmark();

        private readonly IWindsorContainer container;

        public CastleWindsorBenchmark()
        {
            container = new WindsorContainer();
            container.Register(
                Component.For<ISingleton>().ImplementedBy<Singleton>().LifestyleSingleton(),
                Component.For<ITransient>().ImplementedBy<Transient>().LifestyleTransient(),
                Component.For<ICombined>().ImplementedBy<Combined>().LifestyleTransient()
            );
        }

        public ICombined ResolveCombined() => container.Resolve<ICombined>();

        public ISingleton ResolveSingleton() => container.Resolve<ISingleton>();

        public ITransient ResolveTransient() => container.Resolve<ITransient>();
    }
}