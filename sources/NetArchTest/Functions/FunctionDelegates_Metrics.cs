using System.Collections.Generic;
using System.Linq;
using NetArchTest.Assemblies;
using NetArchTest.Extensions.Mono.Cecil;
using NetArchTest.RuleEngine;

namespace NetArchTest.Functions
{
    internal static partial class FunctionDelegates
    {
        internal static IEnumerable<TypeSpec> HaveNumberOfLinesOfCodeFewerThan(FunctionSequenceExecutionContext context, IEnumerable<TypeSpec> input, int number, bool condition)
        {
            if (condition)
            {
                return input.Where(c => c.Definition.GetNumberOfLogicalLinesOfCode() < number);
            }
            else
            {
                return input.Where(c => !(c.Definition.GetNumberOfLogicalLinesOfCode() < number));
            }
        }
    }
}