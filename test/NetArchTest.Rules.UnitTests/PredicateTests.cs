using System;
using System.Linq;
using System.Reflection;
using NetArchTest.CrossAssemblyTest.A;
using NetArchTest.CrossAssemblyTest.B;
using NetArchTest.Rules;
using NetArchTest.TestStructure.CustomAttributes;
using NetArchTest.TestStructure.Inheritance;
using NetArchTest.TestStructure.Interfaces;
using NetArchTest.TestStructure.NameMatching.Namespace1;
using NetArchTest.UnitTests.TestDoubles;
using Xunit;
using static NetArchTest.Utils;

namespace NetArchTest.UnitTests
{
    public partial class PredicateTests
    {
        [Fact(DisplayName = "HaveCustomAttribute")]
        public void HaveCustomAttribute()
        {
            var result = Types
                .InAssembly(Assembly.GetAssembly(typeof(AttributePresent)))
                .That()
                .ResideInNamespace(namespaceof<AttributePresent>())
                .And()
                .HaveCustomAttribute(typeof(ClassCustomAttribute)).GetReflectionTypes();

            Assert.Single(result);
            Assert.Contains<Type>(typeof(AttributePresent), result);
        }

        [Fact(DisplayName = "DoNotHaveCustomAttribute")]
        public void DoNotHaveCustomAttribute()
        {
            var result = Types
                .InAssembly(Assembly.GetAssembly(typeof(AttributePresent)))
                .That()
                .ResideInNamespace(namespaceof<AttributePresent>())
                .And()
                .DoNotHaveCustomAttribute(typeof(ClassCustomAttribute)).GetReflectionTypes();

            Assert.Equal(4, result.Count()); 
            Assert.Contains<Type>(typeof(NoAttributes), result);
            Assert.Contains<Type>(typeof(ClassCustomAttribute), result);
            Assert.Contains<Type>(typeof(InheritAttributePresent), result);
            Assert.Contains<Type>(typeof(InheritClassCustomAttribute), result);
        }

        [Fact(DisplayName = "HaveCustomAttributeOrInherit")]
        public void HaveCustomAttributeOrInherit()
        {
            var result = Types
                .InAssembly(Assembly.GetAssembly(typeof(AttributePresent)))
                .That()
                .ResideInNamespace(typeof(AttributePresent).Namespace)
                .And()
                .HaveCustomAttributeOrInherit(typeof(ClassCustomAttribute)).GetReflectionTypes();

            Assert.Equal(2, result.Count()); 
            Assert.Contains<Type>(typeof(AttributePresent), result);
            Assert.Contains<Type>(typeof(InheritAttributePresent), result);
        }

        [Fact(DisplayName = "DoNotHaveCustomAttributeOrInherit")]
        public void DoNotHaveCustomAttributeOrInherit()
        {
            var result = Types
                .InAssembly(Assembly.GetAssembly(typeof(AttributePresent)))
                .That()
                .ResideInNamespace(typeof(AttributePresent).Namespace)
                .And()
                .DoNotHaveCustomAttributeOrInherit(typeof(ClassCustomAttribute)).GetReflectionTypes();

            Assert.Equal(3, result.Count());
            Assert.Contains<Type>(typeof(NoAttributes), result);
            Assert.Contains<Type>(typeof(ClassCustomAttribute), result);          
            Assert.Contains<Type>(typeof(InheritClassCustomAttribute), result);
        }

        [Fact(DisplayName = "Inherit - Types can be selected if they inherit from a type.")]
        public void Inherit()
        {
            var result = Types
                .InAssembly(Assembly.GetAssembly(typeof(ClassA1)))
                .That()
                .ResideInNamespace("NetArchTest.TestStructure.Inheritance")
                .And()
                .Inherit(typeof(BaseClass)).GetReflectionTypes();

            Assert.Equal(2, result.Count());
            Assert.Contains<Type>(typeof(DerivedClass), result);
            Assert.Contains<Type>(typeof(DerivedDerivedClass), result);
        }

        [Fact(DisplayName = "Inherit - Types can be selected if they inherit from a type from a different assembly")]
        public void Inherit_AcrossAssemblies()
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

        [Fact(DisplayName = "DoNotInherit")]
        public void DoNotInherit()
        {
            var result = Types
                .InAssembly(Assembly.GetAssembly(typeof(ClassA1)))
                .That()
                .ResideInNamespace("NetArchTest.TestStructure.Inheritance")
                .And()
                .DoNotInherit(typeof(BaseClass)).GetReflectionTypes();

            Assert.Equal(2, result.Count());
            Assert.Contains<Type>(typeof(BaseClass), result);
            Assert.Contains<Type>(typeof(NotDerivedClass), result);
        }

        [Fact(DisplayName = "ImplementInterface")]
        public void ImplementInterface()
        {
            var result = Types
                .InAssembly(Assembly.GetAssembly(typeof(ClassA1)))
                .That()
                .ResideInNamespace("NetArchTest.TestStructure.Interfaces")
                .And()
                .ImplementInterface(typeof(IExample)).GetReflectionTypes();

            Assert.Single(result); 
            Assert.Contains<Type>(typeof(ImplementsExampleInterface), result);
        }

        [Fact(DisplayName = "DoNotImplementInterface")]
        public void DoNotImplementInterface()
        {
            var result = Types
                .InAssembly(Assembly.GetAssembly(typeof(ClassA1)))
                .That()
                .ResideInNamespace("NetArchTest.TestStructure.Interfaces")
                .And()
                .DoNotImplementInterface(typeof(IExample)).GetReflectionTypes();

            Assert.Equal(2, result.Count());
            Assert.Contains<Type>(typeof(IExample), result);
            Assert.Contains<Type>(typeof(DoesNotImplementInterface), result);
        }

        [Fact(DisplayName = "MeetCustomRule")]
        public void MeetCustomRule()
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