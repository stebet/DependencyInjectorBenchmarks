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
        private readonly ISingleton _stateless;

        private readonly ITransient _stateful;

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

            _stateless = stateless;
            _stateful = stateful;
        }
    }

    public interface ISingleton
    {
        int Add(int a, int b);
        int Subtract(int a, int b);
        int Multiply(int a, int b);
        int Divide(int a, int b);
    }

    public interface ITransient
    {
        int FakeDbCommand(string doStuff);
    }

    [Mef2.Export(typeof(ISingleton))]
    [Mef2.Shared]
    [Mef.Export(typeof(ISingleton))]
    [Mef.PartCreationPolicy(Mef.CreationPolicy.Shared)]
    public class Singleton : ISingleton
    {
        public static readonly ISingleton Instance = new Singleton();

        public int Add(int a, int b) => a + b;
        public int Divide(int a, int b) => a / b;
        public int Multiply(int a, int b) => a * b;
        public int Subtract(int a, int b) => a - b;
    }

    [Mef2.Export(typeof(ITransient))]
    [Mef.Export(typeof(ITransient))]
    [Mef.PartCreationPolicy(Mef.CreationPolicy.NonShared)]
    public class Transient : ITransient
    {
        public int FakeDbCommand(string doStuff) => doStuff.Length;
    }
}
