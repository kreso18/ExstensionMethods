using System;
using System.Collections.Generic;
using System.Text;

namespace Exstensions
{
    public static class ListExtensions
    {
        /// <summary>
        /// Add data to list if not null.
        /// </summary>
        /// <example>
        /// //Instead of:
        /// var item = GetSomeItem(somePredicate);
        /// if (item != null)
        /// {
        ///     list.Add(item);
        /// }
        /// //Use:
        /// list.AddIfNotNull(GetSomeItem(somePredicate));
        /// </example>
        /// <exception cref="ArgumentNullException">Thrown if <see cref="obj"/> is null</exception>
        public static void AddIfNotNull<T>(this IList<T> source, T value)
        {
            if (source == null)
                throw new ArgumentNullException($"{nameof(source)} is null");

            //If value is null just do nothing (terminate)
            if (value == null)
                return;

            //Else if value is not null add it to given list
            source.Add(value);
        }
    }
}
