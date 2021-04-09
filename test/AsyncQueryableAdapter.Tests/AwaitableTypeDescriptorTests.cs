/* License
 * --------------------------------------------------------------------------------------------------------------------
 * (C) Copyright 2021 Cato Léan Trütschel and contributors 
 * (https://github.com/CatoLeanTruetschel/AsyncQueryableAdapterPrototype)
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 * --------------------------------------------------------------------------------------------------------------------
 */

using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AsyncQueryableAdapter.Utils;
using Xunit;

namespace AsyncQueryableAdapter.Tests
{
    public class AwaitableTypeDescriptorTests
    {
        [Fact]
        public void TaskDescriptionTest()
        {
            var taskType = typeof(Task);
            var descriptor = AwaitableTypeDescriptor.GetTypeDescriptor(taskType);

            Assert.True(descriptor.IsAwaitable);
            Assert.Equal(taskType, descriptor.Type);
            Assert.Equal(typeof(void), descriptor.ResultType);
            Assert.Equal(typeof(TaskAwaiter), descriptor.AwaiterType);
        }

        [Fact]
        public void TaskOfTDescriptionTest()
        {
            var taskType = typeof(Task<string>);
            var descriptor = AwaitableTypeDescriptor.GetTypeDescriptor(taskType);

            Assert.True(descriptor.IsAwaitable);
            Assert.Equal(taskType, descriptor.Type);
            Assert.Equal(typeof(string), descriptor.ResultType);
            Assert.Equal(typeof(TaskAwaiter<string>), descriptor.AwaiterType);
        }

        [Fact]
        public void ValueTaskDescriptionTest()
        {
            var taskType = typeof(ValueTask);
            var descriptor = AwaitableTypeDescriptor.GetTypeDescriptor(taskType);

            Assert.True(descriptor.IsAwaitable);
            Assert.Equal(taskType, descriptor.Type);
            Assert.Equal(typeof(void), descriptor.ResultType);
            Assert.Equal(typeof(ValueTaskAwaiter), descriptor.AwaiterType);
        }

        [Fact]
        public void ValueTaskOfTDescriptionTest()
        {
            var taskType = typeof(ValueTask<string>);
            var descriptor = AwaitableTypeDescriptor.GetTypeDescriptor(taskType);

            Assert.True(descriptor.IsAwaitable);
            Assert.Equal(taskType, descriptor.Type);
            Assert.Equal(typeof(string), descriptor.ResultType);
            Assert.Equal(typeof(ValueTaskAwaiter<string>), descriptor.AwaiterType);
        }

        [Fact]
        public void NonAwaitableDescriptionTest()
        {
            var type = typeof(string);
            var descriptor = AwaitableTypeDescriptor.GetTypeDescriptor(type);

            Assert.False(descriptor.IsAwaitable);
            Assert.Equal(type, descriptor.Type);
            Assert.Equal(typeof(string), descriptor.ResultType);
            Assert.Null(descriptor.AwaiterType);
        }

        [Fact]
        public async Task TaskAwaitTest()
        {
            var taskType = typeof(Task);
            var descriptor = AwaitableTypeDescriptor.GetTypeDescriptor(taskType);

            var awaitable = descriptor.GetAwaitable(DelayTask());
            await awaitable;
        }

        [Fact]
        public async Task TaskOfTAwaitTest()
        {
            var taskType = typeof(Task<int>);
            var descriptor = AwaitableTypeDescriptor.GetTypeDescriptor(taskType);

            var awaitable = descriptor.GetAwaitable(DelayTaskOfT());
            var result = await awaitable;

            Assert.Equal(14, result);
        }

        [Fact]
        public async Task ValueTaskAwaitTest()
        {
            var taskType = typeof(ValueTask);
            var descriptor = AwaitableTypeDescriptor.GetTypeDescriptor(taskType);

            var awaitable = descriptor.GetAwaitable(DelayValueTask());
            await awaitable;
        }

        [Fact]
        public async Task ValueTaskOfTAwaitTest()
        {
            var taskType = typeof(ValueTask<int>);
            var descriptor = AwaitableTypeDescriptor.GetTypeDescriptor(taskType);

            var awaitable = descriptor.GetAwaitable(DelayValueTaskOfT());
            var result = await awaitable;

            Assert.Equal(14, result);
        }

        [Fact]
        public async Task AwaitDefaultAsyncTypeAwaitableTest()
        {
            await default(AsyncTypeAwaitable);
        }

        [Fact]
        public async Task AwaitNonAwaitableTypeTest()
        {
            var type = typeof(string);
            var descriptor = AwaitableTypeDescriptor.GetTypeDescriptor(type);
            var str = "jknorvn";

            var result = await descriptor.GetAwaitable(str);

            Assert.Same(str, result);
        }

        private async Task DelayTask()
        {
            await Task.Delay(10);
        }

        private async Task<int> DelayTaskOfT()
        {
            await Task.Delay(19);
            return 14;
        }

        private async ValueTask DelayValueTask()
        {
            await Task.Delay(10);
        }

        private async ValueTask<int> DelayValueTaskOfT()
        {
            await Task.Delay(19);
            return 14;
        }
    }
}
