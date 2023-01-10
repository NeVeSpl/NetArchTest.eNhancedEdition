using System;
using System.Collections.Generic;
using NetArchTest.Assemblies;
using NetArchTest.Functions;


namespace NetArchTest.Rules
{
    /// <summary>
    /// A set of conditions that can be applied to a list of types.
    /// </summary>
    public sealed partial class Condition
    {        
        private readonly IEnumerable<TypeSpec> _types;     
        private readonly FunctionSequence _sequence;


        /// <summary> Determines the polarity of the selection, i.e. "should" or "should not". </summary>
        private readonly bool _should;       
      
       
        internal Condition(IEnumerable<TypeSpec> types, bool should, FunctionSequence calls = null)
        {
            _types = types;
            _should = should;
            _sequence = calls ?? new FunctionSequence();
        }


        /// <summary>
        /// Selects types that have a specific name.
        /// </summary>
        /// <param name="name">The name of the class to match against.</param>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList HaveName(string name)
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.HaveName(x, name, true));
            return new ConditionList(_types, _should, _sequence);
        }

        /// <summary>
        /// Selects types that do not have a particular name.
        /// </summary>
        /// <param name="name">The name of the class to match against.</param>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList NotHaveName(string name)
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.HaveName(x, name, false));
            return new ConditionList(_types, _should, _sequence);
        }

        /// <summary>
        /// Selects types according to a regular expression matching their name.
        /// </summary>
        /// <param name="pattern">The regular expression pattern to match against.</param>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList HaveNameMatching(string pattern)
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.HaveNameMatching(x, pattern, true));
            return new ConditionList(_types, _should, _sequence);
        }

        /// <summary>
        /// Selects types according to a regular expression that does not match their name.
        /// </summary>
        /// <param name="pattern">The regular expression pattern to match against.</param>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList NotHaveNameMatching(string pattern)
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.HaveNameMatching(x, pattern, false));
            return new ConditionList(_types, _should, _sequence);
        }

        /// <summary>
        /// Selects types whose names start with the specified text.
        /// </summary>
        /// <param name="start">The text to match against.</param>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList HaveNameStartingWith(string start)
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.HaveNameStartingWith(x, start, true));
            return new ConditionList(_types, _should, _sequence);
        }

        /// <summary>
        /// Selects types whose names start with the specified text.
        /// </summary>
        /// <param name="start">The text to match against.</param>
        /// <param name="comparer">The string comparer.</param>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList HaveNameStartingWith(string start, StringComparison comparer)
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.HaveNameStartingWith(x, start, true, comparer));
            return new ConditionList(_types, _should, _sequence);
        }

        /// <summary>
        /// Selects types whose names do not start with the specified text.
        /// </summary>
        /// <param name="start">The text to match against.</param>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList NotHaveNameStartingWith(string start)
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.HaveNameStartingWith(x, start, false));
            return new ConditionList(_types, _should, _sequence);
        }

        /// <summary>
        /// Selects types whose names do not start with the specified text.
        /// </summary>
        /// <param name="start">The text to match against.</param>
        /// <param name="comparer">The string comparer.</param>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList NotHaveNameStartingWith(string start, StringComparison comparer)
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.HaveNameStartingWith(x, start, false, comparer));
            return new ConditionList(_types, _should, _sequence);
        }

        /// <summary>
        /// Selects types whose names do not end with the specified text.
        /// </summary>
        /// <param name="end">The text to match against.</param>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList HaveNameEndingWith(string end)
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.HaveNameEndingWith(x, end, true));
            return new ConditionList(_types, _should, _sequence);
        }

        /// <summary>
        /// Selects types whose names do not end with the specified text.
        /// </summary>
        /// <param name="end">The text to match against.</param>
        /// <param name="comparer">The string comparer.</param>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList HaveNameEndingWith(string end, StringComparison comparer)
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.HaveNameEndingWith(x, end, true, comparer));
            return new ConditionList(_types, _should, _sequence);
        }

        /// <summary>
        /// Selects types whose names do not end with the specified text.
        /// </summary>
        /// <param name="end">The text to match against.</param>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList NotHaveNameEndingWith(string end)
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.HaveNameEndingWith(x, end, false));
            return new ConditionList(_types, _should, _sequence);
        }

        /// <summary>
        /// Selects types whose names do not end with the specified text.
        /// </summary>
        /// <param name="end">The text to match against.</param>
        /// <param name="comparer">The string comparer.</param>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList NotHaveNameEndingWith(string end, StringComparison comparer)
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.HaveNameEndingWith(x, end, false, comparer));
            return new ConditionList(_types, _should, _sequence);
        }

        /// <summary>
        /// Selects types are decorated with a specific custom attribut.
        /// </summary>
        /// <param name="attribute">The attribute to match against.</param>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList HaveCustomAttribute(Type attribute)
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.HaveCustomAttribute(x, attribute, true));
            return new ConditionList(_types, _should, _sequence);
        }

        /// <summary>
        /// Selects types that are not decorated with a specific custom attribute.
        /// </summary>
        /// <param name="attribute">The attribute to match against.</param>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList NotHaveCustomAttribute(Type attribute)
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.HaveCustomAttribute(x, attribute, false));
            return new ConditionList(_types, _should, _sequence);
        }

        /// <summary>
        /// Selects types that are decorated with a specific custom attribute or derived one.
        /// </summary>
        /// <param name="attribute">The base attribute to match against.</param>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList HaveCustomAttributeOrInherit(Type attribute)
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.HaveCustomAttributeOrInherit(x, attribute, true));
            return new ConditionList(_types, _should, _sequence);
        }

        /// <summary>
        /// Selects types are not decorated with a specific custom attribute or derived one.
        /// </summary>
        /// <param name="attribute">The base attribute to match against.</param>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList NotHaveCustomAttributeOrInherit(Type attribute)
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.HaveCustomAttributeOrInherit(x, attribute, false));
            return new ConditionList(_types, _should, _sequence);
        }

        /// <summary>
        /// Selects types that inherit a particular type.
        /// </summary>
        /// <param name="type">The type to match against.</param>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList Inherit(Type type)
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.Inherits(x, type, true));
            return new ConditionList(_types, _should, _sequence);
        }

        /// <summary>
        /// Selects types that do not inherit a particular type.
        /// </summary>
        /// <param name="type">The type to match against.</param>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList NotInherit(Type type)
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.Inherits(x, type, false));
            return new ConditionList(_types, _should, _sequence);
        }

        /// <summary>
        /// Selects types that implement a particular interface.
        /// </summary>
        /// <param name="interfaceType">The interface type to match against.</param>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList ImplementInterface(Type interfaceType)
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.ImplementsInterface(x, interfaceType, true));
            return new ConditionList(_types, _should, _sequence);
        }

        /// <summary>
        /// Selects types that do not implement a particular interface.
        /// </summary>
        /// <param name="interfaceType">The interface type to match against.</param>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList NotImplementInterface(Type interfaceType)
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.ImplementsInterface(x, interfaceType, false));
            return new ConditionList(_types, _should, _sequence);
        }

        /// <summary>
        /// Selects types that are marked as abstract.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList BeAbstract()
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.BeAbstract(x, true, true));
            return new ConditionList(_types, _should, _sequence);
        }

        /// <summary>
        /// Selects types that are not marked as abstract.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList NotBeAbstract()
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.BeAbstract(x, true, false));
            return new ConditionList(_types, _should, _sequence);
        }

        /// <summary>
        /// Selects types that are classes.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList BeClasses()
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.BeClass(x, true, true));
            return new ConditionList(_types, _should, _sequence);
        }

        /// <summary>
        /// Selects types that are not classes.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList NotBeClasses()
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.BeClass(x, true, false));
            return new ConditionList(_types, _should, _sequence);
        }

        /// <summary>
        /// Selects types that have generic parameters.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList BeGeneric()
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.BeGeneric(x, true, true));
            return new ConditionList(_types, _should, _sequence);
        }

        /// <summary>
        /// Selects types that do not have generic parameters.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList NotBeGeneric()
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.BeGeneric(x, true, false));
            return new ConditionList(_types, _should, _sequence);
        }


        /// <summary>
        /// Selects types that are interfaces.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList BeInterfaces()
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.BeInterface(x, true, true));
            return new ConditionList(_types, _should, _sequence);
        }

        /// <summary>
        /// Selects types that are not interfaces.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList NotBeInterfaces()
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.BeInterface(x, true, false));
            return new ConditionList(_types, _should, _sequence);
        }

        /// <summary>
        /// Selects types that are static.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList BeStatic()
        {
	        _sequence.AddFunctionCall(x => FunctionDelegates.BeStatic(x, true, true));
	        return new ConditionList(_types, _should, _sequence);
        }

        /// <summary>
        /// Selects types that are not static.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList NotBeStatic()
        {
	        _sequence.AddFunctionCall(x => FunctionDelegates.BeStatic(x, true, false));
	        return new ConditionList(_types, _should, _sequence);
        }

        /// <summary>
        /// Selects types that are nested.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList BeNested()
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.BeNested(x, true, true));
            return new ConditionList(_types, _should, _sequence);
        }

        /// <summary>
        /// Selects types that are nested and public.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList BeNestedPublic()
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.BeNestedPublic(x, true, true));
            return new ConditionList(_types, _should, _sequence);
        }

        /// <summary>
        /// Selects types that are nested and private.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList BeNestedPrivate()
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.BeNestedPrivate(x, true, true));
            return new ConditionList(_types, _should, _sequence);
        }

        /// <summary>
        /// Selects types that are not nested.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList NotBeNested()
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.BeNested(x, true, false));
            return new ConditionList(_types, _should, _sequence);
        }

        /// <summary>
        /// Selects types that are not nested and public.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList NotBeNestedPublic()
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.BeNestedPublic(x, true, false));
            return new ConditionList(_types, _should, _sequence);
        }

        /// <summary>
        /// Selects types that are not nested and private.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList NotBeNestedPrivate()
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.BeNestedPrivate(x, true, false));
            return new ConditionList(_types, _should, _sequence);
        }

        /// <summary>
        /// Selects types that are have public scope.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList BePublic()
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.BePublic(x, true, true));
            return new ConditionList(_types, _should, _sequence);
        }

        /// <summary>
        /// Selects types that do not have public scope.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList NotBePublic()
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.BePublic(x, true, false));
            return new ConditionList(_types, _should, _sequence);
        }

        /// <summary>
        /// Selects types according that are marked as sealed.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList BeSealed()
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.BeSealed(x, true, true));
            return new ConditionList(_types, _should, _sequence);
        }

        /// <summary>
        /// Selects types according that are not marked as sealed.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList NotBeSealed()
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.BeSealed(x, true, false));
            return new ConditionList(_types, _should, _sequence);
        }

        /// <summary>
        /// Selects types that are immutable.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList BeImmutable()
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.BeImmutable(x, true, true));
            return new ConditionList(_types, _should, _sequence);
        }

        /// <summary>
        /// Selects types that are mutable.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList BeMutable()
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.BeImmutable(x, true, false));
            return new ConditionList(_types, _should, _sequence);
        }

        /// <summary>
        /// Selects types according to whether they have nullable members.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList OnlyHaveNullableMembers()
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.HasNullableMembers(x, true, true));
            return new ConditionList(_types, _should, _sequence);
        }

        /// <summary>
        /// Selects types according to whether they have nullable members.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList HaveSomeNonNullableMembers()
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.HasNullableMembers(x, true, false));
            return new ConditionList(_types, _should, _sequence);
        }

        /// <summary>
        /// Selects types that reside in a particular namespace.
        /// </summary>
        /// <param name="name">The namespace to match against.</param>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList ResideInNamespace(string name)
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.ResideInNamespace(x, name, true));
            return new ConditionList(_types, _should, _sequence);
        }

        /// <summary>
        /// Selects types that do not reside in a particular namespace.
        /// </summary>
        /// <param name="name">The namespace to match against.</param>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList NotResideInNamespace(string name)
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.ResideInNamespace(x, name, false));
            return new ConditionList(_types, _should, _sequence);
        }

        /// <summary>
        /// Selects types that reside in a namespace matching a regular expression.
        /// </summary>
        /// <param name="pattern">The regular expression pattern to match against.</param>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList ResideInNamespaceMatching(string pattern)
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.ResideInNamespaceMatching(x, pattern, true));
            return new ConditionList(_types, _should, _sequence);
        }

        /// <summary>
        /// Selects types that do not reside in a namespace matching a regular expression.
        /// </summary>
        /// <param name="pattern">The regular expression pattern to match against.</param>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList NotResideInNamespaceMatching(string pattern)
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.ResideInNamespaceMatching(x, pattern, false));
            return new ConditionList(_types, _should, _sequence);
        }

        /// <summary>
        /// Selects types whose namespaces start with a particular name part.
        /// </summary>
        /// <param name="name">The namespace part to match against.</param>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public ConditionList ResideInNamespaceStartingWith(string name)
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.ResideInNamespaceMatching(x, $"^{name}", true));
            return new ConditionList(_types, _should, _sequence);
        }

        /// <summary>
        /// Selects types whose namespaces start with a particular name part.
        /// </summary>
        /// <param name="name">The namespace part to match against.</param>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public ConditionList NotResideInNamespaceStartingWith(string name)
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.ResideInNamespaceMatching(x, $"^{name}", false));
            return new ConditionList(_types, _should, _sequence);
        }

        /// <summary>
        /// Selects types whose namespaces end with a particular name part.
        /// </summary>
        /// <param name="name">The namespace part to match against.</param>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public ConditionList ResideInNamespaceEndingWith(string name)
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.ResideInNamespaceMatching(x, $"{name}$", true));
            return new ConditionList(_types, _should, _sequence);
        }

        /// <summary>
        /// Selects types whose namespaces end with a particular name part.
        /// </summary>
        /// <param name="name">The namespace part to match against.</param>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public ConditionList NotResideInNamespaceEndingWith(string name)
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.ResideInNamespaceMatching(x, $"{name}$", false));
            return new ConditionList(_types, _should, _sequence);
        }

        /// <summary>
        /// Selects types whose namespaces contain a particular name part.
        /// </summary>
        /// <param name="name">The namespace part to match against.</param>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public ConditionList ResideInNamespaceContaining(string name)
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.ResideInNamespaceMatching(x, $"^.*{name}.*$", true));
            return new ConditionList(_types, _should, _sequence);
        }

        /// <summary>
        /// Selects types whose namespaces contain a particular name part.
        /// </summary>
        /// <param name="name">The namespace part to match against.</param>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public ConditionList NotResideInNamespaceContaining(string name)
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.ResideInNamespaceMatching(x, $"^.*{name}.*$", false));
            return new ConditionList(_types, _should, _sequence);
        }        

       

        /// <summary>
        /// Selects types that meet a custom rule.
        /// </summary>
        /// <param name="rule">An instance of the custom rule.</param>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList MeetCustomRule(ICustomRule rule)
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.MeetCustomRule(x, rule, true));
            return new ConditionList(_types, _should, _sequence);
        }
    }
}