namespace NetArchTest.TestStructure.Dependencies.Search.DependencyType
{
    using Examples;

    /// <summary>
    /// Example class that includes a dependency in an instruction invocation.
    /// </summary>
    public class VariableGeneric
    {
        public VariableGeneric()
        {
#pragma warning disable 219
            ExampleDependency<int> dependecy = null;
#pragma warning restore 219
        }
    }
}
