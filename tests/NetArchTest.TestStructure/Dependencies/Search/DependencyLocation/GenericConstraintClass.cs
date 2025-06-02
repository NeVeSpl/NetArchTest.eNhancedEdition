namespace NetArchTest.TestStructure.Dependencies.Search.DependencyLocation
{
    using Examples;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Example class that includes a dependency as a generic class constraint.    
    /// </summary>
    public class GenericConstraintClass<T>  where T : ExampleDependency, new() 
    {
#pragma warning disable 169
        private List<Task<T>> foo;
#pragma warning restore 169
    }
}
