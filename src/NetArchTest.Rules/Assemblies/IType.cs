using Mono.Cecil;

namespace NetArchTest.Rules.Assemblies
{
    public interface IType
    {
        TypeDefinition Definition { get; }
    }


    internal sealed class TypeImpl : IType
    {
        public TypeDefinition Definition { get; }


        public TypeImpl(TypeDefinition definition)
        {
            Definition = definition;
        }        
    }
}