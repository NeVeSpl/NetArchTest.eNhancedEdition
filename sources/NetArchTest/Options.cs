using System;

namespace NetArchTest.Rules
{
    /// <summary>
    /// User Options allows to configure how NetArchTest engine works.
    /// </summary>
    public record class Options
    {
        public static readonly Options Default = new Options();

        /// <summary>
        /// Allows to specify how strings will be compared, default: InvariantCultureIgnoreCase
        /// </summary>
        public StringComparison Comparer { get; init; } = StringComparison.InvariantCultureIgnoreCase;

        /// <summary>
        /// Determines if dependency analysis should look for dependency in string field constant, default: false
        /// </summary>
        public bool SerachForDependencyInFieldConstant { get; init; } = false;
    }
}