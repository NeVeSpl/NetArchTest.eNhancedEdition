namespace Mono.Cecil
{
    internal static class PropertyDefinitionExtensions
    {
        public static bool IsReadonly(this PropertyDefinition propertyDefinition)
        {
            if (propertyDefinition.SetMethod == null)
            {
                return true;
            }
            else
            {
                if (propertyDefinition.IsInitOnly())
                {
                    return true;
                }
            }

            return false;
        }
        public static bool IsReadonlyExternally(this PropertyDefinition propertyDefinition)
        {
            if (propertyDefinition.SetMethod?.IsPublic == false)
            {
                return true;
            }
            return propertyDefinition.IsReadonly();
        }

        public static bool IsInitOnly(this PropertyDefinition propertyDefinition)
        {
            return propertyDefinition.SetMethod?.ReturnType.FullName == "System.Void modreq(System.Runtime.CompilerServices.IsExternalInit)";
        }

        public static bool IsNullable(this PropertyDefinition propertyDefinition)
        {
            return propertyDefinition.PropertyType.IsNullable();
        }
    }
}