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

        internal TypeWrapper(TypeDefinition monoTypeDefinition)
        {
            _monoTypeDefinition = monoTypeDefinition;
            _type = new Lazy<Type>(() =>
            {
                Type type = null;
                try
                {
                    type = _monoTypeDefinition.ToType();
                }
                catch { }
                return type;
            });
        }


        public Type ReflectionType => _type.Value;  
        public string FullName => _monoTypeDefinition.FullName;     
        public string Name => _monoTypeDefinition.Name;


        public static implicit operator System.Type(TypeWrapper type)
        {
            return type.ReflectionType;
        }
    }
}