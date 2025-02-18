using System;
using NetArchTest.Functions;

namespace NetArchTest.Rules
{
    public sealed partial class Condition
    {
        /// <summary>
        /// Selects types that are exactly of given type. (inheritance is not considered)
        /// </summary>       
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList BeOfType(params Type[] type)
        {
            AddFunctionCall((context, inputTypes) => FunctionDelegates.AreOfType(context, inputTypes, type, true));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types that are not exactly of given type. (inheritance is not considered)
        /// </summary>       
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList NotBeOfType(params Type[] type)
        {
            AddFunctionCall((context, inputTypes) => FunctionDelegates.AreOfType(context, inputTypes, type, false));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types that have a specific name.
        /// </summary>
        /// <remarks>
        /// StringComparison.InvariantCultureIgnoreCase is used for comparing
        /// </remarks>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList HaveName(string name)
        {
            AddFunctionCall((context, inputTypes) => FunctionDelegates.HaveName(context, inputTypes, new[] { name }, true));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types that do not have a particular name.
        /// </summary>
        /// <remarks>
        /// StringComparison.InvariantCultureIgnoreCase is used for comparing
        /// </remarks>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList NotHaveName(string name)
        {
            AddFunctionCall((context, inputTypes) => FunctionDelegates.HaveName(context, inputTypes, new[] { name }, false));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types according to a regular expression matching their name.
        /// </summary>
        /// <param name="pattern">The regular expression pattern to match against.</param>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList HaveNameMatching(string pattern)
        {
            AddFunctionCall(x => FunctionDelegates.HaveNameMatching(x, pattern, true));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types according to a regular expression that does not match their name.
        /// </summary>
        /// <param name="pattern">The regular expression pattern to match against.</param>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList NotHaveNameMatching(string pattern)
        {
            AddFunctionCall(x => FunctionDelegates.HaveNameMatching(x, pattern, false));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types whose names start with the specified text.
        /// </summary>
        /// <remarks>
        /// StringComparison.InvariantCultureIgnoreCase is used for comparing
        /// </remarks>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList HaveNameStartingWith(string start)
        {
            AddFunctionCall((context, inputTypes) => FunctionDelegates.HaveNameStartingWith(context, inputTypes, new[] { start }, true));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types whose names do not start with the specified text.
        /// </summary>
        /// <remarks>
        /// StringComparison.InvariantCultureIgnoreCase is used for comparing
        /// </remarks>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList NotHaveNameStartingWith(string start)
        {
            AddFunctionCall((context, inputTypes) => FunctionDelegates.HaveNameStartingWith(context, inputTypes, new[] { start }, false));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types whose names do not end with the specified text.
        /// </summary>
        /// <remarks>
        /// StringComparison.InvariantCultureIgnoreCase is used for comparing
        /// </remarks>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList HaveNameEndingWith(string end)
        {
            AddFunctionCall((context, inputTypes) => FunctionDelegates.HaveNameEndingWith(context, inputTypes, new[] { end }, true));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types whose names do not end with the specified text.
        /// </summary>
        /// <remarks>
        /// StringComparison.InvariantCultureIgnoreCase is used for comparing
        /// </remarks>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList NotHaveNameEndingWith(string end)
        {
            AddFunctionCall((context, inputTypes) => FunctionDelegates.HaveNameEndingWith(context, inputTypes, new[] { end }, false));
            return CreateConditionList();
        }
               

        /// <summary>
        /// Selects types that reside in a particular namespace.
        /// </summary>
        /// <param name="name">The namespace to match against.</param>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList ResideInNamespace(string name)
        {
            AddFunctionCall((context, x) => FunctionDelegates.ResideInNamespace(context, x, name, true));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types that do not reside in a particular namespace.
        /// </summary>
        /// <param name="name">The namespace to match against.</param>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList NotResideInNamespace(string name)
        {
            AddFunctionCall((context, x) => FunctionDelegates.ResideInNamespace(context, x, name, false));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types that reside in a namespace matching a regular expression.
        /// </summary>
        /// <param name="pattern">The regular expression pattern to match against.</param>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList ResideInNamespaceMatching(string pattern)
        {
            AddFunctionCall(x => FunctionDelegates.ResideInNamespaceMatching(x, pattern, true));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types that do not reside in a namespace matching a regular expression.
        /// </summary>
        /// <param name="pattern">The regular expression pattern to match against.</param>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList NotResideInNamespaceMatching(string pattern)
        {
            AddFunctionCall(x => FunctionDelegates.ResideInNamespaceMatching(x, pattern, false));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types whose namespaces start with a particular name part.
        /// </summary>
        /// <param name="name">The namespace part to match against.</param>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        internal ConditionList ResideInNamespaceStartingWith(string name)
        {
            AddFunctionCall(x => FunctionDelegates.ResideInNamespaceMatching(x, $"^{name}", true));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types whose namespaces start with a particular name part.
        /// </summary>
        /// <param name="name">The namespace part to match against.</param>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        internal ConditionList NotResideInNamespaceStartingWith(string name)
        {
            AddFunctionCall(x => FunctionDelegates.ResideInNamespaceMatching(x, $"^{name}", false));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types whose namespaces end with a particular name part.
        /// </summary>
        /// <param name="name">The namespace part to match against.</param>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public ConditionList ResideInNamespaceEndingWith(string name)
        {
            AddFunctionCall(x => FunctionDelegates.ResideInNamespaceMatching(x, $"{name}$", true));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types whose namespaces end with a particular name part.
        /// </summary>
        /// <param name="name">The namespace part to match against.</param>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public ConditionList NotResideInNamespaceEndingWith(string name)
        {
            AddFunctionCall(x => FunctionDelegates.ResideInNamespaceMatching(x, $"{name}$", false));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types whose namespaces contain a particular name part.
        /// </summary>
        /// <param name="name">The namespace part to match against.</param>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public ConditionList ResideInNamespaceContaining(string name)
        {
            AddFunctionCall(x => FunctionDelegates.ResideInNamespaceMatching(x, $"^.*{name}.*$", true));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types whose namespaces contain a particular name part.
        /// </summary>
        /// <param name="name">The namespace part to match against.</param>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public ConditionList NotResideInNamespaceContaining(string name)
        {
            AddFunctionCall(x => FunctionDelegates.ResideInNamespaceMatching(x, $"^.*{name}.*$", false));
            return CreateConditionList();
        }
    }
}