using System.Collections.Generic;
using System.Linq;
using Mono.Cecil;
using Mono.Cecil.Rocks;
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

        // Modifiers

        internal static IEnumerable<TypeSpec> BeAbstract(IEnumerable<TypeSpec> input, bool condition)
        {
            if (condition)
            {
                return input.Where(c => c.Definition.IsAbstract);
            }
            else
            {
                return input.Where(c => !c.Definition.IsAbstract);
            }
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

            bool ClassIsStatic(TypeSpec c) => c.Definition.IsAbstract && c.Definition.IsSealed && !c.Definition.IsInterface && !c.Definition.GetConstructors().Any(m => m.IsPublic);
        }

        internal static IEnumerable<TypeSpec> BeSealed(IEnumerable<TypeSpec> input, bool condition)
        {
            if (condition)
            {
                return input.Where(c => c.Definition.IsSealed);
            }
            else
            {
                return input.Where(c => !c.Definition.IsSealed);
            }
        }

        // Generic

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

        // Nested
              
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

        internal static IEnumerable<TypeSpec> BeNestedPublic(IEnumerable<TypeSpec> input, bool condition)
        {
            if (condition)
            {
                return input.Where(c => c.Definition.IsNestedPublic);
            }
            else
            {
                return input.Where(c => !c.Definition.IsNestedPublic);
            }
        }

        internal static IEnumerable<TypeSpec> BeNestedPrivate(IEnumerable<TypeSpec> input, bool condition)
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

        // Access Modifiers

        internal static IEnumerable<TypeSpec> BePublic(IEnumerable<TypeSpec> input, bool condition)
        {
            if (condition)
            {
                return input.Where(c => c.Definition.IsNested ? c.Definition.IsNestedPublic : c.Definition.IsPublic);
            }
            else
            {
                return input.Where(c => c.Definition.IsNested ? !c.Definition.IsNestedPublic : c.Definition.IsNotPublic);
            }
        }
            
        // 
              
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