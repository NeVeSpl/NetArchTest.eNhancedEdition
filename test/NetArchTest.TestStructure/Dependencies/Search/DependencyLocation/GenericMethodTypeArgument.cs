namespace NetArchTest.TestStructure.Dependencies.Search.DependencyLocation
{
    using NetArchTest.TestStructure.Dependencies.Examples;

    /// <summary>
    /// Example class that has dependency as second type argument on the generic method invocation type argument list   
    /// </summary>
    public class GenericMethodTypeArgument
    {
        public void ExampleMethod()
        {
            GenericMethod<int, ExampleDependency>();
        }

        private T2 GenericMethod<T1, T2>() where T2 : new()
        {
            return new T2();
        }
    }
}