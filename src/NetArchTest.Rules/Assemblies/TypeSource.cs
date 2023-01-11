using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Mono.Cecil;
using NetArchTest.Dependencies.DataStructures;

namespace NetArchTest.Assemblies
{
    internal sealed class TypeSource
    {
        private static readonly List<string> exclusionList = new List<string>{ "System", "Microsoft", "Mono.Cecil", "netstandard", "NetArchTest.Rules", "<Module>", "xunit", "<PrivateImplementationDetails>" };
        private static readonly NamespaceTree exclusionTree = new NamespaceTree(exclusionList);


       
        public static IEnumerable<TypeSpec> FromAssemblies(IEnumerable<Assembly> assemblies, IEnumerable<string> searchDirectories = null)
        {
            foreach (var assembly in assemblies)
            {
                if (exclusionTree.GetAllMatchingNames(assembly.FullName).Any() || assembly.IsDynamic)
                {
                    continue;
                }

                foreach (var type in ReadTypes(assembly.Location))
                {
                    yield return type;
                }
            }
        }
        public static IEnumerable<TypeSpec> FromFiles(IEnumerable<string> fileNames, IEnumerable<string> searchDirectories = null)
        {
            foreach (var fileName in fileNames)
            {
                foreach (var type in ReadTypes(fileName))
                {
                    yield return type;
                }
            }
        }

        private static IEnumerable<TypeSpec> ReadTypes(string assemblyLocation, IEnumerable<string> searchDirectories = null)
        {
            ReaderParameters readerParameters = null;

            if (searchDirectories?.Any() == true)
            {
                var assemblyResolver = new DefaultAssemblyResolver();
                foreach (var searchDirectory in searchDirectories)
                {
                    assemblyResolver.AddSearchDirectory(searchDirectory);
                }

                readerParameters = new ReaderParameters { AssemblyResolver = assemblyResolver };
            }

            var assemblyDefinition = ReadAssemblyDefinition(assemblyLocation, readerParameters);

            if (assemblyDefinition != null)
            {
                if (exclusionTree.GetAllMatchingNames(assemblyDefinition.FullName).Any() == false)
                {
                    foreach (var type in GetAllTypes(assemblyDefinition.Modules.SelectMany(t => t.Types)))
                    {
                        yield return type;
                    }
                }
            }
        }
        private static AssemblyDefinition ReadAssemblyDefinition(string path, ReaderParameters readerParameters = null)
        {
            try
            {
                if (readerParameters == null)
                {
                    return AssemblyDefinition.ReadAssembly(path);
                }
                else
                {
                    return AssemblyDefinition.ReadAssembly(path, readerParameters);
                }
            }
            catch (BadImageFormatException)
            {
                return null;
            }
        }
        private static IEnumerable<TypeSpec> GetAllTypes(IEnumerable<TypeDefinition> types)
        {
            foreach (var type in types)
            {
                if (exclusionTree.GetAllMatchingNames(type.FullName).Any() || type.IsCompilerGenerated())
                {
                    continue;
                }

                yield return new TypeSpec(type);

                if (type.NestedTypes?.Any() == true)
                {
                    foreach (var nestedType in GetAllTypes(type.NestedTypes))
                    {
                        yield return nestedType;
                    }
                }
            }
        }
    }
}