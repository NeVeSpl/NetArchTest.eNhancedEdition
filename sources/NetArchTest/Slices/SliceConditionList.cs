using System;
using System.Linq;
using NetArchTest.Assemblies;
using NetArchTest.Rules;
using NetArchTest.Slices.Model;

namespace NetArchTest.Slices
{
    /// <summary>
    /// Executor of condition.
    /// </summary>
    public sealed class SliceConditionList
    {
        private readonly SliceContext sliceContext;
        private readonly IFilter filter;        
        private readonly bool should;


        internal SliceConditionList(SliceContext sliceContext, IFilter filter, bool should)
        {
            this.sliceContext = sliceContext;
            this.filter = filter;            
            this.should = should;
        }


        /// <summary>
        /// Returns an indication of whether all the selected types satisfy the conditions.
        /// </summary>
        /// <returns>An indication of whether the conditions are true, along with a list of types failing the check if they are not.</returns>

        public TestResult GetResult()
        {
            var slicedTypes = sliceContext.GetTypes();

            var filteredTypes = filter.Execute(slicedTypes);

            if (filteredTypes.Count() != slicedTypes.TypeCount)
            {
                throw new Exception("Filter returned wrong number of results!");
            }

            bool successIsWhen = should;
            bool isSuccessful = filteredTypes.All(x => x.IsPassing == successIsWhen);

            if (isSuccessful)
            {
                // todo replace Array.Empty<TypeSpec>() with real data
                return new TestResult(sliceContext.GetAssemblies(), Array.Empty<TypeSpec>(), Array.Empty<TypeSpec>(), Array.Empty<TypeSpec>(), true);
            }
            else
            {
                var failingTypes = filteredTypes.Where(x => x.IsPassing == !successIsWhen);
                return new TestResult(sliceContext.GetAssemblies(), Array.Empty<TypeSpec>(), Array.Empty<TypeSpec>(), failingTypes.Select(x => x.TypeSpec), false);
            }
        }
    }
}