namespace NetArchTest.UnitTests.DependencySearch
{
    using System.Linq;
    using System.Reflection;
    using NetArchTest.Dependencies;
    using NetArchTest.Rules;
    using NetArchTest.TestStructure.Dependencies.Implementation;
    using NetArchTest.TestStructure.Dependencies.TypeOfSearch;
    using NetArchTest.TestStructure.Dependencies.TypeOfSearch.D1;
    using NetArchTest.TestStructure.Dependencies.TypeOfSearch.D2;
    using Xunit;

    [CollectionDefinition("Dependency Search - search type tests ")]
    public class DependencySearch_SearchTypeTests
    {
        [Theory(DisplayName = "A search for types with ANY dependencies returns types that have a dependency on at least one item in the list.")]
        [InlineData(new string[] { "NetArchTest.TestStructure.Dependencies.Examples.ExampleDependency", "NetArchTest.TestStructure.Dependencies.Examples.AnotherExampleDependency" }, "List contains two distinct dependencies.")]
        [InlineData(new string[] { "NetArchTest.TestStructure.Dependencies.Examples.ExampleDependency", "NetArchTest.TestStructure.Dependencies.Examples.AnotherExampleDependency", "NetArchTest.TestStructure.Dependencies" }, "List contains overlapping dependencies.")]
        [InlineData(new string[] { "NetArchTest.TestStructure.Dependencies" }, "List contains only ancestor namespace.")]
        [InlineData(new string[] { "NetArchTest.TestStructure.Dependencies", "NetArchTest.TestStructure.Dependencies" }, "List contains duplicated ancestor namespace.")]
        [InlineData(new string[] { "NetArchTest.TestStructure.Dependencies", "NetArchTest.TestStructure.Dependencies.Examples" }, "List contains overlapping namespaces.")]
#pragma warning disable xUnit1026 // Theory methods should use all of their parameters
        public void FindTypesWithAnyDependencies_Found(string[] dependecies, string comment)
#pragma warning restore xUnit1026 // Theory methods should use all of their parameters
        {
            // Arrange
            var search = new DependencySearch(false);
            var typeList = Types
                .InAssembly(Assembly.GetAssembly(typeof(HasDependency)))
                .That()
                .ResideInNamespace(typeof(HasDependency).Namespace)
                .GetTypeSpecifications();

            // Act
            var result = search.FindTypesThatHaveDependencyOnAny(typeList, dependecies).Where(x => x.IsPassing);

            // Assert
            Assert.Equal(3, result.Count()); // Three types found   
            Assert.Equal(typeof(HasAnotherDependency).FullName, result.First().FullName); // Correct types returned...
            Assert.Equal(typeof(HasDependencies).FullName, result.Skip(1).First().FullName);
            Assert.Equal(typeof(HasDependency).FullName, result.Last().FullName);
        }

        [Theory(DisplayName = "A search for types with ALL dependencies returns types that have a dependency on all the items in the list.")]
        [InlineData(new string[] { "NetArchTest.TestStructure.Dependencies.Examples.ExampleDependency", "NetArchTest.TestStructure.Dependencies.Examples.AnotherExampleDependency" }, "List contains two distinct dependencies.")]
        [InlineData(new string[] { "NetArchTest.TestStructure.Dependencies.Examples.ExampleDependency", "NetArchTest.TestStructure.Dependencies.Examples.AnotherExampleDependency", "NetArchTest.TestStructure.Dependencies" }, "List contains overlapping dependencies.")]      
        [InlineData(new string[] { "NetArchTest.TestStructure.Dependencies.Examples.ExampleDependency", "NetArchTest.TestStructure.Dependencies.Examples.AnotherExampleDependency", "NetArchTest.TestStructure.Dependencies.Examples.AnotherExampleDependency" }, "List contains duplicated dependencies.")]
        [InlineData(new string[] { "NetArchTest.TestStructure.Dependencies.Examples.ExampleDependency", "NetArchTest.TestStructure.Dependencies.Examples.AnotherExampleDependency", "NetArchTest.TestStructure.Dependencies", "NetArchTest.TestStructure.Dependencies.Examples" }, "List contains overlapping namespaces.")]
#pragma warning disable xUnit1026 // Theory methods should use all of their parameters
        public void FindTypesWithAllDependencies_Found(string[] dependecies, string comment)
#pragma warning restore xUnit1026 // Theory methods should use all of their parameters
        {
            // Arrange
            var search = new DependencySearch(false);
            var typeList = Types
                .InAssembly(Assembly.GetAssembly(typeof(HasDependency)))
                .That()
                .ResideInNamespace(typeof(HasDependency).Namespace)
                .GetTypeSpecifications();

            // Act
            var result = search.FindTypesThatHaveDependencyOnAll(typeList, dependecies).Where(x => x.IsPassing);

            // Assert
            Assert.Single(result); // One type found
            Assert.Equal(typeof(HasDependencies).FullName, result.First().FullName); // Correct type returned
        }

