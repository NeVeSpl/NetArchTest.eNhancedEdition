using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Mono.Cecil;
using NetArchTest.Assemblies;

namespace NetArchTest.Functions
{
    internal static partial class FunctionDelegates
    {
        // Name & Namespace

        internal static IEnumerable<TypeSpec> HaveName(IEnumerable<TypeSpec> input, string name, bool condition)
        {
            var plainName = name.RemoveGenericPart();
            if (condition)
            {
                return input.Where(c => c.Definition.GetName().Equals(plainName, StringComparison.InvariantCultureIgnoreCase));
            }
            else
            {
                return input.Where(c => !c.Definition.GetName().Equals(plainName, StringComparison.InvariantCultureIgnoreCase));
            }
        }

        internal static IEnumerable<TypeSpec> HaveNameMatching(IEnumerable<TypeSpec> input, string pattern, bool condition)
        {
            Regex r = new Regex(pattern, RegexOptions.IgnoreCase);
            if (condition)
            {
                return input.Where(c => r.Match(c.Definition.GetName()).Success);
            }
            else
            {
                return input.Where(c => !r.Match(c.Definition.GetName()).Success);
            }
        }

        internal static IEnumerable<TypeSpec> HaveNameStartingWith(IEnumerable<TypeSpec> input, string start, bool condition, StringComparison comparer = StringComparison.InvariantCultureIgnoreCase)
        {
            if (condition)
            {
                return input.Where(c => c.Definition.GetName().StartsWith(start, comparer));
            }
            else
            {
                return input.Where(c => !c.Definition.GetName().StartsWith(start, comparer));
            }
        }

        internal static IEnumerable<TypeSpec> HaveNameEndingWith(IEnumerable<TypeSpec> input, string end, bool condition, StringComparison comparer = StringComparison.InvariantCultureIgnoreCase)
        {
            if (condition)
            {
                return input.Where(c => c.Definition.GetName().EndsWith(end, comparer));
            }
            else
            {
                return input.Where(c => !c.Definition.GetName().EndsWith(end, comparer));
            }
        }

        
        internal static IEnumerable<TypeSpec> ResideInNamespace(IEnumerable<TypeSpec> input, string name, bool condition)
        {
            if (condition)
            {
                return input.Where(c => c.Definition.GetNamespace().StartsWith(name, StringComparison.InvariantCultureIgnoreCase));
            }
            else
            {
                return input.Where(c => !c.Definition.GetNamespace().StartsWith(name, StringComparison.InvariantCultureIgnoreCase));
            }
        }
        
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
    }
}
