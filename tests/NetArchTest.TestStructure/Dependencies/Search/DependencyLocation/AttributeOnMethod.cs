namespace NetArchTest.TestStructure.Dependencies.Search.DependencyLocation
{
    using System.Threading.Tasks;
    using Examples;

    /// <summary>
    /// Example class that includes a dependency as an attribute.    
    /// </summary>   
    public class AttributeOnMethod
    {
        [AttributeDependency()]
        private void method()
        {

        }
    }
}
