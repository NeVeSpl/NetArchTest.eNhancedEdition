using System;
using System.Collections.Generic;
using System.Linq;
using NetArchTest.Assemblies;
using NetArchTest.Rules;

namespace NetArchTest.RuleEngine
{
    internal sealed partial class FunctionSequence
    {
        private readonly List<List<IFunctionCall>> _groups = [ [] ];
        private bool _isEmpty = true;
        
        public void AddFunctionCall(Func<IEnumerable<TypeSpec>, IEnumerable<TypeSpec>> func)
        {
            _isEmpty = false;
            _groups.Last().Add(new FunctionCall(func));
        }
        public void AddFunctionCall(Func<FunctionSequenceExecutionContext, IEnumerable<TypeSpec>, IEnumerable<TypeSpec>> func)
        {
            _isEmpty = false;
            _groups.Last().Add(new FunctionCallWithContext(func));
        }

        public void CreateGroup()
        {
            _groups.Add([]);
        }

        public IReadOnlyList<TypeSpec> ExecuteToGetFailingTypes(IReadOnlyList<TypeSpec> inputTypes, bool selected, Options options, IEnumerable<TypeSpec> allTypes)
        {
            return Execute(inputTypes, selected, true, options, allTypes);
        }
        public IReadOnlyList<TypeSpec> Execute(IReadOnlyList<TypeSpec> inputTypes, Options options, IReadOnlyList<TypeSpec> allTypes)
        {
            return Execute(inputTypes, true, false, options, allTypes);
        }

        private IReadOnlyList<TypeSpec> Execute(IReadOnlyList<TypeSpec> inputTypes, bool selected, bool isFailPathRun, Options options, IEnumerable<TypeSpec> allTypes)
        {
            if (_isEmpty) return inputTypes;

            var context = new FunctionSequenceExecutionContext(allTypes, isFailPathRun, options);
            MarkPassingTypes(context, inputTypes);

            return inputTypes.Where(x => x.IsSelectedInMarkPhase == selected).ToArray();
        }

        private void MarkPassingTypes(FunctionSequenceExecutionContext context, IReadOnlyList<TypeSpec> inputTypes)
        {
            inputTypes.ForEach(x => x.IsSelectedInMarkPhase = false);

            foreach (var group in _groups)
            {
                IEnumerable<TypeSpec> passingTypes = inputTypes;

                foreach (var func in group)
                {
                    var funcResults = func.Execute(context, passingTypes);
                    passingTypes = funcResults;
                }

                passingTypes.ForEach(x => x.IsSelectedInMarkPhase = true);
            }
        }

        private class FunctionCall : IFunctionCall
        {
            private readonly Func<IEnumerable<TypeSpec>, IEnumerable<TypeSpec>> _func;

            public FunctionCall(Func<IEnumerable<TypeSpec>, IEnumerable<TypeSpec>> func)
            {
                _func = func;
            }

            public IEnumerable<TypeSpec> Execute(FunctionSequenceExecutionContext context, IEnumerable<TypeSpec> inputTypes)
            {
                return _func(inputTypes);
            }
        }
        private class FunctionCallWithContext : IFunctionCall
        {
            private readonly Func<FunctionSequenceExecutionContext, IEnumerable<TypeSpec>, IEnumerable<TypeSpec>> _func;

            public FunctionCallWithContext(Func<FunctionSequenceExecutionContext, IEnumerable<TypeSpec>, IEnumerable<TypeSpec>> func)
            {
                _func = func;
            }

            public IEnumerable<TypeSpec> Execute(FunctionSequenceExecutionContext context, IEnumerable<TypeSpec> inputTypes)
            {
                return _func(context, inputTypes);
            }
        }
        private interface IFunctionCall
        {
            IEnumerable<TypeSpec> Execute(FunctionSequenceExecutionContext context, IEnumerable<TypeSpec> inputTypes);
        }
    }
}