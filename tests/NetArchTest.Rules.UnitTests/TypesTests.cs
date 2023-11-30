using System.IO;
using System.Linq;
using System.Reflection;
using NetArchTest.Rules;
using Xunit;

namespace NetArchTest.UnitTests
{   
    public class TypesTests
    {
        [Fact(DisplayName = "System types should be excluded from the current domain.")]
        public void InCurrentDomain_SystemTypesExcluded()
        {
            var result = Types.InCurrentDomain().GetTypes();

            Assert.DoesNotContain(result, t => t.FullName.StartsWith("System.") || t.FullName.Equals("System"));
            Assert.DoesNotContain(result, t => t.FullName.StartsWith("Microsoft.") || t.FullName.Equals("Microsoft"));
            Assert.DoesNotContain(result, t => t.FullName.StartsWith("netstandard.") | t.FullName.Equals("netstandard"));           
        }
        
        [Fact(DisplayName = "Types that reside in namespace that has \"System\" prefix but is not system namespace should be included in the current domain. ")]
        public void InCurrentDomain_TypesWithPrefixSystemInclude()
        {          
            var result = Types.InCurrentDomain().GetTypes();

            Assert.Contains(result, t => t.FullName == typeof(SystemAsNamespacePrefix.ExampleClass).FullName);           
        }
        
        [Fact(DisplayName = "Types that reside in namespace that has \"Module\" prefix but is not <Module> namespace should be included in the current domain. ")]
        public void InCurrentDomain_TypesWithPrefixModuleInclude()
        {
            var type = typeof(ModuleAsNamespacePrefix.ExampleClass);
            var result = Types.InCurrentDomain().GetTypes();

            Assert.Contains(result, t => t.FullName == type.FullName);
        }
        
        [Fact(DisplayName = "<Module> types should be excluded from the current domain.")]
        public void InCurrentDomain_SystemTypesExcludedModule()
        {
            var result = Types.InCurrentDomain().GetTypes();
            Assert.DoesNotContain(result, t => t.FullName.StartsWith("<Module>") | t.FullName.Equals("<Module>"));
        }


      

        [Fact(DisplayName = "Nested public types should be included in the current domain.")]
        public void InCurrentDomain_NestedPublicTypesPresent_Returned()
        {
            var result = Types.InCurrentDomain().GetTypes();
            Assert.Contains(result, t => t.FullName.StartsWith("NetArchTest.TestStructure.AccessModifiers.PublicClass/PublicClassNested"));
        }

        [Fact(DisplayName = "Nested private types should be included in the current domain.")]
        public void InCurrentDomain_NestedPrivateTypesPresent_Returned()
        {
            var result = Types.InCurrentDomain().GetTypes();
            Assert.Contains(result, t => t.FullName.StartsWith("NetArchTest.TestStructure.AccessModifiers.PublicClass/PrivateClassNested"));
        }

       

        [Fact(DisplayName = "A types collection can be created from a filename.")]
        public void FromFile_TypesReturned()
        {
            // Arrange
            var expected = Types.InCurrentDomain().That().ResideInNamespace("NetArchTest.TestStructure").GetTypes().Count();

            // Act
            var result = Types.FromFile("NetArchTest.TestStructure.dll").That().ResideInNamespace("NetArchTest.TestStructure").GetTypes();

            // Assert
            Assert.Equal(expected, result.Count());
            Assert.All(result, r => r.FullName.StartsWith("NetArchTest.TestStructure"));
        }

        [Fact(DisplayName = "A types collection can be created from a path.")]
        public void FromPath_TypesReturned()
        {
            // Arrange
            var expected = Types.InCurrentDomain().That().ResideInNamespace("NetArchTest.TestStructure").GetTypes().Count();
            var dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            // Act
            var result = Types.FromPath(dir).That().ResideInNamespace("NetArchTest.TestStructure").GetTypes();

            // Assert
            Assert.Equal(expected, result.Count());
        }

        [Fact(DisplayName = "When loading a type a BadImageFormatException will be caught and an empty list will be returned.")]
        public void FromFile_BadImage_CaughtAndEmptyListReturned()
        {
            // Act
            var result = Types.FromFile("NetArchTest.TestStructure.pdb").GetTypes();

            // Assert
            Assert.Empty(result);
        }
    }
}