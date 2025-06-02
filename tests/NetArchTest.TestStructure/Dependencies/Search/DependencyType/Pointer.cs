namespace NetArchTest.TestStructure.Dependencies.Search.DependencyType
{
    using System.Threading.Tasks;
    using Examples;

    /// <summary>
    /// Example class that includes a dependency in pointer declaration.    
    /// </summary>
    public class Pointer
    {
        public Pointer()
        {
            unsafe
            {
                StructDependency* test = null;
            }                      
        }
    }
}
