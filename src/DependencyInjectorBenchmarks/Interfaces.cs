using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectorBenchmarks
{
    public interface IStorage
    {
        int Add(int a, int b);
        int Subtract(int a, int b);
        int Multiply(int a, int b);
        int Divide(int a, int b);
    }

    [Export(typeof(IStorage))]
    public class Storage : IStorage
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public int Divide(int a, int b)
        {
            return a / b;
        }

        public int Multiply(int a, int b)
        {
            return a * b;
        }

        public int Subtract(int a, int b)
        {
            return a - b;
        }
    }

    public class SingletonStorage : Storage
    {
        public static readonly IStorage Instance = new Storage();
    }
}
