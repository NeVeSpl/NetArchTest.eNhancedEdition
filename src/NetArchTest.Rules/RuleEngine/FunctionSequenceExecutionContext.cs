using NetArchTest.Rules;

namespace NetArchTest.RuleEngine
{   
    internal class FunctionSequenceExecutionContext
    {
        public bool IsFailPathRun { get; }
        public IDependencyFilter DependencyFilter { get; }
        public Options UserOptions { get; }


        public FunctionSequenceExecutionContext(bool isFailPathRun, Options options = null)
        {
            UserOptions = options ?? Options.Default; 
            IsFailPathRun = isFailPathRun;            
        }
    }
}