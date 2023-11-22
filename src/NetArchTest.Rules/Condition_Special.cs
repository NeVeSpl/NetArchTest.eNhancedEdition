using NetArchTest.Functions;

namespace NetArchTest.Rules
{
    public sealed partial class Condition
    {

        /// <summary>
        /// Selects types that are immutable.
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
        /// Selects types according to whether they have nullable members.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList OnlyHaveNullableMembers()
        {
            AddFunctionCall(x => FunctionDelegates.HasNullableMembers(x, true));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types according to whether they have nullable members.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList HaveSomeNonNullableMembers()
        {
            AddFunctionCall(x => FunctionDelegates.HasNullableMembers(x, false));
            return CreateConditionList();
        }
    }
}
