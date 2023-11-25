using System.Reflection;
using MediatR;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetArchTest.Rules;
using SampleApp.ModuleOmega;


namespace NetArchTest.SampleTests
{
    [TestClass]
    public class SampleApp_ModuleOmega_Tests
    {
        static readonly Assembly AssemblyUnderTest = typeof(TestUtils).Assembly;

        [TestMethod]
        public void RequestHandlersShouldBeSealed()
        {            
            var result = Types.InAssembly(AssemblyUnderTest)
                              .That()
                              .ImplementInterface(typeof(IRequestHandler<,>))
                              .Should()
                              .BeSealed()
                              .GetResult();

            Assert.IsTrue(result.IsSuccessful);
        }
    }
}