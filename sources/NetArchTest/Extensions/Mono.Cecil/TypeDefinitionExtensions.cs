using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Mono.Cecil
{
    public static partial class TypeDefinitionExtensions
    {
        internal static bool IsSubclassOf(this TypeReference child, TypeReference parent)
        {
            var typeDef = child.Resolve();
            return typeDef.IsSubclassOf(parent);
        }

        internal static bool IsSubclassOf(this TypeDefinition child, TypeReference parent)
        {
            if (parent != null)
            {
                return !child.IsSameTypeAs(parent)
                       && child.EnumerateBaseClasses().Any(b => b.IsSameTypeAs(parent));
            }

            return false;
        }        

        private static IEnumerable<TypeDefinition> EnumerateBaseClasses(this TypeDefinition classType)
        {
            for (var typeDefinition = classType; typeDefinition != null; typeDefinition = typeDefinition.BaseType?.Resolve())
            {
                yield return typeDefinition;
            }
        }

        internal static bool IsAlmostEqualTo(this TypeReference child, TypeDefinition parent)
        {            
            if (child is GenericInstanceType genericInstanceTypeB)
            {
                if (parent.IsSameTypeAs(genericInstanceTypeB.ElementType))
                {
                    return true;
                }
            }

            if (parent.IsSameTypeAs(child))
            {
                return true;
            }

            return false;
        }



        /// <summary>
        /// Convert the definition to a <see cref="Type"/> object instance.
        /// </summary>
        /// <param name="typeDefinition">The type definition to convert.</param>
        /// <returns>The equivalent <see cref="Type"/> object instance.</returns>
        public static Type ToType(this TypeDefinition typeDefinition)
        {
            var fullName = typeDefinition.FullName.RuntimeNameToReflectionName();
            return Type.GetType(string.Concat(fullName, ", ", typeDefinition.Module.Assembly.FullName), true);
        }





        /// <summary>
        /// Tests whether a class is immutable, i.e. all public fields are readonly and properties have no set method
        /// </summary>      
        internal static bool IsImmutable(this TypeDefinition typeDefinition)
        {
            var propertiesAreReadonly = typeDefinition.Properties.All(p => p.IsReadonly());
            var fieldsAreReadonly = typeDefinition.Fields.All(f => f.IsReadonly());
            var eventsAreReadonly = typeDefinition.Events.All(f => f.IsReadonly());
            return propertiesAreReadonly && fieldsAreReadonly && eventsAreReadonly;
        }

        internal static bool IsImmutableExternally(this TypeDefinition typeDefinition)
        {
            var propertiesAreReadonly = typeDefinition.Properties.All(p => p.IsReadonlyExternally());
            var fieldsAreReadonly = typeDefinition.Fields.All(f => f.IsReadonlyExternally());
            var eventsAreReadonly = typeDefinition.Events.All(f => f.IsReadonlyExternally());
            return propertiesAreReadonly && fieldsAreReadonly && eventsAreReadonly;
        }



        internal static bool OnlyHasNullableMembers(this TypeDefinition typeDefinition)
        {
            var propertiesAreNullable = typeDefinition.Properties.All(p => p.IsNullable());
            var fieldsAreNullable = typeDefinition.Fields.All(f => f.IsNullable());
            return propertiesAreNullable && fieldsAreNullable;
        }

        internal static bool OnlyHasNonNullableMembers(this TypeDefinition typeDefinition)
        {
            var propertiesAreNonNullable = typeDefinition.Properties.All(p => p.IsNullable() == false);
            var fieldsAreNonNullable = typeDefinition.Fields.All(f => f.IsNullable() == false);
            return propertiesAreNonNullable && fieldsAreNonNullable;
        }

        internal static bool IsCompilerGenerated(this TypeDefinition typeDefinition)
        {
            return typeDefinition.CustomAttributes.Any(x => x?.AttributeType?.FullName == typeof(CompilerGeneratedAttribute).FullName || x?.AttributeType?.FullName == typeof(GeneratedCodeAttribute).FullName);
        }

        /// <summary>
        /// Returns namespace of the given type, if the type is nested, namespace of containing type is returned instead
        /// </summary>        
        /// <remarks>
        /// For nested classes this will take the name of the declaring class. See https://github.com/BenMorris/NetArchTest/issues/73
        /// </remarks>
        internal static string GetNamespace(this TypeDefinition typeDefinition)
        {
            if (typeDefinition.IsNested)
            {
                return typeDefinition.DeclaringType.FullName;
            }
            return typeDefinition.Namespace;
        }



        internal static string GetNameWithoutGenericPart(this TypeDefinition typeDefinition)
        {
            if (typeDefinition.HasGenericParameters == false)
            {
                return typeDefinition.Name;
            }
            return typeDefinition.Name.RemoveGenericPart();
        }





        internal static bool IsDelegate(this TypeDefinition typeDefinition)
        {
            return typeDefinition.IsClass && typeDefinition.BaseType?.FullName == "System.MulticastDelegate";
        }
        internal static bool IsStruct(this TypeDefinition typeDefinition)
        {
            return typeDefinition.IsValueType && typeDefinition.BaseType?.FullName == "System.ValueType";
        }



        internal static string GetFilePath(this TypeDefinition typeDefinition)
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

        internal static bool IsStateless(this TypeDefinition type)
        {            
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
        internal static bool IsStaticless(this TypeDefinition type)
        {           
            if (type.HasFields)
            {
                foreach (var field in type.Fields)
                {                    
                    if (field.IsStatic && field.HasConstant == false)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}