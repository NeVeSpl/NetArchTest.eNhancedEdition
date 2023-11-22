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
                .InAssembly(Assembly.GetAssembly(typeof(StaticClass)))
                .That()
                .ResideInNamespace("NetArchTest.TestStructure.Traits")
                .And();
        }


        [Fact(DisplayName = "BeStatic")]
        public void BeStatic()
        {
            var result = GetTypesThat()
                .HaveNameStartingWith("Static")
                .Should()
                .BeStatic().GetResult();

            Assert.True(result.IsSuccessful);
        }

        [Fact(DisplayName = "NotBeStatic")]
        public void NotBeStatic()
        {
            var result = GetTypesThat()
                .DoNotHaveNameStartingWith("Static")
                .Should()
                .NotBeStatic().GetResult();

            Assert.True(result.IsSuccessful);
        }

        [Fact(DisplayName = "BeAbstract")]
        public void BeAbstract()
        {
            var result = GetTypesThat()
                .HaveNameStartingWith("Abstract")
                .Should()
                .BeAbstract().GetResult();

            Assert.True(result.IsSuccessful);
        }

        [Fact(DisplayName = "NotBeAbstract")]
        public void NotBeAbstract()
        {
            var result = GetTypesThat()
                .DoNotHaveNameStartingWith("Abstract")
                .Should()
                .NotBeAbstract().GetResult();

            Assert.True(result.IsSuccessful);
        }



        [Fact(DisplayName = "BeGeneric")]
        public void BeGeneric()
        {
            var result = GetTypesThat()
                .HaveNameStartingWith("Generic")
                .Should()
                .BeGeneric().GetResult();

            Assert.True(result.IsSuccessful);
        }

        [Fact(DisplayName = "NotBeGeneric")]
        public void NotBeGeneric()
        {
            var result = GetTypesThat()
                .DoNotHaveNameStartingWith("Generic")
                .Should()
                .NotBeGeneric().GetResult();

            Assert.True(result.IsSuccessful);
        }


        [Fact(DisplayName = "BeSealed")]
        public void BeSealed()
        {
            var result = GetTypesThat()
                .HaveNameStartingWith("Sealed")
                .Should()
                .BeSealed().GetResult();

            Assert.True(result.IsSuccessful);
        }

        [Fact(DisplayName = "NotBeSealed")]
        public void NotBeSealed()
        {
            var result = GetTypesThat()
                .DoNotHaveNameStartingWith("Sealed")
                .Should()
                .NotBeSealed().GetResult();

            Assert.True(result.IsSuccessful);
        }
    }
}
