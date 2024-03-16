using System;
using System.Linq;
using System.Reflection;
using Mono.Cecil;
using NetArchTest.CrossAssemblyTest.A;
using NetArchTest.CrossAssemblyTest.B;
using NetArchTest.Rules;
using NetArchTest.TestStructure.CustomAttributes;
using NetArchTest.TestStructure.CustomAttributes.Attributes;
using NetArchTest.TestStructure.Inheritance;
using NetArchTest.TestStructure.Interfaces;
using NetArchTest.TestStructure.NameMatching.Namespace1;
using NetArchTest.TestStructure.NameMatching.Namespace2;
using NetArchTest.UnitTests.TestDoubles;
using NetArchTest.UnitTests.TestFixtures;
using Xunit;
using static NetArchTest.Utils;

namespace NetArchTest.UnitTests
{
    public partial class PredicateTests(AllTypesFixture fixture) : IClassFixture<AllTypesFixture>
    {
        [Fact(DisplayName = "HaveCustomAttribute")]
        public void HaveCustomAttribute()
        {
            var result = fixture.Types                
                .That()
                .ResideInNamespace(namespaceof<AttributePresent>())
                .And()
                .HaveCustomAttribute(typeof(ClassCustomAttribute))
                .GetReflectionTypes();

            Assert.Single(result);
            Assert.Contains<Type>(typeof(AttributePresent), result);
        }

        [Fact(DisplayName = "HaveCustomAttribute_Nested")]
        public void HaveCustomAttribute_Nested()
        {
            var result = fixture.Types
                .That()
                .ResideInNamespace(namespaceof<AttributePresent>())
                .And()
                .HaveCustomAttribute(typeof(ClassCustomAttribute.ClassNestedCustomAttribute.ClassNestedNestedCustomAttribute))
                .GetReflectionTypes();

            Assert.Single(result);
            Assert.Contains<Type>(typeof(AttributePresent), result);
        }

        [Fact(DisplayName = "HaveCustomAttribute_Generic_Unbound")]
        public void HaveCustomAttribute_Generic_Unbound()
        {
            var result = fixture.Types
                .That()
                .ResideInNamespace(namespaceof<AttributePresent>())
                .And()              
                .HaveCustomAttribute(typeof(GenericCustomAttribute<>))
                .GetReflectionTypes();

            Assert.Single(result);
            Assert.Contains<Type>(typeof(AttributePresent), result);
        }

        [Fact(DisplayName = "HaveCustomAttribute_Generic_Closed")]
        public void HaveCustomAttribute_Generic_Closed()
        {
            var result = fixture.Types
                .That()
                .ResideInNamespace(namespaceof<AttributePresent>())
                .And()
                .HaveCustomAttribute(typeof(GenericCustomAttribute<int>))
                .GetReflectionTypes();

            Assert.Single(result);
            Assert.Contains<Type>(typeof(AttributePresent), result);
        }

        [Fact(DisplayName = "HaveCustomAttribute_FromDifferentAssembly")]
        public void HaveCustomAttribute_FromDifferentAssembly()
        {
            var result = fixture.Types
                .That()
                .ResideInNamespace(namespaceof<AttributePresent>())
                .And()
                .HaveCustomAttribute(typeof(ClassCustomAttributeFromA))
                .GetReflectionTypes();

            Assert.Single(result);
            Assert.Contains<Type>(typeof(AttributePresent), result);
        }       

        [Fact(DisplayName = "DoNotHaveCustomAttribute")]
        public void DoNotHaveCustomAttribute()
        {
            var result = fixture.Types
                .That()
                .ResideInNamespace(namespaceof<AttributePresent>())
                .And()
                .DoNotHaveCustomAttribute(typeof(ClassCustomAttribute)).GetReflectionTypes();

            Assert.Equal(7, result.Count()); 
            Assert.Contains<Type>(typeof(NoAttributes), result);
            Assert.Contains<Type>(typeof(ClassCustomAttribute), result);
            Assert.Contains<Type>(typeof(InheritAttributePresent), result);
            Assert.Contains<Type>(typeof(InheritClassCustomAttribute), result);
        }

        [Fact(DisplayName = "HaveCustomAttributeOrInherit")]
        public void HaveCustomAttributeOrInherit()
        {
            var result = fixture.Types
                .That()
                .ResideInNamespace(typeof(AttributePresent).Namespace)
                .And()
                .HaveCustomAttributeOrInherit(typeof(ClassCustomAttribute)).GetReflectionTypes();

            Assert.Equal(2, result.Count()); 
            Assert.Contains<Type>(typeof(AttributePresent), result);
            Assert.Contains<Type>(typeof(InheritAttributePresent), result);
        }

        [Fact(DisplayName = "HaveCustomAttributeOrInheri_FromDifferentAssemblyt")]
        public void HaveCustomAttributeOrInheri_FromDifferentAssemblyt()
        {
            var result = fixture.Types
                .That()
                .ResideInNamespace(typeof(AttributePresent).Namespace)
                .And()
                .HaveCustomAttributeOrInherit(typeof(ClassCustomAttributeFromA)).GetReflectionTypes();

            Assert.Equal(2, result.Count());
            Assert.Contains<Type>(typeof(AttributePresent), result);
            Assert.Contains<Type>(typeof(InheritAttributePresent), result);
        }



