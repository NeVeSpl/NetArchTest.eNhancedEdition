﻿using System.Linq;
using System.Reflection;
using NetArchTest.Rules;
using NetArchTest.TestStructure.File;
using NetArchTest.TestStructure.File.Correct;
using NetArchTest.TestStructure.File.Incorrect.Yabadabado;
using NetArchTest.TestStructure.NameMatching.Namespace1;
using NetArchTest.TestStructure.Stateless;
using Xunit;
using static NetArchTest.Utils;

namespace NetArchTest.UnitTests
{
    public class ConditionTests_Special
    {
        [Fact(DisplayName = "BeImmutable")]
        public void BeImmutable()
        {
            var result = Types
                .InAssembly(Assembly.GetAssembly(typeof(ClassA1)))
                .That()
                .ResideInNamespace("NetArchTest.TestStructure.Mutability")
                .And()
                .HaveNameStartingWith("Immutable")
                .Should()
                .BeImmutable().GetResult();

            Assert.True(result.IsSuccessful);
        }

        [Fact(DisplayName = "BeMutable")]
        public void BeMutable()
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

        [Fact(DisplayName = "BeImmutableExternally")]
        public void BeImmutableExternally()
        {
            var result = Types
                .InAssembly(Assembly.GetAssembly(typeof(ClassA1)))
                .That()
                .ResideInNamespace("NetArchTest.TestStructure.Mutability")
                .And()
                .HaveNameStartingWith("Immutable")
                .Or()
                .HaveName("MutableClass_PublicPropertyPrivateSet", "MutableClass_PrivateField")
                .Should()
                .BeImmutableExternally().GetResult();

            Assert.True(result.IsSuccessful);
        }


        [Fact(DisplayName = "BeStateless")]
        public void BeStateless()
        {
            var result = Types
                .InAssembly(Assembly.GetAssembly(typeof(StatelessClass_StaticField)))
                .That()
                .ResideInNamespace(namespaceof<StatelessClass_StaticField>())
                .And()
                .HaveNameStartingWith("Stateless")
                .Should()
                .BeStateless().GetResult();

            Assert.True(result.IsSuccessful);
        }

        [Fact(DisplayName = "OnlyHaveNullableMembers")]
        public void OnlyHaveNullableMembers()
        {
            var result = Types
                .InAssembly(Assembly.GetAssembly(typeof(ClassA1)))
                .That()
                .ResideInNamespace("NetArchTest.TestStructure.Nullable")
                .And()
                .AreNotNested() 
                .And()
                .DoNotHaveNameStartingWith("NonNullableClass")
                .Should()
                .OnlyHaveNullableMembers().GetResult();

            Assert.True(result.IsSuccessful);
        }

        [Fact(DisplayName = "HaveSomeNonNullableMembers")]
        public void HaveSomeNonNullableMembers()
        {
            var result = Types
                .InAssembly(Assembly.GetAssembly(typeof(ClassA1)))
                .That()
                .ResideInNamespace("NetArchTest.TestStructure.Nullable")
                .And()
                .AreNotNested()
                .And()
                .DoNotHaveNameStartingWith("NullableClass")
                .Should()
                .HaveSomeNonNullableMembers().GetResult();

            Assert.True(result.IsSuccessful);
        }

        [Fact(DisplayName = "OnlyHaveNonNullableMembers")]
        public void OnlyHaveNonNullableMembers()
        {
            var result = Types
                .InAssembly(Assembly.GetAssembly(typeof(ClassA1)))
                .That()
                .ResideInNamespace("NetArchTest.TestStructure.Nullable")
                .And()
                .AreNotNested()
                .And()
                .DoNotHaveNameStartingWith("NonNullableClass1", "NonNullableClass2", "NullableClass")
                .Should()
                .OnlyHaveNonNullableMembers().GetResult();

            Assert.True(result.IsSuccessful);
        }


        [Fact(DisplayName = "HaveFileNameMatchingTypeName_Should")]
        public void HaveFileNameMatchingTypeName_Should()
        {
            var result = Types
                .InAssembly(Assembly.GetAssembly(typeof(SourceFileNameType)))
                .That()
                .ResideInNamespace(namespaceof<SourceFileNameType>())
                .And()
                .DoNotHaveNameStartingWith("Incorrect")
                .Should()
                .HaveSourceFileNameMatchingName().GetResult();

            Assert.True(result.IsSuccessful);
        }

        [Fact(DisplayName = "HaveFileNameMatchingTypeName_ShouldNot")]
        public void HaveFileNameMatchingTypeName_ShouldNot()
        {
            var result = Types
                .InAssembly(Assembly.GetAssembly(typeof(SourceFileNameType)))
                .That()
                .ResideInNamespace(namespaceof<SourceFileNameType>())
                .And()
                .HaveNameStartingWith("Incorrect")
                .ShouldNot()
                .HaveSourceFileNameMatchingName().GetResult();

            Assert.True(result.IsSuccessful);
        }


        [Fact(DisplayName = "HaveSourceFilePathMatchingTypeNamespace_Should")]
        public void HaveSourceFilePathMatchingTypeNamespace_Should()
        {
            var result = Types
                .InAssembly(Assembly.GetAssembly(typeof(SourceFileNameType)))
                .That()
                .ResideInNamespace(namespaceof<SourceFileNameType>())
                .And()
                .ResideInNamespaceContaining(@"\.Correct")
                .Should()
                .HaveSourceFilePathMatchingNamespace().GetResult();

            Assert.True(result.IsSuccessful);
        }

        [Fact(DisplayName = "HaveSourceFilePathMatchingTypeNamespace_ShouldNot")]
        public void HaveSourceFilePathMatchingTypeNamespace_ShouldNot()
        {
            var result = Types
                .InAssembly(Assembly.GetAssembly(typeof(SourceFileNameType)))
                .That()
                .ResideInNamespace(namespaceof<SourceFileNameType>())
                .And()
                .ResideInNamespaceContaining(".Incorrect")
                .ShouldNot()
                .HaveSourceFilePathMatchingNamespace().GetResult();

            Assert.True(result.IsSuccessful);
        }

        [Fact(DisplayName = "HaveMatchingTypeWithName_Should")]
        public void HaveMatchingTypeWithName_Should()
        {
            var result = Types
                .InAssembly(Assembly.GetAssembly(typeof(SourceFileNameType)))
                .That()
                .AreOfType(typeof(CorrectSourceFileNameType))
                .Should()
                .HaveMatchingTypeWithName(x => x.Name + "Tests").GetResult();

            Assert.True(result.IsSuccessful);
        }

        [Fact(DisplayName = "HaveMatchingTypeWithName_ShouldNot")]
        public void HaveMatchingTypeWithName_ShouldNot()
        {
            var result = Types
                .InAssembly(Assembly.GetAssembly(typeof(SourceFileNameType)))
                .That()               
                .AreNotOfType(typeof(CorrectSourceFileNameType))
                .ShouldNot()
                .HaveMatchingTypeWithName(x => x.Name + "Tests").GetResult();

            Assert.True(result.IsSuccessful);
        }
    }
}
