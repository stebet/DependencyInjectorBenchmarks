using Ninject;

namespace DependencyInjectorBenchmarks.Containers
{
    public class NinjectBenchmark : IContainerBenchmark
    {
        public static readonly NinjectBenchmark Instance = new NinjectBenchmark();

        private readonly IKernel kernel = new StandardKernel();

        public NinjectBenchmark()
        {
            kernel.Bind<IStatelessStorage>().To<StatelessStorage>().InSingletonScope();
            kernel.Bind<IStatefulStorage>().To<StatefulStorage>().InTransientScope();
        }

        public IStatelessStorage ResolveSingleton() => kernel.Get<IStatelessStorage>();

        public IStatefulStorage ResolveTransient() => kernel.Get<IStatefulStorage>();
    }
}
