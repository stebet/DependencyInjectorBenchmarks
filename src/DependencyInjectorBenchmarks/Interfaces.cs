using System;
using Mef = System.ComponentModel.Composition;
using Mef2 = System.Composition;
namespace DependencyInjectorBenchmarks
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
            if(stateless == null)
            {
                throw new ArgumentNullException(nameof(stateless));
            }

            if(stateful == null)
            {
                throw new ArgumentNullException(nameof(stateful));
            }

            _singleton = stateless;
            _transient = stateful;
        }
    }

    public interface ISingleton
    {
    }

    public interface ITransient
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

    [Mef2.Export(typeof(ITransient))]
    [Mef.Export(typeof(ITransient))]
    [Mef.PartCreationPolicy(Mef.CreationPolicy.NonShared)]
    public class Transient : ITransient
    {
    }
}
