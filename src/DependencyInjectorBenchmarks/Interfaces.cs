using System.ComponentModel.Composition;

namespace DependencyInjectorBenchmarks
{
    public interface IStatelessStorage
    {
        int Add(int a, int b);
        int Subtract(int a, int b);
        int Multiply(int a, int b);
        int Divide(int a, int b);
    }

    public interface IStatefulStorage
    {
        int FakeDbCommand(string doStuff);
    }

    [System.Composition.Export(typeof(IStatelessStorage))]
    [System.Composition.Shared]
    [Export(typeof(IStatelessStorage))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class StatelessStorage : IStatelessStorage
    {
        public static readonly IStatelessStorage Instance = new StatelessStorage();

        public int Add(int a, int b) => a + b;
        public int Divide(int a, int b) => a / b;
        public int Multiply(int a, int b) => a * b;
        public int Subtract(int a, int b) => a - b;
    }

    [System.Composition.Export(typeof(IStatefulStorage))]
    [Export(typeof(IStatefulStorage))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class StatefulStorage : IStatefulStorage
    {
        public int FakeDbCommand(string doStuff) => doStuff.Length;
    }
}
