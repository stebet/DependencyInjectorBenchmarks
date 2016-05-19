using Autofac;
using DependencyInjectorBenchmarks.Scenarios;

namespace DependencyInjectorBenchmarks.Containers
{
    public class AutofacBenchmark : IContainerBenchmark
    {
        public static readonly AutofacBenchmark Instance = new AutofacBenchmark();

        private readonly IContainer container;

        public AutofacBenchmark()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Singleton>().As<ISingleton>().SingleInstance();
            builder.RegisterType<Transient>().As<ITransient>().InstancePerDependency();
            builder.RegisterType<Combined>().As<ICombined>().InstancePerDependency();
            container = builder.Build();
        }

        public ICombined ResolveCombined() => container.Resolve<ICombined>();

        public ISingleton ResolveSingleton() => container.Resolve<ISingleton>();

        public ITransient ResolveTransient() => container.Resolve<ITransient>();
    }
}
