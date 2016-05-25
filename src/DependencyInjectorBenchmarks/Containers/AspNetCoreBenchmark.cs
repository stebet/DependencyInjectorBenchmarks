using System;
using Microsoft.Extensions.DependencyInjection;
using DependencyInjectorBenchmarks.Scenarios;

namespace DependencyInjectorBenchmarks.Containers
{
    public class AspNetCoreBenchmark : IContainerBenchmark
    {
        public static readonly AspNetCoreBenchmark Instance = new AspNetCoreBenchmark();

        private readonly IServiceProvider provider;

        public AspNetCoreBenchmark()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddSingleton(Singleton.Instance);
            serviceCollection.AddTransient<ITransient, Transient>();
            serviceCollection.AddTransient<ICombined, Combined>();

            provider = serviceCollection.BuildServiceProvider();
        }

        public ICombined ResolveCombined() => provider.GetService<ICombined>();

        public ISingleton ResolveSingleton() => provider.GetService<ISingleton>();

        public ITransient ResolveTransient() => provider.GetService<ITransient>();
    }
}
