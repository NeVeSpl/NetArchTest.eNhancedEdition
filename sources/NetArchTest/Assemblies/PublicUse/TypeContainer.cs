using System;
using System.Diagnostics;
using Mono.Cecil;
using NetArchTest.Rules;

namespace NetArchTest.Assemblies.PublicUse
{
    [DebuggerDisplay("{FullName}")]
    internal sealed class TypeContainer : IType
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly TypeDefinition _monoTypeDefinition;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly Lazy<Type> _reflectionType;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly Lazy<string> _sourceFilePath;

        public Type ReflectionType => _reflectionType.Value;
        public string FullName => _monoTypeDefinition.FullName;
        public string Name => _monoTypeDefinition.Name;
        public string Explanation { get; }
        public string SourceFilePath => _sourceFilePath.Value;

        internal TypeContainer(TypeDefinition monoTypeDefinition, string explanation)
        {
            _monoTypeDefinition = monoTypeDefinition;
            _reflectionType = new Lazy<Type>(() =>
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
            _sourceFilePath = new Lazy<string>(_monoTypeDefinition.GetFilePath);
            Explanation = explanation;
        }

        public static implicit operator Type(TypeContainer type)
        {
            return type.ReflectionType;
        }
    }
}