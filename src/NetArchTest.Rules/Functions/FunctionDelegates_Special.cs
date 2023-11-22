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

        internal static IEnumerable<TypeSpec> HasNullableMembers(IEnumerable<TypeSpec> input, bool condition)
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
    }
}
