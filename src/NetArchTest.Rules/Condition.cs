using System;
using NetArchTest.Assemblies;
using System.Collections.Generic;
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
        private void AddFunctionCall(Func<IEnumerable<TypeSpec>, IEnumerable<TypeSpec>> func)
        {
            context.Sequence.AddFunctionCall(func);
        }


        /// <summary>
        /// Selects types that have a specific name.
        /// </summary>
        /// <param name="name">The name of the class to match against.</param>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList HaveName(string name)
        {
            AddFunctionCall(x => FunctionDelegates.HaveName(x, name, true));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types that do not have a particular name.
        /// </summary>
        /// <param name="name">The name of the class to match against.</param>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList NotHaveName(string name)
        {
            AddFunctionCall(x => FunctionDelegates.HaveName(x, name, false));
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
        /// <param name="start">The text to match against.</param>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList HaveNameStartingWith(string start)
        {
            AddFunctionCall(x => FunctionDelegates.HaveNameStartingWith(x, start, true));
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
            AddFunctionCall(x => FunctionDelegates.HaveNameStartingWith(x, start, true, comparer));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types whose names do not start with the specified text.
        /// </summary>
        /// <param name="start">The text to match against.</param>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList NotHaveNameStartingWith(string start)
        {
            AddFunctionCall(x => FunctionDelegates.HaveNameStartingWith(x, start, false));
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
            AddFunctionCall(x => FunctionDelegates.HaveNameStartingWith(x, start, false, comparer));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types whose names do not end with the specified text.
        /// </summary>
        /// <param name="end">The text to match against.</param>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList HaveNameEndingWith(string end)
        {
            AddFunctionCall(x => FunctionDelegates.HaveNameEndingWith(x, end, true));
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
            AddFunctionCall(x => FunctionDelegates.HaveNameEndingWith(x, end, true, comparer));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types whose names do not end with the specified text.
        /// </summary>
        /// <param name="end">The text to match against.</param>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList NotHaveNameEndingWith(string end)
        {
            AddFunctionCall(x => FunctionDelegates.HaveNameEndingWith(x, end, false));
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
            AddFunctionCall(x => FunctionDelegates.HaveNameEndingWith(x, end, false, comparer));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types are decorated with a specific custom attribut.
        /// </summary>
        /// <param name="attribute">The attribute to match against.</param>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList HaveCustomAttribute(Type attribute)
        {
            AddFunctionCall(x => FunctionDelegates.HaveCustomAttribute(x, attribute, true));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types that are not decorated with a specific custom attribute.
        /// </summary>
        /// <param name="attribute">The attribute to match against.</param>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList NotHaveCustomAttribute(Type attribute)
        {
            AddFunctionCall(x => FunctionDelegates.HaveCustomAttribute(x, attribute, false));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types that are decorated with a specific custom attribute or derived one.
        /// </summary>
        /// <param name="attribute">The base attribute to match against.</param>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList HaveCustomAttributeOrInherit(Type attribute)
        {
            AddFunctionCall(x => FunctionDelegates.HaveCustomAttributeOrInherit(x, attribute, true));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types are not decorated with a specific custom attribute or derived one.
        /// </summary>
        /// <param name="attribute">The base attribute to match against.</param>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList NotHaveCustomAttributeOrInherit(Type attribute)
        {
            AddFunctionCall(x => FunctionDelegates.HaveCustomAttributeOrInherit(x, attribute, false));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types that inherit a particular type.
        /// </summary>
        /// <param name="type">The type to match against.</param>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList Inherit(Type type)
        {
            AddFunctionCall(x => FunctionDelegates.Inherits(x, type, true));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types that do not inherit a particular type.
        /// </summary>
        /// <param name="type">The type to match against.</param>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList NotInherit(Type type)
        {
            AddFunctionCall(x => FunctionDelegates.Inherits(x, type, false));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types that implement a particular interface.
        /// </summary>
        /// <param name="interfaceType">The interface type to match against.</param>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList ImplementInterface(Type interfaceType)
        {
            AddFunctionCall(x => FunctionDelegates.ImplementsInterface(x, interfaceType, true));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types that do not implement a particular interface.
        /// </summary>
        /// <param name="interfaceType">The interface type to match against.</param>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList NotImplementInterface(Type interfaceType)
        {
            AddFunctionCall(x => FunctionDelegates.ImplementsInterface(x, interfaceType, false));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types that are marked as abstract.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList BeAbstract()
        {
            AddFunctionCall(x => FunctionDelegates.BeAbstract(x, true));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types that are not marked as abstract.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList NotBeAbstract()
        {
            AddFunctionCall(x => FunctionDelegates.BeAbstract(x, false));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types that are classes.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList BeClasses()
        {
            AddFunctionCall(x => FunctionDelegates.BeClass(x, true));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types that are not classes.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList NotBeClasses()
        {
            AddFunctionCall(x => FunctionDelegates.BeClass(x, false));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types that have generic parameters.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList BeGeneric()
        {
            AddFunctionCall(x => FunctionDelegates.BeGeneric(x, true));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types that do not have generic parameters.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList NotBeGeneric()
        {
            AddFunctionCall(x => FunctionDelegates.BeGeneric(x, false));
            return CreateConditionList();
        }


        /// <summary>
        /// Selects types that are interfaces.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList BeInterfaces()
        {
            AddFunctionCall(x => FunctionDelegates.BeInterface(x, true));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types that are not interfaces.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList NotBeInterfaces()
        {
            AddFunctionCall(x => FunctionDelegates.BeInterface(x, false));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types that are static.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList BeStatic()
        {
	        AddFunctionCall(x => FunctionDelegates.BeStatic(x, true));
	        return CreateConditionList();
        }

        /// <summary>
        /// Selects types that are not static.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList NotBeStatic()
        {
	        AddFunctionCall(x => FunctionDelegates.BeStatic(x, false));
	        return CreateConditionList();
        }

        /// <summary>
        /// Selects types that are nested.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList BeNested()
        {
            AddFunctionCall(x => FunctionDelegates.BeNested(x, true));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types that are nested and public.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList BeNestedPublic()
        {
            AddFunctionCall(x => FunctionDelegates.BeNestedPublic(x, true));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types that are nested and private.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList BeNestedPrivate()
        {
            AddFunctionCall(x => FunctionDelegates.BeNestedPrivate(x, true));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types that are not nested.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList NotBeNested()
        {
            AddFunctionCall(x => FunctionDelegates.BeNested(x, false));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types that are not nested and public.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList NotBeNestedPublic()
        {
            AddFunctionCall(x => FunctionDelegates.BeNestedPublic(x, false));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types that are not nested and private.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList NotBeNestedPrivate()
        {
            AddFunctionCall(x => FunctionDelegates.BeNestedPrivate(x, false));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types that are have public scope.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList BePublic()
        {
            AddFunctionCall(x => FunctionDelegates.BePublic(x, true));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types that do not have public scope.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList NotBePublic()
        {
            AddFunctionCall(x => FunctionDelegates.BePublic(x, false));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types according that are marked as sealed.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList BeSealed()
        {
            AddFunctionCall(x => FunctionDelegates.BeSealed(x, true));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types according that are not marked as sealed.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList NotBeSealed()
        {
            AddFunctionCall(x => FunctionDelegates.BeSealed(x, false));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types that are immutable.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList BeImmutable()
        {
            AddFunctionCall(x => FunctionDelegates.BeImmutable(x, true));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types that are mutable.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList BeMutable()
        {
            AddFunctionCall(x => FunctionDelegates.BeImmutable(x, false));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types according to whether they have nullable members.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList OnlyHaveNullableMembers()
        {
            AddFunctionCall(x => FunctionDelegates.HasNullableMembers(x, true));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types according to whether they have nullable members.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList HaveSomeNonNullableMembers()
        {
            AddFunctionCall(x => FunctionDelegates.HasNullableMembers(x, false));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types that reside in a particular namespace.
        /// </summary>
        /// <param name="name">The namespace to match against.</param>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList ResideInNamespace(string name)
        {
            AddFunctionCall(x => FunctionDelegates.ResideInNamespace(x, name, true));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types that do not reside in a particular namespace.
        /// </summary>
        /// <param name="name">The namespace to match against.</param>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList NotResideInNamespace(string name)
        {
            AddFunctionCall(x => FunctionDelegates.ResideInNamespace(x, name, false));
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
        public ConditionList ResideInNamespaceStartingWith(string name)
        {
            AddFunctionCall(x => FunctionDelegates.ResideInNamespaceMatching(x, $"^{name}", true));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types whose namespaces start with a particular name part.
        /// </summary>
        /// <param name="name">The namespace part to match against.</param>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public ConditionList NotResideInNamespaceStartingWith(string name)
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

        /// <summary>
        /// Selects types that meet a custom rule.
        /// </summary>
        /// <param name="rule">An instance of the custom rule.</param>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList MeetCustomRule(ICustomRule rule)
        {
            AddFunctionCall(x => FunctionDelegates.MeetCustomRule(x, rule, true));
            return CreateConditionList();
        }
    }
}