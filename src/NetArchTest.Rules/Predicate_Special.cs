using NetArchTest.Functions;

namespace NetArchTest.Rules
{
    public sealed partial class Predicate
    {
        /// <summary>
        /// Selects types that are immutable.
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
        /// Selects types that have only nullable members.
        /// </summary>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList OnlyHaveNullableMembers()
        {
            AddFunctionCall(x => FunctionDelegates.HasNullableMembers(x, true));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types that have some non-nullable members.
        /// </summary>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList HaveSomeNonNullableMembers()
        {
            AddFunctionCall(x => FunctionDelegates.HasNullableMembers(x, false));
            return CreatePredicateList();
        }
    }
}
