using System;
using System.Linq;
using System.Reflection;
using NetArchTest.Rules;
using NetArchTest.TestStructure.Mutability;
using NetArchTest.TestStructure.NameMatching.Namespace1;
using NetArchTest.TestStructure.Nullable;
using Xunit;

namespace NetArchTest.UnitTests
{
    public class PredicateTests_Special
    {
        [Fact(DisplayName = "Types can be selected for being immutable.")]
        public void AreImmutable_MatchesFound_ClassSelected()
        {
            var result = Types
                .InAssembly(Assembly.GetAssembly(typeof(ClassA1)))
                .That()
                .ResideInNamespace("NetArchTest.TestStructure.Mutability")
                .And()
                .AreImmutable().GetReflectionTypes();

            Assert.Equal(4, result.Count()); // Three types found
            Assert.Contains<Type>(typeof(ImmutableClass1), result);
            Assert.Contains<Type>(typeof(ImmutableClass2), result);
            Assert.Contains<Type>(typeof(ImmutableClass3), result);
            Assert.Contains<Type>(typeof(ImmutableRecord1), result);
        }

        [Fact(DisplayName = "Types can be selected for being mutable.")]
        public void AreMutable_MatchesFound_ClassSelected()
        {
            var result = Types
                .InAssembly(Assembly.GetAssembly(typeof(ClassA1)))
                .That()
                .ResideInNamespace("NetArchTest.TestStructure.Mutability")
                .And()
                .AreMutable().GetReflectionTypes();

            Assert.Equal(3, result.Count()); // Three types found
            Assert.Contains<Type>(typeof(PartiallyMutableClass1), result);
            Assert.Contains<Type>(typeof(PartiallyMutableClass2), result);
            Assert.Contains<Type>(typeof(MutableClass), result);
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
                .AreClasses()
                .And()
                .OnlyHaveNullableMembers().GetReflectionTypes();

            Assert.Single(result); // One result
            Assert.Contains<Type>(typeof(NullableClass), result);
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
                .ArePublic()
                .And()
                .HaveSomeNonNullableMembers().GetReflectionTypes();

            Assert.Equal(4, result.Count()); // Four types found
            Assert.Contains<Type>(typeof(NonNullableClass1), result);
            Assert.Contains<Type>(typeof(NonNullableClass2), result);
            Assert.Contains<Type>(typeof(NonNullableClass3), result);
            Assert.Contains<Type>(typeof(NonNullableClass4), result);
        }
    }
}
