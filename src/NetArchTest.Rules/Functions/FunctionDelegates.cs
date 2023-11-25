using System;
using System.Collections.Generic;
using System.Linq;
using Mono.Cecil;
using NetArchTest.Assemblies;
using NetArchTest.RuleEngine;
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
            if (type.IsInterface)
            {
                throw new ArgumentException($"The type {type.FullName} is an interface. interfaces are implemented not inherited, please use ImplementInterface instead.");
            }

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

        internal static IEnumerable<TypeSpec> BeInherited(FunctionSequenceExecutionContext context, IEnumerable<TypeSpec> input, bool condition)
        {
            var InheritedTypes = new HashSet<string>(context.AllTypes.Select(x => x.Definition.BaseType?.FullName).Where(x => x is not null));
            if (condition)
            {
                return input.Where(c => InheritedTypes.Contains(c.Definition.FullName));
            }
            else
            {
                return input.Where(c => !InheritedTypes.Contains(c.Definition.FullName));
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
        internal static IEnumerable<TypeSpec> MeetCustomRule(IEnumerable<TypeSpec> input, Func<TypeDefinition, bool> rule, bool condition)
        {
            if (condition)
            {
                return input.Where(t => rule(t.Definition));
            }
            else
            {
                return input.Where(t => !rule(t.Definition));
            }
        }
    }
}