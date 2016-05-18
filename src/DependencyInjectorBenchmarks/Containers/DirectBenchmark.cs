namespace DependencyInjectorBenchmarks.Containers
{
    public class DirectBenchmark : IContainerBenchmark
    {
        public static readonly DirectBenchmark Instance = new DirectBenchmark();

        public IStatelessStorage ResolveSingleton() => StatelessStorage.Instance;

        public IStatefulStorage ResolveTransient() => new StatefulStorage();
    }
}
