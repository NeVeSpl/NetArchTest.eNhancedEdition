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
        internal static IEnumerable<TypeSpec> HaveCustomAttribute(FunctionSequenceExecutionContext context, IEnumerable<TypeSpec> input, Type attribute, bool condition)
        {
            var target = attribute.ToTypeDefinition();

            if (condition)
            {
                return input.Where(c => c.Definition.CustomAttributes.Any(a => a.AttributeType.IsAlmostEqualTo(target)));
            }
            else
            {
                return input.Where(c => !c.Definition.CustomAttributes.Any(a => a.AttributeType.IsAlmostEqualTo(target)));
            }
        }

        internal static IEnumerable<TypeSpec> HaveCustomAttributeOrInherit(IEnumerable<TypeSpec> input, Type attribute, bool condition)
        {
            var target = attribute.ToTypeDefinition();

            if (condition)
            {
                return input.Where(c => c.Definition.CustomAttributes.Any(a => a.AttributeType.IsSubclassOf(target) || a.AttributeType.IsAlmostEqualTo(target)));
            }
            else
            {
                return input.Where(c => !c.Definition.CustomAttributes.Any(a => a.AttributeType.IsSubclassOf(target) || a.AttributeType.IsAlmostEqualTo(target)));
            }
        }

        internal static IEnumerable<TypeSpec> Inherit(IEnumerable<TypeSpec> input, Type type, bool condition)
        {
            if (type.IsInterface)
            {
                throw new ArgumentException($"The type {type.FullName} is an interface. interfaces are implemented not inherited, please use ImplementInterface instead.");
            }

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
            var inheritedTypes = new HashSet<string>(context.AllTypes.Select(x => x.Definition.BaseType?.GetFullNameWithoutGenericParameters()).Where(x => x is not null));

            if (condition)
            {
                return input.Where(c => inheritedTypes.Contains(c.Definition.FullName));
            }
            else
            {
                return input.Where(c => !inheritedTypes.Contains(c.Definition.FullName));
            }
        }

        internal static IEnumerable<TypeSpec> ImplementInterface(IEnumerable<TypeSpec> input, Type typeInterface, bool condition)
        {
            if (!typeInterface.IsInterface)
            {
                throw new ArgumentException($"The type {typeInterface.FullName} is not an interface.");
            }

            var target = typeInterface.ToTypeDefinition();

            if (condition)
            {
                return input.Where(c => c.Definition.Interfaces.Any(i => i.InterfaceType.IsAlmostEqualTo(target)));
            }
            else
            {
                return input.Where(c => !c.Definition.Interfaces.Any(i => i.InterfaceType.IsAlmostEqualTo(target)));
            }
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

        internal static IEnumerable<TypeSpec> MeetCustomRule(IEnumerable<TypeSpec> input, ICustomRule2 rule, bool condition)
        {
            var ruleDelegate = rule.MeetsRule;

            if (condition)
            {
                return input.Where(t => ExecuteCustomRule(t, ruleDelegate));
            }
            else
            {
                return input.Where(t => !ExecuteCustomRule(t, ruleDelegate));
            }
        }

        internal static IEnumerable<TypeSpec> MeetCustomRule(IEnumerable<TypeSpec> input, Func<TypeDefinition, CustomRuleResult> rule, bool condition)
        {
            if (condition)
            {
                return input.Where(t => ExecuteCustomRule(t, rule));
            }
            else
            {
                return input.Where(t => !ExecuteCustomRule(t, rule));
            }
        }

        private static bool ExecuteCustomRule(TypeSpec inputType, Func<TypeDefinition, CustomRuleResult> rule)
        {
            var result = rule.Invoke(inputType.Definition);
            if (!string.IsNullOrEmpty(result.Explanation))
            {
                inputType.Explanation = result.Explanation;
            }
            return result.IsMet;
        }
    }
}