using System.Collections.Generic;
using NetArchTest.Assemblies;

namespace NetArchTest.Slices.Model
{
    internal class SliceContext
    {
        private readonly LoadedData loadedData;
        private readonly SlicedTypes slicedTypes;

        public SliceContext(LoadedData loadedData, SlicedTypes slicedTypes)
        {
            this.loadedData = loadedData;
            this.slicedTypes = slicedTypes;
        }



        public IReadOnlyList<AssemblySpec> GetAssemblies()
        {
            return loadedData.Assemblies;
        }

        public SlicedTypes GetTypes()
        {
            return slicedTypes;
        }
    }
}
