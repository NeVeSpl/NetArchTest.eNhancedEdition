using System.Collections.Generic;
using NetArchTest.Assemblies;

namespace NetArchTest.Slices.Model
{
    internal sealed class Slice
    {
        public string Name { get;  }
        public IEnumerable<TypeSpec> Types { get;  }


        public Slice(string sliceName, List<TypeSpec> types)
        {
            Name = sliceName;
            Types = types;
        }
    }
}