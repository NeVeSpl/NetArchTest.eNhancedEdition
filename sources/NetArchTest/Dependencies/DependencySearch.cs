using System.Collections.Generic;
using System.Linq;
using NetArchTest.Assemblies;
using NetArchTest.Dependencies.DataStructures;
using NetArchTest.Rules;

namespace NetArchTest.Dependencies
{
    /// <summary>
    /// Finds dependencies within a given set of types.
    /// </summary>
    internal class DependencySearch
    {
        private readonly bool _explainYourself;
        private readonly IDependencyFilter _dependencyFilter;
        private readonly bool _searchForDependencyInFieldConstant;

        public DependencySearch(bool explainYourself, bool searchForDependencyInFieldConstant = false, IDependencyFilter dependencyFilter = null)
        {
            _explainYourself = explainYourself;
            _dependencyFilter = dependencyFilter;
            _searchForDependencyInFieldConstant = searchForDependencyInFieldConstant;
        }

        /// <summary>
        /// Finds types that have a dependency on any item in the given list of dependencies.
        /// </summary>
        public IEnumerable<TypeSpec> FindTypesThatHaveDependencyOnAny(IEnumerable<TypeSpec> input, IEnumerable<string> dependencies)
        {
            return FindTypes(input, HaveDependencyCheckingStrategy.TypeOfCheck.HaveDependencyOnAny, dependencies);
        }

        /// <summary>
        /// Finds types that have a dependency on every item in the given list of dependencies.
        /// </summary>
        public IEnumerable<TypeSpec> FindTypesThatHaveDependencyOnAll(IEnumerable<TypeSpec> input, IEnumerable<string> dependencies)
        {
            return FindTypes(input, HaveDependencyCheckingStrategy.TypeOfCheck.HaveDependencyOnAll, dependencies);
        }

        /// <summary>
        /// Finds types that may have a dependency on any item in the given list of dependencies, but cannot have a dependency that is not in the list.
        /// </summary>
        public IEnumerable<TypeSpec> FindTypesThatOnlyHaveDependencyOnAnyOrNone(IEnumerable<TypeSpec> input, IEnumerable<string> dependencies)
        {
            return FindTypes(input, HaveDependencyCheckingStrategy.TypeOfCheck.OnlyHaveDependenciesOnAnyOrNone, dependencies);
        }

        /// <summary>
        /// Finds types that have a dependency on any item in the given list of dependencies, but cannot have a dependency that is not in the list.
        /// </summary>
        public IEnumerable<TypeSpec> FindTypesThatOnlyHaveDependencyOnAny(IEnumerable<TypeSpec> input, IEnumerable<string> dependencies)
        {
            return FindTypes(input, HaveDependencyCheckingStrategy.TypeOfCheck.OnlyHaveDependenciesOnAny, dependencies);
        }

        /// <summary>
        /// Finds types that have a dependency on every item in the given list of dependencies, but cannot have a dependency that is not in the list.
        /// </summary>
        public IEnumerable<TypeSpec> FindTypesThatOnlyOnlyHaveDependencyOnAll(IEnumerable<TypeSpec> input, IEnumerable<string> dependencies)
        {
            return FindTypes(input, HaveDependencyCheckingStrategy.TypeOfCheck.OnlyHaveDependenciesOnAll, dependencies);
        }

        private IEnumerable<TypeSpec> FindTypes(IEnumerable<TypeSpec> input, HaveDependencyCheckingStrategy.TypeOfCheck typeOfCheck, IEnumerable<string> dependencies)
        {
            var searchTree = new CachedNamespaceTree(dependencies);
            var context = new TypeCheckingContext(_searchForDependencyInFieldConstant, _explainYourself, _dependencyFilter);

            foreach (var type in input)
            {
                var strategy = new HaveDependencyCheckingStrategy(typeOfCheck, searchTree);
                context.PerformCheck(type, strategy);
                type.IsPassing = strategy.DoesTypePassCheck();
            }

            return input;
        }

        public IEnumerable<TypeSpec> FindTypesThatAreUsedByAny(IEnumerable<TypeSpec> input, IEnumerable<string> users, IEnumerable<TypeSpec> allTypes)
        {
            var filterTree = new CachedNamespaceTree(users);
            var context = new TypeCheckingContext(_searchForDependencyInFieldConstant, _explainYourself, _dependencyFilter);
            var strategy = new AreUsedByCheckingStrategy();

            foreach (var type in allTypes)
            {
                bool shouldBeChecked = filterTree.GetAllMatchingNames(type.Definition).Any();

                if (shouldBeChecked)
                {
                    context.PerformCheck(type, strategy);
                }
            }

            foreach (var type in input)
            {
                type.IsPassing = strategy.IsTypeUsed(type.Definition);
            }

            return input;
        }
    }
}