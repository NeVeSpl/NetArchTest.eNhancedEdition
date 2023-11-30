using NetArchTest.Rules;
using NetArchTest.UnitTests.TestFixtures;
using Xunit;

namespace NetArchTest.UnitTests
{
    public class ConditionTests_AccessModifiers(AccessModifiersFixture fixture) : IClassFixture<AccessModifiersFixture>
    {
        private Predicate GetTypesThat()
        {
            return fixture.Types
                .That()
                .ResideInNamespace("NetArchTest.TestStructure.AccessModifiers")
                .And();
        }


        [Fact(DisplayName = "BeInternal")]
        public void BeInternal()
        {

            var result = GetTypesThat()
                .HaveNameStartingWith("Internal")
                .Should()
                .BeInternal().GetResult();

            Assert.True(result.IsSuccessful);
        }

        [Fact(DisplayName = "NotBeInternal")]
        public void NotBeInternal()
        {
            var result = GetTypesThat()
               .DoNotHaveNameStartingWith("Internal")
               .Should()
               .NotBeInternal().GetResult();

            Assert.True(result.IsSuccessful);
        }

        [Fact(DisplayName = "BeNested")]
        public void BeNested()
        {
            
            var result = GetTypesThat()
                .HaveNameEndingWith("Nested")
                .Should()
                .BeNested().GetResult();

            Assert.True(result.IsSuccessful);
        }

        [Fact(DisplayName = "NotBeNested")]
        public void NotBeNested()
        {
            var result = GetTypesThat()
               .DoNotHaveNameEndingWith("Nested")
               .Should()
               .NotBeNested().GetResult();

            Assert.True(result.IsSuccessful);
        }

        [Fact(DisplayName = "BePrivate")]
        public void BePrivate()
        {

            var result = GetTypesThat()
                .HaveNameStartingWith("PrivateClass")
                .Should()
                .BePrivate().GetResult();

            Assert.True(result.IsSuccessful);
        }

        [Fact(DisplayName = "NotBePrivate")]
        public void NotBePrivate()
        {
            var result = GetTypesThat()
               .DoNotHaveNameStartingWith("PrivateClass")
               .Should()
               .NotBePrivate().GetResult();

            Assert.True(result.IsSuccessful);
        }

        [Fact(DisplayName = "BePrivateProtected")]
        public void BePrivateProtected()
        {

            var result = GetTypesThat()
                .HaveNameStartingWith("PrivateProtectedClass")
                .Should()
                .BePrivateProtected().GetResult();

            Assert.True(result.IsSuccessful);
        }

        [Fact(DisplayName = "NotBePrivateProtected")]
        public void NotBePrivateProtected()
        {
            var result = GetTypesThat()
               .DoNotHaveNameStartingWith("PrivateProtectedClass")
               .Should()
               .NotBePrivateProtected().GetResult();

            Assert.True(result.IsSuccessful);
        }

        [Fact(DisplayName = "BeProtected")]
        public void BeProtected()
        {

            var result = GetTypesThat()
                .HaveNameStartingWith("ProtectedClass")
                .Should()
                .BeProtected().GetResult();

            Assert.True(result.IsSuccessful);
        }

        [Fact(DisplayName = "NotBeProtected")]
        public void NotBeProtected()
        {
            var result = GetTypesThat()
               .DoNotHaveNameStartingWith("ProtectedClass")
               .Should()
               .NotBeProtected().GetResult();

            Assert.True(result.IsSuccessful);
        }

        [Fact(DisplayName = "BeProtectedInternal")]
        public void BeProtectedInternal()
        {

            var result = GetTypesThat()
                .HaveNameStartingWith("ProtectedInternalClass")
                .Should()
                .BeProtectedInternal().GetResult();

            Assert.True(result.IsSuccessful);
        }

        [Fact(DisplayName = "NotBeProtectedInternal")]
        public void NotBeProtectedInternal()
        {
            var result = GetTypesThat()
               .DoNotHaveNameStartingWith("ProtectedInternalClass")
               .Should()
               .NotBeProtectedInternal().GetResult();

            Assert.True(result.IsSuccessful);
        }


        [Fact(DisplayName = "BePublic")]
        public void BePublic()
        {

            var result = GetTypesThat()
                .HaveNameStartingWith("Public")
                .Should()
                .BePublic().GetResult();

            Assert.True(result.IsSuccessful);
        }

        [Fact(DisplayName = "NotBePublic")]
        public void NotBePublic()
        {
            var result = GetTypesThat()
               .DoNotHaveNameStartingWith("Public")
               .Should()
               .NotBePublic().GetResult();

            Assert.True(result.IsSuccessful);
        }
    }
}