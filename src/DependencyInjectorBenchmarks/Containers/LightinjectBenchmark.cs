using LightInject;
using DependencyInjectorBenchmarks.Scenarios;

namespace DependencyInjectorBenchmarks.Containers
{
    public class LightInjectBenchmark : IContainerBenchmark
    {
        public static readonly LightInjectBenchmark Instance = new LightInjectBenchmark();

        private readonly IServiceContainer container;

        public LightInjectBenchmark()
        {
            this.container = new ServiceContainer();
            this.container.Register<ISingleton, Singleton>(new PerContainerLifetime());
            this.container.Register<ITransient, Transient>(new PerRequestLifeTime());
            this.container.Register<ICombined, Combined>(new PerRequestLifeTime());
        }

        public ISingleton ResolveSingleton() => this.container.GetInstance<ISingleton>();

        public ITransient ResolveTransient() => this.container.GetInstance<ITransient>();

        public ICombined ResolveCombined() => this.container.GetInstance<ICombined>();
    }
}
