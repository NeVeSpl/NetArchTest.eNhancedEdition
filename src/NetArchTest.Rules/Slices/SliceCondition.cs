using NetArchTest.Rules.Slices.Model;

namespace NetArchTest.Rules.Slices
{
    /// <summary>
    /// A set of conditions that can be applied to slices of types.
    /// </summary>
    public sealed class SliceCondition
    {
        private readonly SlicedTypes slicedTypes;
        private readonly bool should;


        internal SliceCondition(SlicedTypes slices, bool should)
        {
            this.slicedTypes = slices;
            this.should = should;
        }

        /// <summary>
        /// Selects types that have some dependencies on types from other slices.
        /// </summary>  
        public SliceConditionList HaveDependenciesBetweenSlices()
        {
            return new SliceConditionList(new HaveDependenciesBetweenSlices(), slicedTypes, should);
        }

        /// <summary>
        /// Selects types that do not have dependencies on types from other slices.
        /// </summary>       
        public SliceConditionList NotHaveDependenciesBetweenSlices()
        {
            return new SliceConditionList(new HaveDependenciesBetweenSlices(), slicedTypes, !should);
        }
    }
}