namespace DependencyInjectorBenchmarks.Containers
{
    public interface IContainerBenchmark
    {
        IStatelessStorage ResolveSingleton();
        IStatefulStorage ResolveTransient();
    }
}
