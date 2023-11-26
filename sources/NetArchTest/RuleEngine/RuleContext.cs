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
        private readonly IReadOnlyList<TypeSpec> lodedTypes;
        public PredicateContext PredicateContext { get; } = new PredicateContext();
        public ConditionContext ConditionContext { get; } = new ConditionContext();


        public RuleContext(IEnumerable<TypeSpec> inpuTypes)
        {
            lodedTypes = inpuTypes.ToArray();
        }   


        public IEnumerable<TypeSpec> Execute(Options options)
        {
            var result = lodedTypes;
            result = PredicateContext.Sequence.Execute(result, options, lodedTypes);
            result = ConditionContext.Sequence.Execute(result, options, lodedTypes); 
            return result;
        }

        public TestResult GetResult(Options options)
        {
            bool success;

            var filteredTypes = PredicateContext.Sequence.Execute(lodedTypes, options, lodedTypes);
            var passingTypes = ConditionContext.Sequence.Execute(filteredTypes, options, lodedTypes);

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
                return new TestResult(lodedTypes, filteredTypes, Array.Empty<TypeSpec>(), true);
            }

            // If we've failed, get a collection of failing types so these can be reported in a failing test.
            var failedTypes = ConditionContext.Sequence.ExecuteToGetFailingTypes(filteredTypes, selected: !ConditionContext.Should, options, lodedTypes);
            return new TestResult(lodedTypes, filteredTypes, failedTypes, false);
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