using System;
using System.Linq;
using System.Reflection;
using NetArchTest.Rules;
using NetArchTest.TestStructure.NameMatching.Namespace1;
using Xunit;

namespace NetArchTest.UnitTests
{
    public class ConditionTests_Names
    {
        private Predicate GetTypesThat()
        {
            return Types
                .InAssembly(Assembly.GetAssembly(typeof(ClassA1)))
                .That()
                .ResideInNamespace("NetArchTest.TestStructure.NameMatching")
                .And();
        }


        [Fact(DisplayName = "HaveName")]
        public void HaveName()
        {
            var result = GetTypesThat()
                .ResideInNamespace("NetArchTest.TestStructure.NameMatching.Namespace2.Namespace3")
                .Should()
                .HaveName("ClassB2").GetResult();

            Assert.True(result.IsSuccessful);
        }

        [Fact(DisplayName = "NotHaveName")]
        public void NotHaveName()
        {
            var result = GetTypesThat()
                .ResideInNamespace("NetArchTest.TestStructure.NameMatching.Namespace1")
                .Should()
                .NotHaveName("ClassB2").GetResult();

            Assert.True(result.IsSuccessful);
        }

        [Fact(DisplayName = "HaveNameStartingWith")]
        public void HaveNameStartingWith()
        {
            var result = GetTypesThat()
                .DoNotResideInNamespace("NetArchTest.TestStructure.NameMatching.Namespace3")
                .Should()
                .HaveNameStartingWith("Class").GetResult();

            Assert.True(result.IsSuccessful);
        }

        [Fact(DisplayName = "NotHaveNameStartingWith")]
        public void NotHaveNameStartingWith()
        {
            var result = GetTypesThat()
                .ResideInNamespace("NetArchTest.TestStructure.NameMatching")
                .Should()
                .NotHaveNameStartingWith("X").GetResult();

            Assert.True(result.IsSuccessful);
        }

        [Fact(DisplayName = "HaveNameStartingWith_StringComparison")]
        public void HaveNameStartingWith_StringComparison()
        {
            var result = GetTypesThat()
                .ResideInNamespace("NetArchTest.TestStructure.NameMatching.Namespace3")
                .Should()
                .HaveNameStartingWith("Some").GetResult(Options.Default with { Comparer = StringComparison.Ordinal});

            Assert.True(result.IsSuccessful);
        }

        [Fact(DisplayName = "NotHaveNameStartingWith_StringComparison")]
        public void NotHaveNameStartingWith_StringComparison()
        {
            var result = GetTypesThat()
                .ResideInNamespace("NetArchTest.TestStructure.NameMatching")
                .Should()
                .NotHaveNameStartingWith("s").GetResult(Options.Default with { Comparer = StringComparison.Ordinal });

            Assert.True(result.IsSuccessful);
        }

        [Fact(DisplayName = "HaveNameEndingWith")]
        public void HaveNameEndingWith()
        {
            var result = GetTypesThat()
                .ResideInNamespace("NetArchTest.TestStructure.NameMatching.Namespace2.Namespace3")
                .Should()
                .HaveNameEndingWith("B2").GetResult();

            Assert.True(result.IsSuccessful);
        }

        [Fact(DisplayName = "NotHaveNameEndingWith")]
        public void NotHaveNameEndingWith()
        {
            var result = GetTypesThat()
                .ResideInNamespace("NetArchTest.TestStructure.NameMatching.Namespace2.Namespace1")
                .Should()
                .NotHaveNameEndingWith("B2").GetResult();

            Assert.True(result.IsSuccessful);
        }

        [Fact(DisplayName = "HaveNameEndingWith_StringComparison")]
        public void HaveNameEndingWith_StringComparison()
        {
            var result = GetTypesThat()
                .ResideInNamespace("NetArchTest.TestStructure.NameMatching.Namespace2.Namespace3.B")
                .Should()
                .HaveNameEndingWith("ntity").GetResult();

            Assert.True(result.IsSuccessful);
        }

        [Fact(DisplayName = "NotHaveNameEndingWith_StringComparison")]
        public void NotHaveNameEndingWith_StringComparison()
        {
            var result = GetTypesThat()
                .ResideInNamespace("NetArchTest.TestStructure.NameMatching.Namespace3")
                .Should()
                .NotHaveNameEndingWith("ENTITY").GetResult(Options.Default with { Comparer = StringComparison.Ordinal });

            Assert.True(result.IsSuccessful);
        }

        [Fact(DisplayName = "HaveNameMatching")]
        public void HaveNameMatching()
        {
            var result = GetTypesThat()                
                .DoNotResideInNamespace("NetArchTest.TestStructure.NameMatching.Namespace3")
                .Should()
                .HaveNameMatching(@"Class\w\d").GetResult();

            Assert.True(result.IsSuccessful);
        }

        [Fact(DisplayName = "NotHaveNameMatching")]
        public void NotHaveNameMatching()
        {
            var result = GetTypesThat()
                .ResideInNamespace("NetArchTest.TestStructure.NameMatching")
                .Should()
                .NotHaveNameMatching(@"X\w").GetResult();

            Assert.True(result.IsSuccessful);
        }



