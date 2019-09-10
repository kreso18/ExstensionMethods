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

    }
}
