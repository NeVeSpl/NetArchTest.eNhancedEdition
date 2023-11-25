using NetArchTest.Functions;

namespace NetArchTest.Rules
{
    public sealed partial class Predicate
    {
        /// <summary>
        /// Selects types that are classes.
        /// </summary>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList AreClasses()
        {
            AddFunctionCall(x => FunctionDelegates.BeClass(x, true));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types that are not classes.
        /// </summary>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList AreNotClasses()
        {
            AddFunctionCall(x => FunctionDelegates.BeClass(x, false));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types that are delegates.
        /// </summary>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList AreDelegates()
        {
            AddFunctionCall(x => FunctionDelegates.BeDelegate(x, true));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types that are not delegates.
        /// </summary>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList AreNotDelegates()
        {
            AddFunctionCall(x => FunctionDelegates.BeDelegate(x, false));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types that are enums.
        /// </summary>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList AreEnums()
        {
            AddFunctionCall(x => FunctionDelegates.BeEnum(x, true));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types that are not enums.
        /// </summary>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList AreNotEnums()
        {
            AddFunctionCall(x => FunctionDelegates.BeEnum(x, false));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types that are interfaces.
        /// </summary>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList AreInterfaces()
        {
            AddFunctionCall(x => FunctionDelegates.BeInterface(x, true));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types that are not interfaces.
        /// </summary>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList AreNotInterfaces()
        {
            AddFunctionCall(x => FunctionDelegates.BeInterface(x, false));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types that are records.
        /// </summary>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        internal PredicateList AreRecords()
        {
            AddFunctionCall(x => FunctionDelegates.BeRecord(x, true));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types that are not records.
        /// </summary>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        internal PredicateList AreNotRecords()
        {
            AddFunctionCall(x => FunctionDelegates.BeRecord(x, false));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types that are structures.
        /// </summary>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList AreStructures()
        {
            AddFunctionCall(x => FunctionDelegates.BeStruct(x, true));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types that are not structures.
        /// </summary>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList AreNotStructures()
        {
            AddFunctionCall(x => FunctionDelegates.BeStruct(x, false));
            return CreatePredicateList();
        }
    }
}