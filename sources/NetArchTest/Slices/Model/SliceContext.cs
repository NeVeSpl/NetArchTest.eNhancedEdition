using System.Collections.Generic;
using NetArchTest.Assemblies;

namespace NetArchTest.Slices.Model
{
    internal class SliceContext
    {
        private readonly LoadedData _loadedData;
        private readonly SlicedTypes _slicedTypes;

        public SliceContext(LoadedData loadedData, SlicedTypes slicedTypes)
        {
            _loadedData = loadedData;
            _slicedTypes = slicedTypes;
        }

        public IReadOnlyList<AssemblySpec> GetAssemblies()
        {
            return _loadedData.Assemblies;
        }

        public SlicedTypes GetTypes()
        {
            return _slicedTypes;
        }
    }
}
