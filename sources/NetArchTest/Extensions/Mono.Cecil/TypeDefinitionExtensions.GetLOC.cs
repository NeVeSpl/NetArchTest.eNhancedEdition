using Mono.Cecil;

namespace NetArchTest.Extensions.Mono.Cecil
{
    public static partial class TypeDefinitionExtensions
    {
        internal static int GetNumberOfLogicalLinesOfCode(this TypeDefinition type)
        {
            int count = 0; 

            if (type.HasMethods)
            {
                foreach (var method in  type.Methods)
                {
                    if (!method.HasBody) continue;
                    if (method.IsGeneratedCode()) continue;
                    if (method.DeclaringType.Module.HasSymbols == false) continue;

                    var methodLLOC = CountLogicalLinesOfCode(method);
                    count += methodLLOC;
                }
            }

            return count;
        }


        private static int CountLogicalLinesOfCode(MethodDefinition method)
        {
            int count = 0;
            int lastLine = int.MinValue;

            foreach (var instruction in method.Body.Instructions)
            {
                var sequencePoint = method.DebugInformation.GetSequencePoint(instruction);
                if (sequencePoint == null)
                    continue;

                int line = sequencePoint.StartLine;
                // special value for PDB (so that debuggers can ignore a line)
                if (line == 0xFEEFEE)
                    continue;
                
                if (line > lastLine)
                    count++;

                lastLine = line;
            }
            return count;
        }
    }
}