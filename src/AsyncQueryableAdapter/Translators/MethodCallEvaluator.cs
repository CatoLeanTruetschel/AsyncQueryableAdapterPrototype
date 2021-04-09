using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace AsyncQueryableAdapter.Translators
{
    internal delegate bool MethodCallEvaluator(
        ReadOnlyCollection<Expression> arguments,
        [NotNullWhen(true)] out ConstantExpression? result);

    internal delegate bool MethodCallEvaluator<T>(
        ReadOnlyCollection<Expression> arguments,
        T arg,
        [NotNullWhen(true)] out ConstantExpression? result);
}
