using NetArchTest.TestStructure.File;
using NetArchTest.TestStructure.File.Incorrect.Yabadabado;
using NetArchTest.TestStructure.Stateless;
using NetArchTest.UnitTests.TestFixtures;
using Xunit;
using static NetArchTest.Utils;

namespace NetArchTest.UnitTests
{
    public class ConditionTests_Special(SpecialFixture fixture) : IClassFixture<SpecialFixture>
    {
        [Fact(DisplayName = "BeImmutable")]
        public void BeImmutable()
        {
            var result = fixture.Types               
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
            var result = fixture.Types
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
            var result = fixture.Types
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
            var result = fixture.Types
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
            var result = fixture.Types
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
            var result = fixture.Types
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
            var result = fixture.Types
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
            var result = fixture.Types
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
            var result = fixture.Types
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
            var result = fixture.Types
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
            var result = fixture.Types
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
            var result = fixture.Types
                .That()
                .AreOfType(typeof(CorrectSourceFileNameType))
                .Should()
                .HaveMatchingTypeWithName(x => x.Name + "Tests").GetResult();

            Assert.True(result.IsSuccessful);
        }

        [Fact(DisplayName = "HaveMatchingTypeWithName_ShouldNot")]
        public void HaveMatchingTypeWithName_ShouldNot()
        {
            var result = fixture.Types
                .That()               
                .AreNotOfType(typeof(CorrectSourceFileNameType))
                .ShouldNot()
                .HaveMatchingTypeWithName(x => x.Name + "Tests").GetResult();

            Assert.True(result.IsSuccessful);
        }

        [Fact(DisplayName = "HavePublicConstructor")]
        public void HavePublicConstructor()
        {
            var result = fixture.Types
                .That()
                .ResideInNamespace("NetArchTest.TestStructure.Constructors")
                .And()
                .HaveNameStartingWith("Public", "Default")
                .Should()
                .HavePublicConstructor().GetResult();

            Assert.True(result.IsSuccessful);
        }

        [Fact(DisplayName = "DoNotHavePublicConstructor")]
        public void NotHavePublicConstructor()
        {
            var result = fixture.Types
                .That()
                .ResideInNamespace("NetArchTest.TestStructure.Constructors")
                .And()
                .DoNotHaveNameStartingWith("Public", "Default")
                .Should()
                .NotHavePublicConstructor().GetResult();

            Assert.True(result.IsSuccessful);
        }

        [Fact(DisplayName = "HaveParameterlessConstructor")]
        public void HaveParameterlessConstructor()
        {
            var result = fixture.Types
                .That()
                .ResideInNamespace("NetArchTest.TestStructure.Constructors")
                .And()
                .DoNotHaveNameEndingWith("Argument")
                .Should()
                .HaveParameterlessConstructor().GetResult();

            Assert.True(result.IsSuccessful);
        }

        [Fact(DisplayName = "NotHaveParameterlessConstructor")]
        public void NotHaveParameterlessConstructor()
        {
            var result = fixture.Types
                .That()
                .ResideInNamespace("NetArchTest.TestStructure.Constructors")
                .And()
                .HaveNameEndingWith("Argument")
                .Should()
                .NotHaveParameterlessConstructor().GetResult();

            Assert.True(result.IsSuccessful);
        }
    }
}
