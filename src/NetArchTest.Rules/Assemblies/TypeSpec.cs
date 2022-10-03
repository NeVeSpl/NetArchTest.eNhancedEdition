using Mono.Cecil;

namespace NetArchTest.Rules.Assemblies
{
    internal sealed class TypeSpec
    {
        public TypeDefinition Definition { get; }
        public string FullName => Definition.FullName;
        internal bool IsSelected { get; set;  }


        public TypeSpec(TypeDefinition definition)
        {
            Definition = definition;
        }


        public static implicit operator TypeDefinition(TypeSpec type)
        {
            return type.Definition;
        }
    }
}