        [Fact(DisplayName = "ResideInNamespace")]
        public void ResideInNamespace()
        {
            var result = GetTypesThat()
                .HaveNameStartingWith("ClassA")
                .Should()
                .ResideInNamespace("NetArchTest.TestStructure.NameMatching").GetResult();

            Assert.True(result.IsSuccessful);
        }

        [Fact(DisplayName = "NotResideInNamespace")]
        public void NotResideInNamespace_MatchesFound_ClassSelected()
        {
            var result = GetTypesThat()
                .HaveNameStartingWith("ClassA")
                .Should()
                .NotResideInNamespace("NetArchTest.TestStructure.Wrong").GetResult();

            Assert.True(result.IsSuccessful);
        }

        [Fact(DisplayName = "ResideInNamespaceMatching")]
        public void ResideInNamespaceMatching()
        {
            var result = GetTypesThat()
                .ResideInNamespace(@"NetArchTest.TestStructure.NameMatching.NamespaceGeneric.Namespace1")
                .Should()
                .ResideInNamespaceMatching(@"NetArchTest.TestStructure.NameMatching.NamespaceGeneric.Namespace\d")
                .GetResult();

            Assert.True(result.IsSuccessful);
        }

        [Fact(DisplayName = "NotResideInNamespaceMatching")]
        public void NotResideInNamespaceMatching()
        {
            var result = GetTypesThat()
                .ResideInNamespace("NetArchTest.TestStructure.NameMatching.NamespaceGeneric.NamespaceA")
                .Should()
                .NotResideInNamespaceMatching(@"NetArchTest.TestStructure.NameMatching.NamespaceGeneric.Namespace\d")
                .GetResult();

            Assert.True(result.IsSuccessful);
        }

        [Fact(DisplayName = "ResideInNamespaceStartingWith")]
        public void ResideInNamespaceStartingWith()
        {
            var result = GetTypesThat()
                .HaveNameStartingWith("ClassA")
                .Should()
                .ResideInNamespaceStartingWith("NetArchTest.TestStructure.NameMatching")
                .GetResult();

            Assert.True(result.IsSuccessful);
        }

        [Fact(DisplayName = "NotResideInNamespaceStartingWith")]
        public void NotResideInNamespaceStartingWith()
        {
            var result = GetTypesThat()
                .ResideInNamespaceStartingWith("NetArchTest.TestStructure.NameMatching")
                .And()
                .HaveNameEndingWith("1")
                .Should()
                .NotResideInNamespaceStartingWith("NetArchTest.TestStructure.NameMatching.Namespace2")
                .GetResult();

            Assert.True(result.IsSuccessful);
        }

        [Fact(DisplayName = "ResideInNamespaceEndingWith")]
        public void ResideInNamespaceEndingWith()
        {
            var result = GetTypesThat()
                .HaveName("ClassA1")
                .Should()
                .ResideInNamespaceEndingWith(".Namespace1")
                .GetResult();

            Assert.True(result.IsSuccessful);
        }

        [Fact(DisplayName = "NotResideInNamespaceEndingWith")]
        public void NotResideInNamespaceEndingWith()
        {
            var result = GetTypesThat()
                .HaveNameStartingWith("ClassA")
                .Should()
                .NotResideInNamespaceEndingWith(".Namespace3")
                .GetResult();

            Assert.True(result.IsSuccessful);
        }

        [Fact(DisplayName = "ResideInNamespaceContaining")]
        public void ResideInNamespaceContaining()
        {
            var result = GetTypesThat()
                .HaveNameStartingWith("ClassA")
                .Should()
                .ResideInNamespaceContaining(".NameMatching.")
                .GetResult();

            Assert.True(result.IsSuccessful);
        }

        [Fact(DisplayName = "NotResideInNamespaceContaining")]
        public void NotResideInNamespaceContaining()
        {
            var result = GetTypesThat()
                .HaveNameStartingWith("ClassA")
                .Should()
                .NotResideInNamespaceContaining("Namespace3")
                .GetResult();

            Assert.True(result.IsSuccessful);
        }

       


        [Fact(DisplayName = "Types failing condition are reported when test fails.")]
        public void MatchNotFound_ClassesReported()
        {
            var result = GetTypesThat()
                .ResideInNamespace("NetArchTest.TestStructure.NameMatching.Namespace1")
                .Should()
                .HaveName("ClassA2")
                .GetResult();

            Assert.False(result.IsSuccessful);

            var failingTypes = result.FailingTypes.ToList();
            Assert.Equal(2, failingTypes.Count);
            Assert.Equal("NetArchTest.TestStructure.NameMatching.Namespace1.ClassA1", failingTypes[0].ReflectionType.ToString());
            Assert.Equal("NetArchTest.TestStructure.NameMatching.Namespace1.ClassB1", failingTypes[1].ReflectionType.ToString());
        }
    }
}
