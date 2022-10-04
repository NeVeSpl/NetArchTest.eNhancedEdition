﻿using System;
using System.Collections.Generic;
using System.Linq;
using NetArchTest.Rules.Assemblies;

namespace NetArchTest.Rules
{
    /// <summary>
    /// A sequence of function calls that are combined to select types.
    /// </summary>
    internal sealed class FunctionSequence
    {        
        private readonly List<List<IFunctionCall>> groups;


        public FunctionSequence()
        {
            groups = new List<List<IFunctionCall>>();
            groups.Add(new List<IFunctionCall>());
        }


        public void AddFunctionCall<T>(FunctionDelegates.FunctionDelegate<T> method, T value, bool condition)
        {
            groups.Last().Add(new FunctionCall<T>(method, value, condition));
        }
        public void CreateGroup()
        {
            groups.Add(new List<IFunctionCall>());
        }


        /// <summary>
        /// Executes all the function calls that have been specified.
        /// </summary>
        /// <returns>A list of types that are selected by the predicates (or not selected if optional reversing flag is passed).</returns>
        public IReadOnlyList<TypeSpec> ExecuteExtended(IEnumerable<TypeSpec> inputTypes, bool selected = true)
        {
            MarkPassingTypes(inputTypes);

            return inputTypes.Where(x => x.IsSelected == selected).ToList();
        }

        public IReadOnlyList<TypeSpec> Execute(IEnumerable<TypeSpec> inputTypes)
        {
            MarkPassingTypes(inputTypes);

            return inputTypes.Where(x => x.IsSelected == true).ToList();            
        }
        private void MarkPassingTypes(IEnumerable<TypeSpec> inputTypes)
        {
            inputTypes.ForEach(x => x.IsSelected = false);

            foreach (var group in groups)
            {
                IEnumerable<TypeSpec> passingTypes = inputTypes;

                foreach (var func in group)
                {
                    var funcResults = func.Execute(passingTypes);
                    passingTypes = funcResults;
                }

                passingTypes.ForEach(x => x.IsSelected = true);
            }
        }


        internal class FunctionCall<T> : IFunctionCall
        {
            public FunctionDelegates.FunctionDelegate<T> FunctionDelegate { get; }
            public T FunctionArgument { get; }
            public bool Condition { get;  }


            public FunctionCall(FunctionDelegates.FunctionDelegate<T> func, T argument, bool condition)
            {
                this.FunctionDelegate = func;
                this.FunctionArgument = argument;
                this.Condition = condition;
            }


            public IEnumerable<TypeSpec> Execute(IEnumerable<TypeSpec> inputTypes)
            {
                return FunctionDelegate(inputTypes, FunctionArgument, Condition);
            }
        }

        internal interface IFunctionCall
        {
            IEnumerable<TypeSpec> Execute(IEnumerable<TypeSpec> inputTypes);
        }
    }
}