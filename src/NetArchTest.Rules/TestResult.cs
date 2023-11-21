using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using NetArchTest.Assemblies;

namespace NetArchTest.Rules
{
    /// <summary>
    /// Defines a result from a test carried out on a <see cref="ConditionList"/>.
    /// </summary>
    [DebuggerDisplay("FailingTypes = {FailingTypes.Count}")]
    public sealed class TestResult
    {   
        private TestResult()
        {
        }


        /// <summary>
        /// Gets a flag indicating the success or failure of the test.
        /// </summary>
        public bool IsSuccessful { get; private set; }

        /// <summary>
        /// Gets a list of the types that failed the test.
        /// </summary>
        /// <remarks>
        /// This method loads all the types and may throw dependency loading errors if the test project does not have a direct dependency on the type being loaded.
        /// </remarks>
        [DebuggerDisplay("[{FailingTypes.Count}]")]
        public IReadOnlyList<IType> FailingTypes { get; private set; } = Array.Empty<IType>();


        /// <summary>
        /// Creates a new instance of <see cref="TestResult"/> indicating a successful test.
        /// </summary>
        /// <returns>Instance of <see cref="TestResult"/></returns>
        internal static TestResult Success()
        {
            return new TestResult
            {
                IsSuccessful = true
            };
        }

        /// <summary>
        /// Creates a new instance of <see cref="TestResult"/> indicating a failed test.
        /// </summary>
        /// <returns>Instance of <see cref="TestResult"/></returns>
        internal static TestResult Failure(IEnumerable<TypeSpec> failingTypes)
        {
            return new TestResult
            {
                IsSuccessful = false,
                FailingTypes = failingTypes.Select(x => x.CreateWrapper()).ToArray()
            };
        }
    }
}