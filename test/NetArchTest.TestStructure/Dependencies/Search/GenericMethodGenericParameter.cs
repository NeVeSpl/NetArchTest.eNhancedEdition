using System;
using System.Collections.Generic;
using System.Text;

namespace NetArchTest.TestStructure.Dependencies.Search
{
    internal class GenericMethodGenericParameter
    {
        public static void Deconstruct<T1, T2>(KeyValuePair<T1, T2> tuple, T1[] key, out T2 value)
        {
            key = null;
            value = tuple.Value;
        }
    }
}
