using System.Collections.Generic;
using System.Linq;
using Mono.Cecil;
using NetArchTest.Assemblies;

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
    }
}
