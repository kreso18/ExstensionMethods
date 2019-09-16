using System;
using System.Collections.Generic;
using System.Text;

namespace Exstensions
{
    public static class BooleanExstensions
    {
        /// <summary>
        ///     A bool extension method that execute an Action if the value is true.
        /// </summary>
        public static void IfTrue(this bool value, Action action)
        {
            if (value)
                action();
        }

        /// <summary>
        /// Get "Yes" or "No" (or custom) text based on boolean value.
        /// </summary>
        /// <returns>"Yes" if value is true, otherwise "No", or custom given texts.</returns>
        public static string ToBoolText(this bool value, string yes = "Yes", string no = "No")
        {
            return value ? yes : no;
        }

        /// <summary>
        /// Get "Da" or "Ne" (or custom) text based on boolean value.
        /// </summary>
        /// <returns>"Da" if value is true, otherwise "Ne", or custom given texts.</returns>
        public static string ToBoolTextCro(this bool value, string yes = "Da", string no = "Ne")
        {
            return value ? yes : no;
        }
    }
}
