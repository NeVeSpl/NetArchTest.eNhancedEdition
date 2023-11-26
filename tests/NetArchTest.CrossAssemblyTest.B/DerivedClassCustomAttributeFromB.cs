using System;
using System.Collections.Generic;
using System.Text;
using NetArchTest.CrossAssemblyTest.A;

namespace NetArchTest.CrossAssemblyTest.B
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class DerivedClassCustomAttributeFromB : ClassCustomAttributeFromA
    {
    }
}
