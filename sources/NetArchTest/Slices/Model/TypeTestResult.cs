using NetArchTest.Assemblies;

namespace NetArchTest.Slices.Model
{
    internal sealed class TypeTestResult 
    { 
        public TypeSpec TypeSpec { get; }
        public bool IsPassing { get; }        


        public TypeTestResult(TypeSpec type, bool isPassing)
        {
            TypeSpec = type;
            IsPassing = isPassing;
        }       
    }
}