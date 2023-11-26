using System;

namespace Mono.Cecil
{
    static internal class TypeReferenceExtensions
    {
        /// <summary>
        /// Tests whether a Type is a non-nullable value type
        /// </summary>
        /// <param name="typeReference">The class to test.</param>
        /// <returns>An indication of whether the type has any memebers that are non-nullable value types</returns>
        public static bool IsNullable(this TypeReference typeReference)
        {
            return !typeReference.IsValueType || typeReference.Resolve().ToType() == typeof(Nullable<>);
        }

        /// <summary>
        /// Returns namespace of the given type, if the type is nested, namespace of containing type is returned instead
        /// </summary>        
        public static string GetNamespace(this TypeReference typeReference)
        {
            if (typeReference.IsNested)
            {
                return typeReference?.DeclaringType.FullName;
            }
            return typeReference.Namespace;
        }


        public static string GetFullNameWithoutGenericParameters(this TypeReference typeReference)
        {
            if (typeReference is GenericInstanceType genericInstanceType && genericInstanceType.HasGenericArguments)
            {
                return typeReference.GetNamespace() + "." + typeReference.Name;
            }

            if (typeReference.HasGenericParameters == true )
            {
                return typeReference.GetNamespace() + "." + typeReference.Name;
            }

            return typeReference.FullName;
        }

        public static bool IsSameTypeAs(this TypeReference a, TypeReference b)
        {
            bool sameAssembly = a.IsFromSameAssemblyAs(b);
            bool sameName = string.Equals(a.FullName, b.FullName, StringComparison.Ordinal);
            return sameAssembly && sameName;
        }
        private static bool IsFromSameAssemblyAs(this TypeReference a, TypeReference b)
        {
            var aName = GetAssemblyName(a.Scope);
            var bName = GetAssemblyName(b.Scope);

            return aName == bName;
        }
        private static string GetAssemblyName(IMetadataScope scope)
        {
            if (scope is ModuleDefinition moduleDefinition)
            {
                return moduleDefinition.Assembly.FullName;
            }
            if (scope is AssemblyNameReference assemblyNameReference)
            {
                return assemblyNameReference.FullName;
            }
            return scope.Name;
        }
    }
}