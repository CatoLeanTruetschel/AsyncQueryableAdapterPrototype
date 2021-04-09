using System.Threading.Tasks;
using System.Linq;
using System.Runtime.CompilerServices;

namespace System.Collections.Generic
{
    internal static class AsyncEnumerableExtension
    {
        public static async ValueTask<IEnumerable<T>> EvaluateAsync<T>(this IAsyncEnumerable<T> asyncEnumerable)
        {
            if (asyncEnumerable is null)
                throw new ArgumentNullException(nameof(asyncEnumerable));

            return await asyncEnumerable.ToArrayAsync();
        }

        public static ValueTaskAwaiter<IEnumerable<T>> GetAwaiter<T>(this IAsyncEnumerable<T> asyncEnumerable)
        {
            if (asyncEnumerable is null)
                throw new ArgumentNullException(nameof(asyncEnumerable));

            return asyncEnumerable.EvaluateAsync().GetAwaiter();
        }
    }
}
