using System;
using System.Collections.Generic;
using System.Text;

namespace Exstensions
{
    public static class DateTimeExstensions
    {
        /// <summary>
        /// Cast nullable DateTime to string or default value. Default value is empty string. Default format is: dd.MM.yyyy.
        /// </summary>
        /// <seealso cref="https://docs.microsoft.com/en-us/dotnet/api/system.datetime.tostring?view=netframework-4.8"/>
        /// <returns>Nullable DateTime as string or dfault string value</returns>
        public static string ToStringOrDefault(this DateTime? value, string @default = "", string format = "dd.MM.yyyy.")
        {
            return value.HasValue ?
                value.Value.ToString(format) :
                @default;
        }
    }
}
