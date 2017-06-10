using DependencyInjectorBenchmarks.Containers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DependencyInjectorBenchmarks.Tests
{
    [TestClass]
    public class ContainerTests
    {
        [TestMethod]
        public void TestSingleton()
        {
            Assert.IsNotNull(DirectBenchmark.Instance.ResolveSingleton());
            Assert.IsNotNull(NinjectBenchmark.Instance.ResolveSingleton());
            Assert.IsNotNull(SimpleInjectorBenchmark.Instance.ResolveSingleton());
            Assert.IsNotNull(AutofacBenchmark.Instance.ResolveSingleton());
            Assert.IsNotNull(AspNetCoreBenchmark.Instance.ResolveSingleton());
            Assert.IsNotNull(LightInjectBenchmark.Instance.ResolveSingleton());
            Assert.IsNotNull(StructureMapBenchmark.Instance.ResolveSingleton());

            Assert.AreSame(DirectBenchmark.Instance.ResolveSingleton(), DirectBenchmark.Instance.ResolveSingleton());
            Assert.AreSame(NinjectBenchmark.Instance.ResolveSingleton(), NinjectBenchmark.Instance.ResolveSingleton());
            Assert.AreSame(SimpleInjectorBenchmark.Instance.ResolveSingleton(), SimpleInjectorBenchmark.Instance.ResolveSingleton());
            Assert.AreSame(AutofacBenchmark.Instance.ResolveSingleton(), AutofacBenchmark.Instance.ResolveSingleton());
            Assert.AreSame(AspNetCoreBenchmark.Instance.ResolveSingleton(), AspNetCoreBenchmark.Instance.ResolveSingleton());
            Assert.AreSame(LightInjectBenchmark.Instance.ResolveSingleton(), LightInjectBenchmark.Instance.ResolveSingleton());
            Assert.AreSame(StructureMapBenchmark.Instance.ResolveSingleton(), StructureMapBenchmark.Instance.ResolveSingleton());
        }

        [TestMethod]
        public void TestTransient()
        {
            Assert.IsNotNull(DirectBenchmark.Instance.ResolveTransient());
            Assert.IsNotNull(NinjectBenchmark.Instance.ResolveTransient());
            Assert.IsNotNull(SimpleInjectorBenchmark.Instance.ResolveTransient());
            Assert.IsNotNull(AutofacBenchmark.Instance.ResolveTransient());
            Assert.IsNotNull(AspNetCoreBenchmark.Instance.ResolveTransient());
            Assert.IsNotNull(LightInjectBenchmark.Instance.ResolveTransient());
            Assert.IsNotNull(StructureMapBenchmark.Instance.ResolveTransient());

            Assert.AreNotSame(DirectBenchmark.Instance.ResolveTransient(), DirectBenchmark.Instance.ResolveTransient());
            Assert.AreNotSame(NinjectBenchmark.Instance.ResolveTransient(), NinjectBenchmark.Instance.ResolveTransient());
            Assert.AreNotSame(SimpleInjectorBenchmark.Instance.ResolveTransient(), SimpleInjectorBenchmark.Instance.ResolveTransient());
            Assert.AreNotSame(AutofacBenchmark.Instance.ResolveTransient(), AutofacBenchmark.Instance.ResolveTransient());
            Assert.AreNotSame(AspNetCoreBenchmark.Instance.ResolveTransient(), AspNetCoreBenchmark.Instance.ResolveTransient());
            Assert.AreNotSame(LightInjectBenchmark.Instance.ResolveTransient(), LightInjectBenchmark.Instance.ResolveTransient());
            Assert.AreNotSame(StructureMapBenchmark.Instance.ResolveTransient(), StructureMapBenchmark.Instance.ResolveTransient());
        }

        [TestMethod]
        public void TestCombined()
        {
            Assert.IsNotNull(DirectBenchmark.Instance.ResolveCombined());
            Assert.IsNotNull(NinjectBenchmark.Instance.ResolveCombined());
            Assert.IsNotNull(SimpleInjectorBenchmark.Instance.ResolveCombined());
            Assert.IsNotNull(AutofacBenchmark.Instance.ResolveCombined());
            Assert.IsNotNull(AspNetCoreBenchmark.Instance.ResolveCombined());
            Assert.IsNotNull(LightInjectBenchmark.Instance.ResolveCombined());
            Assert.IsNotNull(StructureMapBenchmark.Instance.ResolveCombined());

            Assert.AreNotSame(DirectBenchmark.Instance.ResolveCombined(), DirectBenchmark.Instance.ResolveCombined());
            Assert.AreNotSame(NinjectBenchmark.Instance.ResolveCombined(), NinjectBenchmark.Instance.ResolveCombined());
            Assert.AreNotSame(SimpleInjectorBenchmark.Instance.ResolveCombined(), SimpleInjectorBenchmark.Instance.ResolveCombined());
            Assert.AreNotSame(AutofacBenchmark.Instance.ResolveCombined(), AutofacBenchmark.Instance.ResolveCombined());
            Assert.AreNotSame(AspNetCoreBenchmark.Instance.ResolveCombined(), AspNetCoreBenchmark.Instance.ResolveCombined());
            Assert.AreNotSame(LightInjectBenchmark.Instance.ResolveCombined(), LightInjectBenchmark.Instance.ResolveCombined());
            Assert.AreNotSame(StructureMapBenchmark.Instance.ResolveCombined(), StructureMapBenchmark.Instance.ResolveCombined());
        }
    }
}
