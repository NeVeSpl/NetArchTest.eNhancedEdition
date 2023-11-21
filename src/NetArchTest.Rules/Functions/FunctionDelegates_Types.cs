using System.Collections.Generic;
using System.Linq;
using Mono.Cecil;
using NetArchTest.Assemblies;

namespace NetArchTest.Functions
{
    internal static partial class FunctionDelegates
    {
        // Types

        internal static IEnumerable<TypeSpec> BeClass(IEnumerable<TypeSpec> input, bool condition)
        {
            if (condition)
            {
                return input.Where(c => IsClass(c.Definition));
            }
            else
            {
                return input.Where(c => !IsClass(c.Definition));
            }

            bool IsClass(TypeDefinition c) => c.IsClass && !c.IsValueType && !c.IsDelegate();
        }

        internal static IEnumerable<TypeSpec> BeDelegate(IEnumerable<TypeSpec> input, bool condition)
        {
            if (condition)
            {
                return input.Where(c => c.Definition.IsDelegate());
            }
            else
            {
                return input.Where(c => !c.Definition.IsDelegate());
            }
        }

        internal static IEnumerable<TypeSpec> BeEnum(IEnumerable<TypeSpec> input, bool condition)
        {
            if (condition)
            {
                return input.Where(c => c.Definition.IsEnum);
            }
            else
            {
                return input.Where(c => !c.Definition.IsEnum);
            }
        }

        internal static IEnumerable<TypeSpec> BeInterface(IEnumerable<TypeSpec> input, bool condition)
        {
            if (condition)
            {
                return input.Where(c => c.Definition.IsInterface);
            }
            else
            {
                return input.Where(c => !c.Definition.IsInterface);
            }
        }

        internal static IEnumerable<TypeSpec> BeStruct(IEnumerable<TypeSpec> input, bool condition)
        {
            if (condition)
            {
                return input.Where(c => c.Definition.IsStruct());
            }
            else
            {
                return input.Where(c => !c.Definition.IsStruct());
            }
        }

        // todo

        internal static IEnumerable<TypeSpec> BeRecord(IEnumerable<TypeSpec> input, bool condition)
        {
            if (condition)
            {
                return Enumerable.Empty<TypeSpec>();
            }
            else
            {
                return Enumerable.Empty<TypeSpec>();
            }
        }

    }
}