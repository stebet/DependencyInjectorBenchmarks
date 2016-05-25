using DependencyInjectorBenchmarks.Scenarios;
using StructureMap;

namespace DependencyInjectorBenchmarks.Containers
{
    public class StructureMapBenchmark : IContainerBenchmark
    {
        public static readonly StructureMapBenchmark Instance = new StructureMapBenchmark();

        private readonly Container container = new Container();
        public StructureMapBenchmark()
        {
            container.Configure(conf =>
            {
                conf.For<ISingleton>().Use<Singleton>().Singleton();
                conf.For<ITransient>().Use<Transient>().Transient();
                conf.For<ICombined>().Use<Combined>().Transient();
            });
        }

        public ICombined ResolveCombined() => container.GetInstance<ICombined>();

        public ISingleton ResolveSingleton() => container.GetInstance<ISingleton>();

        public ITransient ResolveTransient() => container.GetInstance<ITransient>();
    }
}