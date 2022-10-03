using System;
using System.Collections.Generic;
using System.Text;

namespace System.Collections.Generic
{
    internal static class IEnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> list, Action<T> action)
        {
            foreach (T item in list)
            {
                action(item);
            }
        }
    }
}