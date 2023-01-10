using System;
using System.Collections.Generic;
using System.Linq;
using NetArchTest.Assemblies;
using NetArchTest.Functions;

namespace NetArchTest.Rules
{
    /// <summary>
    /// A set of conditions and types that have have conjunctions (i.e. "and", "or") and executors (i.e. Types(), GetResult()) applied to them.
    /// </summary>
    public sealed class ConditionList
    {        
        private readonly IEnumerable<TypeSpec> _types;
        private readonly FunctionSequence _sequence;

        /// <summary> Determines the polarity of the selection, i.e. "should" or "should not". </summary>
        private readonly bool _should;

       
        internal ConditionList(IEnumerable<TypeSpec> classes, bool should, FunctionSequence sequence)
        {
            _types = classes;
            _should = should;
            _sequence = sequence;
        }


        /// <summary>
        /// Returns an indication of whether all the selected types satisfy the conditions.
        /// </summary>
        /// <returns>An indication of whether the conditions are true, along with a list of types failing the check if they are not.</returns>
        public TestResult GetResult()
        {
            bool success;

            var passingTypes = _sequence.Execute(_types);

            if (_should)
            {
                // All the classes should meet the condition
                success = (passingTypes.Count() == _types.Count());
            }
            else
            {
                // No classes should meet the condition
                success = (passingTypes.Count() == 0);
            }

            if (success)
            {
                return TestResult.Success();
            }

            // If we've failed, get a collection of failing types so these can be reported in a failing test.
            var failedTypes = _sequence.ExecuteExtended(_types, selected: !_should);
            return TestResult.Failure(failedTypes);
        }

        /// <summary>
        /// Returns the list of types that satisfy the conditions.
        /// </summary>
        /// <returns>A list of types.</returns>
        public IEnumerable<IType> GetTypes()
        {
            return _sequence.Execute(_types).Select(t => t.CreateWrapper());
        }

        internal IEnumerable<Type> GetReflectionTypes()
        {
            return GetTypes().Select(x => x.ReflectionType);
        }

        /// <summary>
        /// Specifies that any subsequent condition should be treated as an "and" condition.
        /// </summary>
        /// <returns>An set of conditions that can be applied to a list of classes.</returns>
        /// <remarks>And() has higher priority than Or() and it is computed first.</remarks>
        public Condition And()
        {
            return new Condition(_types, _should, _sequence);
        }

        /// <summary>
        /// Specifies that any subsequent conditions should be treated as part of an "or" condition.
        /// </summary>
        /// <returns>An set of conditions that can be applied to a list of classes.</returns>
        public Condition Or()
        {
            // Create a new group of functions - this has the effect of creating an "or" condition
            _sequence.CreateGroup();
            return new Condition(_types, _should, _sequence);
        }
    }
}