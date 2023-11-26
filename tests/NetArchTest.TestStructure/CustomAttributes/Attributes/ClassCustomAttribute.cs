namespace NetArchTest.TestStructure.CustomAttributes
{
    using System;

    /// <summary>
    /// Example class level custom attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class ClassCustomAttribute : Attribute
    {


        public class ClassNestedCustomAttribute : Attribute
        {


            public class ClassNestedNestedCustomAttribute : Attribute
            {
            }
        }
    }
}