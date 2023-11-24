using System;
using System.Diagnostics;
using Mono.Cecil;

namespace NetArchTest.Assemblies
{
    [DebuggerDisplay("TypeSpec: {FullName}")]
    internal sealed class TypeSpec
    {
        private readonly Lazy<string> _sourceFilePath;

        public TypeDefinition Definition { get; }
        public string FullName => Definition.FullName;
        // Only for use by FunctionSequence
        internal bool IsSelectedInMarkPhase { get; set;  }
        // Can be use by any function
        internal bool IsPassing { get; set; }
        public string Explanation { get; set; }
        public string SourceFilePath => _sourceFilePath.Value;


        public TypeSpec(TypeDefinition definition)
        {
            Definition = definition;
            _sourceFilePath = new Lazy<string>(() => Definition.GetFilePath());
        }



        public TypeContainer CreateWrapper()
        {
            return new TypeContainer(Definition, Explanation);
        }
    }
}