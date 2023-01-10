using System.Collections.Generic;
using System.Linq;
using NetArchTest.Assemblies;
using NetArchTest.Dependencies;

namespace NetArchTest.Slices.Model
{
    internal sealed class HaveDependenciesBetweenSlices : IFilter
    {
        public IEnumerable<TypeTestResult> Execute(SlicedTypes slicedTypes)
        {
            var dependencySearch = new DependencySearch();
            var result = new List<TypeTestResult>(slicedTypes.TypeCount);

            for (int i = 0; i < slicedTypes.Slices.Count; i++)
            {
                var slice = slicedTypes.Slices[i];
                var dependencies = slicedTypes.Slices.Where((_, index) => index != i).Select(x => x.Name).ToList();

                var foundTypes = dependencySearch.FindTypesThatHaveDependencyOnAny(slice.Types, dependencies);
                var lookup = new HashSet<TypeSpec>(foundTypes);

                foreach (var type in slice.Types)
                {
                    bool isPassing = lookup.Contains(type);
                    var typeResult = new TypeTestResult(type, isPassing);                    
                    result.Add(typeResult);
                }
            }

            return result;
        }
    }
}