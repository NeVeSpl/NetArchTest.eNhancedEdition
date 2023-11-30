using System.Collections.Generic;
using System.Linq;
using Mono.Cecil;

namespace NetArchTest.Assemblies
{
    internal sealed class AssemblySpec
    {
        private AssemblyDefinition assemblyDefinition;
        private IReadOnlyList<TypeDefinition> typeDefinitions;


        public AssemblySpec(AssemblyDefinition assemblyDefinition, IEnumerable<TypeDefinition> typeDefinitions)
        {
            this.assemblyDefinition = assemblyDefinition;
            this.typeDefinitions = typeDefinitions.ToArray();
        }


        public IEnumerable<TypeSpec> GetTypes() 
        {
            return typeDefinitions.Select(x => new TypeSpec(x));
        }
    }
}
