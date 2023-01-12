using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using NetArchTest.Assemblies;
using NetArchTest.RuleEngine;
using NetArchTest.Slices;

[assembly: InternalsVisibleTo("NetArchTest.UnitTests")]

namespace NetArchTest.Rules
{
    /// <summary>
    /// Creates a list of types that can have predicates and conditions applied to it.
    /// </summary>
    public sealed class Types
    {
        private readonly RuleContext rule;


        private Types(IEnumerable<TypeSpec> types)
        {
            rule = new RuleContext(types);
        }


        /// <summary>
        /// Creates a list of types based on all the assemblies in the current AppDomain
        /// </summary>
        /// <returns>A list of types that can have predicates and conditions applied to it.</returns>
        public static Types InCurrentDomain()
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            return Types.InAssemblies(assemblies);
        }

        /// <summary>
        /// Creates a list of types based on a particular assembly.
        /// </summary>
        /// <param name="assembly">The assembly to base the list on.</param>
        /// <param name="searchDirectories">An optional list of search directories to allow resolution of referenced assemblies.</param>
        /// <returns>A list of types that can have predicates and conditions applied to it.</returns>
        public static Types InAssembly(Assembly assembly, IEnumerable<string> searchDirectories = null)
        {
            return Types.InAssemblies(new List<Assembly> { assembly }, searchDirectories);
        }

        /// <summary>
        /// Creates a list of types based on a list of assemblies.
        /// </summary>
        /// <param name="assemblies">The assemblies to base the list on.</param>
        /// <param name="searchDirectories">An optional list of search directories to allow resolution of referenced assemblies.</param>
        /// <returns>A list of types that can have predicates and conditions applied to it.</returns>
        public static Types InAssemblies(IEnumerable<Assembly> assemblies, IEnumerable<string> searchDirectories = null)
        {
            return new Types(TypeSource.FromAssemblies(assemblies, searchDirectories));
        }    

        /// <summary>
        /// Creates a list of all the types in a particular module file.
        /// </summary>
        /// <param name="fileName">The filename of the module. This is case insensitive.</param>
        /// <returns>A list of types that can have predicates and conditions applied to it.</returns>
        /// <remarks>Assumes that the module is in the same directory as the executing assembly.</remarks>
        public static Types FromFile(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException(nameof(fileName));
            }

            // Load the assembly from the current directory
            var dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var path = Path.Combine(dir, fileName);
            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"Could not find the assembly file {path}.");
            }

            return new Types(TypeSource.FromFiles(new string[] { path }, null));           
        }

        /// <summary>
        /// Creates a list of all the types found on a particular path.
        /// </summary>
        /// <param name="path">The relative path to load types from.</param>
        /// <param name="searchDirectories">An optional list of search directories to allow resolution of referenced assemblies.</param>
        /// <returns>A list of types that can have predicates and conditions applied to it.</returns>
        public static Types FromPath(string path, IEnumerable<string> searchDirectories = null)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException(nameof(path));
            }

            if (!Directory.Exists(path))
            {
                throw new DirectoryNotFoundException($"Could not find the path {path}.");
            }

            var files = Directory.GetFiles(path, "*.dll");
            return new Types(TypeSource.FromFiles(files, searchDirectories));
        }


        /// <summary>
        /// Allows a list of types to be applied to one or more filters.
        /// </summary>
        /// <returns>A list of types onto which you can apply a series of filters.</returns>
        public Predicate That()
        {
            return new Predicate(rule);
        }

        /// <summary>
        /// Applies a set of conditions to the list of types.
        /// </summary>
        /// <returns></returns>
        public Condition Should()
        {
            return new Condition(rule, true);
        }

        /// <summary>
        /// Applies a negative set of conditions to the list of types.
        /// </summary>
        /// <returns></returns>
        public Condition ShouldNot()
        {
            return new Condition(rule, false);
        }

        /// <summary>
        /// Allows dividing types into groups, also called slices.
        /// </summary>
        /// <returns></returns>
        public SlicePredicate Slice()
        {
            return new SlicePredicate(rule);
        }


        /// <summary>
        /// Returns the list of <see cref="Type"/> objects describing the types in this list.
        /// </summary>
        /// <returns>The list of <see cref="Type"/> objects in this list.</returns>
        public IEnumerable<IType> GetTypes()
        {
            return rule.GetTypes();
        }
    }
}