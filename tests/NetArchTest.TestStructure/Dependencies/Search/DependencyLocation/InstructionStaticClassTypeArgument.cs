namespace NetArchTest.TestStructure.Dependencies.Search.DependencyLocation
{
    using Examples;

    /// <summary>
    /// Example class that includes a dependency in an instruction invocation.
    /// </summary>
    public class InstructionStaticClassTypeArgument
    {
        public InstructionStaticClassTypeArgument()
        {
            ExampleStaticGenericClass<ExampleDependency>.Foo();
        }
    }
}
