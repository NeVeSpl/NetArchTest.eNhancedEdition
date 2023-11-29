﻿using NetArchTest.Functions;

namespace NetArchTest.Rules
{
    public sealed partial class Predicate
    {
        /// <summary>
        /// Selects types that are immutable, and their state cannot be changed after creation. (shallow immutability). Stronger constraint than AreImmutableExternally()
        /// </summary>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList AreImmutable()
        {
            AddFunctionCall(x => FunctionDelegates.BeImmutable(x, true));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types that are mutable.
        /// </summary>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList AreMutable()
        {
            AddFunctionCall(x => FunctionDelegates.BeImmutable(x, false));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types that are immutable from the outside of the given type. (shallow immutability).  Weaker constraint than AreImmutable()
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public PredicateList AreImmutableExternally()
        {
            AddFunctionCall(x => FunctionDelegates.BeImmutableExternally(x, true));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types that are stateless, they do not have instance state
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public PredicateList AreStateless()
        {
            AddFunctionCall(x => FunctionDelegates.BeStateless(x, true));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types that are staticless, they do not have static state
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public PredicateList AreStaticless()
        {
            AddFunctionCall(x => FunctionDelegates.BeStaticless(x, true));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types that have only nullable members.
        /// </summary>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList OnlyHaveNullableMembers()
        {
            AddFunctionCall(x => FunctionDelegates.OnlyHaveNullableMembers(x, true));
            return CreatePredicateList();
        }  

        /// <summary>
        /// Selects types that have some non-nullable members.
        /// </summary>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList HaveSomeNonNullableMembers()
        {
            AddFunctionCall(x => FunctionDelegates.OnlyHaveNullableMembers(x, false));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types that have only non-nullable members.
        /// </summary>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList OnlyHaveNonNullableMembers()
        {
            AddFunctionCall(x => FunctionDelegates.OnlyHaveNonNullableMembers(x, true));
            return CreatePredicateList();
        }
    }
}