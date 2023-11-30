using System.Reflection;
using NetArchTest.Rules;
using NetArchTest.TestStructure.Dependencies.Implementation;

namespace NetArchTest.UnitTests.TestFixtures
{
    public class DependenciesFixture
    {
        public Types Types { get; } = Types.InAssembly(Assembly.GetAssembly(typeof(HasDependency)));
    }
}