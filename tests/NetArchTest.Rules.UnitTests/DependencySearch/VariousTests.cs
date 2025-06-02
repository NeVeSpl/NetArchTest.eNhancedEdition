namespace NetArchTest.UnitTests.DependencySearch
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Rules;
    using NetArchTest.TestStructure.Dependencies.Example;
    using NetArchTest.TestStructure.Dependencies.Examples;
    using NetArchTest.TestStructure.Dependencies.Implementation;
    using NetArchTest.TestStructure.Dependencies.Search;
    using TestStructure.FalsePositives.NamespaceMatch;
    using TestFixtures;
    using Xunit;

    [CollectionDefinition("Dependency Search - various tests")]
    public class DependencySearchTests_Various(AllTypesFixture fixture) : IClassFixture<AllTypesFixture>
    {
        [Fact(DisplayName = "Does not find a dependency in an indirect reference.")]
        public void DependencySearch_IndirectReference_NotFound()
        {
            // NB: We only look for dependencies in the types being searched 
            Utils.RunDependencyTest(fixture, typeof(IndirectReference), false);
        }

        [Fact(DisplayName = "Does not find things that are not dependency at all")]
        public void DependencySearch_Garbage_NotFound()
        {
            Utils.RunDependencyTest(Utils.GetTypesThatResideInTheSameNamespaceButWithoutGivenType(fixture, typeof(IndirectReference)), new List<string> { "System.Object::.ctor()", "T", "T1", "T2", "ctor()", "!1)", "::.ctor(!0", "T1&", "T2&", "T1[]", "T2[]" }, false);            
        }

        [Fact(DisplayName = "Does not find a dependency that only partially matches actually referenced type.")]       
        public void DependencySearch_PartiallyMatchingDependency_NotFound()
        {
            var subjects = Utils.GetTypesThatResideInTheSameNamespaceButWithoutGivenType(fixture, typeof(IndirectReference), typeof(GenericMethodGenericParameter));
            Utils.RunDependencyTest(fixture, subjects,
                                    dependencyToSearch: typeof(ExampleDep),
                                    expectToFindClass: false,
                                    expectToFindNamespace: true);
        }

        [Fact(DisplayName = "Does not find a dependency from the namespace matching partially to the namespace of actually referenced type.")]       
        public void DependencySearch_PartiallyMatchingNamespace_NotFound()
        {
            Utils.RunDependencyTest(fixture, Utils.GetTypesThatResideInTheSameNamespaceButWithoutGivenType(fixture, typeof(IndirectReference)),
                                    dependencyToSearch: typeof(ExampleDependencyInPartiallyMatchingNamespace),
                                    expectToFindClass: false,
                                    expectToFindNamespace: false);
        }

        [Fact(DisplayName = "Does not find a dependency that differs only in case from actually referenced type.")]       
        public void DependencySearch_DependencyWithDifferentCaseOfCharacters_NotFound()
        {
            var subjects = Utils.GetTypesThatResideInTheSameNamespaceButWithoutGivenType(fixture, typeof(IndirectReference), typeof(GenericMethodGenericParameter));
            Utils.RunDependencyTest(fixture, subjects,
                                    dependencyToSearch: typeof(ExampleDEPENDENCY),
                                    expectToFindClass: false,
                                    expectToFindNamespace: true);
        }

        [Fact(DisplayName = "A dependency search will not return false positives for pattern matched classes.")]
        public void FindTypesWithAllDependencies_PatternMatchedClasses_NotReturned()
        {
            // In this example, searching for a dependency on "PatternMatch" should not return "PatternMatchTwo"

            // Arrange
            var search = new global::NetArchTest.Dependencies.DependencySearch(false);
            var typeList = fixture.Types
                .That()
                .HaveName("ClassMatchingExample")
                .GetTypeSpecifications();

            // Act
            var result = search.FindTypesThatHaveDependencyOnAll(typeList, new List<string> { typeof(PatternMatch).FullName }).Where(x => x.IsPassing);

            // Assert: Before PR#36 this would have returned PatternMatchToo in the results
            Assert.Empty(result); // No results returned
        }

        [Fact(DisplayName = "A dependency search will not return false positives for pattern matched namespaces.")]
        public void FindTypesWithAllDependencies_PatternMatchedNamespaces_NotReturned()
        {
            // In this example, searching for a dependency on "NamespaceMatch" should not return classes in "NamespaceMatchToo"

            // Arrange
            var search = new global::NetArchTest.Dependencies.DependencySearch(false);
            var typeList = fixture.Types
                .That()
                .HaveName("NamespaceMatchingExample")
                .GetTypeSpecifications();

            // Act
            var result = search.FindTypesThatHaveDependencyOnAll(typeList, new List<string> { typeof(PatternMatch).Namespace }).Where(t => t.IsPassing == true);

            // Assert: Before PR#36 this would have returned classes in NamespaceMatchToo in the results
            Assert.Empty(result); // No results returned
        }
    }
}