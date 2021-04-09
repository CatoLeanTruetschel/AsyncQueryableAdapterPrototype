using System.Threading;
using System.Threading.Tasks;

namespace AsyncQueryableAdapterPrototype.Tests.Utils
{
    public interface ISeedHelper
    {
        public ValueTask AddAsync<T>(T obj, CancellationToken cancellation);
    }
}
