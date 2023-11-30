using NetArchTest.Rules;


namespace NetArchTest.UnitTests.TestFixtures
{
    public class TypesInCurrentDomainFixture
    {
        public Types Types { get; } = Types.InCurrentDomain();
    }
}
