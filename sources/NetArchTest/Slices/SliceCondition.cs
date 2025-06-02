using NetArchTest.Slices.Model;

namespace NetArchTest.Slices
{
    /// <summary>
    /// A set of conditions that can be applied to slices of types.
    /// </summary>
    public sealed class SliceCondition
    {
        private readonly SliceContext _sliceContext;
        private readonly bool _should;

        internal SliceCondition(SliceContext sliceContext, bool should)
        {
            _sliceContext = sliceContext;
            _should = should;
        }

        /// <summary>
        /// Selects types that have some dependencies on types from other slices.
        /// </summary>
        public SliceConditionList HaveDependenciesBetweenSlices()
        {
            return new SliceConditionList(_sliceContext, new HaveDependenciesBetweenSlices(), _should);
        }

        /// <summary>
        /// Selects types that do not have dependencies on types from other slices.
        /// </summary>
        public SliceConditionList NotHaveDependenciesBetweenSlices()
        {
            return new SliceConditionList(_sliceContext, new HaveDependenciesBetweenSlices(), !_should);
        }
    }
}