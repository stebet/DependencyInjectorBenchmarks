using SimpleInjector;

namespace DependencyInjectorBenchmarks.Containers
{
    public class SimpleInjectorBenchmark : IContainerBenchmark
    {
        public static readonly SimpleInjectorBenchmark Instance = new SimpleInjectorBenchmark();

        private readonly Container container = new Container();
        public SimpleInjectorBenchmark()
        {
            container.Register<IStatelessStorage, StatelessStorage>(Lifestyle.Singleton);
            container.Register<IStatefulStorage, StatefulStorage>(Lifestyle.Transient);
        }

        public IStatelessStorage ResolveSingleton() => container.GetInstance<IStatelessStorage>();

        public IStatefulStorage ResolveTransient() => container.GetInstance<IStatefulStorage>();
    }
}
