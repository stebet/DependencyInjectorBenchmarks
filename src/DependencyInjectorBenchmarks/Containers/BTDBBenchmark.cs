using BTDB.IOC;
using DependencyInjectorBenchmarks.Scenarios;

namespace DependencyInjectorBenchmarks.Containers
{
    public class BTDBBenchmark : IContainerBenchmark
    {
        public static readonly BTDBBenchmark Instance = new BTDBBenchmark();

        private readonly IContainer container;

        public BTDBBenchmark()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Singleton>().As<ISingleton>().SingleInstance();
            builder.RegisterType<Transient>().As<ITransient>();
            builder.RegisterType<Combined>().As<ICombined>();
            container = builder.Build();
        }

        public ICombined ResolveCombined() => container.Resolve<ICombined>();

        public ISingleton ResolveSingleton() => container.Resolve<ISingleton>();

        public ITransient ResolveTransient() => container.Resolve<ITransient>();
    }
}
