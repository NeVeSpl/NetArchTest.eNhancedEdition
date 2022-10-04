using System;
using System.Diagnostics;
using Mono.Cecil;
using NetArchTest.Rules.Extensions;

namespace NetArchTest.Rules.Assemblies
{
    /// <summary>
    /// Type wrapper.
    /// </summary>
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

        /// <summary>
        /// System.Type
        /// </summary>
        /// <remarks>
        /// This property may be null if the test project does not have a direct dependency on the type.
        /// </remarks>
        public Type Type { get => _type.Value; }

        /// <summary>
        /// FullName of the type
        /// </summary>       
        public string FullName { get => _monoTypeDefinition.FullName; }

        /// <summary>
        /// Name of the type
        /// </summary>       
        public string Name { get => _monoTypeDefinition.Name; }


        public static implicit operator System.Type(TypeWrapper type)
        {
            return type.Type;
        }
    }
}