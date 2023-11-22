using System;
using System.Linq;
using System.Reflection;
using NetArchTest.Rules;
using NetArchTest.TestStructure.AccessModifiers;
using Xunit;
using static NetArchTest.Utils;

namespace NetArchTest.UnitTests
{
    public class PredicateTests_AccessModifiers
    {
        private Predicate GetTypesThat()
        {
            return Types
                .InAssembly(Assembly.GetAssembly(typeof(PublicClass)))
                .That()
                .ResideInNamespace(namespaceof<PublicClass>())
                .And();
        }


        [Fact(DisplayName = "AreInternal")]
        public void AreInternal()
        {
            var result = GetTypesThat().AreInternal().GetReflectionTypes();

            Assert.Equal(3, result.Count());
            Assert.Contains<Type>(typeof(InternalClass), result);
            Assert.Contains<Type>(typeof(InternalClass.InternalClassNested), result);
            Assert.Contains<Type>(typeof(PublicClass.InternalClassNested), result);
        }

        [Fact(DisplayName = "AreNotInternal")]
        public void AreNotInternal()
        {
            var result = GetTypesThat().AreNotInternal().GetReflectionTypes();

            Assert.Equal(11, result.Count());
            Assert.Contains<Type>(typeof(PublicClass), result);
        }

        [Fact(DisplayName = "AreNested")]
        public void AreNested()
        {
            var result = GetTypesThat().AreNested().GetReflectionTypes();

            Assert.Equal(12, result.Count());
            Assert.Contains<Type>(typeof(PublicClass.PublicClassNested), result);
            Assert.Contains<Type>(typeof(InternalClass.PublicClassNested), result);
            Assert.Contains<Type>(typeof(InternalClass.InternalClassNested), result);
        }

        [Fact(DisplayName = "AreNotNested")]
        public void AreNotNested()
        {
            var result = GetTypesThat().AreNotNested().GetReflectionTypes();

            Assert.Equal(2, result.Count());
            Assert.Contains<Type>(typeof(PublicClass), result);
            Assert.Contains<Type>(typeof(InternalClass), result);
        }

        [Fact(DisplayName = "ArePrivate")]
        public void ArePrivate()
        {
            var result = GetTypesThat().ArePrivate().GetReflectionTypes();

            Assert.Equal(2, result.Count());
            Assert.Equal("PrivateClassNested", result.First().Name);
        }

        [Fact(DisplayName = "AreNotPrivate")]
        public void AreNotPrivate()
        {
            var result = GetTypesThat().AreNotPrivate().GetReflectionTypes();

            Assert.Equal(12, result.Count());
        }

        [Fact(DisplayName = "ArePrivateProtected")]
        public void ArePrivateProtected()
        {
            var result = GetTypesThat().ArePrivateProtected().GetReflectionTypes();

            Assert.Equal(2, result.Count());
            Assert.Equal("PrivateProtectedClassNested", result.First().Name);
        }

        [Fact(DisplayName = "AreNotPrivateProtected")]
        public void AreNotPrivateProtected()
        {
            var result = GetTypesThat().AreNotPrivateProtected().GetReflectionTypes();

            Assert.Equal(12, result.Count());
        }

        [Fact(DisplayName = "AreProtected")]
        public void AreProtected()
        {
            var result = GetTypesThat().AreProtected().GetReflectionTypes();

            Assert.Equal(2, result.Count());
            Assert.Equal("ProtectedClassNested", result.First().Name);
        }

        [Fact(DisplayName = "AreNotProtected")]
        public void AreNotProtected()
        {
            var result = GetTypesThat().AreNotProtected().GetReflectionTypes();

            Assert.Equal(12, result.Count());
        }

        [Fact(DisplayName = "AreProtectedInternal")]
        public void AreProtectedInternal()
        {
            var result = GetTypesThat().AreProtectedInternal().GetReflectionTypes();

            Assert.Equal(2, result.Count());
            Assert.Equal("ProtectedInternalClassNested", result.First().Name);
        }

        [Fact(DisplayName = "AreNotProtectedInternal")]
        public void AreNotProtectedInternal()
        {
            var result = GetTypesThat().AreNotProtectedInternal().GetReflectionTypes();

            Assert.Equal(12, result.Count());
        }

        [Fact(DisplayName = "ArePublic")]
        public void ArePublic()
        {
            var result = GetTypesThat().ArePublic().GetReflectionTypes();

            Assert.Equal(3, result.Count());
            Assert.Contains<Type>(typeof(PublicClass), result);
            Assert.Contains<Type>(typeof(PublicClass.PublicClassNested), result);
            Assert.Contains<Type>(typeof(InternalClass.PublicClassNested), result);
        }

        [Fact(DisplayName = "AreNotPublic")]
        public void AreNotPublic()
        {
            var result = GetTypesThat().AreNotPublic().GetReflectionTypes();

            Assert.Equal(11, result.Count());
            Assert.Contains<Type>(typeof(InternalClass), result);
            Assert.Contains<Type>(typeof(InternalClass.InternalClassNested), result);
        }
    }
}