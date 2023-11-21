﻿using System.Diagnostics;
using Mono.Cecil;

namespace NetArchTest.Assemblies
{
    [DebuggerDisplay("TypeSpec: {FullName}")]
    internal sealed class TypeSpec
    {
        public TypeDefinition Definition { get; }
        public string FullName => Definition.FullName;
        // Only for use by FunctionSequence
        internal bool IsSelectedInMarkPhase { get; set;  }
        // Can be use by any function
        internal bool IsPassing { get; set; }
        public string Explanation { get; set; }


        public TypeSpec(TypeDefinition definition)
        {
            Definition = definition;
        }



        public TypeWrapper CreateWrapper()
        {
            return new TypeWrapper(Definition, Explanation);
        }
    }
}