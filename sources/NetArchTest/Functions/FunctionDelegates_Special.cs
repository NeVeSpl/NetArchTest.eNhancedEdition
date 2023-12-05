using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Mono.Cecil;
using Mono.Cecil.Rocks;
using NetArchTest.Assemblies;
using NetArchTest.RuleEngine;

namespace NetArchTest.Functions
{
    internal static partial class FunctionDelegates
    {
        internal static IEnumerable<TypeSpec> BeImmutable(IEnumerable<TypeSpec> input, bool condition)
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
        internal static IEnumerable<TypeSpec> BeImmutableExternally(IEnumerable<TypeSpec> input, bool condition)
        {
            if (condition)
            {
                return input.Where(c => c.Definition.IsImmutableExternally());
            }
            else
            {
                return input.Where(c => !c.Definition.IsImmutableExternally());
            }
        }


        internal static IEnumerable<TypeSpec> OnlyHaveNullableMembers(IEnumerable<TypeSpec> input, bool condition)
        {
            if (condition)
            {
                return input.Where(c => c.Definition.OnlyHasNullableMembers());
            }
            else
            {
                return input.Where(c => !c.Definition.OnlyHasNullableMembers());
            }
        }

        internal static IEnumerable<TypeSpec> OnlyHaveNonNullableMembers(IEnumerable<TypeSpec> input, bool condition)
        {
            if (condition)
            {
                return input.Where(c => c.Definition.OnlyHasNonNullableMembers());
            }
            else
            {
                return input.Where(c => !c.Definition.OnlyHasNonNullableMembers());
            }
        }


        internal static IEnumerable<TypeSpec> BeStateless(IEnumerable<TypeSpec> input, bool condition)
        {
            if (condition)
            {
                return input.Where(c => c.Definition.IsStateless());
            }
            else
            {
                return input.Where(c => !c.Definition.IsStateless());
            }
        }
        internal static IEnumerable<TypeSpec> BeStaticless(IEnumerable<TypeSpec> input, bool condition)
        {
            if (condition)
            {
                return input.Where(c => c.Definition.IsStaticless());
            }
            else
            {
                return input.Where(c => !c.Definition.IsStaticless());
            }
        }

        internal static IEnumerable<TypeSpec> HaveFileNameMatchingTypeName(FunctionSequenceExecutionContext context, IEnumerable<TypeSpec> input, bool condition)
        {
            if (condition)
            {
                return input.Where(c => IsMatching(c.SourceFilePath, c.Definition.GetNameWithoutGenericPart(), context.UserOptions.Comparer));
            }
            else
            {
                return input.Where(c => !IsMatching(c.SourceFilePath, c.Definition.GetNameWithoutGenericPart(), context.UserOptions.Comparer));
            }

            static bool IsMatching(string sourceFilePath, string typeName, StringComparison comparer)
            {
                if (string.IsNullOrEmpty(sourceFilePath)) return true;

                var fileName = Path.GetFileNameWithoutExtension(sourceFilePath);
                return fileName.Equals(typeName, comparer);
            }
        }

        internal static IEnumerable<TypeSpec> HaveFilePathMatchingTypeNamespace(FunctionSequenceExecutionContext context, IEnumerable<TypeSpec> input, bool condition)
        {
            if (condition)
            {
                return input.Where(c => IsMatching(c.SourceFilePath, c.Definition.GetNamespace(), context.UserOptions.Comparer));
            }
            else
            {
                return input.Where(c => !IsMatching(c.SourceFilePath, c.Definition.GetNamespace(), context.UserOptions.Comparer));
            }

            static bool IsMatching(string sourceFilePath, string @namespace, StringComparison comparer)
            {
                if (string.IsNullOrEmpty(sourceFilePath)) return true;

                var fullPath = Path.GetDirectoryName(sourceFilePath);
                var pathAsNamespace = fullPath.Replace(Path.DirectorySeparatorChar, '.');                

                return pathAsNamespace.EndsWith(@namespace, comparer);
            }
        }

        internal static IEnumerable<TypeSpec> HaveMatchingTypeWithName(FunctionSequenceExecutionContext context, IEnumerable<TypeSpec> input, Func<TypeDefinition, string> getMatchingTypeName, bool condition)
        {
            var exisitingTypes = new HashSet<string>(context.AllTypes.Select(x => x.Definition.GetNameWithoutGenericPart()));

            if (condition)
            {
                return input.Where(c => exisitingTypes.Contains(getMatchingTypeName(c.Definition)));
            }
            else
            {
                return input.Where(c => !exisitingTypes.Contains(getMatchingTypeName(c.Definition)));
            }
        }


        internal static IEnumerable<TypeSpec> HavePublicConstructor(FunctionSequenceExecutionContext context, IEnumerable<TypeSpec> input, bool condition)
        {
            if (condition)
            {
                return input.Where(c => PublicConstructorExists(c.Definition));
            }
            else
            {
                return input.Where(c => !PublicConstructorExists(c.Definition));
            }

            static bool PublicConstructorExists(TypeDefinition definition)
            {
                return definition.GetConstructors().Any(c => c.IsPublic && !c.IsStatic);
            }
        }

        internal static IEnumerable<TypeSpec> HaveParameterlessConstructor(FunctionSequenceExecutionContext context, IEnumerable<TypeSpec> input, bool condition)
        {
            if (condition)
            {
                return input.Where(c => ParameterlessConstructorExists(c.Definition));
            }
            else
            {
                return input.Where(c => !ParameterlessConstructorExists(c.Definition));
            }

            static bool ParameterlessConstructorExists(TypeDefinition definition)
            {
                return definition.GetConstructors().Any(c => c.HasParameters == false && !c.IsStatic);
            }
        }
    }
}
