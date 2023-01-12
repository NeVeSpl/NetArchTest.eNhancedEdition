using System;
using NetArchTest.Functions;
using NetArchTest.RuleEngine;

namespace NetArchTest.Rules
{
    /// <summary>
    /// A set of predicates that can be applied to a list of types.
    /// </summary>
    public sealed partial class Predicate
    {
        private readonly RuleContext rule;
        private readonly PredicateContext context;


        internal Predicate(RuleContext rule)
        {
            this.rule = rule;
            this.context = rule.PredicateContext;
        }


        private PredicateList CreatePredicateList()
        {
            return new PredicateList(rule);
        }


        /// <summary>
        /// Selects types that have a specific name.
        /// </summary>
        /// <param name="name">The name of the class to match against.</param>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList HaveName(params string[] name)
        {
            foreach (var item in name)
            {
                context.Sequence.AddFunctionCall(x => FunctionDelegates.HaveName(x, item, true));
            }
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types that do not have a particular name.
        /// </summary>
        /// <param name="name">The name of the class to match against.</param>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList DoNotHaveName(params string[] name)
        {
            foreach (var item in name)
            {
                context.Sequence.AddFunctionCall(x => FunctionDelegates.HaveName(x, item, false));
            }
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types according to a regular expression matching their name.
        /// </summary>
        /// <param name="pattern">The regular expression pattern to match against.</param>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList HaveNameMatching(string pattern)
        {
            context.Sequence.AddFunctionCall(x => FunctionDelegates.HaveNameMatching(x, pattern, true));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types according to a regular expression that does not match their name.
        /// </summary>
        /// <param name="pattern">The regular expression pattern to match against.</param>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList DoNotHaveNameMatching(string pattern)
        {
            context.Sequence.AddFunctionCall(x => FunctionDelegates.HaveNameMatching(x, pattern, false));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types whose names start with the specified text.
        /// </summary>
        /// <param name="start">The text to match against.</param>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList HaveNameStartingWith(params string[] start)
        {
            foreach (var item in start)
            {
                context.Sequence.AddFunctionCall(x => FunctionDelegates.HaveNameStartingWith(x, item, true));
            }
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types whose names start with the specified text.
        /// </summary>
        /// <param name="start">The text to match against.</param>
        /// <param name="comparer">The string comparer.</param>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList HaveNameStartingWith(string start, StringComparison comparer)
        {
	        context.Sequence.AddFunctionCall(x => FunctionDelegates.HaveNameStartingWith(x, start, true, comparer));
	        return CreatePredicateList();
        }

        /// <summary>
        /// Selects types whose names do not start with the specified text.
        /// </summary>
        /// <param name="start">The text to match against.</param>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList DoNotHaveNameStartingWith(params string[] start)
        {
            foreach (var item in start)
            {
                context.Sequence.AddFunctionCall(x => FunctionDelegates.HaveNameStartingWith(x, item, false));
            }
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types whose names do not start with the specified text.
        /// </summary>
        /// <param name="start">The text to match against.</param>
        /// <param name="comparer">The string comparer.</param>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList DoNotHaveNameStartingWith(string start, StringComparison comparer)
        {
	        context.Sequence.AddFunctionCall(x => FunctionDelegates.HaveNameStartingWith(x, start, false, comparer));
	        return CreatePredicateList();
        }

        /// <summary>
        /// Selects types whose names end with the specified text.
        /// </summary>
        /// <param name="end">The text to match against.</param>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList HaveNameEndingWith(string end)
        {
            context.Sequence.AddFunctionCall(x => FunctionDelegates.HaveNameEndingWith(x, end, true));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types whose names end with the specified text.
        /// </summary>
        /// <param name="end">The text to match against.</param>
        /// <param name="comparer">The string comparer.</param>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList HaveNameEndingWith(string end, StringComparison comparer)
        {
	        context.Sequence.AddFunctionCall(x => FunctionDelegates.HaveNameEndingWith((x), end, true, comparer));
	        return CreatePredicateList();
        }

        /// <summary>
        /// Selects types whose names do not end with the specified text.
        /// </summary>
        /// <param name="end">The text to match against.</param>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList DoNotHaveNameEndingWith(string end)
        {
            context.Sequence.AddFunctionCall(x => FunctionDelegates.HaveNameEndingWith(x, end, false));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types whose names do not end with the specified text.
        /// </summary>
        /// <param name="end">The text to match against.</param>
        /// <param name="comparer">The string comparer.</param>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList DoNotHaveNameEndingWith(string end, StringComparison comparer)
        {
            context.Sequence.AddFunctionCall(x => FunctionDelegates.HaveNameEndingWith((x), end, false, comparer));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types that are decorated with a specific custom attribute.
        /// </summary>
        /// <param name="attribute">The attribute to match against.</param>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList HaveCustomAttribute(Type attribute)
        {
            context.Sequence.AddFunctionCall(x => FunctionDelegates.HaveCustomAttribute(x, attribute, true));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types that are decorated with a specific custom attribute or derived one.
        /// </summary>
        /// <param name="attribute">The base attribute to match against.</param>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList HaveCustomAttributeOrInherit(Type attribute)
        {
            context.Sequence.AddFunctionCall(x => FunctionDelegates.HaveCustomAttributeOrInherit(x, attribute, true));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types that are not decorated with a specific custom attribute.
        /// </summary>
        /// <param name="attribute">The attribute to match against.</param>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList DoNotHaveCustomAttribute(Type attribute)
        {
            context.Sequence.AddFunctionCall(x => FunctionDelegates.HaveCustomAttribute(x, attribute, false));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types that are not decorated with a specific custom attribute or derived one.
        /// </summary>
        /// <param name="attribute">The base attribute to match against.</param>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList DoNotHaveCustomAttributeOrInherit(Type attribute)
        {
            context.Sequence.AddFunctionCall(x => FunctionDelegates.HaveCustomAttributeOrInherit(x, attribute, false));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types that inherit a particular type.
        /// </summary>
        /// <param name="type">The type to match against.</param>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList Inherit(Type type)
        {
            context.Sequence.AddFunctionCall(x => FunctionDelegates.Inherits(x, type, true));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types that do not inherit a particular type.
        /// </summary>
        /// <param name="type">The type to match against.</param>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList DoNotInherit(Type type)
        {
            context.Sequence.AddFunctionCall(x => FunctionDelegates.Inherits(x, type, false));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types that implement a particular interface.
        /// </summary>
        /// <param name="interfaceType">The interface type to match against.</param>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList ImplementInterface(Type interfaceType)
        {
            context.Sequence.AddFunctionCall(x => FunctionDelegates.ImplementsInterface(x, interfaceType, true));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types that do not implement a particular interface.
        /// </summary>
        /// <param name="interfaceType">The interface type to match against.</param>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList DoNotImplementInterface(Type interfaceType)
        {
            context.Sequence.AddFunctionCall(x => FunctionDelegates.ImplementsInterface(x, interfaceType, false));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types that are marked as abstract.
        /// </summary>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList AreAbstract()
        {
            context.Sequence.AddFunctionCall(x => FunctionDelegates.BeAbstract(x, true, true));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types that are not marked as abstract.
        /// </summary>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList AreNotAbstract()
        {
            context.Sequence.AddFunctionCall(x => FunctionDelegates.BeAbstract(x, true, false));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types that are classes.
        /// </summary>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList AreClasses()
        {
            context.Sequence.AddFunctionCall(x => FunctionDelegates.BeClass(x, true, true));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types that are not classes.
        /// </summary>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList AreNotClasses()
        {
            context.Sequence.AddFunctionCall(x => FunctionDelegates.BeClass(x, true, false));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types that have generic parameters.
        /// </summary>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList AreGeneric()
        {
            context.Sequence.AddFunctionCall(x => FunctionDelegates.BeGeneric(x, true, true));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types that do not have generic parameters.
        /// </summary>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList AreNotGeneric()
        {
            context.Sequence.AddFunctionCall(x => FunctionDelegates.BeGeneric(x, true, false));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types that are interfaces.
        /// </summary>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList AreInterfaces()
        {
            context.Sequence.AddFunctionCall(x => FunctionDelegates.BeInterface(x, true, true));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types that are not interfaces.
        /// </summary>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList AreNotInterfaces()
        {
            context.Sequence.AddFunctionCall(x => FunctionDelegates.BeInterface(x, true, false));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types that are static.
        /// </summary>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList AreStatic()
        {
	        context.Sequence.AddFunctionCall(x => FunctionDelegates.BeStatic(x, true, true));
	        return CreatePredicateList();
        }

        /// <summary>
        /// Selects types that are not static.
        /// </summary>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList AreNotStatic()
        {
	        context.Sequence.AddFunctionCall(x => FunctionDelegates.BeStatic(x, true, false));
	        return CreatePredicateList();
        }

        /// <summary>
        /// Selects types that are nested.
        /// </summary>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList AreNested()
        {
            context.Sequence.AddFunctionCall(x => FunctionDelegates.BeNested(x, true, true));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types that are nested and declared as public.
        /// </summary>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList AreNestedPublic()
        {
            context.Sequence.AddFunctionCall(x => FunctionDelegates.BeNestedPublic(x, true, true));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types that are nested and declared as private.
        /// </summary>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList AreNestedPrivate()
        {
            context.Sequence.AddFunctionCall(x => FunctionDelegates.BeNestedPrivate(x, true, true));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types that are not nested.
        /// </summary>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList AreNotNested()
        {
            context.Sequence.AddFunctionCall(x => FunctionDelegates.BeNested(x, true, false));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types that are not nested and declared as public.
        /// </summary>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        /// <remarks>NB: This method will return non-nested types and nested types that are declared as private.</remarks>
        public PredicateList AreNotNestedPublic()
        {
            context.Sequence.AddFunctionCall(x => FunctionDelegates.BeNestedPublic(x, true, false));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types that are not nested and declared as private.
        /// </summary>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        /// <remarks>NB: This method will return non-nested types and nested types that are declared as public.</remarks>
        public PredicateList AreNotNestedPrivate()
        {
            context.Sequence.AddFunctionCall(x => FunctionDelegates.BeNestedPrivate(x, true, false));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types that have public scope.
        /// </summary>
        /// <remarks>
        /// This method will only act on types that are visible to the function. Use InternalsVisibleTo if testing from a separate assembly.
        /// </remarks>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList ArePublic()
        {
            context.Sequence.AddFunctionCall(x => FunctionDelegates.BePublic(x, true, true));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types that do not have public scope.
        /// </summary>
        /// <remarks>
        /// This method will only act on types that are visible to the function. Use InternalsVisibleTo if testing from a separate assembly.
        /// </remarks>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList AreNotPublic()
        {
            context.Sequence.AddFunctionCall(x => FunctionDelegates.BePublic(x, true, false));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types according that are marked as sealed.
        /// </summary>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList AreSealed()
        {
            context.Sequence.AddFunctionCall(x => FunctionDelegates.BeSealed(x, true, true));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types according that are not marked as sealed.
        /// </summary>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList AreNotSealed()
        {
            context.Sequence.AddFunctionCall(x => FunctionDelegates.BeSealed(x, true, false));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types that are immutable.
        /// </summary>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList AreImmutable()
        {
            context.Sequence.AddFunctionCall(x => FunctionDelegates.BeImmutable(x, true, true));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types that are mutable.
        /// </summary>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList AreMutable()
        {
            context.Sequence.AddFunctionCall(x => FunctionDelegates.BeImmutable(x, true, false));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types that have only nullable members.
        /// </summary>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList OnlyHaveNullableMembers()
        {
            context.Sequence.AddFunctionCall(x => FunctionDelegates.HasNullableMembers(x, true, true));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types that have some non-nullable members.
        /// </summary>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList HaveSomeNonNullableMembers()
        {
            context.Sequence.AddFunctionCall(x => FunctionDelegates.HasNullableMembers(x, true, false));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types that reside in a particular namespace.
        /// </summary>
        /// <param name="name">The namespace to match against.</param>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList ResideInNamespace(string name)
        {
            context.Sequence.AddFunctionCall(x => FunctionDelegates.ResideInNamespace(x, name, true));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types that do not reside in a particular namespace.
        /// </summary>
        /// <param name="name">The namespace to match against.</param>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList DoNotResideInNamespace(string name)
        {
            context.Sequence.AddFunctionCall(x => FunctionDelegates.ResideInNamespace(x, name, false));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types whose namespaces match a regular expression.
        /// </summary>
        /// <param name="pattern">The regular expression pattern to match against.</param>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList ResideInNamespaceMatching(string pattern)
        {
            context.Sequence.AddFunctionCall(x => FunctionDelegates.ResideInNamespaceMatching(x, pattern, true));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types whose namespaces start with a particular name part.
        /// </summary>
        /// <param name="name">The namespace part to match against.</param>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList ResideInNamespaceStartingWith(string name)
        {
            context.Sequence.AddFunctionCall(x => FunctionDelegates.ResideInNamespaceMatching(x, $"^{name}", true));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types whose namespaces end with a particular name part.
        /// </summary>
        /// <param name="name">The namespace part to match against.</param>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList ResideInNamespaceEndingWith(string name)
        {
            context.Sequence.AddFunctionCall(x => FunctionDelegates.ResideInNamespaceMatching(x, $"{name}$", true));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types whose namespaces contain a particular name part.
        /// </summary>
        /// <param name="name">The namespace part to match against.</param>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList ResideInNamespaceContaining(string name)
        {
            context.Sequence.AddFunctionCall(x => FunctionDelegates.ResideInNamespaceMatching(x, $"^.*{name}.*$", true));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types whose namespaces do not match a regular expression.
        /// </summary>
        /// <param name="pattern">The regular expression pattern to match against.</param>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList DoNotResideInNamespaceMatching(string pattern)
        {
            context.Sequence.AddFunctionCall(x => FunctionDelegates.ResideInNamespaceMatching(x, pattern, false));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types whose namespaces start with a particular name part.
        /// </summary>
        /// <param name="name">The namespace part to match against.</param>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList DoNotResideInNamespaceStartingWith(string name)
        {
            context.Sequence.AddFunctionCall(x => FunctionDelegates.ResideInNamespaceMatching(x, $"^{name}", false));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types whose namespaces end with a particular name part.
        /// </summary>
        /// <param name="name">The namespace part to match against.</param>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList DoNotResideInNamespaceEndingWith(string name)
        {
            context.Sequence.AddFunctionCall(x => FunctionDelegates.ResideInNamespaceMatching(x, $"{name}$", false));
            return CreatePredicateList();
        }

        /// <summary>
        /// Selects types whose namespaces contain a particular name part.
        /// </summary>
        /// <param name="name">The namespace part to match against.</param>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList DoNotResideInNamespaceContaining(string name)
        {
            context.Sequence.AddFunctionCall(x => FunctionDelegates.ResideInNamespaceMatching(x, $"^.*{name}.*$", false));
            return CreatePredicateList();
        }          

        /// <summary>
        /// Selects types that meet a custom rule.
        /// </summary>
        /// <param name="rule">An instance of the custom rule.</param>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public PredicateList MeetCustomRule(ICustomRule rule)
        {
            context.Sequence.AddFunctionCall(x => FunctionDelegates.MeetCustomRule(x, rule, true));
            return CreatePredicateList();
        }
    }
}