        [Fact(DisplayName = "A search for types with ANY dependencies returns types that have a dependency on at least one item in the list.")]
        public void FindTypesThatHaveDependencyOnAny_Found()
        {
            // Arrange
            var search = new DependencySearch(true);
            var typeList = Types
                .InAssembly(Assembly.GetAssembly(typeof(Class_A)))
                .That()
                .ResideInNamespace(typeof(Class_A).Namespace)
                .And()
                .HaveNameStartingWith("Class")
                .GetTypeSpecifications();

            // Act
            var result = search.FindTypesThatHaveDependencyOnAny(typeList, new string[] { typeof(Dependency_1).Namespace, typeof(Dependency_2).Namespace }).Where(x => x.IsPassing).ToList();

            // Assert           
            Assert.Equal(6, result.Count); 
            Assert.Equal(typeof(Class_C).FullName, result[0].FullName);
            Assert.Equal(typeof(Class_D).FullName, result[1].FullName);
            Assert.Equal(typeof(Class_E).FullName, result[2].FullName);
            Assert.Equal(typeof(Class_F).FullName, result[3].FullName);
            Assert.Equal(typeof(Class_G).FullName, result[4].FullName);
            Assert.Equal(typeof(Class_H).FullName, result[5].FullName);
        }

        [Fact(DisplayName = "A search for types with ALL dependencies returns types that have a dependency on all the items in the list.")]
        public void FindTypesThatHaveDependencyOnAll_Found()
        {
            // Arrange
            var search = new DependencySearch(false);
            var typeList = Types
                .InAssembly(Assembly.GetAssembly(typeof(Class_A)))
                .That()
                .ResideInNamespace(typeof(Class_A).Namespace)
                .And()
                .HaveNameStartingWith("Class")
                .GetTypeSpecifications();

            // Act
            var result = search.FindTypesThatHaveDependencyOnAll(typeList, new string[] { typeof(Dependency_1).FullName, typeof(Dependency_2).FullName }).Where(x => x.IsPassing).ToList();

            // Assert           
            Assert.Equal(2, result.Count); 
            Assert.Equal(typeof(Class_G).FullName, result[0].FullName);
            Assert.Equal(typeof(Class_H).FullName, result[1].FullName);           
        }

        [Fact(DisplayName = "A search for types with ANY or NONE dependencies returns types that may have a dependency on an item in the list, but cannot have a dependency that is not in the list.")]
        public void FindTypesThatOnlyHaveDependenciesOnAnyOrNone_Found()
        {
            // Arrange
            var search = new DependencySearch(true);
            var typeList = Types
                .InAssembly(Assembly.GetAssembly(typeof(Class_A)))
                .That()
                .ResideInNamespace(typeof(Class_A).Namespace)
                .And()
                .HaveNameStartingWith("Class")
                .GetTypeSpecifications();

            // Act
            var result = search.FindTypesThatOnlyHaveDependencyOnAnyOrNone(typeList, new string[] { typeof(Dependency_1).FullName, typeof(Dependency_2).FullName, "System" }).Where(x => x.IsPassing).ToList();

            // Assert           
            Assert.Equal(4, result.Count); 
            Assert.Equal(typeof(Class_A).FullName, result[0].FullName);
            Assert.Equal(typeof(Class_C).FullName, result[1].FullName);
            Assert.Equal(typeof(Class_E).FullName, result[2].FullName);
            Assert.Equal(typeof(Class_G).FullName, result[3].FullName);
        }

        [Fact(DisplayName = "A search for types with ANY dependencies returns types that have a dependency on at least one item in the list, but cannot have a dependency that is not in the list.")]
        public void FindTypesThatOnlyHaveDependenciesOnAny_Found()
        {
            // Arrange
            var search = new DependencySearch(false);
            var typeList = Types
                .InAssembly(Assembly.GetAssembly(typeof(Class_A)))
                .That()
                .ResideInNamespace(typeof(Class_A).Namespace)
                .And()
                .HaveNameStartingWith("Class")
                .GetTypeSpecifications();

            // Act
            var result = search.FindTypesThatOnlyHaveDependencyOnAny(typeList, new string[] { typeof(Dependency_1).FullName, typeof(Dependency_2).FullName, "System" }).Where(x => x.IsPassing).ToList();

            // Assert           
            Assert.Equal(4, result.Count); 
            Assert.Equal(typeof(Class_A).FullName, result[0].FullName);
            Assert.Equal(typeof(Class_C).FullName, result[1].FullName);
            Assert.Equal(typeof(Class_E).FullName, result[2].FullName);
            Assert.Equal(typeof(Class_G).FullName, result[3].FullName);
        }

        [Fact(DisplayName = "A search for types with ALL dependencies returns types that have a dependency on all the items in the list, but cannot have a dependency that is not in the list.")]
        public void FindTypesThatOnlyOnlyHaveDependenciesOnAll_Found()
        {
            // Arrange
            var search = new DependencySearch(false);
            var typeList = Types
                .InAssembly(Assembly.GetAssembly(typeof(Class_A)))
                .That()
                .ResideInNamespace(typeof(Class_A).Namespace)
                .And()
                .HaveNameStartingWith("Class")
                .GetTypeSpecifications();

            // Act
            var result = search.FindTypesThatOnlyOnlyHaveDependencyOnAll(typeList, new string[] { typeof(Dependency_1).FullName, typeof(Dependency_2).FullName, "System" }).Where(x => x.IsPassing).ToList();

            // Assert           
            Assert.Equal(1, result.Count);
            Assert.Equal(typeof(Class_G).FullName, result[0].FullName);          
        }
    }
}