namespace System
{
    internal static class TypeExtension
    {
#if !SUPPORTS_TYPE_IS_ASSIGNABLE_TO
        public static bool IsAssignableTo(this Type type, Type assignableType)
        {
            if (type is null)
                throw new ArgumentNullException(nameof(type));

            if(assignableType is null)
            {
                return false;
            }

            return assignableType.IsAssignableFrom(type);
        }
#endif
        public static bool IsAssignableTo<T>(this Type type)
        {
            if (type is null)
                throw new ArgumentNullException(nameof(type));

            return typeof(T).IsAssignableFrom(type);
        }

        public static bool CanContainNull(this Type type)
        {
            if (type is null)
                throw new ArgumentNullException(nameof(type));

            return !type.IsValueType
                || type.IsConstructedGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);
        }
    }
}
