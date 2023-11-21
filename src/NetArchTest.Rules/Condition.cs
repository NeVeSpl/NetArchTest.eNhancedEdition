using System;
using NetArchTest.Assemblies;
using System.Collections.Generic;
using NetArchTest.Functions;
using NetArchTest.RuleEngine;

namespace NetArchTest.Rules
{
    /// <summary>
    /// A set of conditions that can be applied to a list of types.
    /// </summary>
    public sealed partial class Condition
    {
        private readonly RuleContext rule;
        private readonly ConditionContext context;


        internal Condition(RuleContext rule)
        {
            this.rule = rule;
            this.context = rule.ConditionContext;
        }
        internal Condition(RuleContext rule, bool should) : this(rule)
        {           
            rule.ConditionContext.Should= should;
        }
       

        private ConditionList CreateConditionList()
        {
            return new ConditionList(rule);
        }
        private void AddFunctionCall(Func<IEnumerable<TypeSpec>, IEnumerable<TypeSpec>> func)
        {
            context.Sequence.AddFunctionCall(func);
        }


       

       

        /// <summary>
        /// Selects types are decorated with a specific custom attribut.
        /// </summary>
        /// <param name="attribute">The attribute to match against.</param>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList HaveCustomAttribute(Type attribute)
        {
            AddFunctionCall(x => FunctionDelegates.HaveCustomAttribute(x, attribute, true));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types that are not decorated with a specific custom attribute.
        /// </summary>
        /// <param name="attribute">The attribute to match against.</param>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList NotHaveCustomAttribute(Type attribute)
        {
            AddFunctionCall(x => FunctionDelegates.HaveCustomAttribute(x, attribute, false));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types that are decorated with a specific custom attribute or derived one.
        /// </summary>
        /// <param name="attribute">The base attribute to match against.</param>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList HaveCustomAttributeOrInherit(Type attribute)
        {
            AddFunctionCall(x => FunctionDelegates.HaveCustomAttributeOrInherit(x, attribute, true));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types are not decorated with a specific custom attribute or derived one.
        /// </summary>
        /// <param name="attribute">The base attribute to match against.</param>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList NotHaveCustomAttributeOrInherit(Type attribute)
        {
            AddFunctionCall(x => FunctionDelegates.HaveCustomAttributeOrInherit(x, attribute, false));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types that inherit a particular type.
        /// </summary>
        /// <param name="type">The type to match against.</param>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList Inherit(Type type)
        {
            AddFunctionCall(x => FunctionDelegates.Inherits(x, type, true));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types that do not inherit a particular type.
        /// </summary>
        /// <param name="type">The type to match against.</param>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList NotInherit(Type type)
        {
            AddFunctionCall(x => FunctionDelegates.Inherits(x, type, false));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types that implement a particular interface.
        /// </summary>
        /// <param name="interfaceType">The interface type to match against.</param>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList ImplementInterface(Type interfaceType)
        {
            AddFunctionCall(x => FunctionDelegates.ImplementsInterface(x, interfaceType, true));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types that do not implement a particular interface.
        /// </summary>
        /// <param name="interfaceType">The interface type to match against.</param>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList NotImplementInterface(Type interfaceType)
        {
            AddFunctionCall(x => FunctionDelegates.ImplementsInterface(x, interfaceType, false));
            return CreateConditionList();
        }
 
       

        /// <summary>
        /// Selects types that meet a custom rule.
        /// </summary>
        /// <param name="rule">An instance of the custom rule.</param>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList MeetCustomRule(ICustomRule rule)
        {
            AddFunctionCall(x => FunctionDelegates.MeetCustomRule(x, rule, true));
            return CreateConditionList();
        }
    }
}