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
        private readonly RuleContext _rule;

        internal PredicateList(RuleContext rule)
        {
            _rule = rule;
        }

        /// <summary>
        /// Links a predicate defining a set of classes to a condition that tests them.
        /// </summary>
        /// <returns>A condition that tests classes against a given criteria.</returns>
        public Condition Should()
        {
            return new Condition(_rule, true);
        }

        /// <summary>
        /// Links a predicate defining a set of classes to a condition that tests them.
        /// </summary>
        /// <returns>A condition that tests classes against a given criteria.</returns>
        public Condition ShouldNot()
        {
            return new Condition(_rule, false);
        }

        /// <summary>
        /// Allows dividing types into groups, also called slices.
        /// </summary>
        /// <returns></returns>
        public SlicePredicate Slice()
        {
            return new SlicePredicate(_rule);
        }

        /// <summary>
        /// Specifies that any subsequent predicates should be treated as "and" conditions.
        /// </summary>
        /// <returns>An set of predicates that can be applied to a list of classes.</returns>
        /// <remarks>And() has higher priority than Or() and it is computed first.</remarks>
        public Predicate And()
        {
            return new Predicate(_rule);
        }

        /// <summary>
        /// Specifies that any subsequent predicates should be treated as part of an "or" condition.
        /// </summary>
        /// <returns>An set of predicates that can be applied to a list of classes.</returns>
        public Predicate Or()
        {
            // Create a new group of functions - this has the effect of creating an "or" condition
            _rule.PredicateContext.Sequence.CreateGroup();
            return new Predicate(_rule);
        }

        /// <summary>
        /// Returns the types returned by these predicates.
        /// </summary>
        /// <returns>A list of types.</returns>
        public IEnumerable<IType> GetTypes(Options options = null)
        {
            return _rule.GetTypes(options);
        }

        internal IEnumerable<TypeSpec> GetTypeSpecifications(Options options = null)
        {
            return _rule.Execute(options);
        }
        internal IEnumerable<Type> GetReflectionTypes(Options options = null)
        {
            return _rule.GetReflectionTypes(options);
        }
    }
}