using System.Collections.Generic;
using NetArchTest.Rules.Assemblies;
using NetArchTest.Rules.Slices.Model;

namespace NetArchTest.Rules.Slices
{
    /// <summary>
    /// Allows dividing types into groups, also called slices.
    /// </summary>
    /// <returns></returns>
    public sealed class SlicePredicate
    {
        private readonly IEnumerable<TypeSpec> types;


        internal SlicePredicate(IEnumerable<TypeSpec> types)
        {
            this.types = types;
        }


        /// <summary>
        /// Divides types into groups/slices according to the prefix pattern.
        /// It only selects types which namespaces start with a given prefix, rest of the types are ignored.
        /// Groups are defined by the first part of the namespace that comes next after prefix:
        /// namespacePrefix.(groupName).restOfNamespace
        /// </summary>      
        public SlicePredicateList ByNamespacePrefix(string prefix)
        {
            var slicer = new Slicer();
            var slicedTypes = slicer.SliceByNamespacePrefix(types, prefix);
            return new SlicePredicateList(slicedTypes);
        }
    }
}