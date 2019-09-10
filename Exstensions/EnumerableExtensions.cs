using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exstensions
{
    public static class EnumerableExtensions
    {
        /*
       public int CompareTo (object obj);
       Less than zero	    This instance precedes obj in the sort order.
       Zero	                This instance occurs in the same position in the sort order as obj.
       Greater than zero	This instance follows obj in the sort order.
       */

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

        /// <summary>
        /// Get first item of sequence with minimum value by criterion
        /// Can be used as replacement for sequence.OrderBy(...).First();
        /// </summary>
        /// <returns>First item of sequence with minimum value by given criterion</returns>
        public static T WithMinimum<T, TKey>(this IEnumerable<T> sequence, Func<T, TKey> criterion)
            where T : class
            where TKey : IComparable<TKey>
        {
            //return sequence
            //    .Aggregate((T)null, (best, cur) =>
            //        best == null || criterion(cur).CompareTo(criterion(best)) < 0 ? cur : best);

            return sequence
                .Select(obj => Tuple.Create(obj, criterion(obj)))
                .Aggregate((Tuple<T, TKey>)null,
                    (best, current) => best == null || current.Item2.CompareTo(best.Item2) < 0 ? current : best)
                .Item1;
        }

        /// <summary>
        /// Get first item of sequence with minimum value by criterion
        /// Can be used as replacement for sequence.OrderByDescending(...).First();
        /// </summary>
        /// <returns>First item of sequence with minimum value by given criterion</returns>
        public static T WithMaximum<T, TKey>(this IEnumerable<T> sequence, Func<T, TKey> criterion)
            where T : class
            where TKey : IComparable<TKey>
        {
            //return sequence
            //    .Aggregate((T)null, (best, cur) =>
            //        best == null || criterion(cur).CompareTo(criterion(best)) > 0 ? cur : best);

            return sequence
                .Select(obj => Tuple.Create(obj, criterion(obj)))
                .Aggregate((Tuple<T, TKey>)null,
                    (best, current) => best == null || current.Item2.CompareTo(best.Item2) > 0 ? current : best)
                .Item1;
        }

        /// <summary>
        /// Check if collection contains all given values
        /// </summary>
        /// <returns>True if collection contains all given values, false if not.</returns>
        public static bool ContainsAll<T>(this IEnumerable<T> source, params T[] values)
        {
            return values.All(source.Contains);
        }


        /// <summary>
        /// Check if collection contains any of given values
        /// </summary>
        /// <returns>True if collection contains any of given values, false if not.</returns>
        public static bool ContainsAny<T>(this IEnumerable<T> source, params T[] values)
        {
            return values.Any(source.Contains);
        }
    }
}
