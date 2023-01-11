using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Mono.Cecil;
using NetArchTest.Dependencies.DataStructures;

namespace NetArchTest.Dependencies
{
    internal class TypeDefinitionCheckingResult
    {
        public enum SearchType 
        { 
            HaveDependencyOnAny,
            HaveDependencyOnAll, 
            OnlyHaveDependenciesOnAnyOrNone,
            OnlyHaveDependenciesOnAny,
            OnlyHaveDependenciesOnAll 
        }

        private readonly SearchType _searchType;
        private readonly ISearchTree _searchTree;
        /// <summary> The list of dependencies that have been found in the search.</summary>
        private HashSet<string> _foundDependencies = new HashSet<string>();
        private bool _hasDependencyFromOutsideOfSearchTree;

        TypeReference lastFoundDependency = null;
        TypeReference lastFoundDependencyOutsideOfSearchTree = null;

        public TypeDefinitionCheckingResult(SearchType searchType, ISearchTree searchTree)
        {
            _searchType = searchType;
            _searchTree = searchTree;
            _hasDependencyFromOutsideOfSearchTree = false;
        }


        public bool IsTypeFound()
        {            
            switch (_searchType)
            {
                case SearchType.HaveDependencyOnAll:
                    return _foundDependencies.Count == _searchTree.TerminatedNodesCount;
                case SearchType.HaveDependencyOnAny:
                    return _foundDependencies.Count > 0;
                case SearchType.OnlyHaveDependenciesOnAnyOrNone:
                    return !_hasDependencyFromOutsideOfSearchTree && _foundDependencies.Count >= 0;
                case SearchType.OnlyHaveDependenciesOnAny:
                    return !_hasDependencyFromOutsideOfSearchTree && _foundDependencies.Count > 0;
                case SearchType.OnlyHaveDependenciesOnAll:
                    return !_hasDependencyFromOutsideOfSearchTree && _foundDependencies.Count == _searchTree.TerminatedNodesCount;
                default:
                    throw new NotImplementedException();
            }
        }
        public string ExplainWhy()
        {
            var isTypeFound = IsTypeFound();
            switch (_searchType)
            {
                case SearchType.HaveDependencyOnAll:
                    if (isTypeFound)
                    {
                        return "Has dependency on all provided inputs";
                    }
                    else
                    {
                        return string.Empty;
                    }                    
                case SearchType.HaveDependencyOnAny:
                    if (isTypeFound)
                    {
                        return $"Has dependency on: {lastFoundDependency}";
                    }
                    else
                    {
                        return "Does not have a dependency on any provided inputs";
                    }                    
                case SearchType.OnlyHaveDependenciesOnAnyOrNone:
                    if (isTypeFound)
                    {
                        return "Does not have a dependency outside of provided inputs";
                    }
                    else
                    {
                        return $"Has dependency on: {lastFoundDependencyOutsideOfSearchTree}";
                    }
                    break;
            }
            throw new NotImplementedException();
        }

        /// <summary>
        /// If we already know the final answer to the question if type was found,
        /// doing another search will not change the result
        /// </summary>     
        public bool CanWeSkipFurtherSearch()
        {
            switch (_searchType)
            {
                case SearchType.HaveDependencyOnAny:                  
                case SearchType.HaveDependencyOnAll:
                    return IsTypeFound() == true;
                case SearchType.OnlyHaveDependenciesOnAnyOrNone:                   
                case SearchType.OnlyHaveDependenciesOnAny:               
                case SearchType.OnlyHaveDependenciesOnAll:
                    return _hasDependencyFromOutsideOfSearchTree;                  
                default:
                    throw new NotImplementedException();
            }           
        }

        public void CheckDependency(string dependencyTypeFullName)
        {
            var matchedDependencies = _searchTree.GetAllMatchingNames(dependencyTypeFullName);
            if (matchedDependencies.Any())
            {
                foreach (var match in matchedDependencies)
                {
                    _foundDependencies.Add(match);
                }
            }
        }

        public void CheckDependency(TypeReference dependency)
        {
            var matchedDependencies = _searchTree.GetAllMatchingNames(dependency);
            if (matchedDependencies.Any())
            {
                foreach (var match in matchedDependencies)
                {
                    _foundDependencies.Add(match);
                }
                lastFoundDependency = dependency;
            } 
            else
            {
                if (_hasDependencyFromOutsideOfSearchTree == false)
                {
                    bool isGlobalAnonymousCompilerGeneratedType = String.IsNullOrEmpty(dependency.Namespace) && dependency.Name.StartsWith("<>");
                    if (dependency is TypeDefinition typeDefinition)
                    {
                        isGlobalAnonymousCompilerGeneratedType |= typeDefinition.CustomAttributes.Any(x => x?.AttributeType?.FullName == typeof(CompilerGeneratedAttribute).FullName);
                    }
                    if (!isGlobalAnonymousCompilerGeneratedType)
                    {
                        _hasDependencyFromOutsideOfSearchTree = true;
                        lastFoundDependencyOutsideOfSearchTree = dependency;
                    }
                }
            }
        }
    }
}