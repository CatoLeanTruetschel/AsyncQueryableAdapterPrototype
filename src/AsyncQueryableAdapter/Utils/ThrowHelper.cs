using System;
using System.Diagnostics.CodeAnalysis;

namespace AsyncQueryableAdapter.Utils
{
    internal static class ThrowHelper
    {
        [DoesNotReturn]
        public static void ThrowQueryNotSupportedException()
        {
            // TODO: Exception message: Describe the method that is not supported.
            throw new NotSupportedException("The current query is not supported by the query provider.");
        }
    }
}
