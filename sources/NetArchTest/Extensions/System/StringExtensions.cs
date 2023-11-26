using System;
using System.Collections.Generic;
using System.Text;

namespace System
{
    internal static class StringExtensions
    {
        public static string RemoveGenericPart(this string name)
        {
            if (string.IsNullOrEmpty(name)) 
                return name;

            int index = name.LastIndexOf('`');
            if (index > 0)
            {
                return name.Substring(0, index);
            }
            return name;
        }


        public static string RuntimeNameToReflectionName(this string cliName)
        {
            // Nested types have a forward slash that should be replaced with "+"
            // C++ template instantiations contain comma separator for template arguments,
            // getting address operators and pointer type designations which should be prefixed by backslash
            var fullName = cliName.Replace("/", "+")
                .Replace(",", "\\,")
                .Replace("&", "\\&")
                .Replace("*", "\\*");
            return fullName;
        }

        public static string ReflectionNameToRuntimeName(this string typeName)
        {
            var fullName = typeName.Replace("+", "/");                
            return fullName;
        }
    }
}
