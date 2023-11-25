using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Mono.Cecil
{
    static internal class TypeDefinitionExtensions
    {
        /// <summary>
        /// Tests whether one class inherits from another.
        /// </summary>
        /// <param name="child">The class that is inheriting from the parent.</param>
        /// <param name="parent">The parent that is inherited.</param>
        /// <returns>An indication of whether the child inherits from the parent.</returns>
        public static bool IsSubclassOf(this TypeDefinition child, TypeDefinition parent)
        {
            if (parent != null)
            {
                return !child.IsSameTypeAs(parent)
                       && child.EnumerateBaseClasses().Any(b => b.IsSameTypeAs(parent));
            }

            return false;
        }

        /// <summary>
        /// Tests whether two type definitions are from the same assembly.
        /// The comparison is based on the full assembly names.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>An indication of whether the both types are from the same assembly.</returns>
        public static bool IsFromSameAssemblyAs(this TypeDefinition a, TypeDefinition b)
        {
            return a.Module.Assembly.ToString() == b.Module.Assembly.ToString();
        }

        /// <summary>
        /// Tests whether the provided types are the same type.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>An indication of whether the types are the same.</returns>
        public static bool IsSameTypeAs(this TypeDefinition a, TypeDefinition b)
        {
            return a.IsFromSameAssemblyAs(b) && a.MetadataToken == b.MetadataToken;
        }

        /// <summary>
        /// Enumerate the base classes throughout the chain of inheritence.
        /// </summary>
        /// <param name="classType">The class to enumerate.</param>
        /// <returns>The enumeration of base classes.</returns>
        private static IEnumerable<TypeDefinition> EnumerateBaseClasses(this TypeDefinition classType)
        {
            for (var typeDefinition = classType; typeDefinition != null; typeDefinition = typeDefinition.BaseType?.Resolve())
            {
                yield return typeDefinition;
            }
        }

        /// <summary>
        /// Convert the definition to a <see cref="Type"/> object instance.
        /// </summary>
        /// <param name="typeDefinition">The type definition to convert.</param>
        /// <returns>The equivalent <see cref="Type"/> object instance.</returns>
        public static Type ToType(this TypeDefinition typeDefinition)
        {
            var fullName = RuntimeNameToReflectionName(typeDefinition.FullName);
            return Type.GetType(string.Concat(fullName, ", ", typeDefinition.Module.Assembly.FullName), true);
        }
        public static string RuntimeNameToReflectionName(this string cliName)
        {
            // Nested types have a forward slash that should be replaced with "+"
            // C++ template instantiations contain comma separator for template arguments,
            // getting address operators and pointer type designations which should be prefixed by backslash
            var fullName = cliName.Replace("/", "+")
                .Replace(",", "\\,")
                .Replace("&", "\\&")
                .Replace("*", "\\*");
            return fullName;
        }




        /// <summary>
        /// Tests whether a class is immutable, i.e. all public fields are readonly and properties have no set method
        /// </summary>      
        public static bool IsImmutable(this TypeDefinition typeDefinition)
        {
            var propertiesAreReadonly = typeDefinition.Properties.All(p => p.IsReadonly());
            var fieldsAreReadonly = typeDefinition.Fields.All(f => f.IsReadonly());
            var eventsAreReadonly = typeDefinition.Events.All(f => f.IsReadonly());
            return propertiesAreReadonly && fieldsAreReadonly && eventsAreReadonly;
        }

        public static bool IsImmutableExternally(this TypeDefinition typeDefinition)
        {
            var propertiesAreReadonly = typeDefinition.Properties.All(p => p.IsReadonlyExternally());
            var fieldsAreReadonly = typeDefinition.Fields.All(f => f.IsReadonlyExternally());
            var eventsAreReadonly = typeDefinition.Events.All(f => f.IsReadonlyExternally());
            return propertiesAreReadonly && fieldsAreReadonly && eventsAreReadonly;
        }



        public static bool OnlyHasNullableMembers(this TypeDefinition typeDefinition)
        {
            var propertiesAreNullable = typeDefinition.Properties.All(p => p.IsNullable());
            var fieldsAreNullable = typeDefinition.Fields.All(f => f.IsNullable());
            return propertiesAreNullable && fieldsAreNullable;
        }

        public static bool OnlyHasNonNullableMembers(this TypeDefinition typeDefinition)
        {
            var propertiesAreNonNullable = typeDefinition.Properties.All(p => p.IsNullable() == false);
            var fieldsAreNonNullable = typeDefinition.Fields.All(f => f.IsNullable() == false);
            return propertiesAreNonNullable && fieldsAreNonNullable;
        }

        public static bool IsCompilerGenerated(this TypeDefinition typeDefinition)
        {
            return typeDefinition.CustomAttributes.Any(x => x?.AttributeType?.FullName == typeof(CompilerGeneratedAttribute).FullName);
        }

        /// <summary>
        /// Returns namespace of the given type, if the type is nested, namespace of containing type is returned instead
        /// </summary>        
        /// <remarks>
        /// For nested classes this will take the name of the declaring class. See https://github.com/BenMorris/NetArchTest/issues/73
        /// </remarks>
        public static string GetNamespace(this TypeDefinition typeDefinition)
        {
            if (typeDefinition.IsNested)
            {
                return typeDefinition.DeclaringType.FullName;
            }
            return typeDefinition.Namespace;
        }



        public static string GetNameWithoutGenericPart(this TypeDefinition typeDefinition)
        {
            if (typeDefinition.HasGenericParameters == false)
            {
                return typeDefinition.Name;
            }
            return typeDefinition.Name.RemoveGenericPart();
        }
        




        public static bool IsDelegate(this TypeDefinition typeDefinition)
        {
            return typeDefinition.IsClass && typeDefinition.BaseType?.FullName == "System.MulticastDelegate";
        }
        public static bool IsStruct(this TypeDefinition typeDefinition)
        {
            return typeDefinition.IsValueType && typeDefinition.BaseType?.FullName == "System.ValueType";
        }



        public static string GetFilePath(this TypeDefinition typeDefinition)
        {
            if (typeDefinition.HasMethods)
            {
                foreach (var method in typeDefinition.Methods)
                {
                    if (method.DebugInformation.HasSequencePoints)
                    {
                        foreach (var s in method.DebugInformation.SequencePoints)
                        {
                            return s.Document.Url;
                        }
                    }
                }
            }
            return null;
        }

        public static bool IsStateless(this TypeDefinition type)
        {
            // Check if the type has any instance fields
            if (type.HasFields)
            {
                foreach (var field in type.Fields)
                {
                    // If the field is not static, the type is not stateless
                    if (!field.IsStatic)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}