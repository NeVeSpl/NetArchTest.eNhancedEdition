using System;
using System.Collections.Generic;
using NetArchTest.RuleEngine;

namespace NetArchTest.Rules
{
    /// <summary>
    /// A set of conditions and types that have conjunctions (i.e. "and", "or") and executors (i.e. Types(), GetResult()) applied to them.
    /// </summary>
    public sealed class ConditionList
    {
        private readonly RuleContext _rule;

        internal ConditionList(RuleContext rule)
        {
            _rule = rule;
        }
        
        /// <summary>
        /// Specifies that any subsequent condition should be treated as an "and" condition.
        /// </summary>
        /// <returns>An set of conditions that can be applied to a list of classes.</returns>
        /// <remarks>And() has higher priority than Or() and it is computed first.</remarks>
        public Condition And()
        {
            return new Condition(_rule);
        }

        /// <summary>
        /// Specifies that any subsequent conditions should be treated as part of an "or" condition.
        /// </summary>
        /// <returns>An set of conditions that can be applied to a list of classes.</returns>
        public Condition Or()
        {
            // Create a new group of functions - this has the effect of creating an "or" condition
            _rule.ConditionContext.Sequence.CreateGroup();
            return new Condition(_rule);
        }

        /// <summary>
        /// Returns an indication of whether all the selected types satisfy the conditions.
        /// </summary>
        /// <returns>An indication of whether the conditions are true, along with a list of types failing the check if they are not.</returns>
        public TestResult GetResult(Options options = null)
        {
            return _rule.GetResult(options);
        }

        /// <summary>
        /// Returns the list of types that satisfy the conditions.
        /// </summary>
        /// <returns>A list of types.</returns>
        public IEnumerable<IType> GetTypes(Options options = null)
        {
            return _rule.GetTypes(options);
        }

        internal IEnumerable<Type> GetReflectionTypes(Options options = null)
        {
            return _rule.GetReflectionTypes(options);
        }
    }
}