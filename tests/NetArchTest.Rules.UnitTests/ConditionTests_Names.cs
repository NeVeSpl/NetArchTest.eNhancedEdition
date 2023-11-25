using System;
using System.Linq;
using System.Reflection;
using NetArchTest.Rules;
using NetArchTest.TestStructure.Names.Namespace1;
using NetArchTest.TestStructure.Names.Namespace2;
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
                .ResideInNamespace("NetArchTest.TestStructure.Names")
                .And();
        }

        [Fact(DisplayName = "BeOfType")]
        public void BeOfType()
        {
            var result = GetTypesThat()
                .HaveNameStartingWith("Nested")
                .Should()
                .BeOfType(typeof(ClassA1.Nested), typeof(ClassA1<>.Nested1)).GetReflectionTypes();

            Assert.Equal(2, result.Count());          
            Assert.Contains<Type>(typeof(ClassA1.Nested), result);
            Assert.Contains<Type>(typeof(ClassA1<>.Nested1), result);
        }
        [Fact(DisplayName = "NotBeOfType")]
        public void NotBeOfType()
        {
            var result = GetTypesThat()
               .DoNotHaveNameStartingWith("Nested")
               .Should()
               .NotBeOfType(typeof(ClassA1.Nested), typeof(ClassA1<>.Nested1)).GetReflectionTypes();

            Assert.Equal(6, result.Count());           
            Assert.DoesNotContain<Type>(typeof(ClassA1.Nested), result);
            Assert.DoesNotContain<Type>(typeof(ClassA1<>.Nested1), result);
        }


        [Fact(DisplayName = "HaveName")]
        public void HaveName()
        {
            var result = GetTypesThat()
                .ResideInNamespace("NetArchTest.TestStructure.Names.ClassA1")
                .Should()
                .HaveName("Nested").GetResult();

            Assert.True(result.IsSuccessful);
        }

        [Fact(DisplayName = "NotHaveName")]
        public void NotHaveName()
        {
            var result = GetTypesThat()
                .ResideInNamespace("NetArchTest.TestStructure.Names.Namespace1")
                .Should()
                .NotHaveName("ClassG1").GetResult();

            Assert.True(result.IsSuccessful);
        }

        [Fact(DisplayName = "HaveNameStartingWith")]
        public void HaveNameStartingWith()
        {
            var result = GetTypesThat()
                .ResideInNamespace("NetArchTest.TestStructure.Names.Namespace1.ClassA1")
                .Should()
                .HaveNameStartingWith("Nes").GetResult();

            Assert.True(result.IsSuccessful);
        }

        [Fact(DisplayName = "NotHaveNameStartingWith")]
        public void NotHaveNameStartingWith()
        {
            var result = GetTypesThat()
                .ResideInNamespace("NetArchTest.TestStructure.Names.Namespace1")
                .Should()
                .NotHaveNameStartingWith("X").GetResult();

            Assert.True(result.IsSuccessful);
        }

        [Fact(DisplayName = "HaveNameStartingWith_StringComparison")]
        public void HaveNameStartingWith_StringComparison()
        {
            var result = GetTypesThat()
                .ResideInNamespace("NetArchTest.TestStructure.Names.Namespace1.ClassA1")
                .Should()
                .HaveNameStartingWith("Nes").GetResult(Options.Default with { Comparer = StringComparison.Ordinal});

            Assert.True(result.IsSuccessful);
        }

        [Fact(DisplayName = "NotHaveNameStartingWith_StringComparison")]
        public void NotHaveNameStartingWith_StringComparison()
        {
            var result = GetTypesThat()
                .ResideInNamespace("NetArchTest.TestStructure.Names.Namespace1.ClassA1")
                .Should()
                .NotHaveNameStartingWith("nes").GetResult(Options.Default with { Comparer = StringComparison.Ordinal });

            Assert.True(result.IsSuccessful);
        }

        [Fact(DisplayName = "HaveNameEndingWith")]
        public void HaveNameEndingWith()
        {
            var result = GetTypesThat()
                .ResideInNamespace("NetArchTest.TestStructure.Names.Namespace2")
                .Should()
                .HaveNameEndingWith("1").GetResult();

            Assert.True(result.IsSuccessful);
        }

        [Fact(DisplayName = "NotHaveNameEndingWith")]
        public void NotHaveNameEndingWith()
        {
            var result = GetTypesThat()
                .ResideInNamespace("NetArchTest.TestStructure.Names.Namespace2")
                .Should()
                .NotHaveNameEndingWith("2").GetResult();

            Assert.True(result.IsSuccessful);
        }

        

        [Fact(DisplayName = "HaveNameMatching")]
        public void HaveNameMatching()
        {
            var result = GetTypesThat()                
                .DoNotResideInNamespace("NetArchTest.TestStructure.Names.Namespace1")
                .Should()
                .HaveNameMatching(@"\w*\d").GetResult();

            Assert.True(result.IsSuccessful);
        }

        [Fact(DisplayName = "NotHaveNameMatching")]
        public void NotHaveNameMatching()
        {
            var result = GetTypesThat()
                .ResideInNamespace("NetArchTest.TestStructure.Names.Namespace2")
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
                .ResideInNamespace("NetArchTest.TestStructure.Names").GetResult();

            Assert.True(result.IsSuccessful);
        }

        [Fact(DisplayName = "NotResideInNamespace")]
        public void NotResideInNamespace_MatchesFound_ClassSelected()
        {
            var result = GetTypesThat()
                .HaveNameStartingWith("ClassB")
                .Should()
                .NotResideInNamespace("NetArchTest.TestStructure.Names.Namespace2").GetResult();

            Assert.True(result.IsSuccessful);
        }

        [Fact(DisplayName = "ResideInNamespaceMatching")]
        public void ResideInNamespaceMatching()
        {
            var result = GetTypesThat()
                .ResideInNamespace(@"NetArchTest.TestStructure.Names.Namespace1")
                .Should()
                .ResideInNamespaceMatching(@"NetArchTest.TestStructure.Names.Namespace\d")
                .GetResult();

            Assert.True(result.IsSuccessful);
        }

        [Fact(DisplayName = "NotResideInNamespaceMatching")]
        public void NotResideInNamespaceMatching()
        {
            var result = GetTypesThat()
                .ResideInNamespace("NetArchTest.TestStructure.Names.NamespaceB")
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
                .ResideInNamespaceStartingWith("NetArchTest.TestStructure.Names")
                .GetResult();

            Assert.True(result.IsSuccessful);
        }

        [Fact(DisplayName = "NotResideInNamespaceStartingWith")]
        public void NotResideInNamespaceStartingWith()
        {
            var result = GetTypesThat()                
                .HaveNameEndingWith("B1")
                .Should()
                .NotResideInNamespaceStartingWith("NetArchTest.TestStructure.Names.Namespace2")
                .GetResult();

            Assert.True(result.IsSuccessful);
        }

        [Fact(DisplayName = "ResideInNamespaceEndingWith")]
        public void ResideInNamespaceEndingWith()
        {
            var result = GetTypesThat()
                .HaveName("ClassA2")
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
                .ResideInNamespaceContaining(".Names.")
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
    }
}
