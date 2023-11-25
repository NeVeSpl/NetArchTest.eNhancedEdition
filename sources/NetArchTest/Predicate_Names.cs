using System;
using NetArchTest.Functions;

namespace NetArchTest.Rules
{
    public sealed partial class Predicate
    {
        /// <summary>
        /// Selects types that are exactly of given type. (inheritance is not considered)
        /// </summary>       
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList AreOfType(params Type[] type)
        {
            AddFunctionCall((context, inputTypes) => FunctionDelegates.AreOfType(context, inputTypes, type, true));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types that are not exactly of given type. (inheritance is not considered)
        /// </summary>       
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList AreNotOfType(params Type[] type)
        {
            AddFunctionCall((context, inputTypes) => FunctionDelegates.AreOfType(context, inputTypes, type, false));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types that have a specific name.
        /// </summary>
        /// <remarks>
        /// StringComparison.InvariantCultureIgnoreCase is used for comparing, can be changed through Options
        /// </remarks>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList HaveName(params string[] name)
        {            
            AddFunctionCall((context, inputTypes) => FunctionDelegates.HaveName(context, inputTypes, name, true));            
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types that do not have a particular name.
        /// </summary>
        /// <remarks>
        /// StringComparison.InvariantCultureIgnoreCase is used for comparing, can be changed through Options
        /// </remarks>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList DoNotHaveName(params string[] name)
        {
            AddFunctionCall((context, inputTypes) => FunctionDelegates.HaveName(context, inputTypes, name, false));            
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types according to a regular expression matching their name.
        /// </summary>
        /// <param name="pattern">The regular expression pattern to match against.</param>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList HaveNameMatching(string pattern)
        {
            AddFunctionCall(x => FunctionDelegates.HaveNameMatching(x, pattern, true));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types according to a regular expression that does not match their name.
        /// </summary>
        /// <param name="pattern">The regular expression pattern to match against.</param>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList DoNotHaveNameMatching(string pattern)
        {
            AddFunctionCall(x => FunctionDelegates.HaveNameMatching(x, pattern, false));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types whose names start with the specified text.
        /// </summary>
        /// <remarks>
        /// StringComparison.InvariantCultureIgnoreCase is used for comparing, can be changed through Options
        /// </remarks>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList HaveNameStartingWith(params string[] start)
        {           
            AddFunctionCall((context, inputTypes) => FunctionDelegates.HaveNameStartingWith(context, inputTypes, start, true));            
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types whose names do not start with the specified text.
        /// </summary>
        /// <remarks>
        /// StringComparison.InvariantCultureIgnoreCase is used for comparing, can be changed through Options
        /// </remarks>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList DoNotHaveNameStartingWith(params string[] start)
        {            
            AddFunctionCall((context, inputTypes) => FunctionDelegates.HaveNameStartingWith(context, inputTypes, start, false));            
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types whose names end with the specified text.
        /// </summary>
        /// <remarks>
        /// StringComparison.InvariantCultureIgnoreCase is used for comparing, can be changed through Options
        /// </remarks>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList HaveNameEndingWith(params string[] end)
        {            
            AddFunctionCall((context, inputTypes) => FunctionDelegates.HaveNameEndingWith(context, inputTypes, end, true));            
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types whose names do not end with the specified text.
        /// </summary>
        /// <remarks>
        /// StringComparison.InvariantCultureIgnoreCase is used for comparing, can be changed through Options
        /// </remarks>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList DoNotHaveNameEndingWith(params string[] end)
        {          
            AddFunctionCall((context, inputTypes) => FunctionDelegates.HaveNameEndingWith(context, inputTypes, end, false));
            return CreatePredicateList();
        }
               

        /// <summary>
        /// Selects types that reside in a particular namespace.
        /// </summary>
        /// <param name="name">The namespace to match against.</param>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList ResideInNamespace(string name)
        {
            AddFunctionCall(x => FunctionDelegates.ResideInNamespace(x, name, true));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types that do not reside in a particular namespace.
        /// </summary>
        /// <param name="name">The namespace to match against.</param>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList DoNotResideInNamespace(string name)
        {
            AddFunctionCall(x => FunctionDelegates.ResideInNamespace(x, name, false));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types whose namespaces match a regular expression.
        /// </summary>
        /// <param name="pattern">The regular expression pattern to match against.</param>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList ResideInNamespaceMatching(string pattern)
        {
            AddFunctionCall(x => FunctionDelegates.ResideInNamespaceMatching(x, pattern, true));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types whose namespaces do not match a regular expression.
        /// </summary>
        /// <param name="pattern">The regular expression pattern to match against.</param>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList DoNotResideInNamespaceMatching(string pattern)
        {
            AddFunctionCall(x => FunctionDelegates.ResideInNamespaceMatching(x, pattern, false));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types whose namespaces start with a particular name part.
        /// </summary>
        /// <param name="name">The namespace part to match against.</param>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        internal PredicateList ResideInNamespaceStartingWith(string name)
        {
            AddFunctionCall(x => FunctionDelegates.ResideInNamespaceMatching(x, $"^{name}", true));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types whose namespaces start with a particular name part.
        /// </summary>
        /// <param name="name">The namespace part to match against.</param>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        internal PredicateList DoNotResideInNamespaceStartingWith(string name)
        {
            AddFunctionCall(x => FunctionDelegates.ResideInNamespaceMatching(x, $"^{name}", false));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types whose namespaces end with a particular name part.
        /// </summary>
        /// <param name="name">The namespace part to match against.</param>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList ResideInNamespaceEndingWith(string name)
        {
            AddFunctionCall(x => FunctionDelegates.ResideInNamespaceMatching(x, $"{name}$", true));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types whose namespaces end with a particular name part.
        /// </summary>
        /// <param name="name">The namespace part to match against.</param>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList DoNotResideInNamespaceEndingWith(string name)
        {
            AddFunctionCall(x => FunctionDelegates.ResideInNamespaceMatching(x, $"{name}$", false));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types whose namespaces contain a particular name part.
        /// </summary>
        /// <param name="name">The namespace part to match against.</param>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList ResideInNamespaceContaining(string name)
        {
            AddFunctionCall(x => FunctionDelegates.ResideInNamespaceMatching(x, $"^.*{name}.*$", true));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types whose namespaces contain a particular name part.
        /// </summary>
        /// <param name="name">The namespace part to match against.</param>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList DoNotResideInNamespaceContaining(string name)
        {
            AddFunctionCall(x => FunctionDelegates.ResideInNamespaceMatching(x, $"^.*{name}.*$", false));
            return CreatePredicateList();
        }
    }
}