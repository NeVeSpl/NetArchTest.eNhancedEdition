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

        internal static IEnumerable<TypeSpec> AreOfType(FunctionSequenceExecutionContext context, IEnumerable<TypeSpec> input, Type[] types, bool condition)
        {
            var targets = types.Select(x =>  x.ToTypeDefinition());

            if (condition)
            {
                return input.Where(c => targets.Any(t => c.Definition.IsAlmostEqualTo(t)));
            }
            else
            {
                return input.Where(c => !targets.Any(t => c.Definition.IsAlmostEqualTo(t)));
            }
        }

        internal static IEnumerable<TypeSpec> HaveName(FunctionSequenceExecutionContext context, IEnumerable<TypeSpec> input, string[] names, bool condition)
        {
            var plainNames = names.Select(x => x.RemoveGenericPart()).ToArray();
            if (condition)
            {
                return input.Where(c => HasName(c.Definition.GetNameWithoutGenericPart(), plainNames, context.UserOptions.Comparer));
            }
            else
            {
                return input.Where(c => !HasName(c.Definition.GetNameWithoutGenericPart(), plainNames, context.UserOptions.Comparer));
            }

            static bool HasName(string typeName, string[] lookigFor, StringComparison comparer) => lookigFor.Any(x => typeName.Equals(x, comparer));
        }

        internal static IEnumerable<TypeSpec> HaveNameMatching(IEnumerable<TypeSpec> input, string pattern, bool condition)
        {
            Regex r = new Regex(pattern, RegexOptions.IgnoreCase);
            if (condition)
            {
                return input.Where(c => r.Match(c.Definition.GetNameWithoutGenericPart()).Success);
            }
            else
            {
                return input.Where(c => !r.Match(c.Definition.GetNameWithoutGenericPart()).Success);
            }
        }

        internal static IEnumerable<TypeSpec> HaveNameStartingWith(FunctionSequenceExecutionContext context, IEnumerable<TypeSpec> input, string[] prefixes, bool condition)
        {
            if (condition)
            {
                return input.Where(c => StartsWith(c.Definition.GetNameWithoutGenericPart(), prefixes, context.UserOptions.Comparer));
            }
            else
            {
                return input.Where(c => !StartsWith(c.Definition.GetNameWithoutGenericPart(), prefixes, context.UserOptions.Comparer));
            }

            static bool StartsWith(string typeName, string[] lookigFor, StringComparison comparer) => lookigFor.Any(x => typeName.StartsWith(x, comparer));
        }

        internal static IEnumerable<TypeSpec> HaveNameEndingWith(FunctionSequenceExecutionContext context, IEnumerable<TypeSpec> input, string[] suffixes, bool condition)
        {
            if (condition)
            {
                return input.Where(c => EndsWith(c.Definition.GetNameWithoutGenericPart(), suffixes, context.UserOptions.Comparer));
            }
            else
            {
                return input.Where(c => !EndsWith(c.Definition.GetNameWithoutGenericPart(), suffixes, context.UserOptions.Comparer));
            }

            static bool EndsWith(string typeName, string[] lookigFor, StringComparison comparer) => lookigFor.Any(x => typeName.EndsWith(x, comparer));
        }

        
        internal static IEnumerable<TypeSpec> ResideInNamespace(FunctionSequenceExecutionContext context, IEnumerable<TypeSpec> input, string name, bool condition)
        {
            if (condition)
            {
                return input.Where(c => c.Definition.GetNamespace().StartsWith(name, context.UserOptions.Comparer));
            }
            else
            {
                return input.Where(c => !c.Definition.GetNamespace().StartsWith(name, context.UserOptions.Comparer));
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
