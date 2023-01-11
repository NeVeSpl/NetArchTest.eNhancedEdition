using System.Collections.Generic;
using NetArchTest.Assemblies;
using NetArchTest.Dependencies.DataStructures;

namespace NetArchTest.Dependencies
{
    /// <summary>
    /// Finds dependencies within a given set of types.
    /// </summary>
    internal class DependencySearch
    {
        /// <summary>
        /// Finds types that have a dependency on any item in the given list of dependencies.
        /// </summary>
        /// <param name="input">The set of type definitions to search.</param>
        /// <param name="dependencies">The set of dependencies to look for.</param>
        /// <returns>A list of found types.</returns>
        public IEnumerable<TypeSpec> FindTypesThatHaveDependencyOnAny(IEnumerable<TypeSpec> input, IEnumerable<string> dependencies)
        {  
            return FindTypes(input, TypeDefinitionCheckingResult.SearchType.HaveDependencyOnAny, dependencies, true);           
        }

        /// <summary>
        /// Finds types that have a dependency on every item in the given list of dependencies.
        /// </summary>
        /// <param name="input">The set of type definitions to search.</param>
        /// <param name="dependencies">The set of dependencies to look for.</param>
        /// <returns>A list of found types.</returns>
        public IEnumerable<TypeSpec> FindTypesThatHaveDependencyOnAll(IEnumerable<TypeSpec> input, IEnumerable<string> dependencies)
        {  
            return FindTypes(input, TypeDefinitionCheckingResult.SearchType.HaveDependencyOnAll, dependencies, true);         
        }

        /// <summary>
        /// Finds types that may have a dependency on any item in the given list of dependencies, but cannot have a dependency that is not in the list.
        /// </summary>
        /// <param name="input">The set of type definitions to search.</param>
        /// <param name="dependencies">The set of dependencies to look for.</param>
        /// <returns>A list of found types.</returns>
        public IEnumerable<TypeSpec> FindTypesThatOnlyHaveDependenciesOnAnyOrNone(IEnumerable<TypeSpec> input, IEnumerable<string> dependencies)
        {           
            return FindTypes(input, TypeDefinitionCheckingResult.SearchType.OnlyHaveDependenciesOnAnyOrNone, dependencies, false);
        }

        /// <summary>
        /// Finds types that have a dependency on any item in the given list of dependencies, but cannot have a dependency that is not in the list.
        /// </summary>
        /// <param name="input">The set of type definitions to search.</param>
        /// <param name="dependencies">The set of dependencies to look for.</param>
        /// <returns>A list of found types.</returns>
        public IEnumerable<TypeSpec> FindTypesThatOnlyHaveDependenciesOnAny(IEnumerable<TypeSpec> input, IEnumerable<string> dependencies)
        {
            return FindTypes(input, TypeDefinitionCheckingResult.SearchType.OnlyHaveDependenciesOnAny, dependencies, false);
        }

        /// <summary>
        /// Finds types that have a dependency on every item in the given list of dependencies, but cannot have a dependency that is not in the list.
        /// </summary>
        /// <param name="input">The set of type definitions to search.</param>
        /// <param name="dependencies">The set of dependencies to look for.</param>
        /// <returns>A list of found types.</returns>
        public IEnumerable<TypeSpec> FindTypesThatOnlyOnlyHaveDependenciesOnAll(IEnumerable<TypeSpec> input, IEnumerable<string> dependencies)
        {
            return FindTypes(input, TypeDefinitionCheckingResult.SearchType.OnlyHaveDependenciesOnAll, dependencies, false);
        }

        private IEnumerable<TypeSpec> FindTypes(IEnumerable<TypeSpec> input, TypeDefinitionCheckingResult.SearchType searchType, IEnumerable<string> dependencies, bool serachForDependencyInFieldConstant)
        {
            var output = new List<TypeSpec>();
            var searchTree = new CachedNamespaceTree(dependencies);

            foreach (var type in input)
            {
                var context = new TypeDefinitionCheckingContext(type, searchType, searchTree, serachForDependencyInFieldConstant);
                if (context.IsTypeFound())
                {
                    output.Add(type);
                }
            }

            return output;
        }       
    }
}