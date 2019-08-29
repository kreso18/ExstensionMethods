using System;
using System.Collections.Generic;
using System.Text;

namespace Exstensions
{
    public static class ObjectExstensions
    {
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
