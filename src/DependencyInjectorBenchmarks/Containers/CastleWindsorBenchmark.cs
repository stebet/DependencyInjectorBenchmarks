using Castle.MicroKernel.Registration;
using Castle.Windsor;
using DependencyInjectorBenchmarks.Scenarios;

namespace DependencyInjectorBenchmarks.Containers
{
    public class CastleWindsorBenchmark : IContainerBenchmark
    {
        public static readonly CastleWindsorBenchmark Instance = new CastleWindsorBenchmark();

        private readonly WindsorContainer container = new WindsorContainer();

        public CastleWindsorBenchmark()
        {
            container.Register(Component.For<ISingleton>().ImplementedBy<Singleton>().LifestyleSingleton());
            container.Register(Component.For<ITransient>().ImplementedBy<Transient>().LifestyleTransient());
            container.Register(Component.For<ICombined>().ImplementedBy<Combined>().LifestyleTransient());
        }

        public ICombined ResolveCombined() => container.Resolve<ICombined>();

        public ISingleton ResolveSingleton() => container.Resolve<ISingleton>();

        public ITransient ResolveTransient() => container.Resolve<ITransient>();
    }
}
