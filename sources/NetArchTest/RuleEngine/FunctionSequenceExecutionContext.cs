using System.Collections.Generic;
using NetArchTest.Assemblies;
using NetArchTest.Rules;

namespace NetArchTest.RuleEngine
{
    internal class FunctionSequenceExecutionContext
    {
        public IEnumerable<TypeSpec> AllTypes { get; }
        public bool IsFailPathRun { get; }
        public IDependencyFilter DependencyFilter { get; }
        public Options UserOptions { get; }

        public FunctionSequenceExecutionContext(IEnumerable<TypeSpec> allTypes, bool isFailPathRun, Options options = null)
        {
            AllTypes = allTypes;
            UserOptions = options ?? Options.Default;
            IsFailPathRun = isFailPathRun;
        }
    }
}