using NetArchTest.Assemblies;
using NetArchTest.Slices.Model;

namespace NetArchTest.Slices
{
    /// <summary>
    /// A set of conditions that can be applied to slices of types.
    /// </summary>
    public sealed class SliceCondition
    {
        private readonly SliceContext sliceContext;       
        private readonly bool should;


        internal SliceCondition(SliceContext sliceContext, bool should)
        {
            this.sliceContext = sliceContext;            
            this.should = should;
        }

        /// <summary>
        /// Selects types that have some dependencies on types from other slices.
        /// </summary>  
        public SliceConditionList HaveDependenciesBetweenSlices()
        {
            return new SliceConditionList(sliceContext, new HaveDependenciesBetweenSlices(), should);
        }

        /// <summary>
        /// Selects types that do not have dependencies on types from other slices.
        /// </summary>       
        public SliceConditionList NotHaveDependenciesBetweenSlices()
        {
            return new SliceConditionList(sliceContext, new HaveDependenciesBetweenSlices(), !should);
        }
    }
}