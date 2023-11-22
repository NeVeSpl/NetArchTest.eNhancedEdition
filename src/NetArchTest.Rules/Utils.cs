using System;
using System.Collections.Generic;
using System.Text;

namespace NetArchTest
{
    internal class Utils
    {
        public static string fullnameof<T>() => typeof(T).FullName;
        public static string namespaceof<T>() => typeof(T).Namespace;
    }
}
