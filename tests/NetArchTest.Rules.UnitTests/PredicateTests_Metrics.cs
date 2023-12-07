using System;
using NetArchTest.TestStructure.Metrics;
using NetArchTest.UnitTests.TestFixtures;
using Xunit;
using static NetArchTest.Utils;

namespace NetArchTest.UnitTests
{
    public class PredicateTests_Metrics(AllTypesFixture fixture) : IClassFixture<AllTypesFixture>
    {

        [Fact(DisplayName = "HaveNumberOfLinesOfCodeLowerThan")]
        public void HaveNumberOfLinesOfCodeLowerThan()
        {
            var result = fixture.Types
                .That()
                .ResideInNamespace(namespaceof<ClassSmall>())
                .And()
                .HaveNumberOfLinesOfCodeLowerThan(13)
                .GetReflectionTypes();

            Assert.Single(result);
            Assert.Contains<Type>(typeof(ClassSmall), result);
        }

        [Fact(DisplayName = "HaveNumberOfLinesOfCodeGreaterThan")]
        public void HaveNumberOfLinesOfCodeGreaterThan()
        {
            var result = fixture.Types
                .That()
                .ResideInNamespace(namespaceof<ClassSmall>())
                .And()
                .HaveNumberOfLinesOfCodeGreaterThan(13)
                .GetReflectionTypes();

            Assert.Single(result);
            Assert.Contains<Type>(typeof(ClassLarge), result);
        }

    }
}
