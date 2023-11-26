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
    [DebuggerDisplay("LoadedTypes = {LoadedTypes.Count}, SelectedTypesForTesting = {SelectedTypesForTesting.Count},  FailingTypes = {FailingTypes.Count}")]
    public sealed class TestResult
    {
        //private readonly IEnumerable<TypeSpec> loadedTypes;
        //private readonly IEnumerable<TypeSpec> selectedTypes;
        //private readonly IEnumerable<TypeSpec> failingTypes;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly Lazy<IReadOnlyList<IType>> lazyLoadedTypes;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly Lazy<IReadOnlyList<IType>> lazySelectedTypes;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly Lazy<IReadOnlyList<IType>> lazyFailingTypes;


        internal TestResult(IEnumerable<TypeSpec> loadedTypes, IEnumerable<TypeSpec> selectedTypes, IEnumerable<TypeSpec> failingTypes, bool isSuccessful)
        {
            lazyLoadedTypes = new Lazy<IReadOnlyList<IType>>(() => loadedTypes.Select(x => x.CreateWrapper()).ToArray());
            lazySelectedTypes = new Lazy<IReadOnlyList<IType>>(() => selectedTypes.Select(x => x.CreateWrapper()).ToArray());
            lazyFailingTypes = new Lazy<IReadOnlyList<IType>>(() => failingTypes.Select(x => x.CreateWrapper()).ToArray());
            IsSuccessful = isSuccessful;
        }


        /// <summary>
        /// Gets a flag indicating the success or failure of the test.
        /// </summary>
        public bool IsSuccessful { get; private set; }

        /// <summary>
        /// Gets a list of all the types that were loded by <see cref="Types"/>.
        /// </summary>       
        [DebuggerDisplay("[{LoadedTypes.Count}]")]
        public IReadOnlyList<IType> LoadedTypes => lazyLoadedTypes.Value;

        /// <summary>
        /// Gets a list of the types that passed filtering by predicates and were used as input to conditions.  
        /// </summary>       
        [DebuggerDisplay("[{SelectedTypesForTesting.Count}]")]
        public IReadOnlyList<IType> SelectedTypesForTesting => lazySelectedTypes.Value;

        /// <summary>
        /// Gets a list of the types that failed the test.
        /// </summary>       
        [DebuggerDisplay("[{FailingTypes.Count}]")]
        public IReadOnlyList<IType> FailingTypes => lazyFailingTypes.Value;
    }
}