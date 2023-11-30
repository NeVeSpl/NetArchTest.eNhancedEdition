using System.Reflection;
using NetArchTest.Rules;
using NetArchTest.TestStructure.NameMatching.Namespace1;

namespace NetArchTest.UnitTests.TestFixtures
{
    public class SpecialFixture
    {
        public Types Types { get; } = Types.InAssembly(Assembly.GetAssembly(typeof(ClassA1)));
    }
}
