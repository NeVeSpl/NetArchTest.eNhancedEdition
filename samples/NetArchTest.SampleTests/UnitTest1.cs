using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetArchTest.Rules;

namespace NetArchTest.SampleTests
{
    [TestClass]
    public class SampleApp_ModuleAlpha_Tests
    {
        static readonly Assembly AssemblyUnderTest = typeof(SampleApp.ModuleAlpha.TestUtils).Assembly;

        [TestMethod]
        public void PersistenceIsNotAccessibleFromOutsideOfModuleExceptOfDbContext()
        {
            var result = Types.InAssembly(AssemblyUnderTest)
                              .That()
                              .ResideInNamespace("SampleApp.ModuleAlpha.Persistence")                              
                              .And()
                              .DoNotHaveNameEndingWith("DbContext")
                              .Should()
                              .NotBePublic()
                              .GetResult();
            Assert.IsTrue(result.IsSuccessful);
        }

        [TestMethod]
        public void DomainIsIndependent()
        {
            var result = Types.InAssembly(AssemblyUnderTest)
                              .That()
                              .ResideInNamespace("SampleApp.ModuleAlpha.Domain")
                              .ShouldNot()
                              .HaveDependencyOtherThan(
                                "System",
                                "SampleApp.ModuleAlpha.Domain",
                                "SampleApp.SharedKernel.Domain",
                                "SampleApp.BuildingBlocks.Domain"                              
                              )
                              .GetResult();
            Assert.IsTrue(result.IsSuccessful, "Domain has lost its independence!");
        }
    }
}