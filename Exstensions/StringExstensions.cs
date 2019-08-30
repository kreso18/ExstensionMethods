using System;
using System.Collections.Generic;
using System.Text;

namespace Exstensions
{
    public static class StringExstensions
    {

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
