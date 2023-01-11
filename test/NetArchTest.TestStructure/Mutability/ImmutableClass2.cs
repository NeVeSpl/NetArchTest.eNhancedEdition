namespace NetArchTest.TestStructure.Mutability
{
    /// <summary>
    /// An example class that has has no mutable members.
    /// </summary>
    public class ImmutableClass2
    {
        public object PrivateSetProperty {get; }

        public const object constField = null;
    }
}