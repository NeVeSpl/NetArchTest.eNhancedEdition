namespace Mono.Cecil
{

    static internal class PropertyDefinitionExtensions
    {
        /// <summary>
        /// Tests whether a property is readonly
        /// </summary>
        /// <param name="propertyDefinition">The property to test.</param>
        /// <returns>An indication of whether the property is readonly.</returns>
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

        public static bool IsInitOnly(this PropertyDefinition propertyDefinition)
        {
            return propertyDefinition.SetMethod?.ReturnType.FullName == "System.Void modreq(System.Runtime.CompilerServices.IsExternalInit)";
        }

        /// <summary>
        /// Tests whether a property is nullable
        /// </summary>
        /// <param name="propertyDefinition">The property to test.</param>
        /// <returns>An indication of whether the property is nullable.</returns>
        public static bool IsNullable(this PropertyDefinition propertyDefinition)
        {
            return propertyDefinition.PropertyType.IsNullable();
        }
    }
}