namespace NetArchTest.RuleEngine
{
    internal class ConditionContext
    {
        public FunctionSequence Sequence { get; } = new FunctionSequence();
        public bool Should { get; set; }

        public ConditionContext()
        {
        }
    }
}