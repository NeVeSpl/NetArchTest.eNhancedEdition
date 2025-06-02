using System.Diagnostics;
using Mono.Cecil;
using NetArchTest.Rules;

namespace NetArchTest.Assemblies.PublicUse
{
    [DebuggerDisplay("{FullName}")]
    internal sealed class AssemblyContainer(AssemblyDefinition assemblyDefinition) : IAssembly
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly AssemblyDefinition _monoAssemblyDefinition = assemblyDefinition;

        public string FullName => _monoAssemblyDefinition.FullName;
    }
}
