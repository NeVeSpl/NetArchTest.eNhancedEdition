using System;
using System.Diagnostics;
using Mono.Cecil;

namespace NetArchTest.Assemblies
{
    [DebuggerDisplay("TypeSpec: {FullName}")]
    internal sealed class TypeSpec
    {
        private readonly Lazy<string> _filePath;

        public TypeDefinition Definition { get; }
        public string FullName => Definition.FullName;
        // Only for use by FunctionSequence
        internal bool IsSelectedInMarkPhase { get; set;  }
        // Can be use by any function
        internal bool IsPassing { get; set; }
        public string Explanation { get; set; }
        public string FilePath => _filePath.Value;


        public TypeSpec(TypeDefinition definition)
        {
            Definition = definition;
            _filePath = new Lazy<string>(() => Definition.GetFilePath());
        }



        public TypeContainer CreateWrapper()
        {
            return new TypeContainer(Definition, Explanation);
        }
    }
}