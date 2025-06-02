using System.Collections.Generic;
using System.Linq;
using NetArchTest.Assemblies;
using NetArchTest.Dependencies;
using NetArchTest.RuleEngine;

namespace NetArchTest.Functions
{
    internal static partial class FunctionDelegates
    {
        /// <summary> Function for finding types that have a dependency on any of the supplied types. </summary>
        internal static IEnumerable<TypeSpec> HaveDependencyOnAny(FunctionSequenceExecutionContext context, IEnumerable<TypeSpec> input, IEnumerable<string> dependencies, bool condition)
        {
            // Get the types that contain the dependencies
            var search = new DependencySearch(context.IsFailPathRun, context.UserOptions.SerachForDependencyInFieldConstant, context.DependencyFilter);
            search.FindTypesThatHaveDependencyOnAny(input, dependencies);
            
            return input.Where(t => t.IsPassing == condition);
        }

        /// <summary> Function for finding types that have a dependency on all of the supplied types. </summary>
        internal static IEnumerable<TypeSpec> HaveDependencyOnAll(FunctionSequenceExecutionContext context, IEnumerable<TypeSpec> input, IEnumerable<string> dependencies, bool condition)
        {
            // Get the types that contain the dependencies
            var search = new DependencySearch(context.IsFailPathRun, context.UserOptions.SerachForDependencyInFieldConstant, context.DependencyFilter);
            search.FindTypesThatHaveDependencyOnAll(input, dependencies);

            return input.Where(t => t.IsPassing == condition);
        }

        /// <summary> Function for finding types that have a dependency on type other than one of the supplied types.</summary>
        internal static IEnumerable<TypeSpec> OnlyHaveDependenciesOnAnyOrNone(FunctionSequenceExecutionContext context, IEnumerable<TypeSpec> input, IEnumerable<string> dependencies, bool condition)
        {
            var search = new DependencySearch(context.IsFailPathRun, context.UserOptions.SerachForDependencyInFieldConstant, context.DependencyFilter);
            search.FindTypesThatOnlyHaveDependencyOnAnyOrNone(input, dependencies);

            return input.Where(t => t.IsPassing == condition);
        }

        internal static IEnumerable<TypeSpec> AreUsedByAny(FunctionSequenceExecutionContext context, IEnumerable<TypeSpec> input, IEnumerable<string> dependencies, bool condition)
        {
            var search = new DependencySearch(context.IsFailPathRun, context.UserOptions.SerachForDependencyInFieldConstant, context.DependencyFilter);
            search.FindTypesThatAreUsedByAny(input, dependencies, context.AllTypes);
            
            return input.Where(t => t.IsPassing == condition);
        }
    }
}