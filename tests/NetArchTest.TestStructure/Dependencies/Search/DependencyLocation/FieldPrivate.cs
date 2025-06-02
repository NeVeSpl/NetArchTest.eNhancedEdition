namespace NetArchTest.TestStructure.Dependencies.Search.DependencyLocation
{
    using Examples;

    /// <summary>
    /// Example class that includes a dependency in a private field definition.    
    /// </summary>
    public class FieldPrivate
    {
#pragma warning disable 169
        private ExampleDependency Example;
#pragma warning restore 169
        public FieldPrivate()
        {
        }
    }
}
