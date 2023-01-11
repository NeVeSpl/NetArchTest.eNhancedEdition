using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Mono.Cecil;
using Mono.Cecil.Rocks;
using NetArchTest.Assemblies;
using NetArchTest.Dependencies;

using NetArchTest.Rules;

namespace NetArchTest.Functions
{
    internal static class FunctionDelegates
    {
        public static IEnumerable<TypeSpec> HaveName(IEnumerable<TypeSpec> input, string name, bool condition)
        {
            if (condition)
            {
                return input.Where(c => c.Definition.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase));
            }
            else
            {
                return input.Where(c => !c.Definition.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase));
            }
        }

        /// <summary> Function for matching a type name using a regular expression. </summary>
        internal static IEnumerable<TypeSpec> HaveNameMatching(IEnumerable<TypeSpec> input, string pattern, bool condition)
        {
            Regex r = new Regex(pattern, RegexOptions.IgnoreCase);
            if (condition)
            {
                return input.Where(c => r.Match(c.Definition.Name).Success);
            }
            else
            {
                return input.Where(c => !r.Match(c.Definition.Name).Success);
            }
        }

        /// <summary> Function for matching the start of a type name. </summary>
        internal static IEnumerable<TypeSpec> HaveNameStartingWith(IEnumerable<TypeSpec> input, string start, bool condition, StringComparison comparer = StringComparison.InvariantCultureIgnoreCase)
        {
            if (condition)
            {
                return input.Where(c => c.Definition.Name.StartsWith(start, comparer));
            }
            else
            {
                return input.Where(c => !c.Definition.Name.StartsWith(start, comparer));
            }
        }

        /// <summary> Function for matching the end of a type name. </summary>
        internal static IEnumerable<TypeSpec> HaveNameEndingWith(IEnumerable<TypeSpec> input, string end, bool condition, StringComparison comparer = StringComparison.InvariantCultureIgnoreCase)
        {
            if (condition)
            {
                return input.Where(c => c.Definition.Name.EndsWith(end, comparer));
            }
            else
            {
                return input.Where(c => !c.Definition.Name.EndsWith(end, comparer));
            }
        }

        /// <summary> Function for finding classes with a particular custom attribute. </summary>
        internal static IEnumerable<TypeSpec> HaveCustomAttribute(IEnumerable<TypeSpec> input, Type attribute, bool condition)
        {
            if (condition)
            {
                return input.Where(c => c.Definition.CustomAttributes.Any(a => attribute.FullName.Equals(a.AttributeType.FullName, StringComparison.InvariantCultureIgnoreCase)));
            }
            else
            {
                return input.Where(c => !c.Definition.CustomAttributes.Any(a => attribute.FullName.Equals(a.AttributeType.FullName, StringComparison.InvariantCultureIgnoreCase)));
            }
        }

        /// <summary> Function for finding classes decorated with a particular custom attribute or derived one</summary>
        internal static IEnumerable<TypeSpec> HaveCustomAttributeOrInherit(IEnumerable<TypeSpec> input, Type attribute, bool condition)
        {
            // Convert the incoming type to a definition
            var target = attribute.ToTypeDefinition();
            if (condition)
            {
                return input.Where(c => c.Definition.CustomAttributes.Any(a => a.AttributeType.Resolve().IsSubclassOf(target) || attribute.FullName.Equals(a.AttributeType.FullName, StringComparison.InvariantCultureIgnoreCase)));
            }
            else
            {
                return input.Where(c => !c.Definition.CustomAttributes.Any(a => a.AttributeType.Resolve().IsSubclassOf(target) || attribute.FullName.Equals(a.AttributeType.FullName, StringComparison.InvariantCultureIgnoreCase)));
            }
        }


        /// <summary> Function for finding classes that inherit from a particular type. </summary>
        internal static IEnumerable<TypeSpec> Inherits(IEnumerable<TypeSpec> input, Type type, bool condition)
        {
            // Convert the incoming type to a definition
            var target = type.ToTypeDefinition();
            if (condition)
            {
                return input.Where(c => c.Definition.IsSubclassOf(target));
            }
            else
            {
                return input.Where(c => !c.Definition.IsSubclassOf(target));
            }
        }

        /// <summary> Function for finding classes that implement a particular interface. </summary>
        internal static IEnumerable<TypeSpec> ImplementsInterface(IEnumerable<TypeSpec> input, Type typeInterface, bool condition)
        {
            if (!typeInterface.IsInterface)
            {
                throw new ArgumentException($"The type {typeInterface.FullName} is not an interface.");
            }

            var target = typeInterface.FullName;
            var found = new List<TypeSpec>();

            foreach (var type in input)
            {
                if (type.Definition.Interfaces.Any(t => t.InterfaceType.Resolve().FullName.Equals(target, StringComparison.InvariantCultureIgnoreCase)))
                {
                    found.Add(type);
                }
            }

            if (condition)
            {
                return found;
            }
            else
            {
                return input.Where(c => !found.Contains(c));
            }
        }

        /// <summary> Function for finding abstract classes. </summary>
        internal static IEnumerable<TypeSpec> BeAbstract(IEnumerable<TypeSpec> input, bool dummy, bool condition)
        {
            if (condition)
            {
                return input.Where(c => c.Definition.IsAbstract);
            }
            else
            {
                return input.Where(c => !c.Definition.IsAbstract);
            }
        }

        /// <summary> Function for finding classes. </summary>
        internal static IEnumerable<TypeSpec> BeClass(IEnumerable<TypeSpec> input, bool dummy, bool condition)
        {
            if (condition)
            {
                return input.Where(c => c.Definition.IsClass);
            }
            else
            {
                return input.Where(c => !c.Definition.IsClass);
            }
        }

        /// <summary> Function for finding interfaces. </summary>
        internal static IEnumerable<TypeSpec> BeInterface(IEnumerable<TypeSpec> input, bool dummy, bool condition)
        {
            if (condition)
            {
                return input.Where(c => c.Definition.IsInterface);
            }
            else
            {
                return input.Where(c => !c.Definition.IsInterface);
            }
        }

        /// <summary> Function for finding static classes. </summary>
        internal static IEnumerable<TypeSpec> BeStatic(IEnumerable<TypeSpec> input, bool dummy, bool condition)
        {
            if (condition)
            {
                return input.Where(ClassIsStatic);
            }
            else
            {
                return input.Where(c => !ClassIsStatic(c));
            }

            bool ClassIsStatic(TypeSpec c) => c.Definition.IsAbstract && c.Definition.IsSealed && !c.Definition.IsInterface && !c.Definition.GetConstructors().Any(m => m.IsPublic);
        }

        /// <summary> Function for finding types with generic parameters. </summary>
        internal static IEnumerable<TypeSpec> BeGeneric(IEnumerable<TypeSpec> input, bool dummy, bool condition)
        {
            if (condition)
            {
                return input.Where(c => c.Definition.HasGenericParameters);
            }
            else
            {
                return input.Where(c => !c.Definition.HasGenericParameters);
            }
        }


        /// <summary> Function for finding nested classes. </summary>
        internal static IEnumerable<TypeSpec> BeNested(IEnumerable<TypeSpec> input, bool dummy, bool condition)
        {
            if (condition)
            {
                return input.Where(c => c.Definition.IsNested);
            }
            else
            {
                return input.Where(c => !c.Definition.IsNested);
            }
        }

        /// <summary> Function for finding nested public classes. </summary>
        internal static IEnumerable<TypeSpec> BeNestedPublic(IEnumerable<TypeSpec> input, bool dummy, bool condition)
        {
            if (condition)
            {
                return input.Where(c => c.Definition.IsNestedPublic);
            }
            else
            {
                return input.Where(c => !c.Definition.IsNestedPublic);
            }
        }

        /// <summary> Function for finding nested private classes. </summary>
        internal static IEnumerable<TypeSpec> BeNestedPrivate(IEnumerable<TypeSpec> input, bool dummy, bool condition)
        {
            if (condition)
            {
                return input.Where(c => c.Definition.IsNestedPrivate);
            }
            else
            {
                return input.Where(c => !c.Definition.IsNestedPrivate);
            }
        }


        /// <summary> Function for finding public classes. </summary>
        internal static IEnumerable<TypeSpec> BePublic(IEnumerable<TypeSpec> input, bool dummy, bool condition)
        {
            if (condition)
            {
                return input.Where(c => c.Definition.IsNested ? c.Definition.IsNestedPublic : c.Definition.IsPublic);
            }
            else
            {
                return input.Where(c => c.Definition.IsNested ? !c.Definition.IsNestedPublic : c.Definition.IsNotPublic);
            }
        }

        /// <summary> Function for finding sealed classes. </summary>
        internal static IEnumerable<TypeSpec> BeSealed(IEnumerable<TypeSpec> input, bool dummmy, bool condition)
        {
            if (condition)
            {
                return input.Where(c => c.Definition.IsSealed);
            }
            else
            {
                return input.Where(c => !c.Definition.IsSealed);
            }
        }

        /// <summary> Function for finding immutable classes. </summary>
        internal static IEnumerable<TypeSpec> BeImmutable(IEnumerable<TypeSpec> input, bool dummmy, bool condition)
        {
            if (condition)
            {
                return input.Where(c => c.Definition.IsImmutable());
            }
            else
            {
                return input.Where(c => !c.Definition.IsImmutable());
            }
        }

        /// <summary> Function for finding nullable classes. </summary>
        internal static IEnumerable<TypeSpec> HasNullableMembers(IEnumerable<TypeSpec> input, bool dummmy, bool condition)
        {
            if (condition)
            {
                return input.Where(c => c.Definition.HasNullableMembers());
            }
            else
            {
                return input.Where(c => !c.Definition.HasNullableMembers());
            }
        }

        /// <summary> Function for finding types in a particular namespace. </summary>
        internal static IEnumerable<TypeSpec> ResideInNamespace(IEnumerable<TypeSpec> input, string name, bool condition)
        {
            if (condition)
            {
                return input.Where(c => c.Definition.FullName.StartsWith(name, StringComparison.InvariantCultureIgnoreCase));
            }
            else
            {
                return input.Where(c => !c.Definition.FullName.StartsWith(name, StringComparison.InvariantCultureIgnoreCase));
            }
        }

        /// <summary> Function for matching a type name using a regular expression. </summary>
        internal static IEnumerable<TypeSpec> ResideInNamespaceMatching(IEnumerable<TypeSpec> input, string pattern, bool condition)
        {
            Regex r = new Regex(pattern, RegexOptions.IgnoreCase);
            if (condition)
            {
                return input.Where(c => r.Match(c.Definition.GetNamespace()).Success);
            }
            else
            {
                return input.Where(c => !r.Match(c.Definition.GetNamespace()).Success);
            }
        }

        /// <summary> Function for finding types that have a dependency on any of the supplied types. </summary>
        internal static IEnumerable<TypeSpec> HaveDependencyOnAny(IEnumerable<TypeSpec> input, IEnumerable<string> dependencies, bool condition)
        {
            // Get the types that contain the dependencies
            var search = new DependencySearch();
            var results = search.FindTypesThatHaveDependencyOnAny(input, dependencies);

            if (condition)
            {
                return results;
            }
            else
            {
                return input.Where(t => !results.Contains(t));
            }
        }

        /// <summary> Function for finding types that have a dependency on all of the supplied types. </summary>
        internal static IEnumerable<TypeSpec> HaveDependencyOnAll(IEnumerable<TypeSpec> input, IEnumerable<string> dependencies, bool condition)
        {
            // Get the types that contain the dependencies
            var search = new DependencySearch();
            var results = search.FindTypesThatHaveDependencyOnAll(input, dependencies);

            if (condition)
            {
                return results;
            }
            else
            {
                return input.Where(t => !results.Contains(t));
            }
        }

        /// <summary> Function for finding types that have a dependency on type other than one of the supplied types.</summary>
        internal static IEnumerable<TypeSpec> OnlyHaveDependenciesOnAnyOrNone(IEnumerable<TypeSpec> input, IEnumerable<string> dependencies, bool condition)
        {
            var search = new DependencySearch();
            var results = search.FindTypesThatOnlyHaveDependenciesOnAnyOrNone(input, dependencies);

            if (condition)
            {
                return results;
            }
            else
            {
                return input.Where(t => !results.Contains(t));
            }
        }

        /// <summary> Function for finding public classes. </summary>
        internal static IEnumerable<TypeSpec> MeetCustomRule(IEnumerable<TypeSpec> input, ICustomRule rule, bool condition)
        {
            if (condition)
            {
                return input.Where(t => rule.MeetsRule(t.Definition));
            }
            else
            {
                return input.Where(t => !rule.MeetsRule(t.Definition));
            }
        }
    }
}