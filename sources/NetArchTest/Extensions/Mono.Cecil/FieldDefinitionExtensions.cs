namespace Mono.Cecil
{
    internal static class FieldDefinitionExtensions
    {
        public static bool IsReadonly(this FieldDefinition fieldDefinition)
        {
            return fieldDefinition.IsInitOnly || fieldDefinition.HasConstant || fieldDefinition.IsCompilerControlled;
        }
        public static bool IsReadonlyExternally(this FieldDefinition fieldDefinition)
        {
            if (!fieldDefinition.IsPublic)
            {
                return true;
            }
            return fieldDefinition.IsReadonly();
        }

        public static bool IsNullable(this FieldDefinition fieldDefinition)
        {
            return fieldDefinition.FieldType.IsNullable();
        }
    }
}