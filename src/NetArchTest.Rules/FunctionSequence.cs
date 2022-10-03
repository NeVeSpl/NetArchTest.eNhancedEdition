using System;
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
        private readonly List<List<IFunctionCall>> _groups;


        /// <summary>
        /// Initializes a new instance of the <see cref="FunctionSequence"/> class.
        /// </summary>
        internal FunctionSequence()
        {
            _groups = new List<List<IFunctionCall>>();
            _groups.Add(new List<IFunctionCall>());
        }


        /// <summary>
        /// Adds a function call to the current list.
        /// </summary>
        internal void AddFunctionCall<T>(FunctionDelegates.FunctionDelegate<T> method, T value, bool condition)
        {
            _groups.Last().Add(new FunctionCall(method, value, condition));
        }

        /// <summary>
        /// Creates a new logical grouping of function calls.
        /// </summary>
        internal void CreateGroup()
        {
            _groups.Add(new List<IFunctionCall>());
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

            foreach (var group in _groups)
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

        /// <summary>
        /// Represents a single function call.
        /// </summary>
        internal class FunctionCall : IFunctionCall
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="FunctionCall"/> class.
            /// </summary>
            internal FunctionCall(Delegate func, object value, bool condition)
            {
                this.FunctionDelegate = func;
                this.Value = value;
                this.Condition = condition;
            }


            public IEnumerable<TypeSpec> Execute(IEnumerable<TypeSpec> inputTypes)
            {
                return FunctionDelegate.DynamicInvoke(inputTypes, Value, Condition) as IEnumerable<TypeSpec>;
            }


            /// <summary>
            /// A delegate for a function call.
            /// </summary>
            public Delegate FunctionDelegate { get; private set; }

            /// <summary>
            /// The input value for the function call.
            /// </summary>
            public object Value { get; private set; }

            /// <summary>
            /// The Condition to apply to the call - i.e. "is" or "is not".
            /// </summary>
            public bool Condition { get; private set; }

        }

        internal interface IFunctionCall
        {
            IEnumerable<TypeSpec> Execute(IEnumerable<TypeSpec> inputTypes);
        }
    }
}