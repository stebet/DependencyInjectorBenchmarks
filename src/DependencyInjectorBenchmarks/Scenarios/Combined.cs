using System;

namespace DependencyInjectorBenchmarks.Scenarios
{
    public interface ICombined
    {

    }

    public class Combined : ICombined
    {
        private readonly ISingleton _singleton;
        private readonly ITransient _transient;

        public Combined(ISingleton stateless, ITransient stateful)
        {
            if (stateless == null)
            {
                throw new ArgumentNullException(nameof(stateless));
            }

            if (stateful == null)
            {
                throw new ArgumentNullException(nameof(stateful));
            }

            _singleton = stateless;
            _transient = stateful;
        }
    }


}
