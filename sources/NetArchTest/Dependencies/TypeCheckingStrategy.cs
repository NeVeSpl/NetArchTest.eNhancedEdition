using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Mono.Cecil;
using NetArchTest.Dependencies.DataStructures;

namespace NetArchTest.Dependencies
{
    internal interface ITypeCheckingStrategy
    {
        bool CanWeSkipFurtherSearch();
        void CheckType(string dependencyTypeFullName);
        void CheckType(TypeReference dependency);
        string ExplainWhy();      
    }

    internal class HaveDependency_CheckingStrategy : ITypeCheckingStrategy
    {
        public enum TypeOfCheck
        {
            HaveDependencyOnAny,
            HaveDependencyOnAll,
            OnlyHaveDependenciesOnAnyOrNone,
            OnlyHaveDependenciesOnAny,
            OnlyHaveDependenciesOnAll
        }

        private readonly TypeOfCheck _typeOfCheck;
        private readonly ISearchTree _dependencySearchTree;
        /// <summary> The list of dependencies that have been found in the search.</summary>
        private HashSet<string> _foundDependencies = new HashSet<string>();
        private bool _hasDependencyFromOutsideOfSearchTree;

        TypeReference lastFoundDependency = null;
        TypeReference lastFoundDependencyOutsideOfSearchTree = null;


        public HaveDependency_CheckingStrategy(TypeOfCheck searchType, ISearchTree dependencySearchTree)
        {
            _typeOfCheck = searchType;
            _dependencySearchTree = dependencySearchTree;
            _hasDependencyFromOutsideOfSearchTree = false;
        }


        public bool DoesTypePassCheck()
        {
            switch (_typeOfCheck)
            {
                case TypeOfCheck.HaveDependencyOnAll:
                    return _foundDependencies.Count == _dependencySearchTree.TerminatedNodesCount;
                case TypeOfCheck.HaveDependencyOnAny:
                    return _foundDependencies.Count > 0;
                case TypeOfCheck.OnlyHaveDependenciesOnAnyOrNone:
                    return !_hasDependencyFromOutsideOfSearchTree && _foundDependencies.Count >= 0;
                case TypeOfCheck.OnlyHaveDependenciesOnAny:
                    return !_hasDependencyFromOutsideOfSearchTree && _foundDependencies.Count > 0;
                case TypeOfCheck.OnlyHaveDependenciesOnAll:
                    return !_hasDependencyFromOutsideOfSearchTree && _foundDependencies.Count == _dependencySearchTree.TerminatedNodesCount;
                default:
                    throw new NotImplementedException();
            }
        }
        public string ExplainWhy()
        {
            var isTypeFound = DoesTypePassCheck();
            switch (_typeOfCheck)
            {
                case TypeOfCheck.HaveDependencyOnAll:
                    if (isTypeFound)
                    {
                        return "Has dependency on all provided inputs";
                    }
                    else
                    {
                        return string.Empty;
                    }
                case TypeOfCheck.HaveDependencyOnAny:
                    if (isTypeFound)
                    {
                        return $"Has dependency on: {lastFoundDependency}";
                    }
                    else
                    {
                        return "Does not have a dependency on any provided inputs";
                    }
                case TypeOfCheck.OnlyHaveDependenciesOnAnyOrNone:
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
            switch (_typeOfCheck)
            {
                case TypeOfCheck.HaveDependencyOnAny:
                case TypeOfCheck.HaveDependencyOnAll:
                    return DoesTypePassCheck() == true;
                case TypeOfCheck.OnlyHaveDependenciesOnAnyOrNone:
                case TypeOfCheck.OnlyHaveDependenciesOnAny:
                case TypeOfCheck.OnlyHaveDependenciesOnAll:
                    return _hasDependencyFromOutsideOfSearchTree;
                default:
                    throw new NotImplementedException();
            }
        }

        public void CheckType(string dependencyTypeFullName)
        {
            var matchedDependencies = _dependencySearchTree.GetAllMatchingNames(dependencyTypeFullName);
            if (matchedDependencies.Any())
            {
                foreach (var match in matchedDependencies)
                {
                    _foundDependencies.Add(match);
                }
            }
        }

        public void CheckType(TypeReference dependency)
        {
            var matchedDependencies = _dependencySearchTree.GetAllMatchingNames(dependency);
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


    internal class AreUsedBy_CheckingStrategy : ITypeCheckingStrategy
    {
        HashSet<string> usedTypes = new HashSet<string>();

       
        public bool IsTypeUsed(TypeReference type)
        {
            return usedTypes.Contains(type.FullName);
        }


        public bool CanWeSkipFurtherSearch()
        {
            return false;
        }

        public void CheckType(string dependencyTypeFullName)
        {
             
        }

        public void CheckType(TypeReference dependency)
        {
            usedTypes.Add(dependency.FullName);
        }

        public string ExplainWhy()
        {
            return "todo";
        }     
    }
}