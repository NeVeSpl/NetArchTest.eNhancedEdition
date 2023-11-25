namespace NetArchTest.TestStructure.Mutability
{     
    public class ImmutableClass_PropertyOnlyGet
    {
        public object GetOnlyProperty { get; }
    }
    public class ImmutableClass_PropertyInit
    {
        public object GetOnlyProperty { get; init; }
    }

    public class ImmutableClass_FieldConst
    {        
        public const object constField = null;
    }
    public class ImmutableClass_FieldReadonly
    {
        public readonly object readonlyField;
    }

    public class ImmutableClass_FieldReadonlyPrivate
    {        
#pragma warning disable 169
        private readonly object privateField;
#pragma warning restore 169
    }

    public record class ImmutableRecord(int Property)
    {
    }
}