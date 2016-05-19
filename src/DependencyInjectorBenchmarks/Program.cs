using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnostics.Windows;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using DependencyInjectorBenchmarks.Containers;
using System;

namespace DependencyInjectorBenchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkSwitcher switcher = new BenchmarkSwitcher(new[] { typeof(SingletonBenchmark), typeof(TransientBenchmark), typeof(CombinedBenchmark) });
            switcher.Run();
        }
    }
}
