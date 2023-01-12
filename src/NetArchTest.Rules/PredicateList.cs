using System;
using System.Collections.Generic;
using NetArchTest.Assemblies;
using NetArchTest.RuleEngine;
using NetArchTest.Slices;

namespace NetArchTest.Rules
{
    /// <summary>
    /// A set of predicates and types that have have conjunctions (i.e. "and", "or") and executors (i.e. Types(), TypeDefinitions()) applied to them.
    /// </summary>
    public sealed class PredicateList
    {
        private readonly RuleContext rule;       


        internal PredicateList(RuleContext rule) 
        {
            this.rule = rule;          
        }


        /// <summary>
        /// Links a predicate defining a set of classes to a condition that tests them.
        /// </summary>
        /// <returns>A condition that tests classes against a given criteria.</returns>
        public Condition Should()
        {
            return new Condition(rule, true);
        }

        /// <summary>
        /// Links a predicate defining a set of classes to a condition that tests them.
        /// </summary>
        /// <returns>A condition that tests classes against a given criteria.</returns>
        public Condition ShouldNot()
        {
            return new Condition(rule, false);
        }

        /// <summary>
        /// Allows dividing types into groups, also called slices.
        /// </summary>
        /// <returns></returns>
        public SlicePredicate Slice()
        {
            return new SlicePredicate(rule);
        }


        /// <summary>
        /// Specifies that any subsequent predicates should be treated as "and" conditions.
        /// </summary>
        /// <returns>An set of predicates that can be applied to a list of classes.</returns>
        /// <remarks>And() has higher priority than Or() and it is computed first.</remarks>
        public Predicate And()
        {
            return new Predicate(rule);
        }

        /// <summary>
        /// Specifies that any subsequent predicates should be treated as part of an "or" condition.
        /// </summary>
        /// <returns>An set of predicates that can be applied to a list of classes.</returns>
        public Predicate Or()
        {
            // Create a new group of functions - this has the effect of creating an "or" condition
            rule.PredicateContext.Sequence.CreateGroup();
            return new Predicate(rule);
        }

        /// <summary>
        /// Returns the types returned by these predicates.
        /// </summary>
        /// <returns>A list of types.</returns>
        public IEnumerable<IType> GetTypes()
        {
            return rule.GetTypes();
        }


        internal IEnumerable<TypeSpec> GetTypeSpecifications()
        { 
            return rule.Execute();
        }
        internal IEnumerable<Type> GetReflectionTypes()
        {
            return rule.GetReflectionTypes();
        }
    }
}