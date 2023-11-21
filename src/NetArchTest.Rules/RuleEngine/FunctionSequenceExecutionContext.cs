using NetArchTest.Rules;

namespace NetArchTest.RuleEngine
{   
    internal class FunctionSequenceExecutionContext
    {
        public static readonly FunctionSequenceExecutionContext Default = new FunctionSequenceExecutionContext(false);

        public bool IsFailPathRun { get; }
        public IDependencyFilter DependencyFilter { get; }


        public FunctionSequenceExecutionContext(bool isFailPathRun, IDependencyFilter dependencyFilter = null)
        {
            IsFailPathRun = isFailPathRun;
            DependencyFilter = dependencyFilter;
        }
    }
}