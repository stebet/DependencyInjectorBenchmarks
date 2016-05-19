using System;
using Mef = System.ComponentModel.Composition;
using Mef2 = System.Composition;

namespace DependencyInjectorBenchmarks.Scenarios
{
    public interface ICombined
    {

    }

    [Mef.Export(typeof(ICombined))]
    [Mef2.Export(typeof(ICombined))]
    [Mef.PartCreationPolicy(Mef.CreationPolicy.NonShared)]
    public class Combined : ICombined
    {
        private readonly ISingleton _singleton;
        private readonly ITransient _transient;

        [Mef2.ImportingConstructor]
        [Mef.ImportingConstructor]
        public Combined(ISingleton stateless, ITransient stateful)
        {
            if (stateless == null)
            {
                throw new ArgumentNullException(nameof(stateless));
            }

            if (stateful == null)
            {
                throw new ArgumentNullException(nameof(stateful));
            }

            _singleton = stateless;
            _transient = stateful;
        }
    }


}
