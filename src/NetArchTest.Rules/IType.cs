using System;

namespace NetArchTest.Rules
{
    /// <summary>
    /// Type wrapper.
    /// </summary>
    public interface IType
    { 
        /// <summary>
        /// System.Type
        /// </summary>
        /// <remarks>
        /// This property may be null if the test project does not have a direct dependency on the type.
        /// </remarks>
        Type ReflectionType { get; }

        /// <summary>
        /// FullName of the type
        /// </summary>       
        string FullName { get; }

        /// <summary>
        /// Name of the type
        /// </summary>       
        string Name { get; }

        /// <summary>
        /// It contains explanation why this Type has failed dependecy search.
        /// </summary>
        string Explanation { get; }
    }
}