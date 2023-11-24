using System;
using System.Diagnostics;
using Mono.Cecil;
using NetArchTest.Rules;

namespace NetArchTest.Assemblies
{
    [DebuggerDisplay("{FullName}")]
    internal sealed class TypeContainer : IType
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly TypeDefinition _monoTypeDefinition;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly Lazy<Type> _reflactionType;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly Lazy<string> _sourceFilePath;


        internal TypeContainer(TypeDefinition monoTypeDefinition, string explanation)
        {
            _monoTypeDefinition = monoTypeDefinition;
            _reflactionType = new Lazy<Type>(() =>
            {                
                try
                {
                    return _monoTypeDefinition.ToType();
                }
                catch 
                { 
                }
                return null;
            });
            _sourceFilePath = new Lazy<string>(() => _monoTypeDefinition.GetFilePath());
            Explanation = explanation;
        }


        public Type ReflectionType => _reflactionType.Value;  
        public string FullName => _monoTypeDefinition.FullName;     
        public string Name => _monoTypeDefinition.Name;
        public string Explanation { get; }
        public string SourceFilePath => _sourceFilePath.Value;


        public static implicit operator System.Type(TypeContainer type)
        {
            return type.ReflectionType;
        }
    }
}