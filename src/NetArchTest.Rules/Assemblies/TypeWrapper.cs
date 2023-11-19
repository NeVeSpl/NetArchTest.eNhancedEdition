using System;
using System.Diagnostics;
using Mono.Cecil;
using NetArchTest.Rules;

namespace NetArchTest.Assemblies
{
    [DebuggerDisplay("{FullName}")]
    internal sealed class TypeWrapper : IType
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly TypeDefinition _monoTypeDefinition;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly Lazy<Type> _type;

        internal TypeWrapper(TypeDefinition monoTypeDefinition, string explanation)
        {
            _monoTypeDefinition = monoTypeDefinition;
            _type = new Lazy<Type>(() =>
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
            Explanation = explanation;
        }


        public Type ReflectionType => _type.Value;  
        public string FullName => _monoTypeDefinition.FullName;     
        public string Name => _monoTypeDefinition.Name;
        public string Explanation { get; }


        public static implicit operator System.Type(TypeWrapper type)
        {
            return type.ReflectionType;
        }
    }
}