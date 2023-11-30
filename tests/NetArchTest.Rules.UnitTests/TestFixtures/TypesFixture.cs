using System.Reflection;
using NetArchTest.Rules;
using NetArchTest.TestStructure.Types;

namespace NetArchTest.UnitTests.TestFixtures
{
    public class TypesFixture
    {
        public Types Types { get; } = Types.InAssembly(Assembly.GetAssembly(typeof(ExampleClass)));
    }
}