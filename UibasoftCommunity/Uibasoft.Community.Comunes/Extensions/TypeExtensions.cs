using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uibasoft.Community.Comunes.Extensions
{
    public static class TypeExtensions
    {
        public static bool IsDerivedFromGenericType(this Type typeToCheck, Type genericType)
        {
            if (typeToCheck == typeof(object)) return false;

            if (typeToCheck.IsGenericType && typeToCheck.GetGenericTypeDefinition() == genericType) return true;
            return IsDerivedFromGenericType(typeToCheck.BaseType, genericType);
        }
        public static bool IsDerivedFromType(this Type typeToCheck, Type parentType)
        {
            if (typeToCheck == typeof(object)) return false;
            return typeToCheck == parentType || IsDerivedFromType(typeToCheck.BaseType, parentType);
        }

    }
}
