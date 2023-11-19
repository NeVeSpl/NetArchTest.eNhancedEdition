using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Mono.Cecil;
using NetArchTest.Assemblies;
using NetArchTest.Rules;

namespace NetArchTest.Functions
{
    internal static partial class FunctionDelegates
    {
        internal static IEnumerable<TypeSpec> HaveName(IEnumerable<TypeSpec> input, string name, bool condition)
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