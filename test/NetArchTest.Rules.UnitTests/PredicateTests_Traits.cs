using System;
using System.Linq;
using System.Reflection;
using NetArchTest.Rules;
using NetArchTest.TestStructure.Traits;
using Xunit;

namespace NetArchTest.UnitTests
{
    public class PredicateTests_Traits
    {
        private Predicate GetTypesThat()
        {
            return Types
                .InAssembly(Assembly.GetAssembly(typeof(ExampleStaticClass)))
                .That()
                .ResideInNamespace("NetArchTest.TestStructure.Traits")
                .And();
        }




        [Fact(DisplayName = "AreStatic")]
        public void AreStatic()
        {
            var result = GetTypesThat().AreStatic().GetReflectionTypes();

            Assert.Single(result);
            Assert.Contains<Type>(typeof(ExampleStaticClass), result);
        }

        [Fact(DisplayName = "AreNotStatic")]
        public void AreNotStatic()
        {
            var result = GetTypesThat().AreNotStatic().GetReflectionTypes();

            Assert.Equal(0, result.Count());
            //Assert.Contains<Type>(typeof(ExampleClass), result);
            //Assert.Contains<Type>(typeof(IExampleInterface), result);
        }
    }
}
