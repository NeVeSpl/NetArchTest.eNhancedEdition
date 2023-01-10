using System.Collections.Generic;
using System.Linq;
using NetArchTest.Assemblies;
using NetArchTest.Rules.Extensions;

namespace NetArchTest.Slices.Model
{
    internal sealed class Slicer
    {
        public SlicedTypes SliceByNamespacePrefix(IEnumerable<TypeSpec> types, string prefix)
        {
            string prefixWithDot = "";
            if (!string.IsNullOrEmpty(prefix))
            {
                prefixWithDot = prefix;
                if (prefixWithDot.Last() != '.')
                {
                    prefixWithDot = prefixWithDot + ".";
                }
            }

            var groupedTypes = new Dictionary<string, List<TypeSpec>>();
            int typeCount = 0;

            foreach (var type in types)
            {
                var typeNamespace = type.Definition.GetNamespace();
                if (typeNamespace.StartsWith(prefixWithDot))
                {
                    ++typeCount;
                    int nextDotIndex = typeNamespace.IndexOf('.', prefixWithDot.Length);
                    int startIndex = prefixWithDot.Length;
                    int endIndex = nextDotIndex > -1 ? nextDotIndex : typeNamespace.Length;
                    string sliceName = typeNamespace.Substring(0, endIndex);                                     

                    if (groupedTypes.TryGetValue(sliceName, out var list))
                    {
                        list.Add(type);
                    }
                    else
                    {
                        groupedTypes[sliceName] = new List<TypeSpec>() { type };
                    }
                }
            }

            var slices = groupedTypes.Select((x) => new Slice(x.Key, x.Value)).ToList();

            return new SlicedTypes(typeCount, slices);
        }
    }
}