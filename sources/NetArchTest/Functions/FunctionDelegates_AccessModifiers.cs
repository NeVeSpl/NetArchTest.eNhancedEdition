using System.Collections.Generic;
using System.Linq;
using Mono.Cecil;
using NetArchTest.Assemblies;

namespace NetArchTest.Functions
{
    internal static partial class FunctionDelegates
    {
        // Access Modifiers & Nested

        internal static IEnumerable<TypeSpec> BePublic(IEnumerable<TypeSpec> input, bool condition)
        {
            if (condition)
            {
                return input.Where(c => IsPublic(c.Definition));
            }
            else
            {
                return input.Where(c => !IsPublic(c.Definition));
            }
            static bool IsPublic(TypeDefinition c) => c.IsPublic || c.IsNestedPublic;
        }

        internal static IEnumerable<TypeSpec> BeInternal(IEnumerable<TypeSpec> input, bool condition)
        {
            if (condition)
            {
                return input.Where(c => IsInternal(c.Definition));
            }
            else
            {
                return input.Where(c => !IsInternal(c.Definition));
            }

            static bool IsInternal(TypeDefinition c) => c.IsNotPublic || c.IsNestedAssembly;
        }

        internal static IEnumerable<TypeSpec> BeNested(IEnumerable<TypeSpec> input, bool condition)
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

        internal static IEnumerable<TypeSpec> BePrivate(IEnumerable<TypeSpec> input, bool condition)
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

        internal static IEnumerable<TypeSpec> BeProtected(IEnumerable<TypeSpec> input, bool condition)
        {
            if (condition)
            {
                return input.Where(c => c.Definition.IsNestedFamily);
            }
            else
            {
                return input.Where(c => !c.Definition.IsNestedFamily);
            }
        }

        internal static IEnumerable<TypeSpec> BeProtectedInternal(IEnumerable<TypeSpec> input, bool condition)
        {
            if (condition)
            {
                return input.Where(c => c.Definition.IsNestedFamilyOrAssembly);
            }
            else
            {
                return input.Where(c => !c.Definition.IsNestedFamilyOrAssembly);
            }
        }

        internal static IEnumerable<TypeSpec> BePrivateProtected(IEnumerable<TypeSpec> input, bool condition)
        {
            if (condition)
            {
                return input.Where(c => c.Definition.IsNestedFamilyAndAssembly);
            }
            else
            {
                return input.Where(c => !c.Definition.IsNestedFamilyAndAssembly);
            }
        }
    }
}