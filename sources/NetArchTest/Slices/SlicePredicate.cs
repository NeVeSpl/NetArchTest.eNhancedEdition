﻿using NetArchTest.RuleEngine;
using NetArchTest.Slices.Model;

namespace NetArchTest.Slices
{
    /// <summary>
    /// Allows dividing types into groups, also called slices.
    /// </summary>
    /// <returns></returns>
    public sealed class SlicePredicate
    {
        private readonly RuleContext rule;


        internal SlicePredicate(RuleContext rule)
        {
            this.rule = rule;
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
            var slicedTypes = slicer.SliceByNamespacePrefix(rule.Execute(null), prefix);
            return new SlicePredicateList(new SliceContext(rule.loadedData, slicedTypes));
        }
    }
}