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
using System.Reflection;
using System.Threading;
using AsyncQueryableAdapter.Specifications.Generator.Parameters;
using AsyncQueryableAdapterPrototype.Utils;

namespace AsyncQueryableAdapter.Specifications.Generator
{
    internal sealed class OptionsResolver
    {
        public ResolvedOptions ResolveOptions(MethodInfo method, ParameterList arguments)
        {
            var operationName = OperationNameHelper.GetOperationName(method);
            var parameters = method.GetParameters().AsSpan();

            if (parameters[^1].ParameterType == typeof(CancellationToken))
            {
                parameters = parameters[..^1];
            }

            var options = ResolvedOptions.DisallowAll;

            if (string.Equals(operationName, "Aggregate", StringComparison.Ordinal))
            {
                options = ResolvedOptions.AllowInMemoryEvaluation;
            }
            else if (string.Equals(operationName, "Average", StringComparison.Ordinal))
            {
                options = ResolvedOptions.AllowInMemoryEvaluation;
            }
            else if (string.Equals(operationName, "Contains", StringComparison.Ordinal))
            {
                if (parameters.Length == 3) // TODO: && parameters[2] is not NullParameter
                {
                    options = ResolvedOptions.AllowInMemoryEvaluation;
                }
            }
            else if (string.Equals(operationName, "Count", StringComparison.Ordinal))
            {
                options = ResolvedOptions.AllowInMemoryEvaluation;
            }
            else if (string.Equals(operationName, "LongCount", StringComparison.Ordinal))
            {
                options = ResolvedOptions.AllowInMemoryEvaluation;
            }
            else if (string.Equals(operationName, "Sum", StringComparison.Ordinal))
            {
                options = ResolvedOptions.AllowInMemoryEvaluation;
            }

            return options;
        }
    }

    public readonly struct ResolvedOptions
    {
        private readonly string? _value;

        private ResolvedOptions(string value)
        {
            _value = value;
        }

        public static ResolvedOptions DisallowAll => new(nameof(DisallowAll));
        public static ResolvedOptions AllowImplicitPostProcessing => new(nameof(AllowImplicitPostProcessing));
        public static ResolvedOptions AllowInMemoryEvaluation => new(nameof(AllowInMemoryEvaluation));
        public static ResolvedOptions AllowAll => new(nameof(AllowAll));

        public static ResolvedOptions Create(
            bool allowImplicitPostProcessing = false,
            bool allowImplicitDefaultPostProcessing = false,
            bool allowInMemoryEvaluation = false)
        {
            return new($"Options.Create(new AsyncQueryableOptions {{AllowImplicitPostProcessing = {(allowImplicitPostProcessing ? "true" : "false")}, AllowImplicitDefaultPostProcessing = {(allowImplicitDefaultPostProcessing ? "true" : "false")}, AllowInMemoryEvaluation = {(allowInMemoryEvaluation ? "true" : "false")}}})");
        }

        public override string ToString()
        {
            if (_value is null)
            {
                return "DisallowAll";
            }

            return _value;
        }
    }
}
