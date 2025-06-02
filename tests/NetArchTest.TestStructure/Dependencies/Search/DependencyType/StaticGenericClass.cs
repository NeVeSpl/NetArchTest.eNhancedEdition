namespace NetArchTest.TestStructure.Dependencies.Search.DependencyType
{
    using Examples;

    /// <summary>
    /// Example class that includes a dependency in an instruction invocation.
    /// </summary>
    public class StaticGenericClass
    {
        public StaticGenericClass()
        {
            StaticGenericDependency<int>.Foo();
        }
    }
}
