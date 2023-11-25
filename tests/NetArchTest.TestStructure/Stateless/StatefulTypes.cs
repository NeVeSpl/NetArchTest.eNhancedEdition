namespace NetArchTest.TestStructure.Stateless
{
    internal class StatefulClass_Field
    {
        public int field;
    }
    internal record class StatefulRecordClass(int Prop);

    internal record struct StatefulRecordStruct(int Prop);

    internal class StatefulClass_Prop
    {
        public int Prop { get; set; }
    }

    internal class StatefulClass_ReadonlyField
    {
        public readonly int field = 7;
    }
}
