using NetArchTest.Functions;

namespace NetArchTest.Rules
{
    public sealed partial class Predicate
    {
        /// <summary>
        /// Selects types that have more logical lines of code than a given number
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public PredicateList HaveNumberOfLinesOfCodeGreaterThan(int number)
        {
            AddFunctionCall((context, inputTypes) => FunctionDelegates.HaveNumberOfLinesOfCodeFewerThan(context, inputTypes, number, false));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types that have fewer logical lines of code than a given number
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public PredicateList HaveNumberOfLinesOfCodeLowerThan(int number)
        {
            AddFunctionCall((context, inputTypes) => FunctionDelegates.HaveNumberOfLinesOfCodeFewerThan(context, inputTypes, number, true));
            return CreatePredicateList();
        }
    }
}