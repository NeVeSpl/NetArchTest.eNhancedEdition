﻿using System;
using System.Linq;
using System.Reflection;
using NetArchTest.Rules;
using NetArchTest.TestStructure.Types;
using Xunit;

namespace NetArchTest.UnitTests
{
    public class PredicateTests_Types
    {
        private Predicate GetTypesThat()
        {
            return Types
                .InAssembly(Assembly.GetAssembly(typeof(ExampleClass)))
                .That()
                .ResideInNamespace("NetArchTest.TestStructure.Types")
                .And();
        }


        [Fact(DisplayName = "AreClasses")]
        public void AreClasses()
        {
            var result = GetTypesThat().AreClasses().GetReflectionTypes();

            Assert.Equal(3, result.Count());
            Assert.Contains<Type>(typeof(ExampleClass), result);
            Assert.Contains<Type>(typeof(ExampleRecordClass), result);
            Assert.Contains<Type>(typeof(ExampleStaticClass), result);
        }

        [Fact(DisplayName = "AreNotClasses")]
        public void AreNotClasses()
        {
            var result = GetTypesThat().AreNotClasses().GetReflectionTypes();

            Assert.Equal(5, result.Count());
            Assert.Contains<Type>(typeof(IExampleInterface), result);
        }

        [Fact(DisplayName = "AreStructures")]
        public void AreStructuresd()
        {
            var result = GetTypesThat().AreStructures().GetReflectionTypes();

            Assert.Equal(2, result.Count());
            Assert.Contains<Type>(typeof(ExampleStruct), result);
            Assert.Contains<Type>(typeof(ExampleRecordStruct), result);
        }

        [Fact(DisplayName = "AreNotStructures")]
        public void AreNotStructures()
        {
            var result = GetTypesThat().AreNotStructures().GetReflectionTypes();

            Assert.Equal(6, result.Count());
            Assert.Contains<Type>(typeof(ExampleClass), result);
            Assert.Contains<Type>(typeof(ExampleDelegate), result);
            Assert.Contains<Type>(typeof(ExampleEnum), result);
            Assert.Contains<Type>(typeof(IExampleInterface), result);
        }

        [Fact(DisplayName = "AreInterfaces")]
        public void AreInterfaces()
        {
            var result = GetTypesThat().AreInterfaces().GetReflectionTypes();

            Assert.Single(result); 
            Assert.Contains<Type>(typeof(IExampleInterface), result);
        }

        [Fact(DisplayName = "AreNotInterfaces")]
        public void AreNotInterfaces()
        {
            var result = GetTypesThat().AreNotInterfaces().GetReflectionTypes();

            Assert.Equal(7, result.Count());
            Assert.Contains<Type>(typeof(ExampleClass), result);
            Assert.Contains<Type>(typeof(ExampleStaticClass), result);
        }

        [Fact(DisplayName = "AreEnums")]
        public void AreEnums()
        {
            var result = GetTypesThat().AreEnums().GetReflectionTypes();

            Assert.Single(result);
            Assert.Contains<Type>(typeof(ExampleEnum), result);          
        }

        [Fact(DisplayName = "AreNotEnums")]
        public void AreNotEnums()
        {
            var result = GetTypesThat().AreNotEnums().GetReflectionTypes();

            Assert.Equal(7, result.Count());
            Assert.Contains<Type>(typeof(ExampleStruct), result);
            Assert.Contains<Type>(typeof(ExampleRecordStruct), result);
        }

        [Fact(DisplayName = "AreDelegates")]
        public void AreDelegates()
        {
            var result = GetTypesThat().AreDelegates().GetReflectionTypes();

            Assert.Single(result);
            Assert.Contains<Type>(typeof(ExampleDelegate), result);
        }

        [Fact(DisplayName = "AreNotDelegates")]
        public void AreNotDelegates()
        {
            var result = GetTypesThat().AreNotDelegates().GetReflectionTypes();

            Assert.Equal(7, result.Count());
            Assert.Contains<Type>(typeof(ExampleClass ), result);
            Assert.Contains<Type>(typeof(ExampleStaticClass), result);
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

            Assert.Equal(7, result.Count());
            Assert.Contains<Type>(typeof(ExampleClass), result);
            Assert.Contains<Type>(typeof(IExampleInterface), result);
        }
    }
}