namespace Mono.Cecil
{
    internal static class EventDefinitionExtensions
    {
        public static bool IsReadonly(this EventDefinition propertyDefinition)
        {
            if (propertyDefinition.AddMethod == null)
            {
                return true;
            }

            return false;
        }
        public static bool IsReadonlyExternally(this EventDefinition propertyDefinition)
        {
            if (propertyDefinition.AddMethod?.IsPublic == false)
            {
                return true;
            }
            return propertyDefinition.IsReadonly();
        }
    }
}
