﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using NetArchTest.Assemblies;
using NetArchTest.RuleEngine;
using NetArchTest.Slices;

[assembly: InternalsVisibleTo("NetArchTest.UnitTests, PublicKey=002400000480000094000000060200000024000052534131000400000100010059bad09197268099d3d5177d912c250c29764641430e313f3991f5115bd5fb04fb667c802e97b3167394f9e8222d843565eb5403a55bb563e7787d78f9ff2543ddb97405d787148835ebdaf77e7db3043c6d1895c2f2a2bbaabf787d066f8298871ac55c7549648fb0267c4a14f761d438700d1bcba40e9d01dff16a326c55d3")]

namespace NetArchTest.Rules
{
    /// <summary>
    /// Creates a list of types that can have predicates and conditions applied to it.
    /// </summary>
    public sealed class Types
    {
        private readonly LoadedData loadedData;


        private Types(LoadedData loadedData)
        {
            this.loadedData = loadedData;
        }



        /// <summary>
        /// Creates a list of types based on all the assemblies in the current AppDomain
        /// </summary>
        /// <returns>A list of types that can have predicates and conditions applied to it.</returns>
        public static Types InCurrentDomain()
        {            
            return new Types(DataLoader.LoadFromCurrentDomain());
        }

        /// <summary>
        /// Creates a list of types based on a particular assembly.
        /// </summary>
        /// <param name="assembly">The assembly to base the list on.</param>
        /// <param name="searchDirectories">An optional list of search directories to allow resolution of referenced assemblies.</param>
        /// <returns>A list of types that can have predicates and conditions applied to it.</returns>
        public static Types InAssembly(Assembly assembly, IEnumerable<string> searchDirectories = null, bool loadReferencedAssemblies = false)
        {
            return Types.InAssemblies(new List<Assembly> { assembly }, searchDirectories, loadReferencedAssemblies);
        }

        /// <summary>
        /// Creates a list of types based on a list of assemblies.
        /// </summary>
        /// <param name="assemblies">The assemblies to base the list on.</param>
        /// <param name="searchDirectories">An optional list of search directories to allow resolution of referenced assemblies.</param>
        /// <returns>A list of types that can have predicates and conditions applied to it.</returns>
        public static Types InAssemblies(IEnumerable<Assembly> assemblies, IEnumerable<string> searchDirectories = null, bool loadReferencedAssemblies = false)
        {
            return new Types(DataLoader.LoadFromAssemblies(assemblies, searchDirectories, loadReferencedAssemblies));
        }

        /// <summary>
        /// Creates a list of all the types in a particular module file.
        /// </summary>
        /// <param name="fileName">The filename of the module. This is case insensitive.</param>
        /// <param name="searchDirectories">An optional list of search directories to allow resolution of referenced assemblies.</param>
        /// <remarks>Assumes that the module is in the same directory as the executing assembly.</remarks>
        /// <returns>A list of types that can have predicates and conditions applied to it.</returns>        
        public static Types FromFile(string fileName, IEnumerable<string> searchDirectories = null)
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

            return new Types(DataLoader.LoadFromFiles(new string[] { path }, searchDirectories));           
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
            return new Types(DataLoader.LoadFromFiles(files, searchDirectories));
        }



        /// <summary>
        /// Allows a list of types to be applied to one or more filters.
        /// </summary>
        /// <returns>A list of types onto which you can apply a series of filters.</returns>
        public Predicate That()
        {
            return new Predicate(new RuleContext(loadedData));
        }

        /// <summary>
        /// Applies a set of conditions to the list of types.
        /// </summary>
        /// <returns></returns>
        public Condition Should()
        {
            return new Condition(new RuleContext(loadedData), true);
        }

        /// <summary>
        /// Applies a negative set of conditions to the list of types.
        /// </summary>
        /// <returns></returns>
        public Condition ShouldNot()
        {
            return new Condition(new RuleContext(loadedData), false);
        }

        /// <summary>
        /// Allows dividing types into groups, also called slices.
        /// </summary>
        /// <returns></returns>
        public SlicePredicate Slice()
        {
            return new SlicePredicate(new RuleContext(loadedData));
        }


        /// <summary>
        /// Returns the list of <see cref="Type"/> objects describing the types in this list.
        /// </summary>
        /// <returns>The list of <see cref="Type"/> objects in this list.</returns>
        public IEnumerable<IType> GetTypes(Options options = null)
        {
            return new RuleContext(loadedData).GetTypes(options);
        }
    }
}