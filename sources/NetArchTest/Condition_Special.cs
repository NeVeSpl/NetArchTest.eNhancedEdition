using System;
using Mono.Cecil;
using NetArchTest.Functions;

namespace NetArchTest.Rules
{
    public sealed partial class Condition
    {
        /// <summary>
        /// Selects types that are immutable, and their state cannot be changed after creation. (shallow immutability). Stronger constraint than AreImmutableExternally()
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList BeImmutable()
        {
            AddFunctionCall(x => FunctionDelegates.BeImmutable(x, true));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types that are mutable.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList BeMutable()
        {
            AddFunctionCall(x => FunctionDelegates.BeImmutable(x, false));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types that are immutable from the outside of the given type. (shallow immutability).  Weaker constraint than AreImmutable()
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList BeImmutableExternally()
        {
            AddFunctionCall(x => FunctionDelegates.BeImmutableExternally(x, true));
            return CreateConditionList();
        }


        /// <summary>
        /// Selects types that are stateless, they do not have instance state
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList BeStateless()
        {
            AddFunctionCall(x => FunctionDelegates.BeStateless(x, true));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types that are staticless, they do not have static state
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList BeStaticless()
        {
            AddFunctionCall(x => FunctionDelegates.BeStaticless(x, true));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types according to whether they have nullable members.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList OnlyHaveNullableMembers()
        {
            AddFunctionCall(x => FunctionDelegates.OnlyHaveNullableMembers(x, true));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types according to whether they have nullable members.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList HaveSomeNonNullableMembers()
        {
            AddFunctionCall(x => FunctionDelegates.OnlyHaveNullableMembers(x, false));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types according to whether they have only non-nullable members.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList OnlyHaveNonNullableMembers()
        {
            AddFunctionCall(x => FunctionDelegates.OnlyHaveNonNullableMembers(x, true));
            return CreateConditionList();
        }


        /// <summary>
        /// For each type, check if the name is consistent with its source file name.
        /// </summary>
        /// <remarks>
        /// StringComparison.InvariantCultureIgnoreCase is used for comparing, can be changed through Options
        /// </remarks>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList HaveSourceFileNameMatchingName()
        {
            AddFunctionCall((context, inputTypes) => FunctionDelegates.HaveFileNameMatchingTypeName(context, inputTypes, true));
            return CreateConditionList();
        }

        /// <summary>
        /// For each type, check if the namespace is consistent with its source file path.
        /// </summary>
        /// <remarks>
        /// StringComparison.InvariantCultureIgnoreCase is used for comparing, can be changed through Options
        /// </remarks>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList HaveSourceFilePathMatchingNamespace()
        {
            AddFunctionCall((context, inputTypes) => FunctionDelegates.HaveFilePathMatchingTypeNamespace(context, inputTypes, true));
            return CreateConditionList();
        }
               
        /// <summary>
        /// For each type, check if a matching type with the given name exists.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList HaveMatchingTypeWithName(Func<TypeDefinition, string> getMatchingTypeName)
        {
            AddFunctionCall((context, inputTypes) => FunctionDelegates.HaveMatchingTypeWithName(context, inputTypes, getMatchingTypeName, true));
            return CreateConditionList();
        }


        /// <summary>
        /// Selects types that have at least one instance public constructor.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList HavePublicConstructor()
        {
            AddFunctionCall((context, inputTypes) => FunctionDelegates.HavePublicConstructor(context, inputTypes, true));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types that do not have any instance public constructors.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList NotHavePublicConstructor()
        {
            AddFunctionCall((context, inputTypes) => FunctionDelegates.HavePublicConstructor(context, inputTypes, false));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types that have at least one instance parameterless constructor.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList HaveParameterlessConstructor()
        {
            AddFunctionCall((context, inputTypes) => FunctionDelegates.HaveParameterlessConstructor(context, inputTypes, true));
            return CreateConditionList();
        }

        /// <summary>
        /// Selects types that do not have any instance parameterless constructors.
        /// </summary>
        /// <returns>An updated set of conditions that can be applied to a list of types.</returns>
        public ConditionList NotHaveParameterlessConstructor()
        {
            AddFunctionCall((context, inputTypes) => FunctionDelegates.HaveParameterlessConstructor(context, inputTypes, false));
            return CreateConditionList();
        }
    }
}