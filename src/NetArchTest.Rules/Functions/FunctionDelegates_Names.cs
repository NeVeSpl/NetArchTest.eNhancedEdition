using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Mono.Cecil;
using NetArchTest.Assemblies;
using NetArchTest.RuleEngine;

namespace NetArchTest.Functions
{
    internal static partial class FunctionDelegates
    {
        // Name & Namespace

        internal static IEnumerable<TypeSpec> HaveName(FunctionSequenceExecutionContext context, IEnumerable<TypeSpec> input, string name, bool condition)
        {
            var plainName = name.RemoveGenericPart();
            if (condition)
            {
                return input.Where(c => c.Definition.GetName().Equals(plainName, context.UserOptions.Comparer));
            }
            else
            {
                return input.Where(c => !c.Definition.GetName().Equals(plainName, context.UserOptions.Comparer));
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

        internal static IEnumerable<TypeSpec> HaveNameStartingWith(FunctionSequenceExecutionContext context, IEnumerable<TypeSpec> input, string start, bool condition)
        {
            if (condition)
            {
                return input.Where(c => c.Definition.GetName().StartsWith(start, context.UserOptions.Comparer));
            }
            else
            {
                return input.Where(c => !c.Definition.GetName().StartsWith(start, context.UserOptions.Comparer));
            }
        }

        internal static IEnumerable<TypeSpec> HaveNameEndingWith(FunctionSequenceExecutionContext context, IEnumerable<TypeSpec> input, string end, bool condition)
        {
            if (condition)
            {
                return input.Where(c => c.Definition.GetName().EndsWith(end, context.UserOptions.Comparer));
            }
            else
            {
                return input.Where(c => !c.Definition.GetName().EndsWith(end, context.UserOptions.Comparer));
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
