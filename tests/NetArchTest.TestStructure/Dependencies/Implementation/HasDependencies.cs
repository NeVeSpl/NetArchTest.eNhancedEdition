namespace NetArchTest.TestStructure.Dependencies.Implementation
{
    using Examples;

    public class HasDependencies
    {
        public ExampleDependency dependency { get; set; }
        public AnotherExampleDependency anotherDependency { get; set; }
    }
}
