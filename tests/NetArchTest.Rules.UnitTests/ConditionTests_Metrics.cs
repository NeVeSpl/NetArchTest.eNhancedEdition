using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetArchTest.TestStructure.Metrics;
using NetArchTest.UnitTests.TestFixtures;
using Xunit;

namespace NetArchTest.UnitTests
{
    public class ConditionTests_Metrics(AllTypesFixture fixture) : IClassFixture<AllTypesFixture>
    {

        [Fact(DisplayName = "HaveNumberOfLinesOfCodeLowerThan")]
        public void HaveNumberOfLinesOfCodeLowerThan()
        {
            var result = fixture.Types
                .That()
                .ResideInNamespace(typeof(ClassSmall).Namespace)
                .And()
                .AreOfType(typeof(ClassSmall))
                .Should()
                .HaveNumberOfLinesOfCodeLowerThan(13).GetResult();

            Assert.True(result.IsSuccessful);
        }


        [Fact(DisplayName = "HaveNumberOfLinesOfCodeGreaterThan")]
        public void HaveNumberOfLinesOfCodeGreaterThan()
        {
            var result = fixture.Types
                .That()
                .ResideInNamespace(typeof(ClassSmall).Namespace)
                .And()
                .AreOfType(typeof(ClassLarge))
                .Should()
                .HaveNumberOfLinesOfCodeGreaterThan(13).GetResult();

            Assert.True(result.IsSuccessful);
        }
    }
}
