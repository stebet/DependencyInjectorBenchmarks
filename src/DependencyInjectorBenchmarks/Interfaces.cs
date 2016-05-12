using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    [Export(typeof(IStatefulStorage))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class StatefulStorage : IStatefulStorage
    {
        public int FakeDbCommand(string doStuff) => doStuff.Length;
    }
}
