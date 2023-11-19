using NetArchTest.Functions;

namespace NetArchTest.Rules
{
    public sealed partial class Predicate
    {
        /// <summary>
        /// Selects types that are marked as abstract.
        /// </summary>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList AreAbstract()
        {
            AddFunctionCall(x => FunctionDelegates.BeAbstract(x, true));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types that are not marked as abstract.
        /// </summary>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList AreNotAbstract()
        {
            AddFunctionCall(x => FunctionDelegates.BeAbstract(x, false));
            return CreatePredicateList();
        }

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
        /// Selects types that have generic parameters.
        /// </summary>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList AreGeneric()
        {
            AddFunctionCall(x => FunctionDelegates.BeGeneric(x, true));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types that do not have generic parameters.
        /// </summary>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList AreNotGeneric()
        {
            AddFunctionCall(x => FunctionDelegates.BeGeneric(x, false));
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
        /// Selects types that are static.
        /// </summary>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList AreStatic()
        {
            AddFunctionCall(x => FunctionDelegates.BeStatic(x, true));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types that are not static.
        /// </summary>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList AreNotStatic()
        {
            AddFunctionCall(x => FunctionDelegates.BeStatic(x, false));
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
        /// Selects types that are nested and declared as public.
        /// </summary>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList AreNestedPublic()
        {
            AddFunctionCall(x => FunctionDelegates.BeNestedPublic(x, true));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types that are nested and declared as private.
        /// </summary>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList AreNestedPrivate()
        {
            AddFunctionCall(x => FunctionDelegates.BeNestedPrivate(x, true));
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
        /// Selects types that are not nested and declared as public.
        /// </summary>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        /// <remarks>NB: This method will return non-nested types and nested types that are declared as private.</remarks>
        public PredicateList AreNotNestedPublic()
        {
            AddFunctionCall(x => FunctionDelegates.BeNestedPublic(x, false));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types that are not nested and declared as private.
        /// </summary>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        /// <remarks>NB: This method will return non-nested types and nested types that are declared as public.</remarks>
        public PredicateList AreNotNestedPrivate()
        {
            AddFunctionCall(x => FunctionDelegates.BeNestedPrivate(x, false));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types that have public scope.
        /// </summary>
        /// <remarks>
        /// This method will only act on types that are visible to the function. Use InternalsVisibleTo if testing from a separate assembly.
        /// </remarks>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList ArePublic()
        {
            AddFunctionCall(x => FunctionDelegates.BePublic(x, true));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types that do not have public scope.
        /// </summary>
        /// <remarks>
        /// This method will only act on types that are visible to the function. Use InternalsVisibleTo if testing from a separate assembly.
        /// </remarks>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList AreNotPublic()
        {
            AddFunctionCall(x => FunctionDelegates.BePublic(x, false));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types according that are marked as sealed.
        /// </summary>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList AreSealed()
        {
            AddFunctionCall(x => FunctionDelegates.BeSealed(x, true));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types according that are not marked as sealed.
        /// </summary>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList AreNotSealed()
        {
            AddFunctionCall(x => FunctionDelegates.BeSealed(x, false));
            return CreatePredicateList();
        }

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