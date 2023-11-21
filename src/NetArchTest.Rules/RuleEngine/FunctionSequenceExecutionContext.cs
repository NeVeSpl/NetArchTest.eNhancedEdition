using NetArchTest.Rules;

namespace NetArchTest.RuleEngine
{   
    internal class FunctionSequenceExecutionContext
    {
        public static readonly FunctionSequenceExecutionContext Default = new FunctionSequenceExecutionContext(false);

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