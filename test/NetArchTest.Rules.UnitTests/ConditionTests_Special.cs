using System.Reflection;
using NetArchTest.Rules;
using NetArchTest.TestStructure.NameMatching.Namespace1;
using Xunit;

namespace NetArchTest.UnitTests
{
    public class ConditionTests_Special
    {
        [Fact(DisplayName = "Types can be selected for being immutable.")]
        public void AreImmutable_MatchesFound_ClassSelected()
        {
            var result = Types
                .InAssembly(Assembly.GetAssembly(typeof(ClassA1)))
                .That()
                .ResideInNamespace("NetArchTest.TestStructure.Mutability")
                .And()
                .HaveNameStartingWith("ImmutableClass")
                .Should()
                .BeImmutable().GetResult();

            Assert.True(result.IsSuccessful);
        }

        [Fact(DisplayName = "Types can be selected for being mutable.")]
        public void AreMutable_MatchesFound_ClassSelected()
        {
            var result = Types
                .InAssembly(Assembly.GetAssembly(typeof(ClassA1)))
                .That()
                .ResideInNamespace("NetArchTest.TestStructure.Mutability")
                .And()
                .DoNotHaveNameStartingWith("Immutable")
                .Should()
                .BeMutable().GetResult();

            Assert.True(result.IsSuccessful);
        }

        [Fact(DisplayName = "Types can be selected for having only nullable memebers.")]
        public void AreNullable_MatchesFound_ClassSelected()
        {
            var result = Types
                .InAssembly(Assembly.GetAssembly(typeof(ClassA1)))
                .That()
                .ResideInNamespace("NetArchTest.TestStructure.Nullable")
                .And()
                .AreNotNested() // ignore nested helper types
                .And()
                .DoNotHaveNameStartingWith("NonNullableClass")
                .Should()
                .OnlyHaveNullableMembers().GetResult();

            Assert.True(result.IsSuccessful);
        }

        [Fact(DisplayName = "Types can be selected for having non-nullable memebers.")]
        public void AreNonNullable_MatchesFound_ClassSelected()
        {
            var result = Types
                .InAssembly(Assembly.GetAssembly(typeof(ClassA1)))
                .That()
                .ResideInNamespace("NetArchTest.TestStructure.Nullable")
                .And()
                .AreNotNested() // ignore nested helper types
                .And()
                .DoNotHaveNameStartingWith("NullableClass")
                .Should()
                .HaveSomeNonNullableMembers().GetResult();

            Assert.True(result.IsSuccessful);
        }
    }
}
