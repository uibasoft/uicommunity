using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uibasoft.Community.Comunes.Extensions
{
    public static class ObjectExtensions
    {
        public static string ToStringEmpty(this object obj)
        {
            return obj?.ToString() ?? string.Empty;
        }

        public static T As<T>(this object obj)
        {
            return (T)obj;
        }
    }
}
