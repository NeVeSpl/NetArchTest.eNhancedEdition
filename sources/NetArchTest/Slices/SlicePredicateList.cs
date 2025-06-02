using NetArchTest.Slices.Model;

namespace NetArchTest.Slices
{
    /// <summary>
    /// Link between predicate and condition.
    /// </summary>
    public sealed class SlicePredicateList
    {
        private readonly SliceContext _sliceContext;

        internal SlicePredicateList(SliceContext sliceContext)
        {
            _sliceContext = sliceContext;
        }
        
        /// <summary>
        /// Links a predicate defining a set of classes to a condition that tests them.
        /// </summary>
        public SliceCondition Should()
        {
            return new SliceCondition(_sliceContext, true);
        }

        /// <summary>
        /// Links a predicate defining a set of classes to a condition that tests them.
        /// </summary>
        public SliceCondition ShouldNot()
        {
            return new SliceCondition(_sliceContext, false);
        }

        internal SlicedTypes GetSlicedTypes()
        {
            return _sliceContext.GetTypes();
        }
    }
}