using DependencyInjectorBenchmarks.Containers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DependencyInjectorBenchmarks.Tests
{
    public class ContainerTests
    {
        [Fact]
        public void TestSingleton()
        {
            Assert.NotNull(DirectBenchmark.Instance.ResolveSingleton());
            Assert.NotNull(Mef2Benchmark.Instance.ResolveSingleton());
            Assert.NotNull(MefBenchmark.Instance.ResolveSingleton());
            Assert.NotNull(NinjectBenchmark.Instance.ResolveSingleton());
            Assert.NotNull(SimpleInjectorBenchmark.Instance.ResolveSingleton());
            Assert.NotNull(CastleWindsorBenchmark.Instance.ResolveSingleton());
            Assert.NotNull(AutofacBenchmark.Instance.ResolveSingleton());
            Assert.NotNull(UnityBenchmarks.Instance.ResolveSingleton());
            Assert.NotNull(AspNetCoreBenchmark.Instance.ResolveSingleton());
            Assert.NotNull(LightInjectBenchmark.Instance.ResolveSingleton());

            Assert.Same(DirectBenchmark.Instance.ResolveSingleton(), DirectBenchmark.Instance.ResolveSingleton());
            Assert.Same(Mef2Benchmark.Instance.ResolveSingleton(), Mef2Benchmark.Instance.ResolveSingleton());
            Assert.Same(MefBenchmark.Instance.ResolveSingleton(), MefBenchmark.Instance.ResolveSingleton());
            Assert.Same(NinjectBenchmark.Instance.ResolveSingleton(), NinjectBenchmark.Instance.ResolveSingleton());
            Assert.Same(SimpleInjectorBenchmark.Instance.ResolveSingleton(), SimpleInjectorBenchmark.Instance.ResolveSingleton());
            Assert.Same(CastleWindsorBenchmark.Instance.ResolveSingleton(), CastleWindsorBenchmark.Instance.ResolveSingleton());
            Assert.Same(AutofacBenchmark.Instance.ResolveSingleton(), AutofacBenchmark.Instance.ResolveSingleton());
            Assert.Same(UnityBenchmarks.Instance.ResolveSingleton(), UnityBenchmarks.Instance.ResolveSingleton());
            Assert.Same(AspNetCoreBenchmark.Instance.ResolveSingleton(), AspNetCoreBenchmark.Instance.ResolveSingleton());
            Assert.Same(LightInjectBenchmark.Instance.ResolveSingleton(), LightInjectBenchmark.Instance.ResolveSingleton());
        }

        [Fact]
        public void TestTransient()
        {
            Assert.NotNull(DirectBenchmark.Instance.ResolveTransient());
            Assert.NotNull(Mef2Benchmark.Instance.ResolveTransient());
            Assert.NotNull(MefBenchmark.Instance.ResolveTransient());
            Assert.NotNull(NinjectBenchmark.Instance.ResolveTransient());
            Assert.NotNull(SimpleInjectorBenchmark.Instance.ResolveTransient());
            Assert.NotNull(CastleWindsorBenchmark.Instance.ResolveTransient());
            Assert.NotNull(AutofacBenchmark.Instance.ResolveTransient());
            Assert.NotNull(UnityBenchmarks.Instance.ResolveTransient());
            Assert.NotNull(AspNetCoreBenchmark.Instance.ResolveTransient());
            Assert.NotNull(LightInjectBenchmark.Instance.ResolveTransient());

            Assert.NotSame(DirectBenchmark.Instance.ResolveTransient(), DirectBenchmark.Instance.ResolveTransient());
            Assert.NotSame(Mef2Benchmark.Instance.ResolveTransient(), Mef2Benchmark.Instance.ResolveTransient());
            Assert.NotSame(MefBenchmark.Instance.ResolveTransient(), MefBenchmark.Instance.ResolveTransient());
            Assert.NotSame(NinjectBenchmark.Instance.ResolveTransient(), NinjectBenchmark.Instance.ResolveTransient());
            Assert.NotSame(SimpleInjectorBenchmark.Instance.ResolveTransient(), SimpleInjectorBenchmark.Instance.ResolveTransient());
            Assert.NotSame(CastleWindsorBenchmark.Instance.ResolveTransient(), CastleWindsorBenchmark.Instance.ResolveTransient());
            Assert.NotSame(AutofacBenchmark.Instance.ResolveTransient(), AutofacBenchmark.Instance.ResolveTransient());
            Assert.NotSame(UnityBenchmarks.Instance.ResolveTransient(), UnityBenchmarks.Instance.ResolveTransient());
            Assert.NotSame(AspNetCoreBenchmark.Instance.ResolveTransient(), AspNetCoreBenchmark.Instance.ResolveTransient());
            Assert.NotSame(LightInjectBenchmark.Instance.ResolveTransient(), LightInjectBenchmark.Instance.ResolveTransient());
        }

        [Fact]
        public void TestCombined()
        {
            Assert.NotNull(DirectBenchmark.Instance.ResolveCombined());
            Assert.NotNull(Mef2Benchmark.Instance.ResolveCombined());
            Assert.NotNull(MefBenchmark.Instance.ResolveCombined());
            Assert.NotNull(NinjectBenchmark.Instance.ResolveCombined());
            Assert.NotNull(SimpleInjectorBenchmark.Instance.ResolveCombined());
            Assert.NotNull(CastleWindsorBenchmark.Instance.ResolveCombined());
            Assert.NotNull(AutofacBenchmark.Instance.ResolveCombined());
            Assert.NotNull(UnityBenchmarks.Instance.ResolveCombined());
            Assert.NotNull(AspNetCoreBenchmark.Instance.ResolveCombined());
            Assert.NotNull(LightInjectBenchmark.Instance.ResolveCombined());

            Assert.NotSame(DirectBenchmark.Instance.ResolveCombined(), DirectBenchmark.Instance.ResolveCombined());
            Assert.NotSame(Mef2Benchmark.Instance.ResolveCombined(), Mef2Benchmark.Instance.ResolveCombined());
            Assert.NotSame(MefBenchmark.Instance.ResolveCombined(), MefBenchmark.Instance.ResolveCombined());
            Assert.NotSame(NinjectBenchmark.Instance.ResolveCombined(), NinjectBenchmark.Instance.ResolveCombined());
            Assert.NotSame(SimpleInjectorBenchmark.Instance.ResolveCombined(), SimpleInjectorBenchmark.Instance.ResolveCombined());
            Assert.NotSame(CastleWindsorBenchmark.Instance.ResolveCombined(), CastleWindsorBenchmark.Instance.ResolveCombined());
            Assert.NotSame(AutofacBenchmark.Instance.ResolveCombined(), AutofacBenchmark.Instance.ResolveCombined());
            Assert.NotSame(UnityBenchmarks.Instance.ResolveCombined(), UnityBenchmarks.Instance.ResolveCombined());
            Assert.NotSame(AspNetCoreBenchmark.Instance.ResolveCombined(), AspNetCoreBenchmark.Instance.ResolveCombined());
            Assert.NotSame(LightInjectBenchmark.Instance.ResolveCombined(), LightInjectBenchmark.Instance.ResolveCombined());
        }
    }
}
