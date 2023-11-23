using NetArchTest.Functions;

namespace NetArchTest.Rules
{
    public sealed partial class Condition
    {
        /// <summary>
        /// Selects types that are immutable, and their state cannot be changed after creation. (shallow immutability). Stronger constraint than AreImmutableExternally()
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList BeImmutable()
        {
            AddFunctionCall(x => FunctionDelegates.BeImmutable(x, true));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types that are mutable.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList BeMutable()
        {
            AddFunctionCall(x => FunctionDelegates.BeImmutable(x, false));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types that are immutable from the outside of the given type. (shallow immutability).  Weaker constraint than AreImmutable()
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList BeImmutableExternally()
        {
            AddFunctionCall(x => FunctionDelegates.BeImmutableExternally(x, true));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types according to whether they have nullable members.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList OnlyHaveNullableMembers()
        {
            AddFunctionCall(x => FunctionDelegates.OnlyHaveNullableMembers(x, true));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types according to whether they have nullable members.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList HaveSomeNonNullableMembers()
        {
            AddFunctionCall(x => FunctionDelegates.OnlyHaveNullableMembers(x, false));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types according to whether they have only non-nullable members.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList OnlyHaveNonNullableMembers()
        {
            AddFunctionCall(x => FunctionDelegates.OnlyHaveNonNullableMembers(x, true));
            return CreateConditionList();
        }
    }
}