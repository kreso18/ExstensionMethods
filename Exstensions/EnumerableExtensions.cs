using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exstensions
{
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Check if collection is null or empty. Replacement for if(dateset == null || !dataset.Any())
        /// </summary>
        /// <param name="src">The collection</param>
        /// <returns>Return true if collection is null or empty, otherwise return false</returns>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> src)
        {
            return src == null || !src.Any();
        }

        /// <summary>
        /// Check if collection is NOT null and NOT empty. Replacement for if(dateset != null && dataset.Any())
        /// </summary>
        /// <param name="src">The collection to act on.</param>
        /// <returns>Return true if collection is not null and not empty, otherwise return false.</returns>
        public static bool IsNotNullOrEmpty<T>(this IEnumerable<T> src)
        {
            return src != null && src.Any();
        }

        /// <summary>Enumerates (for each) over IEnumerable.</summary>
        /// <returns>A foreach enumerator over IEnumerable collection.</returns>
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (T obj in source)
                action(obj);
        }
    }
}
