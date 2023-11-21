using System.Reflection;
using NetArchTest.Rules;
using NetArchTest.TestStructure.Traits;
using Xunit;


namespace NetArchTest.UnitTests
{
    public class ConditionTests_Traits
    {
        private Predicate GetTypesThat()
        {
            return Types
                .InAssembly(Assembly.GetAssembly(typeof(ExampleStaticClass)))
                .That()
                .ResideInNamespace("NetArchTest.TestStructure.Traits")
                .And();
        }


        [Fact(DisplayName = "BeStatic")]
        public void BeStatic()
        {
            var result = GetTypesThat()
                .HaveNameMatching("Static")
                .Should()
                .BeStatic().GetResult();

            Assert.True(result.IsSuccessful);
        }

        [Fact(DisplayName = "NotBeStatic")]
        public void NotBeStatic()
        {
            var result = GetTypesThat()
                .DoNotHaveNameMatching("Static")
                .Should()
                .NotBeStatic().GetResult();

            Assert.True(result.IsSuccessful);
        }
    }
}
