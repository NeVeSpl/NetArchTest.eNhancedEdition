using System;
using System.Linq;
using System.Reflection;
using NetArchTest.Rules;
using NetArchTest.TestStructure.NameMatching.Namespace1;
using NetArchTest.TestStructure.NameMatching.Namespace2;
using NetArchTest.TestStructure.NameMatching.Namespace2.Namespace3;
using NetArchTest.UnitTests.TestFixtures;
using Xunit;

namespace NetArchTest.UnitTests
{
    public class PredicateListTests(AllTypesFixture fixture) : IClassFixture<AllTypesFixture>
    {
        [Fact(DisplayName = "Predicates can be grouped together using 'or' logic.")]
        public void Or_AppliedToPredicates_SelectCorrectTypes()
        {
            var result = fixture.Types
                .That()
                .ResideInNamespace("NetArchTest.TestStructure.NameMatching.Namespace1")
                .Or()
                .ResideInNamespace("NetArchTest.TestStructure.NameMatching.Namespace2")               
                .GetReflectionTypes();

            Assert.Equal(5, result.Count()); 
            Assert.Contains<Type>(typeof(ClassA1), result);
            Assert.Contains<Type>(typeof(ClassA2), result);
            Assert.Contains<Type>(typeof(ClassA3), result);
            Assert.Contains<Type>(typeof(ClassB1), result);
            Assert.Contains<Type>(typeof(ClassB2), result);           
        }

        [Fact(DisplayName = "Predicates can be chained together using 'and' logic.")]
        public void And_AppliedToPredicates_SelectCorrectTypes()
        {
            var result = fixture.Types
                .That()
                .ResideInNamespace("NetArchTest.TestStructure.NameMatching.Namespace1")
                .And()
                .HaveNameStartingWith("Class")
                .And()
                .HaveNameEndingWith("1")
                .GetReflectionTypes();

            Assert.Equal(2, result.Count()); // two types found
            Assert.Contains<Type>(typeof(ClassA1), result);
            Assert.Contains<Type>(typeof(ClassB1), result);
        }

        [Fact(DisplayName = "An Or() statement will signal the start of a separate group of predicates")]
        public void Or_MultipleInstances_TreatedAsSeparateGroups()
        {
            var result = fixture.Types
                .That()
                // First group (returns ClassA1 and ClassB1)
                .ResideInNamespace("NetArchTest.TestStructure.NameMatching.Namespace1")
                .And()
                .HaveNameStartingWith("ClassA")
                .Or()
                // Second group (returns ClassB2)
                .ResideInNamespace("NetArchTest.TestStructure.NameMatching.Namespace2")
                .And()
                .HaveNameStartingWith("ClassB")
                .GetReflectionTypes();

            // Results will be everything returned by both groups of statements
            Assert.Equal(3, result.Count()); // five types found
            Assert.Contains<Type>(typeof(ClassA1), result);
            Assert.Contains<Type>(typeof(ClassA2), result);
            Assert.Contains<Type>(typeof(ClassB2), result);
        }
    }
}