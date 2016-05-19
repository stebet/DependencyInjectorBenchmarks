using DependencyInjectorBenchmarks.Scenarios;

namespace DependencyInjectorBenchmarks.Containers
{
    public interface IContainerBenchmark
    {
        ISingleton ResolveSingleton();
        ITransient ResolveTransient();
        ICombined ResolveCombined();
    }
}
