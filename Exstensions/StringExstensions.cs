using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Exstensions
{
    public static class StringExstensions
    {

        /// <summary>
        /// Check if given string is numeric
        /// </summary>
        /// <returns>True if string is numeric (only digits).</returns>


        public static bool IsNumeric(this string @this)
        {
            return !Regex.IsMatch(@this, "[^0-9]");
        }

        public static int TryParseToIntOrDefault(this string input, int defaultValue = 0)
        {
            if (int.TryParse(input, out var value))
            {
                return value;
            }

            return defaultValue;
        }

        //public static double TryParseToDoubleOrDefault<T>(this string input, double defaultValue = default(double))
        //{
        //    if (double.TryParse(input, out var value))
        //    {
        //        return value;
        //    }

        //    return defaultValue;
        //}

        /// <summary>
        /// Get the string between the two specified string.
        /// </example>
        /// <returns>The string between the two specified string.</returns>
        public static string GetBetween(this string src, string left, string right)
        {
            if (src.IsNullOrEmpty())
                return string.Empty;

            int leftIndex = src.IndexOf(left);
            int startIndex = leftIndex + left.Length;
            int rightIndex = src.IndexOf(right, startIndex);

            if (leftIndex == -1 || rightIndex == -1)
                return string.Empty;

            return src.Substring(startIndex, rightIndex - startIndex);
        }

    }
}
