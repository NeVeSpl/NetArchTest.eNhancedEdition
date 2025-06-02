namespace NetArchTest.TestStructure.Dependencies.Search.DependencyLocation
{
    using Examples;

    /// <summary>
    /// Example class that includes a dependency in an instruction invocation.
    /// </summary>
    public class InstructionThrow
    {
        public void ExampleMethod()
        {
            throw new ExceptionDependency();
        }
    }
}
