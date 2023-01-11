namespace NetArchTest.TestStructure.Mutability
{
    /// <summary>
    /// An example class that has has no mutable members.
    /// </summary>
    public class ImmutableClass3
    {
        protected object Property {get;}

#pragma warning disable 169
        private readonly object privateField;
#pragma warning restore 169
    }
}