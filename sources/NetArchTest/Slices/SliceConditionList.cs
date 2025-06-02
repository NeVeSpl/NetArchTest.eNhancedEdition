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
        private readonly SliceContext _sliceContext;
        private readonly IFilter _filter;
        private readonly bool _should;

        internal SliceConditionList(SliceContext sliceContext, IFilter filter, bool should)
        {
            _sliceContext = sliceContext;
            _filter = filter;
            _should = should;
        }

        /// <summary>
        /// Returns an indication of whether all the selected types satisfy the conditions.
        /// </summary>
        /// <returns>An indication of whether the conditions are true, along with a list of types failing the check if they are not.</returns>
        public TestResult GetResult()
        {
            var slicedTypes = _sliceContext.GetTypes();

            var filteredTypes = _filter.Execute(slicedTypes);

            if (filteredTypes.Count() != slicedTypes.TypeCount)
            {
                throw new Exception("Filter returned wrong number of results!");
            }

            bool successIsWhen = _should;
            bool isSuccessful = filteredTypes.All(x => x.IsPassing == successIsWhen);

            if (isSuccessful)
            {
                // todo replace Array.Empty<TypeSpec>() with real data
                return new TestResult(_sliceContext.GetAssemblies(), [], [], [], true);
            }
            else
            {
                var failingTypes = filteredTypes.Where(x => x.IsPassing == !successIsWhen);
                return new TestResult(_sliceContext.GetAssemblies(), [], [], failingTypes.Select(x => x.TypeSpec), false);
            }
        }
    }
}