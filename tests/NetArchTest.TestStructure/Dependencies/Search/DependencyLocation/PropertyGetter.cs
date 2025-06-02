namespace NetArchTest.TestStructure.Dependencies.Search.DependencyLocation
{
    using Examples;

    /// <summary>
    /// Example class that includes a dependency in a public property definition.    
    /// </summary>
    public class PropertyGetter
    {
        public object ExampleProperty
        {
            get { return new ExampleDependency(); }
        }
    }
}
