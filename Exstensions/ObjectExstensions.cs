using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Exstensions
{
    public static class ObjectExstensions
    {
        /// <summary>
        /// Check if value is null.
        /// Replacement for (value == null)
        /// </summary>
        /// <returns>true if null, false if not.</returns>
        public static bool IsNull<T>(this T value) where T : class => value == null;

        /// <summary>
        /// Check if value is NOT null.
        /// </summary>
        /// <returns>true if not null, false if is null.</returns>
        public static bool IsNotNull<T>(this T @value) where T : class => value != null;

        /// <summary>
        /// Check if the object is equal to any of the given values.
        /// Good replacement for if(myVar == "string1" || myVar == "straing2") => if(myVar.IsIn("string1", "string2"))
        /// </summary>
        /// <returns>true if the values list contains the object, otherwise false.</returns>
        public static bool IsIn<T>(this T src, params T[] values)
        {
            if (null == src) throw new ArgumentNullException("source");
            return values.Contains(src);
        }


        /// <summary>
        /// Check if value is greater or equal than low value and smaller or equal than high value. [low, high]
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="low"></param>
        /// <param name="high"></param>
        /// <returns>true if the value is between or equal the low and high (Inclusive), otherwise false.</returns>
        public static bool IsBetweenInclusive<T>(this T value, T low, T high) where T : IComparable<T> =>
            value.CompareTo(low) >= 0 && value.CompareTo(high) <= 0;

        /// <summary>
        /// Check if value is greater than low value and smaller than high value. (low, high)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value to check</param>
        /// <param name="low">The low value</param>
        /// <param name="high">The high value</param>
        /// <returns>true if the value is between the low and high (Exclusive), otherwise false.</returns>
        public static bool IsBetweenExclusive<T>(this T value, T low, T high) where T : IComparable<T> =>
            value.CompareTo(low) > 0 && value.CompareTo(high) < 0;


    }
}
