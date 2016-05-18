using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
