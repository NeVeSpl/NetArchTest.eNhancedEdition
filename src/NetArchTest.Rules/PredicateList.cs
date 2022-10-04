using System;
using System.Collections.Generic;
using System.Linq;
using NetArchTest.Rules.Assemblies;
using NetArchTest.Rules.Extensions;
using NetArchTest.Rules.Slices;

namespace NetArchTest.Rules
{
    /// <summary>
    /// A set of predicates and types that have have conjunctions (i.e. "and", "or") and executors (i.e. Types(), TypeDefinitions()) applied to them.
    /// </summary>
    public sealed class PredicateList
    {       
        private readonly IEnumerable<TypeSpec> _types;        
        private readonly FunctionSequence _sequence;


        /// <summary>
        /// Initializes a new instance of the <see cref="PredicateList"/> class.
        /// </summary>
        internal PredicateList(IEnumerable<TypeSpec> classes, FunctionSequence sequence) 
        {
            _types = classes;
            _sequence = sequence;
        }


        /// <summary>
        /// Links a predicate defining a set of classes to a condition that tests them.
        /// </summary>
        /// <returns>A condition that tests classes against a given criteria.</returns>
        public Condition Should()
        {
            return new Condition(GetTypeSpecifications(), true);
        }

        /// <summary>
        /// Links a predicate defining a set of classes to a condition that tests them.
        /// </summary>
        /// <returns>A condition that tests classes against a given criteria.</returns>
        public Condition ShouldNot()
        {
            return new Condition(GetTypeSpecifications(), false);
        }

        /// <summary>
        /// Allows dividing types into groups, also called slices.
        /// </summary>
        /// <returns></returns>
        public SlicePredicate Slice()
        {
            return new SlicePredicate(GetTypeSpecifications());
        }

       
        internal IEnumerable<TypeSpec> GetTypeSpecifications()
        { 
            return _sequence.Execute(_types);
        }
        internal IEnumerable<Type> GetNetTypes()
        {
            return GetTypeSpecifications().Select(x => x.Definition.ToType());
        }

        /// <summary>
        /// Returns the types returned by these predicates.
        /// </summary>
        /// <returns>A list of types.</returns>
        public IEnumerable<IType> GetTypes()
        {
            return GetTypeSpecifications().Select(t => t.CreateWrapper());
        }

        /// <summary>
        /// Specifies that any subsequent predicates should be treated as "and" conditions.
        /// </summary>
        /// <returns>An set of predicates that can be applied to a list of classes.</returns>
        /// <remarks>And() has higher priority than Or() and it is computed first.</remarks>
        public Predicate And()
        {
            return new Predicate(_types, _sequence);
        }

        /// <summary>
        /// Specifies that any subsequent predicates should be treated as part of an "or" condition.
        /// </summary>
        /// <returns>An set of predicates that can be applied to a list of classes.</returns>
        public Predicate Or()
        {
            // Create a new group of functions - this has the effect of creating an "or" condition
            _sequence.CreateGroup();
            return new Predicate(_types, _sequence);
        }
    }
}