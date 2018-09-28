using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace AGP.Utility.ExtensionMethods
{
    public static class DateTimeExtensionMethod
    {
        public static string ToShortTime(this DateTime date)
        {
            PersianCalendar p = new PersianCalendar();
            return $"{p.GetDayOfMonth(date)} / {p.GetMonth(date)} / {p.GetYear(date)}";
        }
    }
}
