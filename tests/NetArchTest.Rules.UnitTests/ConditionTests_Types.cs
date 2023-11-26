using NetArchTest.Rules;
using Xunit;

namespace NetArchTest.UnitTests
{
    public class ConditionTests_Types : IClassFixture<TypesFixture>
    {
        TypesFixture fixture;

        public ConditionTests_Types(TypesFixture fixture)
        {
            this.fixture = fixture;
        }


        private Predicate GetTypesThat()
        {
            return fixture.Types
                .That()
                .ResideInNamespace("NetArchTest.TestStructure.Types")
                .And();
        }


        [Fact(DisplayName = "BeClasses")]
        public void BeClasses()
        {
            var result = GetTypesThat()
                .HaveNameEndingWith("Class")
                .Should()
                .BeClasses().GetResult();

            Assert.True(result.IsSuccessful);
        }

        [Fact(DisplayName = "NotBeClasses")]
        public void NotBeClasses()
        {
            var result = GetTypesThat()
                .DoNotHaveNameEndingWith("Class")
                .Should()
                .NotBeClasses().GetResult();

            Assert.True(result.IsSuccessful);
        }

        [Fact(DisplayName = "BeDelegates")]
        public void BeDelegates()
        {
            var result = GetTypesThat()
                .HaveNameEndingWith("Delegate")
                .Should()
                .BeDelegates().GetResult();

            Assert.True(result.IsSuccessful);
        }

        [Fact(DisplayName = "NotBeDelegates")]
        public void NotBeDelegates()
        {
            var result = GetTypesThat()
                .DoNotHaveNameEndingWith("Delegate")
                .Should()
                .NotBeDelegates().GetResult();

            Assert.True(result.IsSuccessful);
        }

        [Fact(DisplayName = "BeEnums")]
        public void BeEnums()
        {
            var result = GetTypesThat()
                .HaveNameEndingWith("Enum")
                .Should()
                .BeEnums().GetResult();

            Assert.True(result.IsSuccessful);
        }

        [Fact(DisplayName = "NotBeEnums")]
        public void NotBeEnums()
        {
            var result = GetTypesThat()
                .DoNotHaveNameEndingWith("Enum")
                .Should()
                .NotBeEnums().GetResult();

            Assert.True(result.IsSuccessful);
        }

        [Fact(DisplayName = "BeInterfaces")]
        public void BeInterfaces()
        {
            var result = GetTypesThat()
                .HaveNameEndingWith("Interface")
                .Should()
                .BeInterfaces().GetResult();

            Assert.True(result.IsSuccessful);
        }

        [Fact(DisplayName = "NotBeInterfaces")]
        public void NotBeInterfaces()
        {
            var result = GetTypesThat()
                .DoNotHaveNameEndingWith("Interface")
                .Should()
                .NotBeInterfaces().GetResult();

            Assert.True(result.IsSuccessful);
        }       

        [Fact(DisplayName = "BeStructures")]
        public void BeStructures()
        {
            var result = GetTypesThat()
                .HaveNameEndingWith("Struct")
                .Should()
                .BeStructures().GetResult();

            Assert.True(result.IsSuccessful);
        }

        [Fact(DisplayName = "NotBeStructures")]
        public void NotBeStruc()
        {
            var result = GetTypesThat()
                .DoNotHaveNameEndingWith("Struct")
                .Should()
                .NotBeStructures().GetResult();

            Assert.True(result.IsSuccessful);
        }
    }
}