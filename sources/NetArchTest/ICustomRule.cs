using Mono.Cecil;

namespace NetArchTest.Rules
{
    /// <summary>
    /// An externally defined rule that can be applied as a condition or a predicate.
    /// </summary>
    public interface ICustomRule
    {
        /// <summary>
        /// Tests whether the supplied type meets the rule.
        /// </summary>
        /// <param name="type">The type to be tested.</param>
        /// <returns>The result of the test.</returns>
        bool MeetsRule(TypeDefinition type);
    }

    /// <summary>
    /// An externally defined rule that can be applied as a condition or a predicate.
    /// </summary>
    public interface ICustomRule2
    {
        /// <summary>
        /// Tests whether the supplied type meets the rule.
        /// </summary>
        /// <param name="type">The type to be tested.</param>
        /// <returns>The result of the test.</returns>
        CustomRuleResult MeetsRule(TypeDefinition type);
    }

    public class CustomRuleResult
    {
        public bool IsMet { get; init; }

        public string Explanation { get; init; }

        public CustomRuleResult(bool isMet, string explanation = null)
        {
            IsMet = isMet;
            Explanation = explanation;
        }
    }
}