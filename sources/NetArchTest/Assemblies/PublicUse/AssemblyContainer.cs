using System.Diagnostics;
using Mono.Cecil;
using NetArchTest.Rules;

namespace NetArchTest.Assemblies.PublicUse
{
    [DebuggerDisplay("{FullName}")]
    internal sealed class AssemblyContainer : IAssembly
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly AssemblyDefinition _monoAssemblyDefinition;


        public string FullName => _monoAssemblyDefinition.FullName;


        public AssemblyContainer(AssemblyDefinition assemblyDefinition)
        {
            _monoAssemblyDefinition = assemblyDefinition;
        }
    }
}
