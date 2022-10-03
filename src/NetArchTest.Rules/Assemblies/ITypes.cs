using System;
using System.Collections.Generic;
using System.Text;

namespace NetArchTest.Rules.Assemblies
{
    internal interface ITypes
    {
        IEnumerable<TypeSpec> Failing { get; }
        IEnumerable<TypeSpec> Passing { get; }
    }


    internal sealed class TypesImpl : ITypes
    {
        public IEnumerable<TypeSpec> Failing { get; }
        public IEnumerable<TypeSpec> Passing { get; }



    }
}
