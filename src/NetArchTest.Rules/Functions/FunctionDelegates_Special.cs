﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Mono.Cecil;
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

        internal static IEnumerable<TypeSpec> HaveFileNameMatchingTypeName(FunctionSequenceExecutionContext context, IEnumerable<TypeSpec> input, bool condition)
        {
            if (condition)
            {
                return input.Where(c => IsMatching(c.SourceFilePath, c.Definition.GetName(), context.UserOptions.Comparer));
            }
            else
            {
                return input.Where(c => !IsMatching(c.SourceFilePath, c.Definition.GetName(), context.UserOptions.Comparer));
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
    }
}
