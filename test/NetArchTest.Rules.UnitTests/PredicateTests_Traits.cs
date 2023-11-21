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
                .InAssembly(Assembly.GetAssembly(typeof(StaticClass)))
                .That()
                .ResideInNamespace("NetArchTest.TestStructure.Traits")
                .And();
        }


        [Fact(DisplayName = "AreAbstract")]
        public void AreAbstract()
        {
            var result = GetTypesThat().AreAbstract().GetReflectionTypes();

            Assert.Single(result);
            Assert.Contains<Type>(typeof(AbstractClass), result);
        }

        [Fact(DisplayName = "AreNotAbstract")]
        public void AreNotAbstract()
        {
            var result = GetTypesThat().AreNotAbstract().GetReflectionTypes();

            Assert.Equal(4, result.Count());
            Assert.Contains<Type>(typeof(PlainClass), result);
            Assert.Contains<Type>(typeof(StaticClass), result);
        }

        [Fact(DisplayName = "AreGeneric")]
        public void AreGeneric()
        {
            var result = GetTypesThat().AreGeneric().GetReflectionTypes();

            Assert.Single(result);
            Assert.Contains<Type>(typeof(GenericClass<>), result);
        }

        [Fact(DisplayName = "AreNotGeneric")]
        public void AreNotGeneric()
        {
            var result = GetTypesThat().AreNotGeneric().GetReflectionTypes();

            Assert.Equal(4, result.Count());
            Assert.Contains<Type>(typeof(PlainClass), result);
            Assert.Contains<Type>(typeof(StaticClass), result);
        }

        [Fact(DisplayName = "AreSealed")]
        public void AreSealed()
        {
            var result = GetTypesThat().AreSealed().GetReflectionTypes();

            Assert.Single(result);
            Assert.Contains<Type>(typeof(SealedClass), result);
        }

        [Fact(DisplayName = "AreNotSealed")]
        public void AreNotSealed()
        {
            var result = GetTypesThat().AreNotSealed().GetReflectionTypes();

            Assert.Equal(4, result.Count());
            Assert.Contains<Type>(typeof(PlainClass), result);
            Assert.Contains<Type>(typeof(StaticClass), result);
        }

        [Fact(DisplayName = "AreStatic")]
        public void AreStatic()
        {
            var result = GetTypesThat().AreStatic().GetReflectionTypes();

            Assert.Single(result);
            Assert.Contains<Type>(typeof(StaticClass), result);
        }

        [Fact(DisplayName = "AreNotStatic")]
        public void AreNotStatic()
        {
            var result = GetTypesThat().AreNotStatic().GetReflectionTypes();

            Assert.Equal(4, result.Count());
            Assert.Contains<Type>(typeof(PlainClass), result);
            Assert.Contains<Type>(typeof(AbstractClass), result);
        }

    }
}