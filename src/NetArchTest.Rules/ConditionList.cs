using System;
using System.Collections.Generic;
using NetArchTest.RuleEngine;

namespace NetArchTest.Rules
{
    /// <summary>
    /// A set of conditions and types that have have conjunctions (i.e. "and", "or") and executors (i.e. Types(), GetResult()) applied to them.
    /// </summary>
    public sealed class ConditionList
    {
        private readonly RuleContext rule;       


        internal ConditionList(RuleContext rule)
        {
            this.rule = rule;          
        }


        /// <summary>
        /// Specifies that any subsequent condition should be treated as an "and" condition.
        /// </summary>
        /// <returns>An set of conditions that can be applied to a list of classes.</returns>
        /// <remarks>And() has higher priority than Or() and it is computed first.</remarks>
        public Condition And()
        {
            return new Condition(rule);
        }

        /// <summary>
        /// Specifies that any subsequent conditions should be treated as part of an "or" condition.
        /// </summary>
        /// <returns>An set of conditions that can be applied to a list of classes.</returns>
        public Condition Or()
        {
            // Create a new group of functions - this has the effect of creating an "or" condition
            rule.ConditionContext.Sequence.CreateGroup();
            return new Condition(rule);
        }


        /// <summary>
        /// Returns an indication of whether all the selected types satisfy the conditions.
        /// </summary>
        /// <returns>An indication of whether the conditions are true, along with a list of types failing the check if they are not.</returns>
        public TestResult GetResult()
        {
            return rule.GetResult();
        }

        /// <summary>
        /// Returns the list of types that satisfy the conditions.
        /// </summary>
        /// <returns>A list of types.</returns>
        public IEnumerable<IType> GetTypes()
        {
            return rule.GetTypes();
        }

                
        internal IEnumerable<Type> GetReflectionTypes()
        {
            return rule.GetReflectionTypes();
        }
    }
}