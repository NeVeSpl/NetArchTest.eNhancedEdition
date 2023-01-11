namespace Mono.Cecil
{
    static internal class FieldDefinitionExtensions
    {
        /// <summary>
        /// Tests whether a field is readonly
        /// </summary>
        /// <param name="fieldDefinition">The field to test.</param>
        /// <returns>An indication of whether the field is readonly.</returns>
        public static bool IsReadonly(this FieldDefinition fieldDefinition)
        {           
            return fieldDefinition.IsInitOnly || fieldDefinition.HasConstant || fieldDefinition.IsCompilerControlled;
        }
        
        /// <summary>
        /// Tests whether a field is nullable
        /// </summary>
        /// <param name="fieldDefinition">The field to test.</param>
        /// <returns>An indication of whether the field is nullable.</returns>
        public static bool IsNullable(this FieldDefinition fieldDefinition)
        {
            return fieldDefinition.FieldType.IsNullable();
        }
    }
}