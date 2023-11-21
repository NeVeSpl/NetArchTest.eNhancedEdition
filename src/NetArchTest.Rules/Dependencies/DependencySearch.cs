using System.Collections.Generic;
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
        private readonly bool explainYourself;
        private readonly IDependencyFilter dependencyFilter;

        public DependencySearch(bool explainYourself, IDependencyFilter dependencyFilter = null)
        {
            this.explainYourself = explainYourself;
            this.dependencyFilter = dependencyFilter;
        }

        /// <summary>
        /// Finds types that have a dependency on any item in the given list of dependencies.
        /// </summary>
        public IEnumerable<TypeSpec> FindTypesThatHaveDependencyOnAny(IEnumerable<TypeSpec> input, IEnumerable<string> dependencies)
        {  
            return FindTypes(input, TypeDefinitionCheckingResult.SearchType.HaveDependencyOnAny, dependencies, true);           
        }

        /// <summary>
        /// Finds types that have a dependency on every item in the given list of dependencies.
        /// </summary>      
        public IEnumerable<TypeSpec> FindTypesThatHaveDependencyOnAll(IEnumerable<TypeSpec> input, IEnumerable<string> dependencies)
        {  
            return FindTypes(input, TypeDefinitionCheckingResult.SearchType.HaveDependencyOnAll, dependencies, true);         
        }

        /// <summary>
        /// Finds types that may have a dependency on any item in the given list of dependencies, but cannot have a dependency that is not in the list.
        /// </summary>             
        public IEnumerable<TypeSpec> FindTypesThatOnlyHaveDependencyOnAnyOrNone(IEnumerable<TypeSpec> input, IEnumerable<string> dependencies)
        {           
            return FindTypes(input, TypeDefinitionCheckingResult.SearchType.OnlyHaveDependenciesOnAnyOrNone, dependencies, false);
        }

        /// <summary>
        /// Finds types that have a dependency on any item in the given list of dependencies, but cannot have a dependency that is not in the list.
        /// </summary>      
        public IEnumerable<TypeSpec> FindTypesThatOnlyHaveDependencyOnAny(IEnumerable<TypeSpec> input, IEnumerable<string> dependencies)
        {
            return FindTypes(input, TypeDefinitionCheckingResult.SearchType.OnlyHaveDependenciesOnAny, dependencies, false);
        }

        /// <summary>
        /// Finds types that have a dependency on every item in the given list of dependencies, but cannot have a dependency that is not in the list.
        /// </summary>
        public IEnumerable<TypeSpec> FindTypesThatOnlyOnlyHaveDependencyOnAll(IEnumerable<TypeSpec> input, IEnumerable<string> dependencies)
        {
            return FindTypes(input, TypeDefinitionCheckingResult.SearchType.OnlyHaveDependenciesOnAll, dependencies, false);
        }

        private IEnumerable<TypeSpec> FindTypes(IEnumerable<TypeSpec> input, TypeDefinitionCheckingResult.SearchType searchType, IEnumerable<string> dependencies, bool serachForDependencyInFieldConstant)
        {           
            var searchTree = new CachedNamespaceTree(dependencies);           

            foreach (var type in input)
            {
                var context = new TypeDefinitionCheckingContext(type, searchType, searchTree, serachForDependencyInFieldConstant, explainYourself, dependencyFilter);               
                type.IsPassing = context.IsTypeFound();                
            }

            return input;
        }       
    }
}