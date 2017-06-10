namespace DependencyInjectorBenchmarks.Scenarios
{
    public interface ISingleton
    {
    }

    public class Singleton : ISingleton
    {
        public static readonly ISingleton Instance = new Singleton();
    }
}
