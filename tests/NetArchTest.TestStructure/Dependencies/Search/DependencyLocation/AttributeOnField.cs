namespace NetArchTest.TestStructure.Dependencies.Search.DependencyLocation
{
    using System.Threading.Tasks;
    using Examples;

    /// <summary>
    /// Example class that includes a dependency as an attribute.    
    /// </summary>   
    public class AttributeOnField
    {
        [AttributeDependency()]
#pragma warning disable 169
        private int field;
#pragma warning restore 169
    }
}
