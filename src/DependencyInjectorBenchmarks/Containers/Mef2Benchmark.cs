using System;
using System.Collections.Generic;
using System.Composition;
using System.Composition.Hosting;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectorBenchmarks.Containers
{
    public class Mef2Benchmark : IContainerBenchmark
    {
        public static readonly Mef2Benchmark Instance = new Mef2Benchmark();
        private readonly CompositionHost container = new ContainerConfiguration().WithAssembly(Assembly.GetExecutingAssembly()).CreateContainer();

        public ICombined ResolveCombined() => container.GetExport<ICombined>();

        public ISingleton ResolveSingleton() => container.GetExport<ISingleton>();

        public ITransient ResolveTransient() => container.GetExport<ITransient>();
    }
}
