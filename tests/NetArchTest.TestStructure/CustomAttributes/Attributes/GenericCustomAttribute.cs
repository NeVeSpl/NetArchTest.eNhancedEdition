using System;
using System.Collections.Generic;
using System.Text;

namespace NetArchTest.TestStructure.CustomAttributes.Attributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]   
    public class GenericCustomAttribute<T> : Attribute
    {
    }
}