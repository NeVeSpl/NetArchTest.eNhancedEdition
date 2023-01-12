using System;
using NetArchTest.Functions;
using NetArchTest.RuleEngine;

namespace NetArchTest.Rules
{
    /// <summary>
    /// A set of conditions that can be applied to a list of types.
    /// </summary>
    public sealed partial class Condition
    {
        private readonly RuleContext rule;
        private readonly ConditionContext context;


        internal Condition(RuleContext rule)
        {
            this.rule = rule;
            this.context = rule.ConditionContext;
        }
        internal Condition(RuleContext rule, bool should) : this(rule)
        {           
            rule.ConditionContext.Should= should;
        }
       

        private ConditionList CreateConditionList()
        {
            return new ConditionList(rule);
        }


        /// <summary>
        /// Selects types that have a specific name.
        /// </summary>
        /// <param name="name">The name of the class to match against.</param>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList HaveName(string name)
        {
            context.Sequence.AddFunctionCall(x => FunctionDelegates.HaveName(x, name, true));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types that do not have a particular name.
        /// </summary>
        /// <param name="name">The name of the class to match against.</param>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList NotHaveName(string name)
        {
            context.Sequence.AddFunctionCall(x => FunctionDelegates.HaveName(x, name, false));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types according to a regular expression matching their name.
        /// </summary>
        /// <param name="pattern">The regular expression pattern to match against.</param>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList HaveNameMatching(string pattern)
        {
            context.Sequence.AddFunctionCall(x => FunctionDelegates.HaveNameMatching(x, pattern, true));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types according to a regular expression that does not match their name.
        /// </summary>
        /// <param name="pattern">The regular expression pattern to match against.</param>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList NotHaveNameMatching(string pattern)
        {
            context.Sequence.AddFunctionCall(x => FunctionDelegates.HaveNameMatching(x, pattern, false));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types whose names start with the specified text.
        /// </summary>
        /// <param name="start">The text to match against.</param>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList HaveNameStartingWith(string start)
        {
            context.Sequence.AddFunctionCall(x => FunctionDelegates.HaveNameStartingWith(x, start, true));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types whose names start with the specified text.
        /// </summary>
        /// <param name="start">The text to match against.</param>
        /// <param name="comparer">The string comparer.</param>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList HaveNameStartingWith(string start, StringComparison comparer)
        {
            context.Sequence.AddFunctionCall(x => FunctionDelegates.HaveNameStartingWith(x, start, true, comparer));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types whose names do not start with the specified text.
        /// </summary>
        /// <param name="start">The text to match against.</param>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList NotHaveNameStartingWith(string start)
        {
            context.Sequence.AddFunctionCall(x => FunctionDelegates.HaveNameStartingWith(x, start, false));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types whose names do not start with the specified text.
        /// </summary>
        /// <param name="start">The text to match against.</param>
        /// <param name="comparer">The string comparer.</param>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList NotHaveNameStartingWith(string start, StringComparison comparer)
        {
            context.Sequence.AddFunctionCall(x => FunctionDelegates.HaveNameStartingWith(x, start, false, comparer));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types whose names do not end with the specified text.
        /// </summary>
        /// <param name="end">The text to match against.</param>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList HaveNameEndingWith(string end)
        {
            context.Sequence.AddFunctionCall(x => FunctionDelegates.HaveNameEndingWith(x, end, true));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types whose names do not end with the specified text.
        /// </summary>
        /// <param name="end">The text to match against.</param>
        /// <param name="comparer">The string comparer.</param>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList HaveNameEndingWith(string end, StringComparison comparer)
        {
            context.Sequence.AddFunctionCall(x => FunctionDelegates.HaveNameEndingWith(x, end, true, comparer));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types whose names do not end with the specified text.
        /// </summary>
        /// <param name="end">The text to match against.</param>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList NotHaveNameEndingWith(string end)
        {
            context.Sequence.AddFunctionCall(x => FunctionDelegates.HaveNameEndingWith(x, end, false));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types whose names do not end with the specified text.
        /// </summary>
        /// <param name="end">The text to match against.</param>
        /// <param name="comparer">The string comparer.</param>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList NotHaveNameEndingWith(string end, StringComparison comparer)
        {
            context.Sequence.AddFunctionCall(x => FunctionDelegates.HaveNameEndingWith(x, end, false, comparer));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types are decorated with a specific custom attribut.
        /// </summary>
        /// <param name="attribute">The attribute to match against.</param>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList HaveCustomAttribute(Type attribute)
        {
            context.Sequence.AddFunctionCall(x => FunctionDelegates.HaveCustomAttribute(x, attribute, true));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types that are not decorated with a specific custom attribute.
        /// </summary>
        /// <param name="attribute">The attribute to match against.</param>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList NotHaveCustomAttribute(Type attribute)
        {
            context.Sequence.AddFunctionCall(x => FunctionDelegates.HaveCustomAttribute(x, attribute, false));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types that are decorated with a specific custom attribute or derived one.
        /// </summary>
        /// <param name="attribute">The base attribute to match against.</param>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList HaveCustomAttributeOrInherit(Type attribute)
        {
            context.Sequence.AddFunctionCall(x => FunctionDelegates.HaveCustomAttributeOrInherit(x, attribute, true));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types are not decorated with a specific custom attribute or derived one.
        /// </summary>
        /// <param name="attribute">The base attribute to match against.</param>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList NotHaveCustomAttributeOrInherit(Type attribute)
        {
            context.Sequence.AddFunctionCall(x => FunctionDelegates.HaveCustomAttributeOrInherit(x, attribute, false));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types that inherit a particular type.
        /// </summary>
        /// <param name="type">The type to match against.</param>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList Inherit(Type type)
        {
            context.Sequence.AddFunctionCall(x => FunctionDelegates.Inherits(x, type, true));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types that do not inherit a particular type.
        /// </summary>
        /// <param name="type">The type to match against.</param>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList NotInherit(Type type)
        {
            context.Sequence.AddFunctionCall(x => FunctionDelegates.Inherits(x, type, false));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types that implement a particular interface.
        /// </summary>
        /// <param name="interfaceType">The interface type to match against.</param>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList ImplementInterface(Type interfaceType)
        {
            context.Sequence.AddFunctionCall(x => FunctionDelegates.ImplementsInterface(x, interfaceType, true));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types that do not implement a particular interface.
        /// </summary>
        /// <param name="interfaceType">The interface type to match against.</param>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList NotImplementInterface(Type interfaceType)
        {
            context.Sequence.AddFunctionCall(x => FunctionDelegates.ImplementsInterface(x, interfaceType, false));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types that are marked as abstract.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList BeAbstract()
        {
            context.Sequence.AddFunctionCall(x => FunctionDelegates.BeAbstract(x, true, true));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types that are not marked as abstract.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList NotBeAbstract()
        {
            context.Sequence.AddFunctionCall(x => FunctionDelegates.BeAbstract(x, true, false));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types that are classes.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList BeClasses()
        {
            context.Sequence.AddFunctionCall(x => FunctionDelegates.BeClass(x, true, true));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types that are not classes.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList NotBeClasses()
        {
            context.Sequence.AddFunctionCall(x => FunctionDelegates.BeClass(x, true, false));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types that have generic parameters.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList BeGeneric()
        {
            context.Sequence.AddFunctionCall(x => FunctionDelegates.BeGeneric(x, true, true));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types that do not have generic parameters.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList NotBeGeneric()
        {
            context.Sequence.AddFunctionCall(x => FunctionDelegates.BeGeneric(x, true, false));
            return CreateConditionList();
        }


        /// <summary>
        /// Selects types that are interfaces.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList BeInterfaces()
        {
            context.Sequence.AddFunctionCall(x => FunctionDelegates.BeInterface(x, true, true));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types that are not interfaces.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList NotBeInterfaces()
        {
            context.Sequence.AddFunctionCall(x => FunctionDelegates.BeInterface(x, true, false));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types that are static.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList BeStatic()
        {
	        context.Sequence.AddFunctionCall(x => FunctionDelegates.BeStatic(x, true, true));
	        return CreateConditionList();
        }

        /// <summary>
        /// Selects types that are not static.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList NotBeStatic()
        {
	        context.Sequence.AddFunctionCall(x => FunctionDelegates.BeStatic(x, true, false));
	        return CreateConditionList();
        }

        /// <summary>
        /// Selects types that are nested.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList BeNested()
        {
            context.Sequence.AddFunctionCall(x => FunctionDelegates.BeNested(x, true, true));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types that are nested and public.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList BeNestedPublic()
        {
            context.Sequence.AddFunctionCall(x => FunctionDelegates.BeNestedPublic(x, true, true));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types that are nested and private.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList BeNestedPrivate()
        {
            context.Sequence.AddFunctionCall(x => FunctionDelegates.BeNestedPrivate(x, true, true));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types that are not nested.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList NotBeNested()
        {
            context.Sequence.AddFunctionCall(x => FunctionDelegates.BeNested(x, true, false));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types that are not nested and public.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList NotBeNestedPublic()
        {
            context.Sequence.AddFunctionCall(x => FunctionDelegates.BeNestedPublic(x, true, false));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types that are not nested and private.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList NotBeNestedPrivate()
        {
            context.Sequence.AddFunctionCall(x => FunctionDelegates.BeNestedPrivate(x, true, false));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types that are have public scope.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList BePublic()
        {
            context.Sequence.AddFunctionCall(x => FunctionDelegates.BePublic(x, true, true));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types that do not have public scope.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList NotBePublic()
        {
            context.Sequence.AddFunctionCall(x => FunctionDelegates.BePublic(x, true, false));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types according that are marked as sealed.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList BeSealed()
        {
            context.Sequence.AddFunctionCall(x => FunctionDelegates.BeSealed(x, true, true));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types according that are not marked as sealed.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList NotBeSealed()
        {
            context.Sequence.AddFunctionCall(x => FunctionDelegates.BeSealed(x, true, false));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types that are immutable.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList BeImmutable()
        {
            context.Sequence.AddFunctionCall(x => FunctionDelegates.BeImmutable(x, true, true));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types that are mutable.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList BeMutable()
        {
            context.Sequence.AddFunctionCall(x => FunctionDelegates.BeImmutable(x, true, false));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types according to whether they have nullable members.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList OnlyHaveNullableMembers()
        {
            context.Sequence.AddFunctionCall(x => FunctionDelegates.HasNullableMembers(x, true, true));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types according to whether they have nullable members.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList HaveSomeNonNullableMembers()
        {
            context.Sequence.AddFunctionCall(x => FunctionDelegates.HasNullableMembers(x, true, false));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types that reside in a particular namespace.
        /// </summary>
        /// <param name="name">The namespace to match against.</param>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList ResideInNamespace(string name)
        {
            context.Sequence.AddFunctionCall(x => FunctionDelegates.ResideInNamespace(x, name, true));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types that do not reside in a particular namespace.
        /// </summary>
        /// <param name="name">The namespace to match against.</param>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList NotResideInNamespace(string name)
        {
            context.Sequence.AddFunctionCall(x => FunctionDelegates.ResideInNamespace(x, name, false));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types that reside in a namespace matching a regular expression.
        /// </summary>
        /// <param name="pattern">The regular expression pattern to match against.</param>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList ResideInNamespaceMatching(string pattern)
        {
            context.Sequence.AddFunctionCall(x => FunctionDelegates.ResideInNamespaceMatching(x, pattern, true));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types that do not reside in a namespace matching a regular expression.
        /// </summary>
        /// <param name="pattern">The regular expression pattern to match against.</param>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList NotResideInNamespaceMatching(string pattern)
        {
            context.Sequence.AddFunctionCall(x => FunctionDelegates.ResideInNamespaceMatching(x, pattern, false));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types whose namespaces start with a particular name part.
        /// </summary>
        /// <param name="name">The namespace part to match against.</param>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public ConditionList ResideInNamespaceStartingWith(string name)
        {
            context.Sequence.AddFunctionCall(x => FunctionDelegates.ResideInNamespaceMatching(x, $"^{name}", true));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types whose namespaces start with a particular name part.
        /// </summary>
        /// <param name="name">The namespace part to match against.</param>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public ConditionList NotResideInNamespaceStartingWith(string name)
        {
            context.Sequence.AddFunctionCall(x => FunctionDelegates.ResideInNamespaceMatching(x, $"^{name}", false));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types whose namespaces end with a particular name part.
        /// </summary>
        /// <param name="name">The namespace part to match against.</param>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public ConditionList ResideInNamespaceEndingWith(string name)
        {
            context.Sequence.AddFunctionCall(x => FunctionDelegates.ResideInNamespaceMatching(x, $"{name}$", true));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types whose namespaces end with a particular name part.
        /// </summary>
        /// <param name="name">The namespace part to match against.</param>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public ConditionList NotResideInNamespaceEndingWith(string name)
        {
            context.Sequence.AddFunctionCall(x => FunctionDelegates.ResideInNamespaceMatching(x, $"{name}$", false));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types whose namespaces contain a particular name part.
        /// </summary>
        /// <param name="name">The namespace part to match against.</param>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public ConditionList ResideInNamespaceContaining(string name)
        {
            context.Sequence.AddFunctionCall(x => FunctionDelegates.ResideInNamespaceMatching(x, $"^.*{name}.*$", true));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types whose namespaces contain a particular name part.
        /// </summary>
        /// <param name="name">The namespace part to match against.</param>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public ConditionList NotResideInNamespaceContaining(string name)
        {
            context.Sequence.AddFunctionCall(x => FunctionDelegates.ResideInNamespaceMatching(x, $"^.*{name}.*$", false));
            return CreateConditionList();
        }               

        /// <summary>
        /// Selects types that meet a custom rule.
        /// </summary>
        /// <param name="rule">An instance of the custom rule.</param>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList MeetCustomRule(ICustomRule rule)
        {
            context.Sequence.AddFunctionCall(x => FunctionDelegates.MeetCustomRule(x, rule, true));
            return CreateConditionList();
        }
    }
}