        [Fact(DisplayName = "DoNotHaveCustomAttributeOrInherit")]
        public void DoNotHaveCustomAttributeOrInherit()
        {
            var result = fixture.Types
                .That()
                .ResideInNamespace(typeof(AttributePresent).Namespace)
                .And()
                .DoNotHaveCustomAttributeOrInherit(typeof(ClassCustomAttribute)).GetReflectionTypes();

            Assert.Equal(6, result.Count());
            Assert.Contains<Type>(typeof(NoAttributes), result);
            Assert.Contains<Type>(typeof(ClassCustomAttribute), result);          
            Assert.Contains<Type>(typeof(InheritClassCustomAttribute), result);
        }

        [Fact(DisplayName = "Inherit - Types can be selected if they inherit from a type.")]
        public void Inherit()
        {
            var result = fixture.Types
                .That()
                .ResideInNamespace("NetArchTest.TestStructure.Inheritance")
                .And()
                .Inherit(typeof(BaseClass)).GetReflectionTypes();

            Assert.Equal(2, result.Count());
            Assert.Contains<Type>(typeof(DerivedClass<>), result);
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
            var result = fixture.Types
                .That()
                .ResideInNamespace("NetArchTest.TestStructure.Inheritance")
                .And()
                .DoNotInherit(typeof(BaseClass)).GetReflectionTypes();

            Assert.Equal(2, result.Count());
            Assert.Contains<Type>(typeof(BaseClass), result);
            Assert.Contains<Type>(typeof(NotDerivedClass), result);
        }


        [Fact(DisplayName = "AreInheritedByAnyType")]
        public void AreInheritedByAnyType()
        {
            var result = fixture.Types
                .That()
                .ResideInNamespace("NetArchTest.TestStructure.Inheritance")
                .And()
                .AreInheritedByAnyType().GetReflectionTypes();

            Assert.Equal(2, result.Count());
            Assert.Contains<Type>(typeof(BaseClass), result);           
            Assert.Contains<Type>(typeof(DerivedClass<>), result);
        }

        [Fact(DisplayName = "AreNotInheritedByAnyType")]
        public void AreNotInheritedByAnyType()
        {
            var result = fixture.Types
                .That()
                .ResideInNamespace("NetArchTest.TestStructure.Inheritance")
                .And()
                .AreNotInheritedByAnyType().GetReflectionTypes();

            Assert.Equal(2, result.Count());
            Assert.Contains<Type>(typeof(DerivedDerivedClass), result);
            Assert.Contains<Type>(typeof(NotDerivedClass), result);
        }


        [Fact(DisplayName = "ImplementInterface")]
        public void ImplementInterface()
        {
            var result = fixture.Types
                .That()
                .ResideInNamespace("NetArchTest.TestStructure.Interfaces")
                .And()
                .ImplementInterface(typeof(IExample)).GetReflectionTypes();

            Assert.Equal(3, result.Count());
            Assert.Contains<Type>(typeof(ImplementsExampleInterface), result);
            Assert.Contains<Type>(typeof(IGenericExample<>), result);
            Assert.Contains<Type>(typeof(ImplementsGenericExampleInterface), result);
        }

        [Fact(DisplayName = "ImplementInterface_OpenGeneric")]
        public void ImplementInterface_OpenGeneric()
        {
            var result = fixture.Types
                .That()
                .ResideInNamespace("NetArchTest.TestStructure.Interfaces")
                .And()
                .ImplementInterface(typeof(IGenericExample<>))
                .GetReflectionTypes();

            Assert.Equal(1, result.Count());          
            Assert.Contains<Type>(typeof(ImplementsGenericExampleInterface), result);
        }

        [Fact(DisplayName = "DoNotImplementInterface")]
        public void DoNotImplementInterface()
        {
            var result = fixture.Types
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
            var rule = new CustomRuleTestDouble(t => t.Name.Equals("ClassA3", StringComparison.InvariantCultureIgnoreCase));

            // Use the custom rule
            var result = fixture.Types
                .That()
                .MeetCustomRule(rule)
                .GetReflectionTypes();

            // ClassA1 has been returned
            Assert.Single(result);
            Assert.Equal<Type>(typeof(ClassA3), result.First());

            // The custom rule was executed at least once
            Assert.True(rule.TestMethodCalled);
        }

        [Fact(DisplayName = "MeetCustomRule2")]
        public void MeetCustomRule2()
        {
            // Create a custom rule that selects "ClassA1"
            Func <TypeDefinition, CustomRuleResult> rule = t => new CustomRuleResult(t.Name.Equals("ClassA3", StringComparison.InvariantCultureIgnoreCase), "yup");

            // Use the custom rule
            var result = fixture.Types
                .That()
                .MeetCustomRule(rule)
                .GetTypes();
               

            // ClassA1 has been returned
            Assert.Single(result);

            var first = result.First();

            Assert.Equal<Type>(typeof(ClassA3), first.ReflectionType);
            Assert.Equal("yup", first.Explanation);

            
        }
    }
}