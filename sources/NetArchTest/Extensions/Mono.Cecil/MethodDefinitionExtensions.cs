using System.CodeDom.Compiler;
using System.Linq;
using System.Runtime.CompilerServices;
using Mono.Cecil;

namespace NetArchTest.Extensions.Mono.Cecil
{
    internal static class MethodDefinitionExtensions
    {
        public static bool IsGeneratedCode(this MethodDefinition method)
        {
            if (method == null)
                return false;

            if (method.HasCustomAttributes == false)
                return false;

            return method.CustomAttributes.Any(x => x?.AttributeType?.FullName == typeof(CompilerGeneratedAttribute).FullName || x?.AttributeType?.FullName == typeof(GeneratedCodeAttribute).FullName);
        }
    }
}