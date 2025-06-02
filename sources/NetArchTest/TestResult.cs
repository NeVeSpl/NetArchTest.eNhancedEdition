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
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly Lazy<IReadOnlyList<IAssembly>> _lazyLoadedAssemblies;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly Lazy<IReadOnlyList<IType>> _lazyLoadedTypes;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly Lazy<IReadOnlyList<IType>> _lazySelectedTypes;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly Lazy<IReadOnlyList<IType>> _lazyFailingTypes;

        /// <summary>
        /// Gets a list of all the assemblies that were loded by <see cref="Types"/>.
        /// </summary>
        public IReadOnlyList<IAssembly> LoadedAssemblies => _lazyLoadedAssemblies.Value;

        /// <summary>
        /// Gets a list of all the types that were loded by <see cref="Types"/>.
        /// </summary>
        public IReadOnlyList<IType> LoadedTypes => _lazyLoadedTypes.Value;

        /// <summary>
        /// Gets a list of the types that passed filtering by predicates and were used as input to conditions.
        /// </summary>
        public IReadOnlyList<IType> SelectedTypesForTesting => _lazySelectedTypes.Value;

        /// <summary>
        /// Gets a list of the types that failed the test.
        /// </summary>
        public IReadOnlyList<IType> FailingTypes => _lazyFailingTypes.Value;

        /// <summary>
        /// Gets a flag indicating the success or failure of the test.
        /// </summary>
        public bool IsSuccessful { get; private set; }

        internal TestResult(IEnumerable<AssemblySpec> loadedAssemblies, IEnumerable<TypeSpec> loadedTypes, IEnumerable<TypeSpec> selectedTypes, IEnumerable<TypeSpec> failingTypes, bool isSuccessful)
        {
            _lazyLoadedAssemblies = new Lazy<IReadOnlyList<IAssembly>>(() => loadedAssemblies.Select(x => x.CreateWrapper()).ToList());
            _lazyLoadedTypes = new Lazy<IReadOnlyList<IType>>(() => loadedTypes.Select(x => x.CreateWrapper()).ToList());
            _lazySelectedTypes = new Lazy<IReadOnlyList<IType>>(() => selectedTypes.Select(x => x.CreateWrapper()).ToList());
            _lazyFailingTypes = new Lazy<IReadOnlyList<IType>>(() => failingTypes.Select(x => x.CreateWrapper()).ToList());
            IsSuccessful = isSuccessful;
        }
    }
}