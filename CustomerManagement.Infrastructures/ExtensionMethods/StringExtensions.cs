using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace CustomerManagement.Infrastructures
{
    public static class StringExtensions
    {
        public static string SplitGetStringByIndex(this String str, int index)
        {
            var valueArr = str.Split(':');
            return valueArr[index];
        }

        public static DateTime SplitGetDateTimeByIndex(this String str, int index)
        {
            var valueArr = str.Split(':');
            return DateTime.ParseExact(valueArr[index],
                                  "yyyy-MM-dd",
                                   CultureInfo.InvariantCulture);
        }

        public static DateTime StringToDateTime(this String str)
        {
            return DateTime.ParseExact(str,
                                  "yyyy-MM-dd",
                                   CultureInfo.InvariantCulture);
        }
        public static string FormatShortDate(this DateTime dt)
        {
            return dt.ToString("yyyy-MM-dd", new CultureInfo("en-US"));
        }
    }
}
