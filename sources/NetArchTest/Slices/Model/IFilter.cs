using System.Collections.Generic;

namespace NetArchTest.Slices.Model
{
    internal interface IFilter
    {
        IEnumerable<TypeTestResult> Execute(SlicedTypes slicedTypes);
    }
}