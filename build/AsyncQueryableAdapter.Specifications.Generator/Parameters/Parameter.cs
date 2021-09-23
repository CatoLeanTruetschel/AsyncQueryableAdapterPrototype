// License
// --------------------------------------------------------------------------------------------------------------------
// (C) Copyright 2021 Cato Léan Trütschel and contributors
// (github.com/CatoLeanTruetschel/AsyncQueryableAdapterPrototype)
//
// Licensed under the Apache License, Version 2.0 (the "License")
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//      www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using AsyncQueryableAdapter.Utils;

namespace AsyncQueryableAdapter.Specifications.Generator.Parameters
{
    internal abstract class Parameter
    {
        public Parameter(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public abstract Task SetupParameterAsync(StreamWriter writer);

        public static Parameter Default(string name)
        {
            return new DefaultParameter(name);
        }

        public static Parameter Default(string name, Func<StreamWriter, string, Task> setup)
        {
            return new DefaultParameter(name, setup);
        }

        public static Parameter Default(string name, string? prefix, Func<StreamWriter, string, Task> setup)
        {
            if (!string.IsNullOrEmpty(prefix))
            {
                name = $"{prefix}{name.FirstRuneToUpperCase()}";
            }

            return Default(name, setup);
        }

        private class DefaultParameter : Parameter
        {
            private readonly Func<StreamWriter, string, Task> _setup;

            public DefaultParameter(string name, Func<StreamWriter, string, Task> setup) : base(name)
            {
                _setup = setup;
            }

            public DefaultParameter(string name) : this(name, (_, _) => Task.CompletedTask) { }

            public override Task SetupParameterAsync(StreamWriter writer)
            {
                return _setup(writer, Name);
            }
        }
    }

    internal class LambdaParameter : Parameter
    {
        private readonly KnownNamespaces _knownNamespaces;
        private readonly Action<StringBuilder> _formatResult;
        private readonly IReadOnlyList<string> _parameters;

        public LambdaParameter(
            KnownNamespaces knownNamespaces,
            string name,
            Type resultType,
            Type delegateType,
            bool isAsync,
            bool hasCancellation,
            bool hasIndex,
            bool isExpression,
            Action<StringBuilder> formatResult,
            IReadOnlyList<string>? parameters = null) : base(name)
        {
            if (knownNamespaces is null)
                throw new ArgumentNullException(nameof(knownNamespaces));

            if (resultType is null)
                throw new ArgumentNullException(nameof(resultType));

            if (delegateType is null)
                throw new ArgumentNullException(nameof(delegateType));

            _knownNamespaces = knownNamespaces;
            ResultType = resultType;
            DelegateType = delegateType;
            IsAsync = isAsync;
            HasCancellation = hasCancellation;
            HasIndex = hasIndex;
            IsExpression = isExpression;
            _formatResult = formatResult;
            _parameters = parameters ?? Array.Empty<string>();
        }

        public Type ResultType { get; }

        public Type DelegateType { get; }

        public bool IsAsync { get; }

        public bool HasCancellation { get; }

        public bool HasIndex { get; }

        public bool IsExpression { get; }

        public override Task SetupParameterAsync(StreamWriter writer)
        {
            var builder = new StringBuilder();

            builder.Append(' ', repeatCount: 12);
            FormatVariableType(builder);
            builder.Append(' ');
            builder.Append(Name);
            builder.Append(' ');
            builder.Append('=');
            builder.Append(' ');
            FormatParameterList(builder);
            builder.Append(' ');
            builder.Append('=');
            builder.Append('>');
            builder.Append(' ');
            FormatResult(builder);
            builder.Append(';');
            builder.AppendLine();

            return writer.WriteAsync(builder.ToString());
        }

        private void FormatResult(StringBuilder builder)
        {
            if (!IsAsync)
            {
                _formatResult(builder);
            }
            else
            {
                builder.Append("new ValueTask<");
                builder.Append(TypeHelper.FormatCSharpTypeName(ResultType, _knownNamespaces.Namespaces));
                builder.Append('>');
                builder.Append('(');
                _formatResult(builder);
                builder.Append(')');
            }
        }

        private void FormatVariableType(StringBuilder builder)
        {
            var variableType = IsExpression ? TypeHelper.GetExpressionType(DelegateType) : DelegateType;

            builder.Append(TypeHelper.FormatCSharpTypeName(variableType, _knownNamespaces.Namespaces));
        }

        private void FormatParameterList(StringBuilder builder)
        {
            builder.Append('(');
            builder.Append('p');

            for (var i = 0; i < _parameters.Count; i++)
            {
                builder.Append(',');
                builder.Append(' ');
                builder.Append(_parameters[i]);
            }

            if (HasIndex)
            {
                builder.Append(',');
                builder.Append(' ');
                builder.Append('i');
            }

            if (HasCancellation)
            {
                builder.Append(',');
                builder.Append(' ');
                builder.Append('c');
            }

            builder.Append(')');
        }
    }
}
