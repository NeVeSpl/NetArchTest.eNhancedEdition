using System;
using System.Collections.Generic;
using System.Text;

namespace NetArchTest.TestStructure.Stateless
{
    internal class StatelessClass_StaticField
    {
        public static int field;
    }
    internal class StatelessClass_ConstField
    {
        public const int field = 7;
    }
    internal class StatelessClass_StaticReadonlyField
    {
        public static readonly int field = 7;
    }

    internal class StatelessClass_Prop
    {
        public static int Prop { get; set; }
    }
}
