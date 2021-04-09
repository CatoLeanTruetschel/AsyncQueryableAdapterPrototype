using System;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Reflection;

namespace AsyncQueryableAdapter.Translators
{
    internal sealed class AnyMethodTranslator : MethodTranslator
    {
        public override bool TryTranslate(
            MethodInfo method,
            Expression? instance,
            ReadOnlyCollection<Expression> arguments,
            ReadOnlySpan<int> translatedQueryableArgumentIndices,
            [NotNullWhen(true)] out Expression? result)
        {
            // TODO: Implement me pls

            result = null;
            return false;
        }
    }
}
