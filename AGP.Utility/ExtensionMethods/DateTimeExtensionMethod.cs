using System;
using System.Collections.Generic;
using System.Text;

namespace AGP.Utility.ExtensionMethods
{
    public static class DateTimeExtensionMethod
    {
        public static string ToShortTime(this DateTime date)
        {
            return $"{date.Year} / {date.Month} / {date.Day}";
        }
    }
}
