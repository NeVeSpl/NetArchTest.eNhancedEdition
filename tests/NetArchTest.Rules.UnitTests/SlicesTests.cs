using System.Linq;
using NetArchTest.Rules;
using NetArchTest.Slices;
using NetArchTest.UnitTests.TestFixtures;
using Xunit;

namespace NetArchTest.UnitTests
{
    public class SlicesTests(AllTypesFixture fixture) : IClassFixture<AllTypesFixture>
    {
        [Fact(DisplayName = "Types are divided correctly into slices for a valid tree")]
        public void TypesAreDividedCorrectlyIntoSlicesForValidTree()
        {
            var slicedTypes = (fixture.Types
                               .Slice()
                               .ByNamespacePrefix("NetArchTest.TestStructure.Slices.ValidTree") as SlicePredicateList).GetSlicedTypes();

            Assert.Equal(9, slicedTypes.TypeCount);
            Assert.Equal(3, slicedTypes.Slices.Count());
            Assert.Equal(5, slicedTypes.Slices.Where(x => x.Name == "NetArchTest.TestStructure.Slices.ValidTree.FeatureA").First().Types.Count());
            Assert.Equal(3, slicedTypes.Slices.Where(x => x.Name == "NetArchTest.TestStructure.Slices.ValidTree.FeatureB").First().Types.Count());
            Assert.Single(slicedTypes.Slices.Where(x => x.Name == "NetArchTest.TestStructure.Slices.ValidTree.FeatureC").First().Types);
        }


        [Fact(DisplayName = "Valid tree does not have dependencies between slices")]
        public void ValidTreeDoesNotHaveDependenciesBetweenSlices()
        {
            var testResult = fixture.Types
                               .Slice()
                               .ByNamespacePrefix("NetArchTest.TestStructure.Slices.ValidTree")
                               .Should()
                               .NotHaveDependenciesBetweenSlices()
                               .GetResult();

            Assert.True(testResult.IsSuccessful);
        }

        [Fact(DisplayName = "Invalid tree has dependencies between slices")]
        public void InvalidTreeHasDependenciesBetweenSlices()
        {
            var testResult = fixture.Types
                               .Slice()
                               .ByNamespacePrefix("NetArchTest.TestStructure.Slices.InvalidTree")
                               .Should()
                               .NotHaveDependenciesBetweenSlices()
                               .GetResult();

            Assert.False(testResult.IsSuccessful);
        }
    }
}