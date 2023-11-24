using System;
using System.Collections.Generic;
using System.Linq;
using NetArchTest.Assemblies;
using NetArchTest.Rules;

namespace NetArchTest.RuleEngine
{
    internal sealed partial class FunctionSequence
    {
        private readonly List<List<IFunctionCall>> groups = new List<List<IFunctionCall>> { new List<IFunctionCall>() };
        private bool isEmpty = true;     


        public void AddFunctionCall(Func<IEnumerable<TypeSpec>, IEnumerable<TypeSpec>> func)
        {
            isEmpty = false;
            groups.Last().Add(new FunctionCall(func));
        }
        public void AddFunctionCall(Func<FunctionSequenceExecutionContext, IEnumerable<TypeSpec>, IEnumerable<TypeSpec>> func)
        {
            isEmpty = false;
            groups.Last().Add(new FunctionCallWithContext(func));
        }

        public void CreateGroup()
        {
            groups.Add(new List<IFunctionCall>());
        }


        public IEnumerable<TypeSpec> ExecuteToGetFailingTypes(IEnumerable<TypeSpec> inputTypes, bool selected, Options options, IEnumerable<TypeSpec> allTypes)
        {
            return Execute(inputTypes, selected, true, options, allTypes);
        }
        public IEnumerable<TypeSpec> Execute(IEnumerable<TypeSpec> inputTypes, Options options, IEnumerable<TypeSpec> allTypes)
        {
            return Execute(inputTypes, true, false, options, allTypes);
        }

        private IEnumerable<TypeSpec> Execute(IEnumerable<TypeSpec> inputTypes, bool selected, bool isFailPathRun, Options options, IEnumerable<TypeSpec> allTypes)
        {
            if (isEmpty) return inputTypes;

            var context = new FunctionSequenceExecutionContext(allTypes, isFailPathRun, options);
            MarkPassingTypes(context, inputTypes);

            return inputTypes.Where(x => x.IsSelectedInMarkPhase == selected).ToArray();
        }


        private void MarkPassingTypes(FunctionSequenceExecutionContext context, IEnumerable<TypeSpec> inputTypes)
        {
            inputTypes.ForEach(x => x.IsSelectedInMarkPhase = false);

            foreach (var group in groups)
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
            private readonly Func<IEnumerable<TypeSpec>, IEnumerable<TypeSpec>> func;

            public FunctionCall(Func<IEnumerable<TypeSpec>, IEnumerable<TypeSpec>> func)
            {
                this.func = func;
            }

            public IEnumerable<TypeSpec> Execute(FunctionSequenceExecutionContext context, IEnumerable<TypeSpec> inputTypes)
            {
                return func(inputTypes);
            }
        }
        private class FunctionCallWithContext : IFunctionCall
        {
            private readonly Func<FunctionSequenceExecutionContext, IEnumerable<TypeSpec>, IEnumerable<TypeSpec>> func;

            public FunctionCallWithContext(Func<FunctionSequenceExecutionContext, IEnumerable<TypeSpec>, IEnumerable<TypeSpec>> func)
            {
                this.func = func;
            }

            public IEnumerable<TypeSpec> Execute(FunctionSequenceExecutionContext context, IEnumerable<TypeSpec> inputTypes)
            {
                return func(context, inputTypes);
            }
        }
        private interface IFunctionCall
        {
            IEnumerable<TypeSpec> Execute(FunctionSequenceExecutionContext context, IEnumerable<TypeSpec> inputTypes);
        }
    }
}