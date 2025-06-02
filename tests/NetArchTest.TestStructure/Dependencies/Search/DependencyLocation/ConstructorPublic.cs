namespace NetArchTest.TestStructure.Dependencies.Search.DependencyLocation
{
    using Examples;

    /// <summary>
    /// Example class that includes a dependency in a public constructor definition.    
    /// </summary>
    public class ConstructorPublic
    {
        public ConstructorPublic()
        {
            var test = new ExampleDependency();
        }
    }
}
