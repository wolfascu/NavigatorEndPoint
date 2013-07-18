using System;

namespace NavigatorApplication.Common.Helpers
{
    public static class TypeExtensions
    {
        /// <summary>
        /// Determines whether the <paramref name="type"/> implements <typeparamref name="T"/>.
        /// </summary>
        public static bool Implements<T>(this Type type)
        {
            Ensure.Argument.NotNull(type, "type");
            return typeof(T).IsAssignableFrom(type);
        }
    }
}
