using Mono.Cecil;

namespace NetArchTest
{
    /// <summary>
    /// An externally defined filter that can be used to decided if a dependency should be checked by DependencySearch engine or not
    /// </summary>
    public interface IDependencyFilter
    {
        /// <summary>
        /// Tests whether the supplied type should be checked by DependencySearch engine or not
        /// </summary>
        /// <param name="type">The type to be tested.</param>
        /// <returns>The result of the test.</returns>
        bool ShouldDependencyBeChecked(TypeReference dependency);
    }
}