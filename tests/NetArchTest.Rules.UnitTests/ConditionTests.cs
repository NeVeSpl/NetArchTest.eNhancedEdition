using System;
using NetArchTest.TestStructure.CustomAttributes;
using NetArchTest.TestStructure.Inheritance;
using NetArchTest.TestStructure.Interfaces;
using NetArchTest.UnitTests.TestDoubles;
using NetArchTest.UnitTests.TestFixtures;
using Xunit;

namespace NetArchTest.UnitTests
{
    public class ConditionTests(AllTypesFixture fixture) : IClassFixture<AllTypesFixture>
    {
        [Fact(DisplayName = "HaveCustomAttribute")]
        public void HaveCustomAttribute()
        {
            var result = fixture.Types
                .That()
                .ResideInNamespace("NetArchTest.TestStructure.CustomAttributes")
                .And()
                .HaveName("AttributePresent")
                .Should()
                .HaveCustomAttribute(typeof(ClassCustomAttribute)).GetResult();

            Assert.True(result.IsSuccessful);
        }

        [Fact(DisplayName = "NotHaveCustomAttribute")]
        public void NotHaveCustomAttribute()
        {
            var result = fixture.Types
                .That()
                .ResideInNamespace("NetArchTest.TestStructure.CustomAttributes")
                .And()
                .DoNotHaveName("AttributePresent")
                .Should()
                .NotHaveCustomAttribute(typeof(ClassCustomAttribute)).GetResult();

            Assert.True(result.IsSuccessful);
        }

        [Fact(DisplayName = "HaveCustomAttributeOrInherit")]
        public void HaveCustomAttributeOrInherit()
        {
            var result = fixture.Types
                .That()
                .ResideInNamespace("NetArchTest.TestStructure.CustomAttributes")
                .And()
                .HaveName("InheritAttributePresent")
                .Should()
                .HaveCustomAttributeOrInherit(typeof(ClassCustomAttribute)).GetResult();

            Assert.True(result.IsSuccessful);
        }

        [Fact(DisplayName = "NotHaveCustomAttributeOrInherit")]
        public void NotHaveCustomAttributeOrInherit()
        {
            var result = fixture.Types
                .That()
                .ResideInNamespace("NetArchTest.TestStructure.CustomAttributes")
                .And()
                .DoNotHaveNameEndingWith("AttributePresent")
                .Should()
                .NotHaveCustomAttributeOrInherit(typeof(ClassCustomAttribute)).GetResult();

            Assert.True(result.IsSuccessful);
        }

        [Fact(DisplayName = "Inherit")]
        public void Inherit()
        {
            var result = fixture.Types
                .That()
                .ResideInNamespace("NetArchTest.TestStructure.Inheritance")
                .And()
                .HaveNameStartingWith("Derived")
                .Should()
                .Inherit(typeof(BaseClass)).GetResult();

            Assert.True(result.IsSuccessful);
        }

        [Fact(DisplayName = "NotInherit")]
        public void NotInherit()
        {
            var result = fixture.Types
                .That()
                .ResideInNamespace("NetArchTest.TestStructure.Inheritance")
                .And()
                .DoNotHaveNameStartingWith("Derived")
                .Should()
                .NotInherit(typeof(BaseClass)).GetResult();

            Assert.True(result.IsSuccessful);
        }

        [Fact(DisplayName = "ImplementInterface")]
        public void ImplementInterface()
        {
            var result = fixture.Types
                .That()
                .ResideInNamespace("NetArchTest.TestStructure.Interfaces")
                .And()
                .HaveNameStartingWith("Implements")
                .Should()
                .ImplementInterface(typeof(IExample)).GetResult();

            Assert.True(result.IsSuccessful);
        }

        [Fact(DisplayName = "NotImplementInterface")]
        public void NotImplementInterface()
        {
            var result = fixture.Types
                .That()
                .ResideInNamespace("NetArchTest.TestStructure.Interfaces")
                .And()
                .HaveNameStartingWith("DoesNotImplement")
                .Should()
                .NotImplementInterface(typeof(IExample)).GetResult();

            Assert.True(result.IsSuccessful);
        }

        [Fact(DisplayName = "MeetCustomRule")]
        public void MeetCustomRule()
        {
            // Create a custom rule that selected "ClassA1"
            var rule = new CustomRuleTestDouble(t => t.Name.Equals("ClassA2", StringComparison.InvariantCultureIgnoreCase));

            // This rule uses the custom rule to confirm that "ClassA1" has been selected
            var result = fixture.Types
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
