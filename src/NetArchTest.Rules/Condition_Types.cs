using NetArchTest.Functions;

namespace NetArchTest.Rules
{
    public sealed partial class Condition
    {
        /// <summary>
        /// Selects types that are classes.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList BeClasses()
        {
            AddFunctionCall(x => FunctionDelegates.BeClass(x, true));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types that are not classes.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList NotBeClasses()
        {
            AddFunctionCall(x => FunctionDelegates.BeClass(x, false));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types that are delegates.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList BeDelegates()
        {
            AddFunctionCall(x => FunctionDelegates.BeDelegate(x, true));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types that are not delegates.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList NotBeDelegates()
        {
            AddFunctionCall(x => FunctionDelegates.BeDelegate(x, false));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types that are enums.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList BeEnums()
        {
            AddFunctionCall(x => FunctionDelegates.BeEnum(x, true));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types that are not enums.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList NotBeEnums()
        {
            AddFunctionCall(x => FunctionDelegates.BeEnum(x, false));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types that are interfaces.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList BeInterfaces()
        {
            AddFunctionCall(x => FunctionDelegates.BeInterface(x, true));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types that are not interfaces.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList NotBeInterfaces()
        {
            AddFunctionCall(x => FunctionDelegates.BeInterface(x, false));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types that are structures.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList BeStructures()
        {
            AddFunctionCall(x => FunctionDelegates.BeStruct(x, true));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types that are not structures.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList NotBeStructures()
        {
            AddFunctionCall(x => FunctionDelegates.BeStruct(x, false));
            return CreateConditionList();
        }
    }
}
