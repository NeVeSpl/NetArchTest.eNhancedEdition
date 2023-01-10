using Mono.Cecil;

namespace NetArchTest.Assemblies
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



        public TypeWrapper CreateWrapper()
        {
            return new TypeWrapper(Definition);
        }


        public static implicit operator TypeDefinition(TypeSpec type)
        {
            return type.Definition;
        }
    }
}