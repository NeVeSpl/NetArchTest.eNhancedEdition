using System.Reflection;
using Mono.Cecil;
using NetArchTest.Dependencies;

namespace System
{
    internal static class TypeExtensions
    {
        public static TypeDefinition ToTypeDefinition(this Type type)
        {
            var reflectionAssembly = Assembly.GetAssembly(type);
            var assemblyDef = AssemblyDefinition.ReadAssembly(reflectionAssembly.Location);

            foreach (var module in assemblyDef.Modules)
            {
                var typeRef = module.GetType(type.FullName, true);
                var typeDef = typeRef?.Resolve();
                if (typeDef is not null) return typeDef;
            }

            return null;
        }

        public static string GetNormalizedFullName(this Type type)
        {
            var monoName = TypeParser.ParseReflectionNameToRuntimeName(type.FullName);

            if (type.IsGenericType && !type.ContainsGenericParameters)
            {
                //return toString.ReflectionNameToRuntimeName();
            }

            return monoName;
        }
    }
}