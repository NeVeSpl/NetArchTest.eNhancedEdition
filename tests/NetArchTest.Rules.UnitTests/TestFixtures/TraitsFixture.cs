using System.Reflection;
using NetArchTest.Rules;
using NetArchTest.TestStructure.Traits;

namespace NetArchTest.UnitTests.TestFixtures
{
    public class TraitsFixture
    {
        public Types Types { get; } = Types.InAssembly(Assembly.GetAssembly(typeof(StaticClass)));
    }
}