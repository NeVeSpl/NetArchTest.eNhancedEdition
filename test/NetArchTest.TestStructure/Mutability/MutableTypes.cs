using System;

namespace NetArchTest.TestStructure.Mutability
{
    public class MutableClass_PublicProperty
    {
        public object Property { get; set; }
    }

    public class MutableClass_PublicPropertyPrivateSet
    {
        public object Property { get; private set; }
    }

    public class MutableClass_PublicField
    {
        public object field;
    }

    public class MutableClass_PrivateField
    {
        private object field;
    }

    public class MutableClass_PublicEvent
    {
        public event Action Event;
    }

    public record struct MutableRecord(int Property)
    {
    }
}