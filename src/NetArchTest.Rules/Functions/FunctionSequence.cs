using System;
using System.Collections.Generic;
using System.Linq;
using Mono.Cecil;
using NetArchTest.Assemblies;

namespace NetArchTest.Functions
{
    internal sealed class FunctionSequence
    {
        private readonly List<List<IFunctionCall>> groups;


        public FunctionSequence()
        {
            groups = new List<List<IFunctionCall>>();
            groups.Add(new List<IFunctionCall>());
        }


        public void AddFunctionCall(Func<IEnumerable<TypeSpec>, IEnumerable<TypeSpec>> func)
        {
            groups.Last().Add(new FunctionCall(func));
        }
        public void AddFunctionCall(Func<FunctionInvokeContext, IEnumerable<TypeSpec>, IEnumerable<TypeSpec>> func)
        {
            groups.Last().Add(new FunctionCallWithContext(func));
        }

        public void CreateGroup()
        {
            groups.Add(new List<IFunctionCall>());
        }



        public IReadOnlyList<TypeSpec> ExecuteToGetFailingTypes(IEnumerable<TypeSpec> inputTypes, bool selected = true)
        {
            var context = new FunctionInvokeContext(true);
            MarkPassingTypes(context, inputTypes);

            return inputTypes.Where(x => x.IsSelected == selected).ToList();
        }

        public IReadOnlyList<TypeSpec> Execute(IEnumerable<TypeSpec> inputTypes)
        {
            var context = new FunctionInvokeContext(false);
            MarkPassingTypes(context, inputTypes);

            return inputTypes.Where(x => x.IsSelected == true).ToList();
        }
        private void MarkPassingTypes(FunctionInvokeContext context, IEnumerable<TypeSpec> inputTypes)
        {
            inputTypes.ForEach(x => x.IsSelected = false);

            foreach (var group in groups)
            {
                IEnumerable<TypeSpec> passingTypes = inputTypes;

                foreach (var func in group)
                {
                    var funcResults = func.Execute(context, passingTypes);
                    passingTypes = funcResults;
                }

                passingTypes.ForEach(x => x.IsSelected = true);
            }
        }


        public class FunctionInvokeContext
        {
            public static readonly FunctionInvokeContext Default = new FunctionInvokeContext(false);

            public bool IsFailPathRun { get; }

            public FunctionInvokeContext(bool isFailPathRun)
            {
                IsFailPathRun = isFailPathRun;
            }
        }


        private class FunctionCall : IFunctionCall
        {
            private readonly Func<IEnumerable<TypeSpec>, IEnumerable<TypeSpec>> func;           

            public FunctionCall(Func<IEnumerable<TypeSpec>, IEnumerable<TypeSpec>> func)
            {
                this.func = func;
            }           

            public IEnumerable<TypeSpec> Execute(FunctionInvokeContext context, IEnumerable<TypeSpec> inputTypes)
            {
                return func(inputTypes);
            }
        }
        private class FunctionCallWithContext : IFunctionCall
        {
            private readonly Func<FunctionInvokeContext, IEnumerable<TypeSpec>, IEnumerable<TypeSpec>> func;

            public FunctionCallWithContext(Func<FunctionInvokeContext, IEnumerable<TypeSpec>, IEnumerable<TypeSpec>> func)
            {
                this.func = func;
            }

            public IEnumerable<TypeSpec> Execute(FunctionInvokeContext context, IEnumerable<TypeSpec> inputTypes)
            {
                return func(context, inputTypes);
            }
        }
        private interface IFunctionCall
        {
            IEnumerable<TypeSpec> Execute(FunctionInvokeContext context, IEnumerable<TypeSpec> inputTypes);
        }
    }
}