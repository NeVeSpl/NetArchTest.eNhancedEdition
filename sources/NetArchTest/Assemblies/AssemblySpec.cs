using System.Collections.Generic;
using System.Linq;
using Mono.Cecil;
using NetArchTest.Assemblies.PublicUse;
using NetArchTest.Rules;

namespace NetArchTest.Assemblies
{
    internal sealed class AssemblySpec
    {
        private readonly AssemblyDefinition _assemblyDefinition;
        private readonly TypeDefinition[] _typeDefinitions;
        private readonly List<AssemblySpec> _referenced = [];

        public string FullName => _assemblyDefinition.FullName;

        public AssemblySpec(AssemblyDefinition assemblyDefinition, IEnumerable<TypeDefinition> typeDefinitions)
        {
            _assemblyDefinition = assemblyDefinition;
            _typeDefinitions = typeDefinitions.ToArray();
        }

        public void AddRef(AssemblySpec assemblySpec)
        {
            _referenced.Add(assemblySpec);
        }

        public IEnumerable<TypeSpec> GetTypes()
        {
            return _typeDefinitions.Select(x => new TypeSpec(x));
        }

        public IAssembly CreateWrapper()
        {
            return new AssemblyContainer(_assemblyDefinition);
        }
    }
}
