using NetArchTest.Functions;

namespace NetArchTest.Rules
{
    public sealed partial class Predicate
    {
        /// <summary>
        /// Selects types that have a dependency on any of the supplied types.
        /// </summary>
        /// <param name="dependencies">The dependencies to match against. These can be namespaces or specific types.</param>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public PredicateList HaveDependencyOnAny(params string[] dependencies)
        {
            AddFunctionCall((context, inputTypes) => FunctionDelegates.HaveDependencyOnAny(context, inputTypes, dependencies, true));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types that have a dependency on all of the supplied types.
        /// </summary>
        /// <param name="dependencies">The dependencies to match against. These can be namespaces or specific types.</param>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public PredicateList HaveDependencyOnAll(params string[] dependencies)
        {
            AddFunctionCall((context, inputTypes) => FunctionDelegates.HaveDependencyOnAll(context, inputTypes, dependencies, true));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types that have a dependency on any of the supplied types and cannot have any other dependency.
        /// </summary>
        /// <param name="dependencies">The dependencies to match against. These can be namespaces or specific types.</param>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public PredicateList OnlyHaveDependencyOn(params string[] dependencies)
        {
            AddFunctionCall((context, inputTypes) => FunctionDelegates.OnlyHaveDependenciesOnAnyOrNone(context, inputTypes, dependencies, true));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types that do not have a dependency on any of the supplied types.
        /// </summary>
        /// <param name="dependencies">The dependencies to match against. These can be namespaces or specific types.</param>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public PredicateList DoNotHaveDependencyOnAny(params string[] dependencies)
        {
            AddFunctionCall((context, inputTypes) => FunctionDelegates.HaveDependencyOnAny(context, inputTypes, dependencies, false));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types that do not have a dependency on all of the supplied types.
        /// </summary>
        /// <param name="dependencies">The dependencies to match against. These can be namespaces or specific types.</param>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public PredicateList DoNotHaveDependencyOnAll(params string[] dependencies)
        {
            AddFunctionCall((context, inputTypes) => FunctionDelegates.HaveDependencyOnAll(context, inputTypes, dependencies, false));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types that have a dependency other than any of the supplied dependencies.
        /// </summary>
        /// <param name="dependencies">The dependencies to match against. These can be namespaces or specific types.</param>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public PredicateList HaveDependencyOtherThan(params string[] dependencies)
        {
            AddFunctionCall((context, inputTypes) => FunctionDelegates.OnlyHaveDependenciesOnAnyOrNone(context, inputTypes, dependencies, false));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types that are used by any of the supplied types.
        /// </summary>
        /// <param name="users">The types to match against. These can be namespaces or specific types.</param>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public PredicateList AreUsedByAny(params string[] users)
        {
            AddFunctionCall((context, inputTypes) => FunctionDelegates.AreUsedByAny(context, inputTypes, users, true));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types that are not used by any of the supplied types.
        /// </summary>
        /// <param name="users">The types to match against. These can be namespaces or specific types.</param>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public PredicateList AreNotUsedByAny(params string[] users)
        {
            AddFunctionCall((context, inputTypes) => FunctionDelegates.AreUsedByAny(context, inputTypes, users, false));
            return CreatePredicateList();
        }
    }
}