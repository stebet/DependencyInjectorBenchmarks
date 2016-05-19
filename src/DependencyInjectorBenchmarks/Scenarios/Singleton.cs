using Mef = System.ComponentModel.Composition;
using Mef2 = System.Composition;

namespace DependencyInjectorBenchmarks.Scenarios
{
    public interface ISingleton
    {
    }

    [Mef2.Export(typeof(ISingleton))]
    [Mef2.Shared]
    [Mef.Export(typeof(ISingleton))]
    [Mef.PartCreationPolicy(Mef.CreationPolicy.Shared)]
    public class Singleton : ISingleton
    {
        public static readonly ISingleton Instance = new Singleton();
    }
}
