using System.Collections.Generic;

namespace NetArchTest.Rules.Slices.Model
{
    internal interface IFilter
    {
        IEnumerable<TypeTestResult> Execute(SlicedTypes slicedTypes);
    }
}