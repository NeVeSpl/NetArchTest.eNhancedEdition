using System.Collections.Generic;

namespace NetArchTest.Rules.Slices.Model
{
    internal sealed class SlicedTypes
    {
        public int TypeCount { get; }       
        public IReadOnlyList<Slice> Slices { get; }


        public SlicedTypes(int typeCount, List<Slice> slices)
        {
            TypeCount = typeCount;
            Slices = slices;
        }
    }
}