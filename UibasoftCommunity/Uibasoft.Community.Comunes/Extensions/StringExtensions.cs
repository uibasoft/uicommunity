using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uibasoft.Community.Comunes.Extensions
{
    public static class StringExtensions
    {
        public static string ToStringEmpty(this string obj)
        {
            return obj ?? string.Empty;
        }
        private static readonly CultureInfo DefaultCultureInfo = new CultureInfo("en-US");
        public static string ToCamelCase(this string str)
        {
            return str.ToCamelCase(DefaultCultureInfo);
        }
        public static string ToCamelCase(this string str, CultureInfo culture)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return str;
            }

            if (str.Length == 1)
            {
                return str.ToLower(culture);
            }
            return char.ToLower(str[0], culture) + str.Substring(1);
        }
        public static string ToPascalCase(this string str)
        {
            return str.ToPascalCase(DefaultCultureInfo);
        }
        public static string ToPascalCase(this string str, CultureInfo culture)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return str;
            }

            if (str.Length == 1)
            {
                return str.ToUpper(culture);
            }

            return char.ToUpper(str[0], culture) + str.Substring(1);
        }
    }
}
