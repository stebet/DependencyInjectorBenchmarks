using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnostics.Windows;
using BenchmarkDotNet.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectorBenchmarks
{
    public class Config : ManualConfig
    {
        public Config()
        {
            Add(Job.Default
                .WithLaunchCount(3)     // benchmark process will be launched only once
                .WithIterationTime(100) // 100ms per iteration
                .WithWarmupCount(3)     // 3 warmup iteration
                .WithTargetCount(3)     // 3 target iteration
                );

            Add(new MemoryDiagnoser());
        }
    }
}
