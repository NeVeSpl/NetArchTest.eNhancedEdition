using NetArchTest.Functions;

namespace NetArchTest.Rules
{
    public sealed partial class Condition
    {
        /// <summary>
        /// Selects types that have a dependency on any of the supplied types.
        /// </summary>
        /// <param name="dependencies">The dependencies to match against. These can be namespaces or specific types.</param>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList HaveDependencyOnAny(params string[] dependencies)
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.HaveDependencyOnAny(x, dependencies, true));
            return new ConditionList(_types, _should, _sequence);
        }

        /// <summary>
        /// Selects types that have a dependency on all of the particular types.
        /// </summary>
        /// <param name="dependencies">The dependencies to match against. These can be namespaces or specific types.</param>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList HaveDependencyOnAll(params string[] dependencies)
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.HaveDependencyOnAll(x, dependencies, true));
            return new ConditionList(_types, _should, _sequence);
        }

        /// <summary>
        /// Selects types that have a dependency on any of the supplied types and cannot have any other dependency. 
        /// </summary>
        /// <param name="dependencies">The dependencies to match against. These can be namespaces or specific types.</param>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList OnlyHaveDependencyOn(params string[] dependencies)
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.OnlyHaveDependenciesOnAnyOrNone(x, dependencies, true));
            return new ConditionList(_types, _should, _sequence);
        }

        /// <summary>
        /// Selects types that do not have a dependency on any of the particular types.
        /// </summary>
        /// <param name="dependencies">The dependencies to match against. These can be namespaces or specific types.</param>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList NotHaveDependencyOnAny(params string[] dependencies)
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.HaveDependencyOnAny(x, dependencies, false));
            return new ConditionList(_types, _should, _sequence);
        }

        /// <summary>
        /// Selects types that do not have a dependency on all of the particular types.
        /// </summary>
        /// <param name="dependencies">The dependencies to match against. These can be namespaces or specific types.</param>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList NotHaveDependencyOnAll(params string[] dependencies)
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.HaveDependencyOnAll(x, dependencies, false));
            return new ConditionList(_types, _should, _sequence);
        }

        /// <summary>
        /// Selects types that have a dependency other than any of the given dependencies.
        /// </summary>
        /// <param name="dependencies">The dependencies to match against. These can be namespaces or specific types.</param>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList HaveDependencyOtherThan(params string[] dependencies)
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.OnlyHaveDependenciesOnAnyOrNone(x, dependencies, false));
            return new ConditionList(_types, _should, _sequence);
        }
    }
}
