using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnostics.Windows;
using BenchmarkDotNet.Jobs;

namespace DependencyInjectorBenchmarks
{
    public class Config : ManualConfig
    {
        public Config()
        {
            //Add(Job.RyuJitX64.WithLaunchCount(3).WithIterationTime(100).WithWarmupCount(3).WithTargetCount(3));
            Add(Job.RyuJitX64);
            Add(new MemoryDiagnoser());
        }
    }
}
