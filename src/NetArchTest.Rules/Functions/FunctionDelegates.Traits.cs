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

            bool ClassIsAbstract(TypeDefinition c) => c.IsAbstract && !c.IsSealed;
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
                return input.Where(c => ClassIsSealed(c.Definition));
            }
            else
            {
                return input.Where(c => !ClassIsSealed(c.Definition));
            }

            bool ClassIsSealed(TypeDefinition c) => !c.IsAbstract && c.IsSealed;
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
            bool IsPublic(TypeDefinition c) => c.IsPublic || c.IsNestedPublic;
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

            bool IsInternal(TypeDefinition c) => c.IsNotPublic || c.IsNestedAssembly;
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