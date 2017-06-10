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
            Assert.NotNull(NinjectBenchmark.Instance.ResolveSingleton());
            Assert.NotNull(SimpleInjectorBenchmark.Instance.ResolveSingleton());
            Assert.NotNull(AutofacBenchmark.Instance.ResolveSingleton());
            Assert.NotNull(AspNetCoreBenchmark.Instance.ResolveSingleton());
            Assert.NotNull(LightInjectBenchmark.Instance.ResolveSingleton());
            Assert.NotNull(StructureMapBenchmark.Instance.ResolveSingleton());

            Assert.Same(DirectBenchmark.Instance.ResolveSingleton(), DirectBenchmark.Instance.ResolveSingleton());
            Assert.Same(NinjectBenchmark.Instance.ResolveSingleton(), NinjectBenchmark.Instance.ResolveSingleton());
            Assert.Same(SimpleInjectorBenchmark.Instance.ResolveSingleton(), SimpleInjectorBenchmark.Instance.ResolveSingleton());
            Assert.Same(AutofacBenchmark.Instance.ResolveSingleton(), AutofacBenchmark.Instance.ResolveSingleton());
            Assert.Same(AspNetCoreBenchmark.Instance.ResolveSingleton(), AspNetCoreBenchmark.Instance.ResolveSingleton());
            Assert.Same(LightInjectBenchmark.Instance.ResolveSingleton(), LightInjectBenchmark.Instance.ResolveSingleton());
            Assert.Same(StructureMapBenchmark.Instance.ResolveSingleton(), StructureMapBenchmark.Instance.ResolveSingleton());
        }

        [Fact]
        public void TestTransient()
        {
            Assert.NotNull(DirectBenchmark.Instance.ResolveTransient());
            Assert.NotNull(NinjectBenchmark.Instance.ResolveTransient());
            Assert.NotNull(SimpleInjectorBenchmark.Instance.ResolveTransient());
            Assert.NotNull(AutofacBenchmark.Instance.ResolveTransient());
            Assert.NotNull(AspNetCoreBenchmark.Instance.ResolveTransient());
            Assert.NotNull(LightInjectBenchmark.Instance.ResolveTransient());
            Assert.NotNull(StructureMapBenchmark.Instance.ResolveTransient());

            Assert.NotSame(DirectBenchmark.Instance.ResolveTransient(), DirectBenchmark.Instance.ResolveTransient());
            Assert.NotSame(NinjectBenchmark.Instance.ResolveTransient(), NinjectBenchmark.Instance.ResolveTransient());
            Assert.NotSame(SimpleInjectorBenchmark.Instance.ResolveTransient(), SimpleInjectorBenchmark.Instance.ResolveTransient());
            Assert.NotSame(AutofacBenchmark.Instance.ResolveTransient(), AutofacBenchmark.Instance.ResolveTransient());
            Assert.NotSame(AspNetCoreBenchmark.Instance.ResolveTransient(), AspNetCoreBenchmark.Instance.ResolveTransient());
            Assert.NotSame(LightInjectBenchmark.Instance.ResolveTransient(), LightInjectBenchmark.Instance.ResolveTransient());
            Assert.NotSame(StructureMapBenchmark.Instance.ResolveTransient(), StructureMapBenchmark.Instance.ResolveTransient());
        }

        [Fact]
        public void TestCombined()
        {
            Assert.NotNull(DirectBenchmark.Instance.ResolveCombined());
            Assert.NotNull(NinjectBenchmark.Instance.ResolveCombined());
            Assert.NotNull(SimpleInjectorBenchmark.Instance.ResolveCombined());
            Assert.NotNull(AutofacBenchmark.Instance.ResolveCombined());
            Assert.NotNull(AspNetCoreBenchmark.Instance.ResolveCombined());
            Assert.NotNull(LightInjectBenchmark.Instance.ResolveCombined());
            Assert.NotNull(StructureMapBenchmark.Instance.ResolveCombined());

            Assert.NotSame(DirectBenchmark.Instance.ResolveCombined(), DirectBenchmark.Instance.ResolveCombined());
            Assert.NotSame(NinjectBenchmark.Instance.ResolveCombined(), NinjectBenchmark.Instance.ResolveCombined());
            Assert.NotSame(SimpleInjectorBenchmark.Instance.ResolveCombined(), SimpleInjectorBenchmark.Instance.ResolveCombined());
            Assert.NotSame(AutofacBenchmark.Instance.ResolveCombined(), AutofacBenchmark.Instance.ResolveCombined());
            Assert.NotSame(AspNetCoreBenchmark.Instance.ResolveCombined(), AspNetCoreBenchmark.Instance.ResolveCombined());
            Assert.NotSame(LightInjectBenchmark.Instance.ResolveCombined(), LightInjectBenchmark.Instance.ResolveCombined());
            Assert.NotSame(StructureMapBenchmark.Instance.ResolveCombined(), StructureMapBenchmark.Instance.ResolveCombined());
        }
    }
}
