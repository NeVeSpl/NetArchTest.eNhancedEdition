using System;
using System.Collections.Generic;
using System.Linq;
using Mono.Cecil;
using NetArchTest.Assemblies;
using NetArchTest.Rules;

namespace NetArchTest.Functions
{
    internal static partial class FunctionDelegates
    {
        internal static IEnumerable<TypeSpec> HaveCustomAttribute(IEnumerable<TypeSpec> input, Type attribute, bool condition)
        {
            if (condition)
            {
                return input.Where(c => c.Definition.CustomAttributes.Any(a => attribute.FullName.Equals(a.AttributeType.FullName, StringComparison.InvariantCultureIgnoreCase)));
            }
            else
            {
                return input.Where(c => !c.Definition.CustomAttributes.Any(a => attribute.FullName.Equals(a.AttributeType.FullName, StringComparison.InvariantCultureIgnoreCase)));
            }
        }
        
        internal static IEnumerable<TypeSpec> HaveCustomAttributeOrInherit(IEnumerable<TypeSpec> input, Type attribute, bool condition)
        {
            // Convert the incoming type to a definition
            var target = attribute.ToTypeDefinition();
            if (condition)
            {
                return input.Where(c => c.Definition.CustomAttributes.Any(a => a.AttributeType.Resolve().IsSubclassOf(target) || attribute.FullName.Equals(a.AttributeType.FullName, StringComparison.InvariantCultureIgnoreCase)));
            }
            else
            {
                return input.Where(c => !c.Definition.CustomAttributes.Any(a => a.AttributeType.Resolve().IsSubclassOf(target) || attribute.FullName.Equals(a.AttributeType.FullName, StringComparison.InvariantCultureIgnoreCase)));
            }
        }
        
        internal static IEnumerable<TypeSpec> Inherit(IEnumerable<TypeSpec> input, Type type, bool condition)
        {
            // Convert the incoming type to a definition
            var target = type.ToTypeDefinition();
            if (condition)
            {
                return input.Where(c => c.Definition.IsSubclassOf(target));
            }
            else
            {
                return input.Where(c => !c.Definition.IsSubclassOf(target));
            }
        }
        
        internal static IEnumerable<TypeSpec> ImplementInterface(IEnumerable<TypeSpec> input, Type typeInterface, bool condition)
        {
            if (!typeInterface.IsInterface)
            {
                throw new ArgumentException($"The type {typeInterface.FullName} is not an interface.");
            }

            if (condition)
            {
                return input.Where(c => Implements(c.Definition, typeInterface));
            }
            else
            {
                return input.Where(c => !Implements(c.Definition, typeInterface));
            }

            static bool Implements(TypeDefinition c, Type typeInterface) => c.Interfaces.Any(t => t.InterfaceType.FullName.Equals(typeInterface.FullName, StringComparison.InvariantCultureIgnoreCase));
        } 

        internal static IEnumerable<TypeSpec> MeetCustomRule(IEnumerable<TypeSpec> input, ICustomRule rule, bool condition)
        {
            if (condition)
            {
                return input.Where(t => rule.MeetsRule(t.Definition));
            }
            else
            {
                return input.Where(t => !rule.MeetsRule(t.Definition));
            }
        }
    }
}