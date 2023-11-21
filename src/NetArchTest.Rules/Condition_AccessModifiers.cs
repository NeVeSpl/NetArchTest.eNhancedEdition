using NetArchTest.Functions;

namespace NetArchTest.Rules
{
    public sealed partial class Condition
    {
        /// <summary>
        /// Selects types that are internal.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList BeInternal()
        {
            AddFunctionCall(x => FunctionDelegates.BeInternal(x, true));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types that are not internal.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList NotBeInternal()
        {
            AddFunctionCall(x => FunctionDelegates.BeInternal(x, false));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types that are nested.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList BeNested()
        {
            AddFunctionCall(x => FunctionDelegates.BeNested(x, true));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types that are not nested.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList NotBeNested()
        {
            AddFunctionCall(x => FunctionDelegates.BeNested(x, false));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types that are private.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList BePrivate()
        {
            AddFunctionCall(x => FunctionDelegates.BePrivate(x, true));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types that are not private.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList NotBePrivate()
        {
            AddFunctionCall(x => FunctionDelegates.BePrivate(x, false));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types that are private protected.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList BePrivateProtected()
        {
            AddFunctionCall(x => FunctionDelegates.BePrivateProtected(x, true));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types that are not private protected.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList NotBePrivateProtected()
        {
            AddFunctionCall(x => FunctionDelegates.BePrivateProtected(x, false));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types that are protected.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList BeProtected()
        {
            AddFunctionCall(x => FunctionDelegates.BeProtected(x, true));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types that are not protected.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList NotBeProtected()
        {
            AddFunctionCall(x => FunctionDelegates.BeProtected(x, false));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types that are protected internal.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList BeProtectedInternal()
        {
            AddFunctionCall(x => FunctionDelegates.BeProtectedInternal(x, true));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types that are not protected internal.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList NotBeProtectedInternal()
        {
            AddFunctionCall(x => FunctionDelegates.BeProtectedInternal(x, false));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types that are have public scope.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList BePublic()
        {
            AddFunctionCall(x => FunctionDelegates.BePublic(x, true));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types that do not have public scope.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList NotBePublic()
        {
            AddFunctionCall(x => FunctionDelegates.BePublic(x, false));
            return CreateConditionList();
        }
    }
}
