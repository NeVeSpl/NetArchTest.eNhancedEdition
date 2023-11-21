using System;

namespace NetArchTest.Rules
{
    public record class Options
    {
        public static readonly Options Default = new Options();


        public StringComparison Comparer { get; init; } = StringComparison.InvariantCultureIgnoreCase;


    }
}
