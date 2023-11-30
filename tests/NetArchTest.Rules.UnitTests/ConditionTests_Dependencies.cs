using NetArchTest.Rules;
using NetArchTest.TestStructure.Dependencies.Examples;
using NetArchTest.TestStructure.Dependencies.Implementation;
using NetArchTest.UnitTests.TestFixtures;
using Xunit;

namespace NetArchTest.UnitTests
{
    public class ConditionTests_Dependencies(DependenciesFixture fixture) : IClassFixture<DependenciesFixture>
    {
        private Predicate GetTypesThat()
        {
            return fixture.Types                
                .That()
                .ResideInNamespace(typeof(HasDependency).Namespace)
                .And();
        }


        [Fact(DisplayName = "Types can be selected if they have a dependency on a specific item.")]
        public void HaveDependencyOnAny()
        {
            var result = GetTypesThat()
                .HaveNameStartingWith("HasDepend")
                .Should()
                .HaveDependencyOnAny(typeof(ExampleDependency).FullName)
                .GetResult();

            Assert.True(result.IsSuccessful);
        }

        [Fact(DisplayName = "Types can be selected if they have a dependency on any item in a list.")]
        public void HaveDependencyOnAny_Many()
        {
            var result = GetTypesThat()
                .HaveNameStartingWith("Has")
                .Should()
                .HaveDependencyOnAny(new[] { typeof(ExampleDependency).FullName, typeof(AnotherExampleDependency).FullName })
                .GetResult();

            Assert.True(result.IsSuccessful);
        }

        [Fact(DisplayName = "Types can be selected if they have a dependency on all the items in a list.")]
        public void HaveDependencyOnAll()
        {
            var result = GetTypesThat()
                .HaveNameStartingWith("HasDependencies")
                .Should()
                .HaveDependencyOnAll(new[] { typeof(ExampleDependency).FullName, typeof(AnotherExampleDependency).FullName })
                .GetResult();

            Assert.True(result.IsSuccessful);
        }

        [Fact(DisplayName = "Types can be selected if they only have a dependency on any item in a list.")]
        public void HaveNameStartingWith()
        {
            var result = GetTypesThat()
                .HaveNameStartingWith("HasDependency")
                .Should()
                .OnlyHaveDependencyOn(new[] { typeof(ExampleDependency).FullName, "System" })
                .GetResult();

            Assert.True(result.IsSuccessful);
        }

        [Fact(DisplayName = "Types can be selected if they do not have a dependency on another type.")]
        public void NotHaveDependencyOnAny()
        {
            var result = GetTypesThat()
                .HaveNameStartingWith("NoDependency")
                .Should()
                .NotHaveDependencyOnAny(typeof(ExampleDependency).FullName)
                .GetResult();

            Assert.True(result.IsSuccessful);
        }

        [Fact(DisplayName = "Types can be selected if they do not have a dependency on any item in a list.")]
        public void NotHaveDependencyOnAny_Many()
        {
            var result = GetTypesThat()
                .HaveNameStartingWith("NoDependency")
                .Should()
                .NotHaveDependencyOnAny(new[] { typeof(ExampleDependency).FullName, typeof(AnotherExampleDependency).FullName })
                .GetResult();

            Assert.True(result.IsSuccessful);
        }

        [Fact(DisplayName = "Types can be selected if they do not have a dependency on all the items in a list.")]
        public void NotHaveDependencyOnAll()
        {
            var result = GetTypesThat()
                .HaveNameStartingWith("NoDependency")
                .Should()
                .NotHaveDependencyOnAll(new[] { typeof(ExampleDependency).FullName, typeof(AnotherExampleDependency).FullName })
                .GetResult();

            Assert.True(result.IsSuccessful);
        }

        [Fact(DisplayName = "Types can be selected if they have a dependency that is not on the a list.")]
        public void HaveDependencyOtherThan()
        {
            var result = GetTypesThat()
                .HaveNameStartingWith("HasDependencies")
                .Should()
                .HaveDependencyOtherThan(new[] { typeof(ExampleDependency).FullName, "System" })
                .GetResult();

            Assert.True(result.IsSuccessful);
        }


        [Fact(DisplayName = "BeUsedByAny")]
        public void BeUsedByAny()
        {
            var result = fixture.Types
                .That()
                .ResideInNamespace(typeof(ExampleDependency).Namespace)
                .And()
                .AreOfType(typeof(ExampleDependency), typeof(AnotherExampleDependency))
                .Should()
                .BeUsedByAny(typeof(HasDependencies).FullName, typeof(HasAnotherDependency).FullName)
                .GetResult();

            Assert.True(result.IsSuccessful);
        }

        [Fact(DisplayName = "NotBeUsedByAny")]
        public void NotBeUsedByAny()
        {
            var result = fixture.Types
                .That()
                .ResideInNamespace(typeof(ExampleDependency).Namespace)
                .And()
                .AreNotOfType(typeof(ExampleDependency), typeof(AnotherExampleDependency))
                .Should()
                .NotBeUsedByAny(typeof(HasDependencies).FullName, typeof(HasAnotherDependency).FullName)
                .GetResult();

            Assert.True(result.IsSuccessful);
        }
    }
}