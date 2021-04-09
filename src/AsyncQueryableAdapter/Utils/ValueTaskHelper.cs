using AsyncQueryableAdapter.Utils;

namespace System.Threading.Tasks
{
    internal static class ValueTaskHelper
    {
        public static AsyncTypeAwaitable AsTypeAwaitable<TSource>(this ValueTask<TSource> task)
        {
            var taskTypeDescritor = AwaitableTypeDescriptor.GetTypeDescriptor(task.GetType());
            return taskTypeDescritor.GetAwaitable(task);
        }
    }
}
