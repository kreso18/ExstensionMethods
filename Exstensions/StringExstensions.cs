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
        /// Get the string between the two specified string (delimiters).
        /// </example>
        /// <returns>The string between the two specified string or empty string if not found.</returns>
        public static string ExtractBetween(this string src, string left, string right)
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

        /// <summary>
        /// Get the string between the two specified string (delimiters) at given position.
        /// </summary>
        /// <returns>The string between the two specified string (delimiters) at given position or empty string if not found.</returns>
        public static string ExtractBetweenAtPosition(this string value, string left, string right, int position = 1)
        {
            if (string.IsNullOrEmpty(value))
                return String.Empty;

            int start = -1;

            // Find start at given position
            for (int i = 1; i <= position; i++)
                start = value.IndexOf(left, start + 1);

            if (start < 0)
                return string.Empty;
            start += left.Length;

            // Find End
            int end = value.IndexOf(right, start);
            if (end < 0)
                return string.Empty;

            var length = end - start;
            return value.Substring(start, length);
        }

        /// <summary>
        /// Check if a string is match with given regular expression pattern.
        /// </summary>
        /// <returns>True if string match with given regex, otherwise False</returns>
        public static bool IsMatchRegex(this string value, string pattern)
        {
            Regex regex = new Regex(pattern);
            return (regex.IsMatch(value));
        }
    }
}
