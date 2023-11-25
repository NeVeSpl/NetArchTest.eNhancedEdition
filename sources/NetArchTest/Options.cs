using System;

namespace NetArchTest.Rules
{
    /// <summary>
    /// User Options allows to configure how NetArchTest engine works.
    /// </summary>
    public record class Options
    {
        public static readonly Options Default = new Options();


        public StringComparison Comparer { get; init; } = StringComparison.InvariantCultureIgnoreCase;

    }
}
