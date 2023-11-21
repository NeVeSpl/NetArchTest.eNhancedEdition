using System;
using System.Reflection;
using NetArchTest.Rules;
using NetArchTest.TestStructure.CustomAttributes;
using NetArchTest.TestStructure.Inheritance;
using NetArchTest.TestStructure.Interfaces;
using NetArchTest.TestStructure.NameMatching.Namespace1;
using NetArchTest.UnitTests.TestDoubles;
using Xunit;

namespace NetArchTest.UnitTests
{
    public class ConditionTests
    {
        [Fact(DisplayName = "Types can be selected by a the presence of a custom attribute.")]
        public void HaveCustomAttribute_MatchesFound_ClassesSelected()
        {
            var result = Types
                .InAssembly(Assembly.GetAssembly(typeof(ClassA1)))
                .That()
                .ResideInNamespace("NetArchTest.TestStructure.CustomAttributes")
                .And()
                .HaveName("AttributePresent")
                .Should()
                .HaveCustomAttribute(typeof(ClassCustomAttribute)).GetResult();

            Assert.True(result.IsSuccessful);
        }

        [Fact(DisplayName = "Types can be selected by the absence of a custom attribute.")]
        public void NotHaveCustomAttribute_MatchesFound_ClassesSelected()
        {
            var result = Types
                .InAssembly(Assembly.GetAssembly(typeof(ClassA1)))
                .That()
                .ResideInNamespace("NetArchTest.TestStructure.CustomAttributes")
                .And()
                .DoNotHaveName("AttributePresent")
                .Should()
                .NotHaveCustomAttribute(typeof(ClassCustomAttribute)).GetResult();

            Assert.True(result.IsSuccessful);
        }

        [Fact(DisplayName = "Types can be selected by a the presence of an inherited custom attribute.")]
        public void HaveInheritCustomAttribute_MatchesFound_ClassesSelected()
        {
            var result = Types
                .InAssembly(Assembly.GetAssembly(typeof(ClassA1)))
                .That()
                .ResideInNamespace("NetArchTest.TestStructure.CustomAttributes")
                .And()
                .HaveName("InheritAttributePresent")
                .Should()
                .HaveCustomAttributeOrInherit(typeof(ClassCustomAttribute)).GetResult();

            Assert.True(result.IsSuccessful);
        }

        [Fact(DisplayName = "Types can be selected by the absence of an inherited custom attribute.")]
        public void NotHaveInheritCustomAttribute_MatchesFound_ClassesSelected()
        {
            var result = Types
                .InAssembly(Assembly.GetAssembly(typeof(ClassA1)))
                .That()
                .ResideInNamespace("NetArchTest.TestStructure.CustomAttributes")
                .And()
                .DoNotHaveNameEndingWith("AttributePresent")
                .Should()
                .NotHaveCustomAttributeOrInherit(typeof(ClassCustomAttribute)).GetResult();

            Assert.True(result.IsSuccessful);
        }




        [Fact(DisplayName = "Types can be selected if they inherit from a type.")]
        public void Inherit_MatchesFound_ClassesSelected()
        {
            var result = Types
                .InAssembly(Assembly.GetAssembly(typeof(ClassA1)))
                .That()
                .ResideInNamespace("NetArchTest.TestStructure.Inheritance")
                .And()
                .HaveNameStartingWith("Derived")
                .Should()
                .Inherit(typeof(BaseClass)).GetResult();

            Assert.True(result.IsSuccessful);
        }

        [Fact(DisplayName = "Types can be selected if they do not inherit from a type.")]
        public void NotInherit_MatchesFound_ClassesSelected()
        {
            var result = Types
                .InAssembly(Assembly.GetAssembly(typeof(ClassA1)))
                .That()
                .ResideInNamespace("NetArchTest.TestStructure.Inheritance")
                .And()
                .DoNotHaveNameStartingWith("Derived")
                .Should()
                .NotInherit(typeof(BaseClass)).GetResult();

            Assert.True(result.IsSuccessful);
        }

        [Fact(DisplayName = "Types can be selected if they implement an interface.")]
        public void ImplementInterface_MatchesFound_ClassesSelected()
        {
            var result = Types
                .InAssembly(Assembly.GetAssembly(typeof(ClassA1)))
                .That()
                .ResideInNamespace("NetArchTest.TestStructure.Interfaces")
                .And()
                .HaveNameStartingWith("Implements")
                .Should()
                .ImplementInterface(typeof(IExample)).GetResult();

            Assert.True(result.IsSuccessful);
        }

        [Fact(DisplayName = "Types can be selected if they do not implement an interface.")]
        public void NotImplementInterface_MatchesFound_ClassesSelected()
        {
            var result = Types
                .InAssembly(Assembly.GetAssembly(typeof(ClassA1)))
                .That()
                .ResideInNamespace("NetArchTest.TestStructure.Interfaces")
                .And()
                .DoNotHaveNameStartingWith("Implements")
                .Should()
                .NotImplementInterface(typeof(IExample)).GetResult();

            Assert.True(result.IsSuccessful);
        }

      

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

       

        [Fact(DisplayName = "Types can be selected according to a custom rule.")]
        public void MeetCustomRule_MatchesFound_ClassSelected()
        {
            // Create a custom rule that selected "ClassA1"
            var rule = new CustomRuleTestDouble(t => t.Name.Equals("ClassA2", StringComparison.InvariantCultureIgnoreCase));

            // This rule uses the custom rule to confirm that "ClassA1" has been selected
            var result = Types
                .InAssembly(Assembly.GetAssembly(typeof(ClassA1)))
                .That()
                .HaveName("ClassA2")
                .Should()
                .MeetCustomRule(rule)
                .GetResult();

            // The custom rule selected the right class
            Assert.True(result.IsSuccessful);

            // The custom rule was executed at least once
            Assert.True(rule.TestMethodCalled);
        }
    }
}
