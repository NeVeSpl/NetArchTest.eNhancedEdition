using System;
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
            return FindTypes(input, HaveDependency_CheckingStrategy.TypeOfCheck.HaveDependencyOnAny, dependencies, true);           
        }

        /// <summary>
        /// Finds types that have a dependency on every item in the given list of dependencies.
        /// </summary>      
        public IEnumerable<TypeSpec> FindTypesThatHaveDependencyOnAll(IEnumerable<TypeSpec> input, IEnumerable<string> dependencies)
        {  
            return FindTypes(input, HaveDependency_CheckingStrategy.TypeOfCheck.HaveDependencyOnAll, dependencies, true);         
        }

        /// <summary>
        /// Finds types that may have a dependency on any item in the given list of dependencies, but cannot have a dependency that is not in the list.
        /// </summary>             
        public IEnumerable<TypeSpec> FindTypesThatOnlyHaveDependencyOnAnyOrNone(IEnumerable<TypeSpec> input, IEnumerable<string> dependencies)
        {           
            return FindTypes(input, HaveDependency_CheckingStrategy.TypeOfCheck.OnlyHaveDependenciesOnAnyOrNone, dependencies, false);
        }

        /// <summary>
        /// Finds types that have a dependency on any item in the given list of dependencies, but cannot have a dependency that is not in the list.
        /// </summary>      
        public IEnumerable<TypeSpec> FindTypesThatOnlyHaveDependencyOnAny(IEnumerable<TypeSpec> input, IEnumerable<string> dependencies)
        {
            return FindTypes(input, HaveDependency_CheckingStrategy.TypeOfCheck.OnlyHaveDependenciesOnAny, dependencies, false);
        }

        /// <summary>
        /// Finds types that have a dependency on every item in the given list of dependencies, but cannot have a dependency that is not in the list.
        /// </summary>
        public IEnumerable<TypeSpec> FindTypesThatOnlyOnlyHaveDependencyOnAll(IEnumerable<TypeSpec> input, IEnumerable<string> dependencies)
        {
            return FindTypes(input, HaveDependency_CheckingStrategy.TypeOfCheck.OnlyHaveDependenciesOnAll, dependencies, false);
        }

        private IEnumerable<TypeSpec> FindTypes(IEnumerable<TypeSpec> input, HaveDependency_CheckingStrategy.TypeOfCheck typeOfCheck, IEnumerable<string> dependencies, bool serachForDependencyInFieldConstant)
        {           
            var searchTree = new CachedNamespaceTree(dependencies);
            var context = new TypeCheckingContext(serachForDependencyInFieldConstant, explainYourself, dependencyFilter);

            foreach (var type in input)
            {
                var strategy = new HaveDependency_CheckingStrategy(typeOfCheck, searchTree);                
                context.PerformCheck(type, strategy);
                type.IsPassing = strategy.DoesTypePassCheck();                
            }

            return input;
        }


        public IEnumerable<TypeSpec> FindTypesThatAreUsedByAny(IEnumerable<TypeSpec> input, IEnumerable<string> users, IEnumerable<TypeSpec> allTypes)
        {
            var filterTree = new CachedNamespaceTree(users);
            var context = new TypeCheckingContext(false, explainYourself, dependencyFilter);
            var strategy = new AreUsedBy_CheckingStrategy();


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