using NetArchTest.CrossAssemblyTest.A;
using NetArchTest.CrossAssemblyTest.B;
using NetArchTest.TestStructure.CustomAttributes.Attributes;

namespace NetArchTest.TestStructure.CustomAttributes
{
    [ClassCustom]
    [ClassCustomAttribute.ClassNestedCustom]
    [ClassCustomAttribute.ClassNestedCustomAttribute.ClassNestedNestedCustom]
    [GenericCustom<int>]
    [ClassCustomAttributeFromA]   
    public class AttributePresent
    {
    }
}
