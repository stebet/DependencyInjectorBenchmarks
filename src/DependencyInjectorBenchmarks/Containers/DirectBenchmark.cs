using DependencyInjectorBenchmarks.Scenarios;
using System;

namespace DependencyInjectorBenchmarks.Containers
{
    public class DirectBenchmark : IContainerBenchmark
    {
        public static readonly DirectBenchmark Instance = new DirectBenchmark();

        public ICombined ResolveCombined() => new Combined(Singleton.Instance, new Transient());

        public ISingleton ResolveSingleton() => Singleton.Instance;

        public ITransient ResolveTransient() => new Transient();
    }
}
