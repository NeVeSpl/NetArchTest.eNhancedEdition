using System;
using System.Linq;
using System.Reflection;
using NetArchTest.Rules;
using NetArchTest.TestStructure.NameMatching.Namespace1;
using NetArchTest.TestStructure.NameMatching.Namespace2;
using NetArchTest.TestStructure.NameMatching.Namespace2.Namespace3;
using NetArchTest.TestStructure.NameMatching.Namespace3.A;
using NetArchTest.TestStructure.NameMatching.Namespace3.B;
using NetArchTest.TestStructure.NameMatching.NamespaceGeneric.Namespace1;
using Xunit;

namespace NetArchTest.UnitTests
{
    public class PredicateTests_Names
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
            var result = GetTypesThat().HaveName("ClassA1").GetReflectionTypes();

            Assert.Equal(2, result.Count());
            Assert.Contains<Type>(typeof(ClassA1), result);
            Assert.Contains<Type>(typeof(ClassA1<>), result);
        }

        [Fact(DisplayName = "DoNotHaveName")]
        public void DoNotHaveName()
        {
            var result = GetTypesThat().DoNotHaveName("ClassA1").GetReflectionTypes();

            Assert.Equal(9, result.Count());
            Assert.Contains<Type>(typeof(ClassA2), result);
            Assert.Contains<Type>(typeof(ClassB1), result);
            Assert.Contains<Type>(typeof(ClassB2), result);
            Assert.Contains<Type>(typeof(ClassA3), result);
            Assert.Contains<Type>(typeof(SomeThing), result);
            Assert.Contains<Type>(typeof(SomethingElse), result);
            Assert.Contains<Type>(typeof(SomeEntity), result);
            Assert.Contains<Type>(typeof(SomeIdentity), result);
        }

        [Fact(DisplayName = "HaveNameStartingWith")]
        public void HaveNameStartingWith()
        {
            var result = GetTypesThat().HaveNameStartingWith("SomeT").GetReflectionTypes();

            Assert.Equal(2, result.Count()); 
            Assert.Contains<Type>(typeof(SomeThing), result);
            Assert.Contains<Type>(typeof(SomethingElse), result);
        }

        [Fact(DisplayName = "DoNotHaveNameStartingWith")]
        public void DoNotHaveNameStartingWith()
        {
            var result = GetTypesThat().DoNotHaveNameStartingWith("ClassA").GetReflectionTypes();

            Assert.Equal(7, result.Count());
            Assert.Contains<Type>(typeof(ClassB1), result);
            Assert.Contains<Type>(typeof(ClassB2), result);
            Assert.Contains<Type>(typeof(SomeThing), result);
            Assert.Contains<Type>(typeof(SomethingElse), result);
            Assert.Contains<Type>(typeof(SomeEntity), result);
            Assert.Contains<Type>(typeof(SomeIdentity), result);
        }

        [Fact(DisplayName = "HaveNameStartingWith_StringComparison")]
        public void HaveNameStartingWith_StringComparison()
        {
            var result = GetTypesThat().HaveNameStartingWith("SomeT").GetReflectionTypes(Options.Default with { Comparer = StringComparison.Ordinal });

            Assert.Single(result); 
            Assert.Contains<Type>(typeof(SomeThing), result);
            Assert.DoesNotContain<Type>(typeof(SomethingElse), result);
        }       

        [Fact(DisplayName = "DoNotHaveNameStartingWith_StringComparison")]
        public void DoNotHaveNameStartingWith_StringComparison()
        {
            var result = GetTypesThat().DoNotHaveNameStartingWith("SomeT").GetReflectionTypes(Options.Default with { Comparer = StringComparison.Ordinal });

            Assert.Equal(10, result.Count());
            Assert.DoesNotContain<Type>(typeof(SomeThing), result);
            Assert.Contains<Type>(typeof(SomethingElse), result);
            Assert.Contains<Type>(typeof(SomeEntity), result);
            Assert.Contains<Type>(typeof(SomeIdentity), result);
        }

        [Fact(DisplayName = "HaveNameEndingWith")]
        public void HaveNameEndingWith()
        {
            var result = GetTypesThat().HaveNameEndingWith("Entity").GetReflectionTypes();

            Assert.Equal(2, result.Count()); 
            Assert.Contains<Type>(typeof(SomeEntity), result);
            Assert.Contains<Type>(typeof(SomeIdentity), result);
        }

        [Fact(DisplayName = "DoNotHaveNameEndingWith")]
        public void DoNotHaveNameEndingWith()
        {
            var result = GetTypesThat().DoNotHaveNameEndingWith("A1").GetReflectionTypes();

            Assert.Equal(9, result.Count());
            Assert.Contains<Type>(typeof(ClassA2), result);
            Assert.Contains<Type>(typeof(ClassA3), result);
            Assert.Contains<Type>(typeof(ClassB1), result);
            Assert.Contains<Type>(typeof(ClassB2), result);
            Assert.Contains<Type>(typeof(SomeThing), result);
            Assert.Contains<Type>(typeof(SomethingElse), result);
            Assert.Contains<Type>(typeof(SomeEntity), result);
            Assert.Contains<Type>(typeof(SomeIdentity), result);
        }

        [Fact(DisplayName = "HaveNameEndingWith_StringComparison")]
        public void HaveNameEndingWith_StringComparison()
        {
            var result = GetTypesThat().HaveNameEndingWith("Entity").GetReflectionTypes(Options.Default with { Comparer = StringComparison.Ordinal });

            Assert.Single(result); 
            Assert.Contains<Type>(typeof(SomeEntity), result);
            Assert.DoesNotContain<Type>(typeof(SomeIdentity), result);
        }       

        [Fact(DisplayName = "HaveNameMatching")]
        public void HaveNameMatching()
        {
            var result = GetTypesThat().HaveNameMatching(@"Class\w1").GetReflectionTypes();

            Assert.Equal(4, result.Count());
            Assert.Contains<Type>(typeof(ClassA1), result);
            Assert.Contains<Type>(typeof(ClassA1<>), result);
            Assert.Contains<Type>(typeof(ClassB1), result);
        }

        [Fact(DisplayName = "DoNotHaveNameMatching")]
        public void DoNotHaveNameMatching()
        {
            var result = GetTypesThat().DoNotHaveNameMatching(@"Class\w1").GetReflectionTypes();

            Assert.Equal(7, result.Count()); 
            Assert.Contains<Type>(typeof(ClassA2), result);
            Assert.Contains<Type>(typeof(ClassA3), result);
            Assert.Contains<Type>(typeof(ClassB2), result);
            Assert.Contains<Type>(typeof(SomeThing), result);
            Assert.Contains<Type>(typeof(SomethingElse), result);
            Assert.Contains<Type>(typeof(SomeEntity), result);
            Assert.Contains<Type>(typeof(SomeIdentity), result);
        }



        [Fact(DisplayName = "ResideInNamespace")]
        public void ResideInNamespace()
        {
            var result = GetTypesThat()
                .ResideInNamespace("NetArchTest.TestStructure.NameMatching.Namespace1")
                .GetReflectionTypes();

            Assert.Equal(3, result.Count()); 
            Assert.Contains<Type>(typeof(ClassA1), result);
            Assert.Contains<Type>(typeof(ClassA2), result);
            Assert.Contains<Type>(typeof(ClassB1), result);
        }

        [Fact(DisplayName = "DoNotResideInNamespace")]
        public void DoNotResideInNamespace()
        {
            var result = GetTypesThat()
                .DoNotResideInNamespace("NetArchTest.TestStructure.NameMatching.Namespace2")
                .GetReflectionTypes();

            Assert.Equal(9, result.Count()); 
            Assert.Contains<Type>(typeof(ClassA1), result);
            Assert.Contains<Type>(typeof(ClassA2), result);
            Assert.Contains<Type>(typeof(ClassB1), result);
            Assert.Contains<Type>(typeof(SomeThing), result);
            Assert.Contains<Type>(typeof(SomethingElse), result);
            Assert.Contains<Type>(typeof(SomeEntity), result);
            Assert.Contains<Type>(typeof(SomeIdentity), result);
        }

        [Fact(DisplayName = "ResideInNamespaceMatching")]
        public void ResideInNamespaceMatching()
        {
            var result = GetTypesThat()
                .ResideInNamespaceMatching(@"NetArchTest.TestStructure.NameMatching.NamespaceGeneric.Namespace\d")
                .GetReflectionTypes();

            Assert.Single(result); 
            Assert.Contains<Type>(typeof(ClassA1<>), result);
        }

        [Fact(DisplayName = "DoNotResideInNamespaceMatching")]
        public void DoNotResideInNamespaceMatching()
        {
            var result = GetTypesThat()
                .DoNotResideInNamespaceMatching(@"NetArchTest.TestStructure.NameMatching.NamespaceGeneric.Namespace\d")
                .GetReflectionTypes();

            Assert.Equal(10, result.Count());
        }

        [Fact(DisplayName = "ResideInNamespaceStartingWith")]
        public void ResideInNamespaceStartingWith()
        {
            var result = GetTypesThat()
                .ResideInNamespaceStartingWith("NetArchTest.TestStructure.NameMatching")
                .GetReflectionTypes();

            Assert.Equal(11, result.Count());
            Assert.Contains<Type>(typeof(ClassA1), result);
            Assert.Contains<Type>(typeof(ClassA2), result);
            Assert.Contains<Type>(typeof(ClassA3), result);
            Assert.Contains<Type>(typeof(ClassB2), result);
            Assert.Contains<Type>(typeof(ClassA1), result);
            Assert.Contains<Type>(typeof(SomeThing), result);
            Assert.Contains<Type>(typeof(SomethingElse), result);
            Assert.Contains<Type>(typeof(SomeEntity), result);
            Assert.Contains<Type>(typeof(SomeIdentity), result);
        }

        [Fact(DisplayName = "DoNotResideInNamespaceStartingWith")]
        public void DoNotResideInNamespaceStartingWith()
        {
            var result = GetTypesThat()
                .DoNotResideInNamespaceStartingWith("NetArchTest.TestStructure.NameMatching.Namespace2")
                .GetReflectionTypes();

            Assert.Equal(9, result.Count()); 
            Assert.Contains<Type>(typeof(ClassA1), result);
            Assert.Contains<Type>(typeof(ClassA2), result);
            Assert.Contains<Type>(typeof(ClassB1), result);
            Assert.Contains<Type>(typeof(SomeThing), result);
            Assert.Contains<Type>(typeof(SomethingElse), result);
            Assert.Contains<Type>(typeof(SomeEntity), result);
            Assert.Contains<Type>(typeof(SomeIdentity), result);
        }

        [Fact(DisplayName = "ResideInNamespaceEndingWith")]
        public void ResideInNamespaceEndingWith()
        {
            var result = GetTypesThat()
                .ResideInNamespaceEndingWith(".NameMatching.Namespace1")
                .GetReflectionTypes();

            Assert.Equal(3, result.Count());
            Assert.Contains<Type>(typeof(ClassA1), result);
        }

        [Fact(DisplayName = "DoNotResideInNamespaceEndingWith")]
        public void DoNotResideInNamespaceEndingWith()
        {
            var result = GetTypesThat()
                .DoNotResideInNamespaceEndingWith(".NameMatching.Namespace1")
                .GetReflectionTypes();

            Assert.Equal(8, result.Count());            
            Assert.Contains<Type>(typeof(ClassA3), result);        
            Assert.Contains<Type>(typeof(ClassB2), result);
            Assert.Contains<Type>(typeof(SomeThing), result);
            Assert.Contains<Type>(typeof(SomethingElse), result);
            Assert.Contains<Type>(typeof(SomeEntity), result);
            Assert.Contains<Type>(typeof(SomeIdentity), result);
        }

        [Fact(DisplayName = "ResideInNamespaceContaining")]
        public void ResideInNamespaceContaining_ClassSelected()
        {
            var result = GetTypesThat()
                .ResideInNamespaceContaining(".NameMatching.")
                .GetReflectionTypes();

            Assert.Equal(11, result.Count()); 
            Assert.Contains<Type>(typeof(ClassA1), result);
            Assert.Contains<Type>(typeof(ClassA2), result);
            Assert.Contains<Type>(typeof(ClassA3), result);
            Assert.Contains<Type>(typeof(ClassB1), result);
            Assert.Contains<Type>(typeof(ClassB2), result);
            Assert.Contains<Type>(typeof(SomeThing), result);
            Assert.Contains<Type>(typeof(SomethingElse), result);
            Assert.Contains<Type>(typeof(SomeEntity), result);
            Assert.Contains<Type>(typeof(SomeIdentity), result);
        }

        [Fact(DisplayName = "DoNotResideInNamespaceContaining")]
        public void DoNotResideInNamespaceContaining()
        {
            var result = GetTypesThat()
                .DoNotResideInNamespaceContaining("Namespace2")
                .GetReflectionTypes();

            Assert.Equal(9, result.Count()); 
            Assert.Contains<Type>(typeof(ClassA1), result);
            Assert.Contains<Type>(typeof(ClassA2), result);
            Assert.Contains<Type>(typeof(ClassB1), result);
            Assert.Contains<Type>(typeof(SomeThing), result);
            Assert.Contains<Type>(typeof(SomethingElse), result);
            Assert.Contains<Type>(typeof(SomeEntity), result);
            Assert.Contains<Type>(typeof(SomeIdentity), result);
        }
    }
}