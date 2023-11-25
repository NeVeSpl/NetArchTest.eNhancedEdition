using NetArchTest.Functions;

namespace NetArchTest.Rules
{
    public sealed partial class Predicate
    {
        /// <summary>
        /// Selects types that are declared as internal.
        /// </summary>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList AreInternal()
        {
            AddFunctionCall(x => FunctionDelegates.BeInternal(x, true));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types that are not declared as internal.
        /// </summary>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>       
        public PredicateList AreNotInternal()
        {
            AddFunctionCall(x => FunctionDelegates.BeInternal(x, false));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types that are nested.
        /// </summary>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList AreNested()
        {
            AddFunctionCall(x => FunctionDelegates.BeNested(x, true));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types that are not nested.
        /// </summary>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList AreNotNested()
        {
            AddFunctionCall(x => FunctionDelegates.BeNested(x, false));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types that are declared as private.
        /// </summary>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList ArePrivate()
        {
            AddFunctionCall(x => FunctionDelegates.BePrivate(x, true));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types that are not declared as private.
        /// </summary>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>     
        public PredicateList AreNotPrivate()
        {
            AddFunctionCall(x => FunctionDelegates.BePrivate(x, false));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types that are declared as private protected.
        /// </summary>     
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList ArePrivateProtected()
        {
            AddFunctionCall(x => FunctionDelegates.BePrivateProtected(x, true));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types that are not declared as private protected.
        /// </summary>      
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList AreNotPrivateProtected()
        {
            AddFunctionCall(x => FunctionDelegates.BePrivateProtected(x, false));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types that are declared as protected.
        /// </summary>     
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList AreProtected()
        {
            AddFunctionCall(x => FunctionDelegates.BeProtected(x, true));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types that are not declared as protected.
        /// </summary>      
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList AreNotProtected()
        {
            AddFunctionCall(x => FunctionDelegates.BeProtected(x, false));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types that are declared as protected internal.
        /// </summary>     
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList AreProtectedInternal()
        {
            AddFunctionCall(x => FunctionDelegates.BeProtectedInternal(x, true));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types that are not declared as protected internal.
        /// </summary>      
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList AreNotProtectedInternal()
        {
            AddFunctionCall(x => FunctionDelegates.BeProtectedInternal(x, false));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types that have public scope.
        /// </summary>        
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList ArePublic()
        {
            AddFunctionCall(x => FunctionDelegates.BePublic(x, true));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types that do not have public scope.
        /// </summary>        
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList AreNotPublic()
        {
            AddFunctionCall(x => FunctionDelegates.BePublic(x, false));
            return CreatePredicateList();
        }
    }
}