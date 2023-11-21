using System;
using System.Collections.Generic;
using System.Linq;
using Mono.Cecil;
using NetArchTest.Assemblies;
using NetArchTest.Rules;

namespace NetArchTest.RuleEngine
{
    internal class RuleContext
    {
        private readonly IReadOnlyList<TypeSpec> types;
        public PredicateContext PredicateContext { get; } = new PredicateContext();
        public ConditionContext ConditionContext { get; } = new ConditionContext();


        public RuleContext(IEnumerable<TypeSpec> inpuTypes)
        {
            types = inpuTypes.ToArray();
        }   


        public IEnumerable<TypeSpec> Execute(Options options)
        {
            IEnumerable<TypeSpec> result = types;
            result = PredicateContext.Sequence.Execute(result, options);
            result = ConditionContext.Sequence.Execute(result, options); 
            return result;
        }

        public TestResult GetResult(Options options)
        {
            bool success;

            var filteredTypes = PredicateContext.Sequence.Execute(types, options);
            var passingTypes = ConditionContext.Sequence.Execute(filteredTypes, options);

            if (ConditionContext.Should)
            {
                // All the classes should meet the condition
                success = (passingTypes.Count() == filteredTypes.Count());
            }
            else
            {
                // No classes should meet the condition
                success = (passingTypes.Count() == 0);
            }

            if (success)
            {
                return TestResult.Success();
            }

            // If we've failed, get a collection of failing types so these can be reported in a failing test.
            var failedTypes = ConditionContext.Sequence.ExecuteToGetFailingTypes(filteredTypes, selected: !ConditionContext.Should, options);
            return TestResult.Failure(failedTypes);
        }


        public IEnumerable<IType> GetTypes(Options options)
        {
            return Execute(options).Select(t => t.CreateWrapper());
        }
        internal IEnumerable<Type> GetReflectionTypes(Options options)
        {
            return Execute(options).Select(x => x.Definition.ToType());
        }
    }
}