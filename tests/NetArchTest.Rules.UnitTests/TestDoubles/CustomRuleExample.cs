﻿namespace NetArchTest.UnitTests.TestDoubles
{
    using Mono.Cecil;
    using NetArchTest.Rules;
    using System;

    /// <summary>
    /// A simple custom rule example that always passes.
    /// </summary>
    public class CustomRuleTestDouble : ICustomRule
    {
        /// <summary> Used by tests to indicate whether the test method has been called. </summary>
        public bool TestMethodCalled = false;

        /// <summary> The delegate that is used for the rule - this allows the test to define the custom rule. </summary>
        private Func<TypeDefinition, bool> _test;

        public CustomRuleTestDouble(Func<TypeDefinition, bool> test)
        {
            _test = test;
        }

        public bool MeetsRule(TypeDefinition type)
        {
            TestMethodCalled = true;
            return _test(type);
        }
    }
}
