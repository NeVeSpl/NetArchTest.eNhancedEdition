using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Mono.Cecil;
using Mono.Cecil.Cil;
using NetArchTest.Dependencies.DataStructures;

namespace NetArchTest.Assemblies
{
    internal static class DataLoader
    {
        private static readonly List<string> exclusionList = new List<string> 
        { 
            "System",
            "Microsoft", 
            "netstandard", 
            "NuGet", 
            "Newtonsoft",
            "Xunit", 
            "Internal.Microsoft",
            "Mono.Cecil",
            "NetArchTest.Assemblies",
            "NetArchTest.Dependencies",
            "NetArchTest.Functions",
            "NetArchTest.Policies",
            "NetArchTest.RuleEngine",
            "NetArchTest.Rules",
            "NetArchTest.Slices",
        };
        private static readonly NamespaceTree exclusionTree = new NamespaceTree(exclusionList);


        public static LoadedData LoadFromCurrentDomain()
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var selectedAssemblies = assemblies.Where(assembly => assembly.IsDynamic == false);

            return LoadFromAssemblies(selectedAssemblies);
        }
        public static LoadedData LoadFromAssemblies(IEnumerable<Assembly> assemblies, IEnumerable<string> searchDirectories = null)
        {
            var files = assemblies.Select(x => x.Location);

            return LoadFromFiles(files, searchDirectories);
        }
        public static LoadedData LoadFromFiles(IEnumerable<string> fileNames, IEnumerable<string> searchDirectories = null)
        {
            var assemblies = Load(fileNames, searchDirectories);

            return new LoadedData(assemblies);
        }


        private static IEnumerable<AssemblySpec> Load(IEnumerable<string> fileNames, IEnumerable<string> searchDirectories = null)
        {
            var readerParameters = CreateReaderParameters(searchDirectories);

            foreach (var fileName in fileNames)
            {
                var assemblyDefinition = ReadAssemblyDefinition(fileName, readerParameters);
                if (assemblyDefinition == null) continue;

                if (exclusionTree.GetAllMatchingNames(assemblyDefinition.Name.Name).Any() == true) continue;

                var typeDefinitions = ReadTypes(assemblyDefinition);

                yield return new AssemblySpec(assemblyDefinition, typeDefinitions);
            }
        }
        private static ReaderParameters CreateReaderParameters(IEnumerable<string> searchDirectories, bool readSymbols = true)
        {
            DefaultAssemblyResolver assemblyResolver = null;
            if (searchDirectories?.Any() == true)
            {
                assemblyResolver = new DefaultAssemblyResolver();
                foreach (var searchDirectory in searchDirectories)
                {
                    assemblyResolver.AddSearchDirectory(searchDirectory);
                }
            }

            return new ReaderParameters { AssemblyResolver = assemblyResolver, ReadSymbols = readSymbols, SymbolReaderProvider = new DefaultSymbolReaderProvider(false) };
        }
        private static AssemblyDefinition ReadAssemblyDefinition(string path, ReaderParameters readerParameters = null)
        {
            try
            {
                return AssemblyDefinition.ReadAssembly(path, readerParameters);
            }
            catch (BadImageFormatException)
            {
                return null;
            }
        }


        private static IEnumerable<TypeDefinition> ReadTypes(AssemblyDefinition assemblyDefinition)
        {
            foreach (var module in assemblyDefinition.Modules)
            {
                foreach (var type in module.GetTypes())
                {                   
                    if (type.FullName.Equals("<Module>")) continue;
                    if (type.FullName.StartsWith("<>")) continue;
                    if (type.FullName.StartsWith("<PrivateImplementationDetails>")) continue;

                    if (exclusionTree.GetAllMatchingNames(type.FullName).Any()) continue;
                    if (type.IsCompilerGenerated()) continue;

                    yield return type;
                }
            }
        }
    }       


    internal sealed class LoadedData
    {
        public IReadOnlyList<AssemblySpec> Assemblies { get; }


        public LoadedData(IEnumerable<AssemblySpec> assemblies)
        {
            Assemblies = assemblies.ToArray();
        }


        public IEnumerable<TypeSpec> GetTypes()
        {
            foreach (var assembly in Assemblies)
            {
                foreach (var type in assembly.GetTypes())
                {
                    yield return type;
                }
            }
        }
    }
}