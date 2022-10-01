using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace WMSTest
{
    public static class StringExtension
    {
        public static string ToString(this IEnumerable<int> source)
        {
            return string.Join(',', source.Select(x => x));
        }

        public static string ToString<T>(this T source)
        {
            var result = "";
            var propInfo = source.GetType().GetProperties();
            foreach (var property in propInfo)
            {
                result += $"{property.Name}: {property.GetValue(source)}\n";
            }
            return result;
        }

        public static string ToString<T>(this IEnumerable<T> source)
        {
            var result = "";
            foreach (var elem in source)
            {
                result += $"{elem.ToString<T>()}\n";
            }

            return result;
        }
    }
}