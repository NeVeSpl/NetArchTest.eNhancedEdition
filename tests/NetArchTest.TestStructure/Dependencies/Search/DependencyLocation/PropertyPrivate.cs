namespace NetArchTest.TestStructure.Dependencies.Search.DependencyLocation
{
    using Examples;

    /// <summary>
    /// Example class that includes a dependency in a private property definition.    
    /// </summary>
    public class PropertyPrivate
    {
        private ExampleDependency ExampleProperty
        {
            get { return null; }
        }
    }
}
