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

            int index = name.IndexOf('`');
            if (index > 0)
            {
                return name.Substring(0, index);
            }
            return name;
        }
    }
}
