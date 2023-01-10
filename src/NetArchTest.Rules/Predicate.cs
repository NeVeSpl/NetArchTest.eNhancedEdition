using System;
using System.Collections.Generic;
using NetArchTest.Assemblies;
using NetArchTest.Functions;

namespace NetArchTest.Rules
{
    /// <summary>
    /// A set of predicates that can be applied to a list of types.
    /// </summary>
    public sealed partial class Predicate
    {       
        private readonly IEnumerable<TypeSpec> _types;
        private readonly FunctionSequence _sequence;


        /// <summary>
        /// Initializes a new instance of the <see cref="Predicate"/> class.
        /// </summary>
        internal Predicate(IEnumerable<TypeSpec> types, FunctionSequence calls = null)
        {
            _types = types;
            _sequence = calls ?? new FunctionSequence();
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
                _sequence.AddFunctionCall(x => FunctionDelegates.HaveName(x, item, true));
            }
            return new PredicateList(_types, _sequence);
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
                _sequence.AddFunctionCall(x => FunctionDelegates.HaveName(x, item, false));
            }
            return new PredicateList(_types, _sequence);
        }

        /// <summary>
        /// Selects types according to a regular expression matching their name.
        /// </summary>
        /// <param name="pattern">The regular expression pattern to match against.</param>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList HaveNameMatching(string pattern)
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.HaveNameMatching(x, pattern, true));
            return new PredicateList(_types, _sequence);
        }

        /// <summary>
        /// Selects types according to a regular expression that does not match their name.
        /// </summary>
        /// <param name="pattern">The regular expression pattern to match against.</param>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList DoNotHaveNameMatching(string pattern)
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.HaveNameMatching(x, pattern, false));
            return new PredicateList(_types, _sequence);
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
                _sequence.AddFunctionCall(x => FunctionDelegates.HaveNameStartingWith(x, item, true));
            }
            return new PredicateList(_types, _sequence);
        }

        /// <summary>
        /// Selects types whose names start with the specified text.
        /// </summary>
        /// <param name="start">The text to match against.</param>
        /// <param name="comparer">The string comparer.</param>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList HaveNameStartingWith(string start, StringComparison comparer)
        {
	        _sequence.AddFunctionCall(x => FunctionDelegates.HaveNameStartingWith(x, start, true, comparer));
	        return new PredicateList(_types, _sequence);
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
                _sequence.AddFunctionCall(x => FunctionDelegates.HaveNameStartingWith(x, item, false));
            }
            return new PredicateList(_types, _sequence);
        }

        /// <summary>
        /// Selects types whose names do not start with the specified text.
        /// </summary>
        /// <param name="start">The text to match against.</param>
        /// <param name="comparer">The string comparer.</param>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList DoNotHaveNameStartingWith(string start, StringComparison comparer)
        {
	        _sequence.AddFunctionCall(x => FunctionDelegates.HaveNameStartingWith(x, start, false, comparer));
	        return new PredicateList(_types, _sequence);
        }

        /// <summary>
        /// Selects types whose names end with the specified text.
        /// </summary>
        /// <param name="end">The text to match against.</param>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList HaveNameEndingWith(string end)
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.HaveNameEndingWith(x, end, true));
            return new PredicateList(_types, _sequence);
        }

        /// <summary>
        /// Selects types whose names end with the specified text.
        /// </summary>
        /// <param name="end">The text to match against.</param>
        /// <param name="comparer">The string comparer.</param>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList HaveNameEndingWith(string end, StringComparison comparer)
        {
	        _sequence.AddFunctionCall(x => FunctionDelegates.HaveNameEndingWith((x), end, true, comparer));
	        return new PredicateList(_types, _sequence);
        }

        /// <summary>
        /// Selects types whose names do not end with the specified text.
        /// </summary>
        /// <param name="end">The text to match against.</param>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList DoNotHaveNameEndingWith(string end)
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.HaveNameEndingWith(x, end, false));
            return new PredicateList(_types, _sequence);
        }

        /// <summary>
        /// Selects types whose names do not end with the specified text.
        /// </summary>
        /// <param name="end">The text to match against.</param>
        /// <param name="comparer">The string comparer.</param>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList DoNotHaveNameEndingWith(string end, StringComparison comparer)
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.HaveNameEndingWith((x), end, false, comparer));
            return new PredicateList(_types, _sequence);
        }

        /// <summary>
        /// Selects types that are decorated with a specific custom attribute.
        /// </summary>
        /// <param name="attribute">The attribute to match against.</param>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList HaveCustomAttribute(Type attribute)
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.HaveCustomAttribute(x, attribute, true));
            return new PredicateList(_types, _sequence);
        }

        /// <summary>
        /// Selects types that are decorated with a specific custom attribute or derived one.
        /// </summary>
        /// <param name="attribute">The base attribute to match against.</param>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList HaveCustomAttributeOrInherit(Type attribute)
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.HaveCustomAttributeOrInherit(x, attribute, true));
            return new PredicateList(_types, _sequence);
        }

        /// <summary>
        /// Selects types that are not decorated with a specific custom attribute.
        /// </summary>
        /// <param name="attribute">The attribute to match against.</param>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList DoNotHaveCustomAttribute(Type attribute)
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.HaveCustomAttribute(x, attribute, false));
            return new PredicateList(_types, _sequence);
        }

        /// <summary>
        /// Selects types that are not decorated with a specific custom attribute or derived one.
        /// </summary>
        /// <param name="attribute">The base attribute to match against.</param>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList DoNotHaveCustomAttributeOrInherit(Type attribute)
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.HaveCustomAttributeOrInherit(x, attribute, false));
            return new PredicateList(_types, _sequence);
        }

        /// <summary>
        /// Selects types that inherit a particular type.
        /// </summary>
        /// <param name="type">The type to match against.</param>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList Inherit(Type type)
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.Inherits(x, type, true));
            return new PredicateList(_types, _sequence);
        }

        /// <summary>
        /// Selects types that do not inherit a particular type.
        /// </summary>
        /// <param name="type">The type to match against.</param>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList DoNotInherit(Type type)
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.Inherits(x, type, false));
            return new PredicateList(_types, _sequence);
        }

        /// <summary>
        /// Selects types that implement a particular interface.
        /// </summary>
        /// <param name="interfaceType">The interface type to match against.</param>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList ImplementInterface(Type interfaceType)
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.ImplementsInterface(x, interfaceType, true));
            return new PredicateList(_types, _sequence);
        }

        /// <summary>
        /// Selects types that do not implement a particular interface.
        /// </summary>
        /// <param name="interfaceType">The interface type to match against.</param>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList DoNotImplementInterface(Type interfaceType)
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.ImplementsInterface(x, interfaceType, false));
            return new PredicateList(_types, _sequence);
        }

        /// <summary>
        /// Selects types that are marked as abstract.
        /// </summary>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList AreAbstract()
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.BeAbstract(x, true, true));
            return new PredicateList(_types, _sequence);
        }

        /// <summary>
        /// Selects types that are not marked as abstract.
        /// </summary>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList AreNotAbstract()
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.BeAbstract(x, true, false));
            return new PredicateList(_types, _sequence);
        }

        /// <summary>
        /// Selects types that are classes.
        /// </summary>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList AreClasses()
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.BeClass(x, true, true));
            return new PredicateList(_types, _sequence);
        }

        /// <summary>
        /// Selects types that are not classes.
        /// </summary>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList AreNotClasses()
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.BeClass(x, true, false));
            return new PredicateList(_types, _sequence);
        }

        /// <summary>
        /// Selects types that have generic parameters.
        /// </summary>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList AreGeneric()
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.BeGeneric(x, true, true));
            return new PredicateList(_types, _sequence);
        }

        /// <summary>
        /// Selects types that do not have generic parameters.
        /// </summary>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList AreNotGeneric()
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.BeGeneric(x, true, false));
            return new PredicateList(_types, _sequence);
        }

        /// <summary>
        /// Selects types that are interfaces.
        /// </summary>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList AreInterfaces()
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.BeInterface(x, true, true));
            return new PredicateList(_types, _sequence);
        }

        /// <summary>
        /// Selects types that are not interfaces.
        /// </summary>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList AreNotInterfaces()
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.BeInterface(x, true, false));
            return new PredicateList(_types, _sequence);
        }

        /// <summary>
        /// Selects types that are static.
        /// </summary>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList AreStatic()
        {
	        _sequence.AddFunctionCall(x => FunctionDelegates.BeStatic(x, true, true));
	        return new PredicateList(_types, _sequence);
        }

        /// <summary>
        /// Selects types that are not static.
        /// </summary>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList AreNotStatic()
        {
	        _sequence.AddFunctionCall(x => FunctionDelegates.BeStatic(x, true, false));
	        return new PredicateList(_types, _sequence);
        }

        /// <summary>
        /// Selects types that are nested.
        /// </summary>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList AreNested()
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.BeNested(x, true, true));
            return new PredicateList(_types, _sequence);
        }

        /// <summary>
        /// Selects types that are nested and declared as public.
        /// </summary>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList AreNestedPublic()
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.BeNestedPublic(x, true, true));
            return new PredicateList(_types, _sequence);
        }

        /// <summary>
        /// Selects types that are nested and declared as private.
        /// </summary>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList AreNestedPrivate()
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.BeNestedPrivate(x, true, true));
            return new PredicateList(_types, _sequence);
        }

        /// <summary>
        /// Selects types that are not nested.
        /// </summary>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList AreNotNested()
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.BeNested(x, true, false));
            return new PredicateList(_types, _sequence);
        }

        /// <summary>
        /// Selects types that are not nested and declared as public.
        /// </summary>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        /// <remarks>NB: This method will return non-nested types and nested types that are declared as private.</remarks>
        public PredicateList AreNotNestedPublic()
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.BeNestedPublic(x, true, false));
            return new PredicateList(_types, _sequence);
        }

        /// <summary>
        /// Selects types that are not nested and declared as private.
        /// </summary>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        /// <remarks>NB: This method will return non-nested types and nested types that are declared as public.</remarks>
        public PredicateList AreNotNestedPrivate()
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.BeNestedPrivate(x, true, false));
            return new PredicateList(_types, _sequence);
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
            _sequence.AddFunctionCall(x => FunctionDelegates.BePublic(x, true, true));
            return new PredicateList(_types, _sequence);
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
            _sequence.AddFunctionCall(x => FunctionDelegates.BePublic(x, true, false));
            return new PredicateList(_types, _sequence);
        }

        /// <summary>
        /// Selects types according that are marked as sealed.
        /// </summary>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList AreSealed()
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.BeSealed(x, true, true));
            return new PredicateList(_types, _sequence);
        }

        /// <summary>
        /// Selects types according that are not marked as sealed.
        /// </summary>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList AreNotSealed()
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.BeSealed(x, true, false));
            return new PredicateList(_types, _sequence);
        }

        /// <summary>
        /// Selects types that are immutable.
        /// </summary>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList AreImmutable()
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.BeImmutable(x, true, true));
            return new PredicateList(_types, _sequence);
        }

        /// <summary>
        /// Selects types that are mutable.
        /// </summary>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList AreMutable()
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.BeImmutable(x, true, false));
            return new PredicateList(_types, _sequence);
        }

        /// <summary>
        /// Selects types that have only nullable members.
        /// </summary>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList OnlyHaveNullableMembers()
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.HasNullableMembers(x, true, true));
            return new PredicateList(_types, _sequence);
        }

        /// <summary>
        /// Selects types that have some non-nullable members.
        /// </summary>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList HaveSomeNonNullableMembers()
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.HasNullableMembers(x, true, false));
            return new PredicateList(_types, _sequence);
        }

        /// <summary>
        /// Selects types that reside in a particular namespace.
        /// </summary>
        /// <param name="name">The namespace to match against.</param>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList ResideInNamespace(string name)
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.ResideInNamespace(x, name, true));
            return new PredicateList(_types, _sequence);
        }

        /// <summary>
        /// Selects types that do not reside in a particular namespace.
        /// </summary>
        /// <param name="name">The namespace to match against.</param>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList DoNotResideInNamespace(string name)
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.ResideInNamespace(x, name, false));
            return new PredicateList(_types, _sequence);
        }

        /// <summary>
        /// Selects types whose namespaces match a regular expression.
        /// </summary>
        /// <param name="pattern">The regular expression pattern to match against.</param>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList ResideInNamespaceMatching(string pattern)
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.ResideInNamespaceMatching(x, pattern, true));
            return new PredicateList(_types, _sequence);
        }

        /// <summary>
        /// Selects types whose namespaces start with a particular name part.
        /// </summary>
        /// <param name="name">The namespace part to match against.</param>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList ResideInNamespaceStartingWith(string name)
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.ResideInNamespaceMatching(x, $"^{name}", true));
            return new PredicateList(_types, _sequence);
        }

        /// <summary>
        /// Selects types whose namespaces end with a particular name part.
        /// </summary>
        /// <param name="name">The namespace part to match against.</param>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList ResideInNamespaceEndingWith(string name)
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.ResideInNamespaceMatching(x, $"{name}$", true));
            return new PredicateList(_types, _sequence);
        }

        /// <summary>
        /// Selects types whose namespaces contain a particular name part.
        /// </summary>
        /// <param name="name">The namespace part to match against.</param>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList ResideInNamespaceContaining(string name)
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.ResideInNamespaceMatching(x, $"^.*{name}.*$", true));
            return new PredicateList(_types, _sequence);
        }

        /// <summary>
        /// Selects types whose namespaces do not match a regular expression.
        /// </summary>
        /// <param name="pattern">The regular expression pattern to match against.</param>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList DoNotResideInNamespaceMatching(string pattern)
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.ResideInNamespaceMatching(x, pattern, false));
            return new PredicateList(_types, _sequence);
        }

        /// <summary>
        /// Selects types whose namespaces start with a particular name part.
        /// </summary>
        /// <param name="name">The namespace part to match against.</param>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList DoNotResideInNamespaceStartingWith(string name)
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.ResideInNamespaceMatching(x, $"^{name}", false));
            return new PredicateList(_types, _sequence);
        }

        /// <summary>
        /// Selects types whose namespaces end with a particular name part.
        /// </summary>
        /// <param name="name">The namespace part to match against.</param>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList DoNotResideInNamespaceEndingWith(string name)
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.ResideInNamespaceMatching(x, $"{name}$", false));
            return new PredicateList(_types, _sequence);
        }

        /// <summary>
        /// Selects types whose namespaces contain a particular name part.
        /// </summary>
        /// <param name="name">The namespace part to match against.</param>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList DoNotResideInNamespaceContaining(string name)
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.ResideInNamespaceMatching(x, $"^.*{name}.*$", false));
            return new PredicateList(_types, _sequence);
        }    

      

        /// <summary>
        /// Selects types that meet a custom rule.
        /// </summary>
        /// <param name="rule">An instance of the custom rule.</param>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public PredicateList MeetCustomRule(ICustomRule rule)
        {
            _sequence.AddFunctionCall(x => FunctionDelegates.MeetCustomRule(x, rule, true));
            return new PredicateList(_types, _sequence);
        }
    }
}