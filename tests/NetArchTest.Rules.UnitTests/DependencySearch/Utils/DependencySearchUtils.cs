﻿namespace NetArchTest.UnitTests.DependencySearch
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using NetArchTest.Assemblies;
    using NetArchTest.Rules;
    using NetArchTest.TestStructure.Dependencies.Examples;
    using NetArchTest.UnitTests.TestFixtures;
    using Xunit;

    internal static class Utils
    {
        /// <summary>
        /// Run a generic test against a target type to ensure that a single dependency is picked up by the search.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="expectToFind"></param>
        public static void RunDependencyTest(AllTypesFixture fixture, Type input, bool expectToFind = true)
        {
            RunDependencyTest(fixture, input, typeof(ExampleDependency), expectToFind, expectToFind);
        }

        public static void RunDependencyTest(AllTypesFixture fixture, Type input, Type dependencyToSearch, bool expectToFindClass, bool expectToFindNamespace)
        {
            var subject = fixture.Types.That().HaveName(input.Name).GetTypeSpecifications();

            RunDependencyTest(fixture, subject, dependencyToSearch, expectToFindClass, expectToFindNamespace);
        }

        public static void RunDependencyTest(AllTypesFixture fixture, IEnumerable<TypeSpec> inputs, Type dependencyToSearch, bool expectToFindClass, bool expectToFindNamespace)
        {
            // Search against the type name and its namespace - this demonstrates that namespace based searches also work
            FindTypesWithAnyDependencies(inputs, new List<string> { dependencyToSearch.FullName }, expectToFindClass);
            FindTypesWithAnyDependencies(inputs, new List<string> { dependencyToSearch.Namespace }, expectToFindNamespace);
        }

        public static void RunDependencyTest(AllTypesFixture fixture, Type input, IEnumerable<string> dependenciesToSearch, bool expectToFind)
        {
            var subject = fixture.Types.That().HaveName(input.Name).GetTypeSpecifications();

            RunDependencyTest(subject, dependenciesToSearch, expectToFind);
        }

        public static void RunDependencyTest(IEnumerable<TypeSpec> inputs, IEnumerable<string> dependenciesToSearch, bool expectToFind)
        {
            FindTypesWithAnyDependencies(inputs, dependenciesToSearch, expectToFind);
        }
                
        public static IEnumerable<TypeSpec> GetTypesThatResideInTheSameNamespaceButWithoutGivenType(AllTypesFixture fixture, params Type[] type)
        {
            var types = fixture.Types
                     .That()
                     .ResideInNamespace(type.First().Namespace);
            foreach (var item in type)
            {
                types = types.And().DoNotHaveName(item.Name);
            }
            return types.GetTypeSpecifications();
        }

        private static void FindTypesWithAnyDependencies(IEnumerable<TypeSpec> subjects, IEnumerable<string> dependencies, bool expectToFind)
        {
            // Arrange
            var search = new global::NetArchTest.Dependencies.DependencySearch(false, true);

            // Act
            // Search against the dependencies
            var resultClass = search.FindTypesThatHaveDependencyOnAny(subjects, dependencies).Where(x => x.IsPassing).ToList();

            // Assert
            if (expectToFind)
            {
                Assert.Equal(subjects.Count(), resultClass.Count);
                Assert.Equal(subjects.First().FullName, resultClass.First().FullName); 
            }
            else
            {
                Assert.Equal(0, resultClass.Count); 
            }
        }
    }
}
