using Mef = System.ComponentModel.Composition;
using Mef2 = System.Composition;

namespace DependencyInjectorBenchmarks.Scenarios
{
    public interface ITransient
    {
    }

    [Mef2.Export(typeof(ITransient))]
    [Mef.Export(typeof(ITransient))]
    [Mef.PartCreationPolicy(Mef.CreationPolicy.NonShared)]
    public class Transient : ITransient
    {
    }
}
