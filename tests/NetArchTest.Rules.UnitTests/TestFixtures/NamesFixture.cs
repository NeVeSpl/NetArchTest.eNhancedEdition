using System.Reflection;
using NetArchTest.Rules;
using NetArchTest.TestStructure.Names.Namespace1;

namespace NetArchTest.UnitTests.TestFixtures
{
    public class NamesFixture
    {
        public Types Types { get; } = Types.InAssembly(Assembly.GetAssembly(typeof(ClassA1)));
    }
}