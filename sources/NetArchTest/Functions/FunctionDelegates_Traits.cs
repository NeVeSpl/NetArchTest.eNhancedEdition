using System.Collections.Generic;
using System.Linq;
using Mono.Cecil;
using Mono.Cecil.Rocks;
using NetArchTest.Assemblies;

namespace NetArchTest.Functions
{
    internal static partial class FunctionDelegates
    {
        // Modifiers & Generic

        internal static IEnumerable<TypeSpec> BeAbstract(IEnumerable<TypeSpec> input, bool condition)
        {
            if (condition)
            {
                return input.Where(c => ClassIsAbstract(c.Definition));
            }
            else
            {
                return input.Where(c => !ClassIsAbstract(c.Definition));
            }

            static bool ClassIsAbstract(TypeDefinition c) => c.IsAbstract && !c.IsSealed;
        }

        internal static IEnumerable<TypeSpec> BeStatic(IEnumerable<TypeSpec> input, bool condition)
        {
            if (condition)
            {
                return input.Where(ClassIsStatic);
            }
            else
            {
                return input.Where(c => !ClassIsStatic(c));
            }

            static bool ClassIsStatic(TypeSpec c) => c.Definition.IsAbstract && c.Definition.IsSealed && !c.Definition.IsInterface && !c.Definition.GetConstructors().Any(m => m.IsPublic);
        }

        internal static IEnumerable<TypeSpec> BeSealed(IEnumerable<TypeSpec> input, bool condition)
        {
            if (condition)
            {
                return input.Where(c => ClassIsSealed(c.Definition));
            }
            else
            {
                return input.Where(c => !ClassIsSealed(c.Definition));
            }

            static bool ClassIsSealed(TypeDefinition c) => !c.IsAbstract && c.IsSealed;
        }

        internal static IEnumerable<TypeSpec> BeGeneric(IEnumerable<TypeSpec> input, bool condition)
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

        // todo

        internal static IEnumerable<TypeSpec> BeRecord(IEnumerable<TypeSpec> input, bool condition)
        {
            if (condition)
            {
                return [];
            }
            else
            {
                return [];
            }
        }
    }
}