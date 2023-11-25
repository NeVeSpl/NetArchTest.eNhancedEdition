using System;
using System.Linq;
using System.Reflection;
using NetArchTest.Rules;
using NetArchTest.TestStructure.Names.Namespace1;
using NetArchTest.TestStructure.Names.Namespace2;
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
                .ResideInNamespace("NetArchTest.TestStructure.Names")
                .And();
        }


        [Fact(DisplayName = "AreOfType")]
        public void AreOfType()
        {
            var result = GetTypesThat().AreOfType(typeof(ClassA1), typeof(ClassA1.Nested), typeof(ClassA1<>.Nested1)).GetReflectionTypes();

            Assert.Equal(3, result.Count());
            Assert.Contains<Type>(typeof(ClassA1), result);
            Assert.Contains<Type>(typeof(ClassA1.Nested), result);
            Assert.Contains<Type>(typeof(ClassA1<>.Nested1), result);
        }
        [Fact(DisplayName = "AreNotOfType")]
        public void AreNotOfType()
        {
            var result = GetTypesThat().AreNotOfType(typeof(ClassA1), typeof(ClassA1.Nested), typeof(ClassA1<>.Nested1)).GetReflectionTypes();

            Assert.Equal(5, result.Count());
            Assert.DoesNotContain<Type>(typeof(ClassA1), result);
            Assert.DoesNotContain<Type>(typeof(ClassA1.Nested), result);
            Assert.DoesNotContain<Type>(typeof(ClassA1<>.Nested1), result);
        }
        [Fact(DisplayName = "HaveName")]
        public void HaveName()
        {
            var result = GetTypesThat().HaveName("ClassA1").GetReflectionTypes();

            Assert.Equal(3, result.Count());
            Assert.Contains<Type>(typeof(ClassA1), result);
            Assert.Contains<Type>(typeof(ClassA1<>), result);
            Assert.Contains<Type>(typeof(CLASSa1), result);
        }

        [Fact(DisplayName = "DoNotHaveName")]
        public void DoNotHaveName()
        {
            var result = GetTypesThat().DoNotHaveName("ClassA1").GetReflectionTypes();

            Assert.Equal(5, result.Count());
            Assert.Contains<Type>(typeof(ClassA2), result);
            Assert.Contains<Type>(typeof(ClassB1), result);
            Assert.Contains<Type>(typeof(ClassA1.Nested), result);
            Assert.Contains<Type>(typeof(ClassA1<>.Nested1), result);
            Assert.Contains<Type>(typeof(ClassG1<>), result);
          
        }

        [Fact(DisplayName = "HaveName_Many")]
        public void HaveName_Many()
        {
            var result = GetTypesThat().HaveName("ClassA1", "ClassA2").GetReflectionTypes();

            Assert.Equal(4, result.Count());
            Assert.Contains<Type>(typeof(ClassA1), result);
            Assert.Contains<Type>(typeof(ClassA1<>), result);
            Assert.Contains<Type>(typeof(CLASSa1), result);
            Assert.Contains<Type>(typeof(ClassA2), result);
        }

        [Fact(DisplayName = "DoNotHaveName_Many")]
        public void DoNotHaveName_Many()
        {
            var result = GetTypesThat().DoNotHaveName("ClassA1", "ClassA2").GetReflectionTypes();

            Assert.Equal(4, result.Count());
            Assert.Contains<Type>(typeof(ClassB1), result);
            Assert.Contains<Type>(typeof(ClassG1<>), result);
            Assert.Contains<Type>(typeof(ClassA1.Nested), result);
            Assert.Contains<Type>(typeof(ClassA1<>.Nested1), result);
        }

        [Fact(DisplayName = "HaveNameStartingWith")]
        public void HaveNameStartingWith()
        {
            var result = GetTypesThat().HaveNameStartingWith("ClassA").GetReflectionTypes();
           
            Assert.Equal(4, result.Count());
            Assert.Contains<Type>(typeof(ClassA1), result);
            Assert.Contains<Type>(typeof(ClassA2), result);
            Assert.Contains<Type>(typeof(ClassA1<>), result);
            Assert.Contains<Type>(typeof(CLASSa1), result);   
        }

        [Fact(DisplayName = "DoNotHaveNameStartingWith")]
        public void DoNotHaveNameStartingWith()
        {
            var result = GetTypesThat().DoNotHaveNameStartingWith("ClassA").GetReflectionTypes();

            Assert.Equal(4, result.Count());
            Assert.Contains<Type>(typeof(ClassB1), result);
            Assert.Contains<Type>(typeof(ClassG1<>), result);
            Assert.Contains<Type>(typeof(ClassA1.Nested), result);
            Assert.Contains<Type>(typeof(ClassA1<>.Nested1), result);
        }

        [Fact(DisplayName = "HaveNameStartingWith_Many")]
        public void HaveNameStartingWith_Many()
        {
            var result = GetTypesThat().HaveNameStartingWith("ClassA", "ClassB").GetReflectionTypes();

            Assert.Equal(5, result.Count());
            Assert.Contains<Type>(typeof(ClassA1), result);
            Assert.Contains<Type>(typeof(ClassA2), result);
            Assert.Contains<Type>(typeof(ClassA1<>), result);
            Assert.Contains<Type>(typeof(CLASSa1), result);
            Assert.Contains<Type>(typeof(ClassB1), result);
        }

        [Fact(DisplayName = "HaveNameStartingWith_StringComparison")]
        public void HaveNameStartingWith_StringComparison()
        {
            var result = GetTypesThat().HaveNameStartingWith("ClassA").GetReflectionTypes(Options.Default with { Comparer = StringComparison.Ordinal });

            Assert.Equal(3, result.Count());
            Assert.Contains<Type>(typeof(ClassA1), result);
            Assert.Contains<Type>(typeof(ClassA2), result);
            Assert.Contains<Type>(typeof(ClassA1<>), result);
        }       

        [Fact(DisplayName = "DoNotHaveNameStartingWith_StringComparison")]
        public void DoNotHaveNameStartingWith_StringComparison()
        {
            var result = GetTypesThat().DoNotHaveNameStartingWith("ClassA").GetReflectionTypes(Options.Default with { Comparer = StringComparison.Ordinal });

            Assert.Equal(5, result.Count());
            Assert.Contains<Type>(typeof(CLASSa1), result);
            Assert.Contains<Type>(typeof(ClassB1), result);
            Assert.Contains<Type>(typeof(ClassG1<>), result);
            Assert.Contains<Type>(typeof(ClassA1.Nested), result);
            Assert.Contains<Type>(typeof(ClassA1<>.Nested1), result);

        }

        [Fact(DisplayName = "HaveNameEndingWith")]
        public void HaveNameEndingWith()
        {
            var result = GetTypesThat().HaveNameEndingWith("A1").GetReflectionTypes();

            Assert.Equal(3, result.Count());
            Assert.Contains<Type>(typeof(ClassA1), result);
            Assert.Contains<Type>(typeof(CLASSa1), result);          
            Assert.Contains<Type>(typeof(ClassA1), result);           
        }

        [Fact(DisplayName = "DoNotHaveNameEndingWith")]
        public void DoNotHaveNameEndingWith()
        {
            var result = GetTypesThat().DoNotHaveNameEndingWith("A1").GetReflectionTypes();

            Assert.Equal(5, result.Count());
            Assert.Contains<Type>(typeof(ClassA1.Nested), result);
            Assert.Contains<Type>(typeof(ClassA2), result);
            Assert.Contains<Type>(typeof(ClassB1), result);
            Assert.Contains<Type>(typeof(ClassA1<>.Nested1), result);
            Assert.Contains<Type>(typeof(ClassG1<>), result);
        }

        [Fact(DisplayName = "HaveNameEndingWith_StringComparison")]
        public void HaveNameEndingWith_StringComparison()
        {
            var result = GetTypesThat().HaveNameEndingWith("A1").GetReflectionTypes(Options.Default with { Comparer = StringComparison.Ordinal });

            Assert.Equal(2, result.Count());
            Assert.Contains<Type>(typeof(ClassA1), result);           
            Assert.Contains<Type>(typeof(ClassA1), result);
        }       

        [Fact(DisplayName = "HaveNameMatching")]
        public void HaveNameMatching()
        {
            var result = GetTypesThat().HaveNameMatching(@"Class\w1").GetReflectionTypes();

            Assert.Equal(5, result.Count());
            Assert.Contains<Type>(typeof(ClassA1), result);
            Assert.Contains<Type>(typeof(CLASSa1), result);
            Assert.Contains<Type>(typeof(ClassB1), result);
            Assert.Contains<Type>(typeof(ClassA1<>), result);
            Assert.Contains<Type>(typeof(ClassG1<>), result);
        }

        [Fact(DisplayName = "DoNotHaveNameMatching")]
        public void DoNotHaveNameMatching()
        {
            var result = GetTypesThat().DoNotHaveNameMatching(@"Class\w1").GetReflectionTypes();

            Assert.Equal(3, result.Count());
            Assert.Contains<Type>(typeof(ClassA2), result);
            Assert.Contains<Type>(typeof(ClassA1.Nested), result);
            Assert.Contains<Type>(typeof(ClassA1<>.Nested1), result);
        }

        [Fact(DisplayName = "ResideInNamespace")]
        public void ResideInNamespace()
        {
            var result = GetTypesThat()
                .ResideInNamespace("NetArchTest.TestStructure.Names.Namespace1")
                .GetReflectionTypes();

            Assert.Equal(5, result.Count()); 
            Assert.Contains<Type>(typeof(ClassA1), result);
            Assert.Contains<Type>(typeof(CLASSa1), result);
            Assert.Contains<Type>(typeof(ClassA2), result);
            Assert.Contains<Type>(typeof(ClassB1), result);
            Assert.Contains<Type>(typeof(ClassA1.Nested), result);
        }

        [Fact(DisplayName = "DoNotResideInNamespace")]
        public void DoNotResideInNamespace()
        {
            var result = GetTypesThat()
                .DoNotResideInNamespace("NetArchTest.TestStructure.Names.Namespace1")
                .GetReflectionTypes();

            Assert.Equal(3, result.Count()); 
            Assert.Contains<Type>(typeof(ClassA1<>), result);
            Assert.Contains<Type>(typeof(ClassA1<>.Nested1), result);
            Assert.Contains<Type>(typeof(ClassG1<>), result);
           
        }

        [Fact(DisplayName = "ResideInNamespaceMatching")]
        public void ResideInNamespaceMatching()
        {
            var result = GetTypesThat()
                .ResideInNamespaceMatching(@"NetArchTest.TestStructure.Names.Namespace\d")
                .GetReflectionTypes();

            Assert.Equal(8, result.Count());
            
        }

        [Fact(DisplayName = "DoNotResideInNamespaceMatching")]
        public void DoNotResideInNamespaceMatching()
        {
            var result = GetTypesThat()
                .DoNotResideInNamespaceMatching(@"NetArchTest.TestStructure.Names.Namespace\d")
                .GetReflectionTypes();

            Assert.Empty(result);
        }      

        [Fact(DisplayName = "ResideInNamespaceEndingWith")]
        public void ResideInNamespaceEndingWith()
        {
            var result = GetTypesThat()
                .ResideInNamespaceEndingWith(".Names.Namespace1")
                .GetReflectionTypes();

            Assert.Equal(4, result.Count());
            Assert.Contains<Type>(typeof(ClassA1), result);
            Assert.Contains<Type>(typeof(CLASSa1), result);
            Assert.Contains<Type>(typeof(ClassA2), result);
            Assert.Contains<Type>(typeof(ClassB1), result);            
        }

        [Fact(DisplayName = "DoNotResideInNamespaceEndingWith")]
        public void DoNotResideInNamespaceEndingWith()
        {
            var result = GetTypesThat()
                .DoNotResideInNamespaceEndingWith(".Names.Namespace1")
                .GetReflectionTypes();

            Assert.Equal(4, result.Count());
            Assert.Contains<Type>(typeof(ClassA1.Nested), result);
            Assert.Contains<Type>(typeof(ClassA1<>), result);
            Assert.Contains<Type>(typeof(ClassA1<>.Nested1), result);
            Assert.Contains<Type>(typeof(ClassG1<>), result);
        }

        [Fact(DisplayName = "ResideInNamespaceContaining")]
        public void ResideInNamespaceContaining()
        {
            var result = GetTypesThat()
                .ResideInNamespaceContaining(".Names.")
                .GetReflectionTypes();

            Assert.Equal(8, result.Count()); 
        }

        [Fact(DisplayName = "DoNotResideInNamespaceContaining")]
        public void DoNotResideInNamespaceContaining()
        {
            var result = GetTypesThat()
                .DoNotResideInNamespaceContaining("Namespace2")
                .GetReflectionTypes();

            Assert.Equal(5, result.Count());
            Assert.Contains<Type>(typeof(ClassA1), result);
            Assert.Contains<Type>(typeof(CLASSa1), result);
            Assert.Contains<Type>(typeof(ClassA2), result);
            Assert.Contains<Type>(typeof(ClassB1), result);
        }    
    }
}