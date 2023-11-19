using System.Collections.Generic;
using System.Linq;
using Mono.Cecil;
using Mono.Cecil.Rocks;
using NetArchTest.Assemblies;

namespace NetArchTest.Functions
{
    internal static partial class FunctionDelegates
    {
        /// <summary> Function for finding abstract classes. </summary>
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

        /// <summary> Function for finding classes. </summary>
        internal static IEnumerable<TypeSpec> BeClass(IEnumerable<TypeSpec> input, bool condition)
        {
            if (condition)
            {
                return input.Where(c => c.Definition.IsClass);
            }
            else
            {
                return input.Where(c => !c.Definition.IsClass);
            }
        }

        /// <summary> Function for finding interfaces. </summary>
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

        /// <summary> Function for finding static classes. </summary>
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

        /// <summary> Function for finding types with generic parameters. </summary>
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


        /// <summary> Function for finding nested classes. </summary>
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

        /// <summary> Function for finding nested public classes. </summary>
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

        /// <summary> Function for finding nested private classes. </summary>
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


        /// <summary> Function for finding public classes. </summary>
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

        /// <summary> Function for finding sealed classes. </summary>
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

        /// <summary> Function for finding immutable classes. </summary>
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


        /// <summary> Function for finding nullable classes. </summary>
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