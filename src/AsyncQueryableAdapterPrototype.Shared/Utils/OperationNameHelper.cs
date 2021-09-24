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

namespace AsyncQueryableAdapterPrototype.Utils
{
    public static class OperationNameHelper
    {
        private const string _awaitPostfix = "Await";
        private const string _asyncPostfix = "Async";
        private const string _awaitAsyncPostfix = _awaitPostfix + _asyncPostfix;
        private const string _awaitWithCancellationPostfix = _awaitPostfix + "WithCancellation";
        private const string _awaitWithCancellationAsyncPostfix = _awaitWithCancellationPostfix + _asyncPostfix;

        public static string GetOperationName(MethodInfo method)
        {
            if (method is null)
                throw new ArgumentNullException(nameof(method));

            var operationName = method.Name;

            if (operationName.EndsWith(_awaitWithCancellationAsyncPostfix, StringComparison.Ordinal))
            {
                operationName = operationName[..^_awaitWithCancellationAsyncPostfix.Length];
            }
            else if (operationName.EndsWith(_awaitAsyncPostfix, StringComparison.Ordinal))
            {
                operationName = operationName[..^_awaitAsyncPostfix.Length];
            }
            else if (operationName.EndsWith(_awaitWithCancellationPostfix, StringComparison.Ordinal))
            {
                operationName = operationName[..^_awaitWithCancellationPostfix.Length];
            }
            else if (operationName.EndsWith(_awaitPostfix, StringComparison.Ordinal))
            {
                operationName = operationName[..^_awaitPostfix.Length];
            }
            else if (operationName.EndsWith(_asyncPostfix, StringComparison.Ordinal))
            {
                operationName = operationName[..^_asyncPostfix.Length];
            }

            return operationName;
        }
    }
}
