using System.Reflection;
using NetArchTest.Rules;
using NetArchTest.TestStructure.AccessModifiers;

namespace NetArchTest.UnitTests.TestFixtures
{
    public class AccessModifiersFixture
    {
        public Types Types { get; } = Types.InAssembly(Assembly.GetAssembly(typeof(PublicClass)));
    }
}