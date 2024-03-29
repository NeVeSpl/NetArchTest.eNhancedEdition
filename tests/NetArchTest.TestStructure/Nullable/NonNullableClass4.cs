namespace NetArchTest.TestStructure.Nullable {
    
    /// <summary>
    /// An example class that has has non-nullable (i.e.null simple value typed) members.
    /// </summary>
    public class NonNullableClass4 {
        public TestStruct StructProperty {get; set;}

        public struct TestStruct {
#pragma warning disable 169
            public object nullableObject;
            public int nonNullable;
#pragma warning restore 169
        }
    }
}