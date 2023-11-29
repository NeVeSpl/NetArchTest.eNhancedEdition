using System;
using System.Linq;
using System.Reflection;
using NetArchTest.Rules;
using NetArchTest.TestStructure.Mutability;
using NetArchTest.TestStructure.NameMatching.Namespace1;
using NetArchTest.TestStructure.Nullable;
using NetArchTest.TestStructure.Stateless;
using Xunit;
using static NetArchTest.Utils;

namespace NetArchTest.UnitTests
{
    public class SpecialFixture
    {
        public Types Types { get; } = Types.InAssembly(Assembly.GetAssembly(typeof(ClassA1)));
    }



    public class PredicateTests_Special : IClassFixture<SpecialFixture>
    {
        SpecialFixture fixture;

        public PredicateTests_Special(SpecialFixture fixture)
        {
            this.fixture = fixture;
        }


        [Fact(DisplayName = "AreImmutable")]
        public void AreImmutable()
        {
            var result = fixture.Types                
                .That()
                .ResideInNamespace("NetArchTest.TestStructure.Mutability")
                .And()
                .AreImmutable().GetReflectionTypes();

            Assert.Equal(6, result.Count()); 
            Assert.Contains<Type>(typeof(ImmutableClass_PropertyOnlyGet), result);
            Assert.Contains<Type>(typeof(ImmutableClass_PropertyInit), result);
            Assert.Contains<Type>(typeof(ImmutableClass_FieldConst), result);
            Assert.Contains<Type>(typeof(ImmutableClass_FieldReadonly), result);
            Assert.Contains<Type>(typeof(ImmutableClass_FieldReadonlyPrivate), result);
            Assert.Contains<Type>(typeof(ImmutableRecord), result);
        }

        [Fact(DisplayName = "AreMutable")]
        public void AreMutable()
        {
            var result = fixture.Types                
                .That()
                .ResideInNamespace("NetArchTest.TestStructure.Mutability")
                .And()
                .AreMutable().GetReflectionTypes();

            Assert.Equal(6, result.Count()); 
            Assert.Contains<Type>(typeof(MutableClass_PublicProperty), result);
            Assert.Contains<Type>(typeof(MutableClass_PublicPropertyPrivateSet), result);
            Assert.Contains<Type>(typeof(MutableClass_PublicField), result);
            Assert.Contains<Type>(typeof(MutableClass_PrivateField), result);
            Assert.Contains<Type>(typeof(MutableClass_PublicEvent), result);
            Assert.Contains<Type>(typeof(MutableRecord), result);
        }

        [Fact(DisplayName = "AreImmutableExternally")]
        public void AreImmutableExternally()
        {
            var result = fixture.Types
                .That()
                .ResideInNamespace("NetArchTest.TestStructure.Mutability")
                .And()
                .AreImmutableExternally().GetReflectionTypes();

            Assert.Equal(8, result.Count());
            Assert.Contains<Type>(typeof(ImmutableClass_PropertyOnlyGet), result);
            Assert.Contains<Type>(typeof(ImmutableClass_PropertyInit), result);
            Assert.Contains<Type>(typeof(ImmutableClass_FieldConst), result);
            Assert.Contains<Type>(typeof(ImmutableClass_FieldReadonly), result);
            Assert.Contains<Type>(typeof(ImmutableClass_FieldReadonlyPrivate), result);
            Assert.Contains<Type>(typeof(ImmutableRecord), result);
            Assert.Contains<Type>(typeof(MutableClass_PublicPropertyPrivateSet), result);
            Assert.Contains<Type>(typeof(MutableClass_PrivateField), result);           
        }

        [Fact(DisplayName = "AreStateless")]
        public void AreStateless()
        {
            var result = fixture.Types
                .That()
                .ResideInNamespace(namespaceof<StatelessClass_StaticField>())
                .And()
                .AreStateless().GetReflectionTypes();

            Assert.Equal(4, result.Count());
            Assert.Contains<Type>(typeof(StatelessClass_StaticField), result);
            Assert.Contains<Type>(typeof(StatelessClass_ConstField), result);
            Assert.Contains<Type>(typeof(StatelessClass_StaticReadonlyField), result);
            Assert.Contains<Type>(typeof(StatelessClass_Prop), result);
        }

        [Fact(DisplayName = "AreStaticless")]
        public void AreStaticless()
        {
            var result = fixture.Types
                .That()
                .ResideInNamespace(namespaceof<StatelessClass_StaticField>())
                .And()
                .AreStaticless().GetReflectionTypes();

            Assert.Equal(6, result.Count());
    
            Assert.Contains<Type>(typeof(StatelessClass_ConstField), result);
            Assert.Contains<Type>(typeof(StatefulClass_Field), result);
            Assert.Contains<Type>(typeof(StatefulRecordClass), result);
            Assert.Contains<Type>(typeof(StatefulRecordStruct), result);
            Assert.Contains<Type>(typeof(StatefulClass_Prop), result);
            Assert.Contains<Type>(typeof(StatefulClass_ReadonlyField), result);
        }

        [Fact(DisplayName = "OnlyHaveNullableMembers")]
        public void OnlyHaveNullableMembers()
        {
            var result = fixture.Types
                .That()
                .ResideInNamespace("NetArchTest.TestStructure.Nullable")                
                .And()
                .OnlyHaveNullableMembers().GetReflectionTypes();

            Assert.Single(result);
            Assert.Contains<Type>(typeof(NullableClass), result);
        }

        [Fact(DisplayName = "HaveSomeNonNullableMembers")]
        public void HaveSomeNonNullableMembers()
        {
            var result = fixture.Types
                .That()
                .ResideInNamespace("NetArchTest.TestStructure.Nullable")
                .And()
                .AreNotNested()             
                .And()
                .HaveSomeNonNullableMembers().GetReflectionTypes();

            Assert.Equal(4, result.Count());
            Assert.Contains<Type>(typeof(NonNullableClass1), result);
            Assert.Contains<Type>(typeof(NonNullableClass2), result);
            Assert.Contains<Type>(typeof(NonNullableClass3), result);
            Assert.Contains<Type>(typeof(NonNullableClass4), result);
        }

        [Fact(DisplayName = "OnlyHaveNonNullableMembers")]
        public void OnlyHaveNonNullableMembers()
        {
            var result = fixture.Types
                .That()
                .ResideInNamespace("NetArchTest.TestStructure.Nullable")
                .And()
                .AreNotNested()
                .And()
                .OnlyHaveNonNullableMembers().GetReflectionTypes();

            Assert.Equal(2, result.Count());
            Assert.Contains<Type>(typeof(NonNullableClass3), result);
            Assert.Contains<Type>(typeof(NonNullableClass4), result);
        }
    }
}
