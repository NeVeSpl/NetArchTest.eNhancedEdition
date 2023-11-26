using System;
using System.Collections.Generic;
using System.Text;

namespace NetArchTest.CrossAssemblyTest.A
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class ClassCustomAttributeFromA : Attribute
    {
    }
}
