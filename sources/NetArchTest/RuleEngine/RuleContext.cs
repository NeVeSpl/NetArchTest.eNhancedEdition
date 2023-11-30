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
        internal readonly LoadedData loadedData;
        public PredicateContext PredicateContext { get; } = new PredicateContext();
        public ConditionContext ConditionContext { get; } = new ConditionContext();


        public RuleContext(LoadedData loadedData)
        {
            this.loadedData = loadedData;
        }   


        public IReadOnlyList<TypeSpec> Execute(Options options)
        {
            var lodedTypes = loadedData.GetTypes().ToArray();           
            var selectedTypes = PredicateContext.Sequence.Execute(lodedTypes, options, lodedTypes);
            var passingTypes = ConditionContext.Sequence.Execute(selectedTypes, options, lodedTypes); 
            return passingTypes;
        }

        public TestResult GetResult(Options options)
        {
            bool success;

            var lodedTypes = loadedData.GetTypes().ToArray();
            var selectedTypes = PredicateContext.Sequence.Execute(lodedTypes, options, lodedTypes);
            var passingTypes = ConditionContext.Sequence.Execute(selectedTypes, options, lodedTypes);

            if (ConditionContext.Should)
            {
                // All the classes should meet the condition
                success = (passingTypes.Count() == selectedTypes.Count());
            }
            else
            {
                // No classes should meet the condition
                success = (passingTypes.Count() == 0);
            }

            if (success)
            {
                return new TestResult(loadedData.Assemblies, lodedTypes, selectedTypes, Array.Empty<TypeSpec>(), true);
            }

            // If we've failed, get a collection of failing types so these can be reported in a failing test.
            var failedTypes = ConditionContext.Sequence.ExecuteToGetFailingTypes(selectedTypes, selected: !ConditionContext.Should, options, lodedTypes);
            return new TestResult(loadedData.Assemblies, lodedTypes, selectedTypes, failedTypes, false);
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