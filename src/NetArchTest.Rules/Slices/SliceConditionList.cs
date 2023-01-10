using System;
using System.Linq;
using NetArchTest.Rules;
using NetArchTest.Slices.Model;

namespace NetArchTest.Slices
{
    /// <summary>
    /// Executor of condition.
    /// </summary>
    public sealed class SliceConditionList
    {
        private readonly IFilter filter;
        private readonly SlicedTypes slicedTypes;
        private readonly bool should;


        internal SliceConditionList(IFilter filter, SlicedTypes slicedTypes, bool should)
        {
            this.filter = filter;
            this.slicedTypes = slicedTypes;
            this.should = should;
        }


        /// <summary>
        /// Returns an indication of whether all the selected types satisfy the conditions.
        /// </summary>
        /// <returns>An indication of whether the conditions are true, along with a list of types failing the check if they are not.</returns>

        public TestResult GetResult()
        {
            var filteredTypes = filter.Execute(slicedTypes);

            if (filteredTypes.Count() != slicedTypes.TypeCount)
            {
                throw new Exception("Filter returned wrong number of results!");
            }

            bool successIsWhen = should;
            bool isSuccessful = filteredTypes.All(x => x.IsPassing == successIsWhen);

            if (isSuccessful)
            {
                return TestResult.Success();
            }
            else
            {
                var failingTypes = filteredTypes.Where(x => x.IsPassing == !successIsWhen);
                return TestResult.Failure(failingTypes.Select(x => x.TypeSpec));
            }
        }
    }
}