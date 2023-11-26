using System;
using System.Linq;
using System.Reflection;
using NetArchTest.Rules;
using NetArchTest.TestStructure.Dependencies.Examples;
using NetArchTest.TestStructure.Dependencies.Implementation;
using Xunit;

namespace NetArchTest.UnitTests
{
    public class DependenciesFixture
    {
        public Types Types { get; } = Types.InAssembly(Assembly.GetAssembly(typeof(HasDependency)));
    }


    public class PredicateTests_Dependencies : IClassFixture<DependenciesFixture>
    {
        DependenciesFixture fixture;

        public PredicateTests_Dependencies(DependenciesFixture fixture)
        {
            this.fixture = fixture;
        }



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
                .HaveDependencyOnAny(typeof(ExampleDependency).FullName)
                .GetReflectionTypes();

            Assert.Equal(2, result.Count());
            Assert.Equal<Type>(typeof(HasDependencies), result.First());
            Assert.Equal<Type>(typeof(HasDependency), result.Last());
        }

        [Fact(DisplayName = "Types can be selected if they have a dependency on any item in a list.")]
        public void HaveDependencyOnAny_Many()
        {
            var result = GetTypesThat()
                .HaveDependencyOnAny(new[] { typeof(ExampleDependency).FullName, typeof(AnotherExampleDependency).FullName })
                .GetReflectionTypes();

            Assert.Equal(3, result.Count()); 
            Assert.Equal<Type>(typeof(HasAnotherDependency), result.First());
            Assert.Equal<Type>(typeof(HasDependencies), result.Skip(1).First());
            Assert.Equal<Type>(typeof(HasDependency), result.Last());
        }

        [Fact(DisplayName = "Types can be selected if they have a dependency on all the items in a list.")]
        public void HaveDependencyOnAll()
        {
            var result = GetTypesThat()
                .HaveDependencyOnAll(new[] { typeof(ExampleDependency).FullName, typeof(AnotherExampleDependency).FullName })
                .GetReflectionTypes();

            Assert.Single(result); 
            Assert.Equal<Type>(typeof(HasDependencies), result.First());
        }

        [Fact(DisplayName = "Types can be selected if they only have a dependency on any item in a list.")]
        public void OnlyHaveDependencyOn()
        {
            var result = GetTypesThat()
                .OnlyHaveDependencyOn(new[] { typeof(ExampleDependency).FullName, "System" })
                .GetReflectionTypes();

            Assert.Equal(2, result.Count());
            Assert.Equal<Type>(typeof(HasDependency), result.First());
            Assert.Equal<Type>(typeof(NoDependency), result.Skip(1).First());
        }

        [Fact(DisplayName = "Types can be selected if they do not have a dependency on another type.")]
        public void DoNotHaveDependencyOnAny()
        {
            var result = GetTypesThat()
                .DoNotHaveDependencyOnAny(typeof(ExampleDependency).FullName)
                .GetReflectionTypes();

            Assert.Equal(2, result.Count());
            Assert.Equal<Type>(typeof(HasAnotherDependency), result.First());
            Assert.Equal<Type>(typeof(NoDependency), result.Last());
        }

        [Fact(DisplayName = "Types can be selected if they do not have a dependency on any item in a list.")]
        public void DoNotHaveDependencyOnAny_Many()
        {
            var result = GetTypesThat()
                .DoNotHaveDependencyOnAny(new[] { typeof(ExampleDependency).FullName, typeof(AnotherExampleDependency).FullName })
                .GetReflectionTypes();

            Assert.Single(result); 
            Assert.Equal<Type>(typeof(NoDependency), result.First()); 
        }

        [Fact(DisplayName = "Types can be selected if they do not have a dependency on all the items in a list.")]
        public void DoNotHaveDependencyOnAll()
        {
            var result = GetTypesThat()
                .DoNotHaveDependencyOnAll(new[] { typeof(ExampleDependency).FullName, typeof(AnotherExampleDependency).FullName })
                .GetReflectionTypes();

            Assert.Equal(3, result.Count());
            Assert.Equal<Type>(typeof(HasAnotherDependency), result.First());
            Assert.Equal<Type>(typeof(HasDependency), result.Skip(1).First());
            Assert.Equal<Type>(typeof(NoDependency), result.Last());
        }

        [Fact(DisplayName = "Types can be selected if they do not have a dependency on any item in a list.")]
        public void HaveDependencyOtherThan()
        {
            var result = GetTypesThat()
                .HaveDependencyOtherThan(new[] { typeof(ExampleDependency).FullName, "System" })
                .GetReflectionTypes();

            Assert.Equal(2, result.Count());
            Assert.Equal<Type>(typeof(HasAnotherDependency), result.First());
            Assert.Equal<Type>(typeof(HasDependencies), result.Skip(1).First());
        }
    }
}