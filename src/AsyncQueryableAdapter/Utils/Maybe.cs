using System;

namespace AsyncQueryableAdapter.Utils
{
    internal readonly struct Maybe<T>
    {
        private readonly T _value;

        public Maybe(T value)
        {
            _value = value;
            HasValue = true;
        }

        public static Maybe<T> None { get; }

        public bool HasValue { get; }

        public T Value => HasValue ? _value : throw new InvalidOperationException();

        public bool TryGetValue(out T value)
        {
            value = _value;
            return HasValue;
        }
    }
}
