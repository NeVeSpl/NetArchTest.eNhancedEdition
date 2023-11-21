using System;
using System.Linq;
using System.Reflection;
using NetArchTest.CrossAssemblyTest.A;
using NetArchTest.CrossAssemblyTest.B;
using NetArchTest.Rules;
using NetArchTest.TestStructure.CustomAttributes;
using NetArchTest.TestStructure.Inheritance;
using NetArchTest.TestStructure.Interfaces;
using NetArchTest.TestStructure.Mutability;
using NetArchTest.TestStructure.NameMatching.Namespace1;
using NetArchTest.TestStructure.Nullable;
using NetArchTest.UnitTests.TestDoubles;
using Xunit;

namespace NetArchTest.UnitTests
{
    public partial class PredicateTests
    {
        [Fact(DisplayName = "Types can be selected by a the presence of a custom attribute.")]
        public void HaveCustomAttribute_MatchesFound_ClassesSelected()
        {
            var result = Types
                .InAssembly(Assembly.GetAssembly(typeof(ClassA1)))
                .That()
                .ResideInNamespace("NetArchTest.TestStructure.CustomAttributes")
                .And()
                .HaveCustomAttribute(typeof(ClassCustomAttribute)).GetReflectionTypes();

            Assert.Single(result); // One type found
            Assert.Contains<Type>(typeof(AttributePresent), result);
        }

        [Fact(DisplayName = "Types can be selected by the absence of a custom attribute.")]
        public void DoNotHaveCustomAttribute_MatchesFound_ClassesSelected()
        {
            var result = Types
                .InAssembly(Assembly.GetAssembly(typeof(ClassA1)))
                .That()
                .ResideInNamespace("NetArchTest.TestStructure.CustomAttributes")
                .And()
                .DoNotHaveCustomAttribute(typeof(ClassCustomAttribute)).GetReflectionTypes();

            Assert.Equal(4, result.Count()); // Four types found
            Assert.Contains<Type>(typeof(NoAttributes), result);
            Assert.Contains<Type>(typeof(ClassCustomAttribute), result);
            Assert.Contains<Type>(typeof(InheritAttributePresent), result);
            Assert.Contains<Type>(typeof(InheritClassCustomAttribute), result);
        }

        [Fact(DisplayName = "Types can be selected by the presence of an inherited custom attribute.")]
        public void HaveInheritCustomAttribute_MatchesFound_ClassesSelected()
        {
            var result = Types
                .InAssembly(Assembly.GetAssembly(typeof(ClassA1)))
                .That()
                .ResideInNamespace("NetArchTest.TestStructure.CustomAttributes")
                .And()
                .HaveCustomAttributeOrInherit(typeof(ClassCustomAttribute)).GetReflectionTypes();

            Assert.Equal(2, result.Count()); // Two types found
            Assert.Contains<Type>(typeof(AttributePresent), result);
            Assert.Contains<Type>(typeof(InheritAttributePresent), result);
        }

        [Fact(DisplayName = "Types can be selected by the absence of an inherited custom attribute.")]
        public void DoNotHaveInheritCustomAttribute_MatchesFound_ClassesSelected()
        {
            var result = Types
                .InAssembly(Assembly.GetAssembly(typeof(ClassA1)))
                .That()
                .ResideInNamespace("NetArchTest.TestStructure.CustomAttributes")
                .And()
                .DoNotHaveCustomAttributeOrInherit(typeof(ClassCustomAttribute)).GetReflectionTypes();

            Assert.Equal(3, result.Count()); // Three types found
            Assert.Contains<Type>(typeof(NoAttributes), result);
            Assert.Contains<Type>(typeof(ClassCustomAttribute), result);          
            Assert.Contains<Type>(typeof(InheritClassCustomAttribute), result);
        }



        [Fact(DisplayName = "Types can be selected if they inherit from a type.")]
        public void Inherit_MatchesFound_ClassesSelected()
        {
            var result = Types
                .InAssembly(Assembly.GetAssembly(typeof(ClassA1)))
                .That()
                .ResideInNamespace("NetArchTest.TestStructure.Inheritance")
                .And()
                .Inherit(typeof(BaseClass)).GetReflectionTypes();

            Assert.Equal(2, result.Count()); // Two types found
            Assert.Contains<Type>(typeof(DerivedClass), result);
            Assert.Contains<Type>(typeof(DerivedDerivedClass), result);
        }

        [Fact(DisplayName = "Types can be selected if they inherit from a type from a different assembly")]
        public void Inherit_MatchesFound_ClassesSelected_AcrossAssemblies()
        {
            var result = Types
                .InAssembly(Assembly.GetAssembly(typeof(DerivedClassFromB)))
                .That()
                .Inherit(typeof(BaseClassFromA))
                .GetReflectionTypes();

            Assert.Equal(2, result.Count());
            Assert.Contains(typeof(DerivedClassFromB), result);
            Assert.Contains(typeof(AnotherDerivedClassFromB), result);
        }

        [Fact(DisplayName = "Types can be selected if they do not inherit from a type.")]
        public void DoNotInherit_MatchesFound_ClassesSelected()
        {
            var result = Types
                .InAssembly(Assembly.GetAssembly(typeof(ClassA1)))
                .That()
                .ResideInNamespace("NetArchTest.TestStructure.Inheritance")
                .And()
                .DoNotInherit(typeof(BaseClass)).GetReflectionTypes();

            Assert.Equal(2, result.Count()); // Two types found
            Assert.Contains<Type>(typeof(BaseClass), result);
            Assert.Contains<Type>(typeof(NotDerivedClass), result);
        }

        [Fact(DisplayName = "Types can be selected if they implement an interface.")]
        public void ImplementInterface_MatchesFound_ClassesSelected()
        {
            var result = Types
                .InAssembly(Assembly.GetAssembly(typeof(ClassA1)))
                .That()
                .ResideInNamespace("NetArchTest.TestStructure.Interfaces")
                .And()
                .ImplementInterface(typeof(IExample)).GetReflectionTypes();

            Assert.Single(result); // One type found
            Assert.Contains<Type>(typeof(ImplementsExampleInterface), result);
        }

        [Fact(DisplayName = "Types can be selected if they do not implement an interface.")]
        public void DoNotImplementInterface_MatchesFound_ClassesSelected()
        {
            var result = Types
                .InAssembly(Assembly.GetAssembly(typeof(ClassA1)))
                .That()
                .ResideInNamespace("NetArchTest.TestStructure.Interfaces")
                .And()
                .DoNotImplementInterface(typeof(IExample)).GetReflectionTypes();

            Assert.Equal(2, result.Count()); // Two types found
            Assert.Contains<Type>(typeof(IExample), result);
            Assert.Contains<Type>(typeof(DoesNotImplementInterface), result);
        }

      

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


       

        [Fact(DisplayName = "Types can be selected according to a custom rule.")]
        public void MeetCustomRule_MatchesFound_ClassSelected()
        {
            // Create a custom rule that selects "ClassA1"
            var rule = new CustomRuleTestDouble(t => t.Name.Equals("ClassA1", StringComparison.InvariantCultureIgnoreCase));

            // Use the custom rule
            var result = Types
                .InAssembly(Assembly.GetAssembly(typeof(ClassA1)))
                .That()
                .MeetCustomRule(rule)
                .GetReflectionTypes();

            // ClassA1 has been returned
            Assert.Single(result);
            Assert.Equal<Type>(typeof(ClassA1), result.First());

            // The custom rule was executed at least once
            Assert.True(rule.TestMethodCalled);
        }
    }
}