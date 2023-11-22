using System;
using NetArchTest.Assemblies;
using System.Collections.Generic;
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
        private void AddFunctionCall(Func<IEnumerable<TypeSpec>, IEnumerable<TypeSpec>> func)
        {
            context.Sequence.AddFunctionCall(func);
        }
        private void AddFunctionCall(Func<FunctionSequenceExecutionContext, IEnumerable<TypeSpec>, IEnumerable<TypeSpec>> func)
        {
            context.Sequence.AddFunctionCall(func);
        }



        /// <summary>
        /// Selects types that are decorated with a specific custom attribute.
        /// </summary>       
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList HaveCustomAttribute(Type attribute)
        {
            AddFunctionCall(x => FunctionDelegates.HaveCustomAttribute(x, attribute, true));
            return CreatePredicateList();
        }
        /// <summary>
        /// Selects types that are decorated with a specific custom attribute.
        /// </summary>       
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList HaveCustomAttribute<T>()
        {
            return HaveCustomAttribute(typeof(T));
        }

        /// <summary>
        /// Selects types that are not decorated with a specific custom attribute.
        /// </summary>
        /// <param name="attribute">The attribute to match against.</param>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList DoNotHaveCustomAttribute(Type attribute)
        {
            AddFunctionCall(x => FunctionDelegates.HaveCustomAttribute(x, attribute, false));
            return CreatePredicateList();
        }
        /// <summary>
        /// Selects types that are not decorated with a specific custom attribute.
        /// </summary>       
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList DoNotHaveCustomAttribute<T>()
        {
            return DoNotHaveCustomAttribute(typeof(T));
        }

        /// <summary>
        /// Selects types that are decorated with a specific custom attribute or derived one.
        /// </summary>
        /// <param name="attribute">The base attribute to match against.</param>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList HaveCustomAttributeOrInherit(Type attribute)
        {
            AddFunctionCall(x => FunctionDelegates.HaveCustomAttributeOrInherit(x, attribute, true));
            return CreatePredicateList();
        }
        /// <summary>
        /// Selects types that are decorated with a specific custom attribute or derived one.
        /// </summary>      
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList HaveCustomAttributeOrInherit<T>()
        {
            return HaveCustomAttributeOrInherit(typeof(T));
        }

        /// <summary>
        /// Selects types that are not decorated with a specific custom attribute or derived one.
        /// </summary>
        /// <param name="attribute">The base attribute to match against.</param>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList DoNotHaveCustomAttributeOrInherit(Type attribute)
        {
            AddFunctionCall(x => FunctionDelegates.HaveCustomAttributeOrInherit(x, attribute, false));
            return CreatePredicateList();
        }
        /// <summary>
        /// Selects types that are not decorated with a specific custom attribute or derived one.
        /// </summary>     
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList DoNotHaveCustomAttributeOrInherit<T>()
        {
            return DoNotHaveCustomAttributeOrInherit(typeof(T));
        }


        /// <summary>
        /// Selects types that inherit a particular type.
        /// </summary>
        /// <param name="type">The type to match against.</param>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList Inherit(Type type)
        {
            AddFunctionCall(x => FunctionDelegates.Inherit(x, type, true));
            return CreatePredicateList();
        }
        /// <summary>
        /// Selects types that inherit a particular type.
        /// </summary>     
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList Inherit<T>()
        {
            return Inherit(typeof(T));
        }

        /// <summary>
        /// Selects types that do not inherit a particular type.
        /// </summary>
        /// <param name="type">The type to match against.</param>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList DoNotInherit(Type type)
        {
            AddFunctionCall(x => FunctionDelegates.Inherit(x, type, false));
            return CreatePredicateList();
        }
        /// <summary>
        /// Selects types that do not inherit a particular type.
        /// </summary>       
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList DoNotInherit<T>()
        { 
            return DoNotInherit(typeof(T));
        }


        /// <summary>
        /// Selects types that implement a particular interface.
        /// </summary>
        /// <param name="interfaceType">The interface type to match against.</param>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList ImplementInterface(Type interfaceType)
        {
            AddFunctionCall(x => FunctionDelegates.ImplementInterface(x, interfaceType, true));
            return CreatePredicateList();
        }
        /// <summary>
        /// Selects types that implement a particular interface.
        /// </summary>        
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList ImplementInterface<T>()
        {
            return ImplementInterface(typeof(T));
        }

        /// <summary>
        /// Selects types that do not implement a particular interface.
        /// </summary>
        /// <param name="interfaceType">The interface type to match against.</param>
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList DoNotImplementInterface(Type interfaceType)
        {
            AddFunctionCall(x => FunctionDelegates.ImplementInterface(x, interfaceType, false));
            return CreatePredicateList();
        }
        /// <summary>
        /// Selects types that do not implement a particular interface.
        /// </summary>      
        /// <returns>An updated set of predicates that can be applied to a list of types.</returns>
        public PredicateList DoNotImplementInterface<T>()
        {
            return DoNotImplementInterface(typeof(T));
        }


        /// <summary>
        /// Selects types that meet a custom rule.
        /// </summary>
        /// <param name="rule">An instance of the custom rule.</param>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public PredicateList MeetCustomRule(ICustomRule rule)
        {
            AddFunctionCall(x => FunctionDelegates.MeetCustomRule(x, rule, true));
            return CreatePredicateList();
        }
    }
}