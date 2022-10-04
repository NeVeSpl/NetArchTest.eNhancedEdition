using System;
using System.Collections.Generic;
using System.Text;
using NetArchTest.Rules.Slices.Model;

namespace NetArchTest.Rules.Slices
{
    /// <summary>
    /// Link between predicate and condition.
    /// </summary>
    public sealed class SlicePredicateList
    {
        private readonly SlicedTypes slicedTypes;


        internal SlicePredicateList(SlicedTypes slicedTypes)
        {
            this.slicedTypes = slicedTypes;
        }


        /// <summary>
        /// Links a predicate defining a set of classes to a condition that tests them.
        /// </summary>
        public SliceCondition Should()
        {
            return new SliceCondition(slicedTypes, true);
        }

        /// <summary>
        /// Links a predicate defining a set of classes to a condition that tests them.
        /// </summary>
        public SliceCondition ShouldNot()
        {
            return new SliceCondition(slicedTypes, false);
        }


        internal SlicedTypes GetSlicedTypes()
        {
            return slicedTypes;
        }
    }
}